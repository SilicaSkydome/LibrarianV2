using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Librarian.forms
{
    public partial class Edit : Form
    {
        int ID;
        //Подключение БД
        DBContext db = new DBContext();
        Book edited;

        public Edit(int id)
        {
            InitializeComponent();
            ID = id;

            db.Book.Load();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            edited = db.Book.Local.Where(b => b.ID == this.ID).First();
            editName.Text = edited.Name;
            editAuthor.Text = edited.Author;
            editPublisher.Text = edited.Publisher;
            editType.Text = edited.Type;
            editGenre.Text = edited.Genre; ;
            editYear.Text = Convert.ToString(edited.Year);
        }
        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            edited = new Book { Name = editName.Text, Author = editAuthor.Text, Publisher = editPublisher.Text, Type = editType.Text, Genre = editGenre.Text, Year = Convert.ToInt32(editYear.Text) };
            db.Entry(edited).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
