using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Librarian.forms
{
    public partial class Add : Form
    {
        //Подключение БД
        //SqlConnection sqlConnection = null;
        

        public Add()
        {
            InitializeComponent();
        }
        private void Add_Load(object sender, EventArgs e)
        {
            //sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["librarianDatabase"].ConnectionString);
            //sqlConnection.Open();
        }
        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand(
            //    $"INSERT INTO Book VALUES (N'{addName.Text}', N'{addAuthor.Text}', N'{addPublisher.Text}', N'{addType.Text}', N'{addGenre.Text}', {addYear.Text});", 
            //    sqlConnection);

            //command.ExecuteNonQuery();

            using (DBContext db = new DBContext())
            {
                db.Book.Add(new Book { Name = addName.Text , Author = addAuthor.Text, Publisher = addPublisher.Text, Type = addType.Text, Genre = addGenre.Text, Year = Convert.ToInt32(addYear.Text) });

                db.SaveChanges();
            }
        }

        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
