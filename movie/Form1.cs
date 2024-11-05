using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace movie
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private int selectedSeatNumber = -1; // Số ghế người dùng đã chọn

        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoSoGhe(5, 7); // Khởi tạo 5 hàng và 7 cột ghế
            LoadBookingData(); // Tải dữ liệu đặt vé vào dataGridView1 khi mở form
            LoadShowtimeOptions(); // Tải các tùy chọn giờ chiếu vào ComboBox
        }

        private void KhoiTaoSoGhe(int dong, int cot)
        {
            int x, y = 20, khoangCach = 100, dem = 1;
            for (int i = 0; i < dong; i++)
            {
                x = 3;

                for (int j = 0; j < cot; j++)
                {
                    Button btnGhe = new Button();
                    btnGhe.Location = new Point(x, y);
                    btnGhe.Size = new Size(90, 60);
                    btnGhe.Text = dem++.ToString();
                    btnGhe.BackColor = Color.White;
                    pnlHangGhe.Controls.Add(btnGhe);
                    btnGhe.Click += BtnGhe_Click;
                    x += khoangCach;
                }
                y += khoangCach;
            }
        }

        private void LoadShowtimeOptions()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ShowtimeID, StartTime FROM Showtime";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int showtimeId = reader.GetInt32(0);
                        DateTime startTime = reader.GetDateTime(1);
                        comboBoxShowtime.Items.Add(new { ShowtimeID = showtimeId, Time = startTime.ToString("yyyy-MM-dd HH:mm") });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách giờ chiếu: " + ex.Message);
                }
            }
        }

        private void BtnGhe_Click(object? sender, EventArgs e)
        {
            Button btnGhe = (Button)sender;
            selectedSeatNumber = int.Parse(btnGhe.Text);

            if (btnGhe.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế đã được đặt!");
                return;
            }

            // Hiển thị các ô nhập liệu và điền số ghế
            textBoxName.Visible = true;
            comboBoxShowtime.Visible = true;
            textBoxSeatNumber.Visible = true;
            buttonSave.Visible = true;
            labelName.Visible = true;
            labelTime.Visible = true;
            labelGhe.Visible = true;

            textBoxSeatNumber.Text = selectedSeatNumber.ToString();
        }
        private void LoadBookingData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY sb.BookingID) AS STT,
                    c.FullName AS CustomerName,
                    sb.SeatNumber,
                    sb.BookingTime
                FROM SeatBooking sb
                JOIN Customers c ON sb.CustomerID = c.CustomerID
                WHERE sb.Status = 'Đã đặt'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();
                    List<int> bookedSeats = new List<int>();

                    while (reader.Read())
                    {
                        int stt = (int)reader.GetInt64(0);
                        string customerName = reader.GetString(1);
                        int seatNumber = reader.GetInt32(2);
                        DateTime bookingTime = reader.GetDateTime(3);

                        // Thêm số ghế đã đặt vào danh sách
                        bookedSeats.Add(seatNumber);

                        // Thêm dữ liệu vào DataGridView
                        dataGridView1.Rows.Add(stt, customerName, seatNumber, bookingTime);
                    }
                    reader.Close();

                    // Đổi màu ghế đã đặt thành màu đỏ
                    foreach (Control control in pnlHangGhe.Controls)
                    {
                        if (control is Button btnGhe)
                        {
                            int seatNum = int.Parse(btnGhe.Text);
                            if (bookedSeats.Contains(seatNum))
                            {
                                btnGhe.BackColor = Color.Red;
                                btnGhe.Enabled = false; // Vô hiệu hóa nút ghế đã đặt
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string customerName = textBoxName.Text;
            var selectedShowtime = comboBoxShowtime.SelectedItem as dynamic;

            if (string.IsNullOrEmpty(customerName) || selectedShowtime == null || selectedSeatNumber == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return;
            }

            int showtimeId = selectedShowtime.ShowtimeID;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Thêm thông tin khách hàng vào bảng Customer nếu chưa tồn tại
                    SqlCommand cmdCustomer = new SqlCommand("IF NOT EXISTS (SELECT * FROM Customers  WHERE FullName = @Name) INSERT INTO Customers  (FullName) VALUES (@Name); SELECT CustomerID FROM Customers  WHERE FullName = @Name;", conn);
                    cmdCustomer.Parameters.AddWithValue("@Name", customerName);
                    int customerId = (int)cmdCustomer.ExecuteScalar();

                    // Gọi Stored Procedure để đặt ghế
                    SqlCommand cmdBooking = new SqlCommand("sp_BookSeat", conn);
                    cmdBooking.CommandType = CommandType.StoredProcedure;
                    cmdBooking.Parameters.AddWithValue("@SeatNumber", selectedSeatNumber);
                    cmdBooking.Parameters.AddWithValue("@ShowtimeID", showtimeId);
                    cmdBooking.Parameters.AddWithValue("@CustomerID", customerId);

                    int result = cmdBooking.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Cập nhật màu ghế sau khi đặt thành công
                        foreach (Control control in pnlHangGhe.Controls)
                        {
                            if (control is Button btn && int.Parse(btn.Text) == selectedSeatNumber)
                            {
                                btn.BackColor = Color.Red;
                                btn.Enabled = false;
                            }
                        }
                        MessageBox.Show("Đặt ghế thành công!");
                        LoadBookingData();
                    }
                    else
                    {
                        MessageBox.Show("Ghế đã được đặt bởi người khác!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            // Ẩn các điều khiển nhập liệu sau khi lưu xong
            textBoxName.Visible = false;
            comboBoxShowtime.Visible = false;
            textBoxSeatNumber.Visible = false;
            buttonSave.Visible = false;
            labelName.Visible = false;
            labelTime.Visible = false;
            labelGhe.Visible = false;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            KhoiTaoSoGhe(5, 7); // Khởi tạo 5 hàng và 7 cột ghế
            LoadBookingData(); // Tải dữ liệu đặt vé vào dataGridView1 khi mở form
            LoadShowtimeOptions(); // Tải các tùy chọn giờ chiếu vào ComboBox
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            home homeForm = new home(); // Khởi tạo Form home
            homeForm.Show(); // Hiển thị Form home
            this.Hide(); // Ẩn Form1
        }
    }
}
