using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Librarian.forms
{
    public partial class Orders : Form
    {
        //Подключение БД
        DBContext db = new DBContext();

        int bookID;

        public Orders()
        {
            InitializeComponent();
        }
        private void Orders_Load(object sender, EventArgs e)
        {
            orderName.Text = ActiveUser.Name;
            orderLogin.Text = ActiveUser.Login;

            db.Book.Load();
            var books = db.Book.Local.ToBindingList();
            orderView.DataSource = books;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (orderSearch.Text == "")
            {
                var books = db.Book.Local.ToBindingList();
                orderView.DataSource = books;
            }
            else if (searchAuthor.Checked && orderSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Author.Contains($"{orderSearch.Text}"));
                orderView.DataSource = books;
            }
            else if (searchName.Checked && orderSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Name.Contains($"{orderSearch.Text}"));
                orderView.DataSource = books;
            }
            else if (searchGenre.Checked && orderSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Genre.Contains($"{orderSearch.Text}"));
                orderView.DataSource = books;
            }
            else if (searchYear.Checked && orderSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Year == Convert.ToInt32(orderSearch.Text));
                orderView.DataSource = books;
            }
        }

        private void orderView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bookID = Convert.ToInt32(orderView.Rows[e.RowIndex].Cells[0].Value);
        }

        private void orderCreate_Click(object sender, EventArgs e)
        {
            db.Orders.Add(new Librarian.Orders { BookID = bookID, UserID = ActiveUser.ID, DateGiven = DateTime.Now });
            db.SaveChanges();
        }


    }
}
