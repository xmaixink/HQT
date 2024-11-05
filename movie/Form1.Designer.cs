using System;
using System.Drawing;
using System.Windows.Forms;

namespace movie
{
    partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            STT = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            SeatNumber = new DataGridViewTextBoxColumn();
            BookingTime = new DataGridViewTextBoxColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            pnlHangGhe = new Panel();
            textBoxName = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            comboBoxShowtime = new ComboBox();
            textBoxSeatNumber = new TextBox();
            buttonSave = new Button();
            labelName = new Label();
            labelTime = new Label();
            labelGhe = new Label();
            button1 = new Button();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            STT.Width = 50;
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "Người mua";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 150;
            // 
            // SeatNumber
            // 
            SeatNumber.HeaderText = "Số ghế";
            SeatNumber.MinimumWidth = 6;
            SeatNumber.Name = "SeatNumber";
            SeatNumber.Width = 125;
            // 
            // BookingTime
            // 
            BookingTime.HeaderText = "Giờ đặt";
            BookingTime.MinimumWidth = 6;
            BookingTime.Name = "BookingTime";
            BookingTime.Width = 150;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.BackColor = SystemColors.ActiveCaption;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Location = new Point(12, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(744, 83);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(738, 83);
            label1.TabIndex = 0;
            label1.Text = "MÀN ẢNH";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHangGhe
            // 
            pnlHangGhe.Location = new Point(15, 98);
            pnlHangGhe.Name = "pnlHangGhe";
            pnlHangGhe.Size = new Size(741, 395);
            pnlHangGhe.TabIndex = 2;
            pnlHangGhe.Paint += pnlHangGhe_Paint;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxName.Location = new Point(982, 316);
            textBoxName.Multiline = true;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(336, 44);
            textBoxName.TabIndex = 3;
            textBoxName.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { STT, CustomerName, SeatNumber, BookingTime });
            dataGridView1.Location = new Point(791, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(570, 188);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(807, 30);
            label2.Name = "label2";
            label2.Size = new Size(224, 20);
            label2.TabIndex = 9;
            label2.Text = "Danh sách người dùng đã đặt vé";
            // 
            // comboBoxShowtime
            // 
            comboBoxShowtime.FormattingEnabled = true;
            comboBoxShowtime.Location = new Point(982, 382);
            comboBoxShowtime.Name = "comboBoxShowtime";
            comboBoxShowtime.Size = new Size(336, 28);
            comboBoxShowtime.TabIndex = 10;
            comboBoxShowtime.Visible = false;
            // 
            // textBoxSeatNumber
            // 
            textBoxSeatNumber.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSeatNumber.Location = new Point(982, 432);
            textBoxSeatNumber.Multiline = true;
            textBoxSeatNumber.Name = "textBoxSeatNumber";
            textBoxSeatNumber.ReadOnly = true;
            textBoxSeatNumber.Size = new Size(91, 46);
            textBoxSeatNumber.TabIndex = 11;
            textBoxSeatNumber.Visible = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = SystemColors.ActiveCaption;
            buttonSave.Location = new Point(982, 520);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(232, 40);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Lưu";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Visible = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(866, 331);
            labelName.Name = "labelName";
            labelName.Size = new Size(73, 20);
            labelName.TabIndex = 13;
            labelName.Text = "Nhập tên:";
            labelName.Visible = false;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(778, 385);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(166, 20);
            labelTime.TabIndex = 14;
            labelTime.Text = "Chọn phim và thời gian:";
            labelTime.Visible = false;
            // 
            // labelGhe
            // 
            labelGhe.AutoSize = true;
            labelGhe.Location = new Point(836, 447);
            labelGhe.Name = "labelGhe";
            labelGhe.Size = new Size(103, 20);
            labelGhe.TabIndex = 15;
            labelGhe.Text = "Ghế bạn chọn:";
            labelGhe.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(1254, 21);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 16;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 653);
            Controls.Add(button1);
            Controls.Add(labelGhe);
            Controls.Add(labelTime);
            Controls.Add(labelName);
            Controls.Add(buttonSave);
            Controls.Add(textBoxSeatNumber);
            Controls.Add(comboBoxShowtime);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(textBoxName);
            Controls.Add(pnlHangGhe);
            Controls.Add(tableLayoutPanel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Panel pnlHangGhe;
        private TextBox textBoxName;
        private DataGridView dataGridView1;
        private Label label2;

        // Định nghĩa sự kiện trống để tránh lỗi
        private void pnlHangGhe_Paint(object sender, PaintEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn SeatNumber;
        private DataGridViewTextBoxColumn BookingTime;
        private ComboBox comboBoxShowtime;
        private TextBox textBoxSeatNumber;
        private Button buttonSave;
        private Label labelName;
        private Label labelTime;
        private Label labelGhe;
        private Button button1;
    }
}
