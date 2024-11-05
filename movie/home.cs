using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace movie
{
    public partial class home : Form
    {
        private string[] movieTitles = {
            "BLACK PANTHER",
            "AVENGERS",
            "SPIDER-MAN",
            "SUPERMAN",
            "BATMAN",
            "WONDER WOMAN",
            "THOR",
            "IRON MAN"
        };

        private string[] movieImages = {
            "black_panther.jpg",
            "avengers.jpg",
            "spider_man.jpg",
            "superman.jpg",
            "batman.jpg",
            "wonder_woman.jpg",
            "thor.jpg",
            "iron_man.jpg"
        };

        public home()
        {
            InitializeComponent();
            InitializeSearch();
            GenerateMovieList(movieTitles);
        }

        private void InitializeSearch()
        {
            TextBox searchTextBox = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(this.ClientSize.Width - 300, 40) 
            };

            Button searchButton = new Button
            {
                Text = "Search",
                Size = new Size(75, 30),
                Location = new Point(this.ClientSize.Width - 90, 40) 
            };

            searchButton.Click += (sender, e) => SearchMovies(searchTextBox.Text);

            this.Controls.Add(searchTextBox);
            this.Controls.Add(searchButton);
        }

        private void SearchMovies(string searchTerm)
        {
            var filteredTitles = movieTitles
                .Where(title => title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToArray();

            this.Controls.OfType<Panel>().ToList().ForEach(panel => this.Controls.Remove(panel));

            GenerateMovieList(filteredTitles);
        }

        private void GenerateMovieList(string[] titles)
        {
            int x = 20, y = 80;
            for (int i = 0; i < titles.Length; i++)
            {
                Panel moviePanel = new Panel
                {
                    Size = new Size(150, 270),
                    Location = new Point(x, y),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.DarkRed 
                };

                
                PictureBox moviePicture = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(150, 200),
                    Location = new Point(0, 0)
                };

                string imagePath = movieImages[i];
                if (System.IO.File.Exists(imagePath))
                {
                    moviePicture.Image = Image.FromFile(imagePath); 
                }
                else
                {
                    moviePicture.Image = Image.FromFile("default_image.jpg"); 
                }

                moviePanel.Controls.Add(moviePicture);

                Label titleLabel = new Label
                {
                    Text = titles[i],
                    ForeColor = Color.White,
                    BackColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(150, 30),
                    Location = new Point(0, 200), 
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                moviePanel.Controls.Add(titleLabel);

                Button bookButton = new Button
                {
                    Text = "Book Now",
                    Size = new Size(150, 30),
                    Location = new Point(0, 240),
                    BackColor = Color.Yellow,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                bookButton.Click += (sender, e) => OpenForm1();
                moviePanel.Controls.Add(bookButton);

                this.Controls.Add(moviePanel);

                x += 170; 
                if ((i + 1) % 4 == 0) 
                {
                    x = 20;
                    y += 270; 
                }
            }
        }

        private void OpenForm1()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        // Các sự kiện nút sử dụng hàm OpenForm1()
        private void button1_Click(object sender, EventArgs e) => OpenForm1();
        private void button2_Click(object sender, EventArgs e) => OpenForm1();
        private void button3_Click(object sender, EventArgs e) => OpenForm1();
        private void button4_Click(object sender, EventArgs e) => OpenForm1();
        private void button5_Click(object sender, EventArgs e) => OpenForm1();
        private void button6_Click(object sender, EventArgs e) => OpenForm1();
        private void button7_Click(object sender, EventArgs e) => OpenForm1();
        private void button8_Click(object sender, EventArgs e) => OpenForm1();

        private void home_Load(object sender, EventArgs e)
        {

        }
    }
}
