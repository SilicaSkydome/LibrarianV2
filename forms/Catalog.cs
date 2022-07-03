using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Librarian.forms
{
    public partial class Catalog : Form
    {
        //Подключение БД
        DBContext db = new DBContext();

        Add add = new Add();
        Edit edit = null;

        int id;

        public Catalog()
        {
            InitializeComponent();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            if (ActiveUser.Status == "user")
            {
                buttonAdd.Visible = false;
                buttonEdit.Visible = false;
            }

            db.Book.Load();
            var books = db.Book.Local.ToBindingList();
            catalogView.DataSource = books;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (catalogSearch.Text == "")
            {
                var books = db.Book.Local.ToBindingList();
                catalogView.DataSource = books;
            }
            else if (searchAuthor.Checked && catalogSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Author.Contains($"{catalogSearch.Text}"));
                catalogView.DataSource = books;
            }
            else if (searchName.Checked && catalogSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Name.Contains($"{catalogSearch.Text}"));
                catalogView.DataSource = books;
            }
            else if (searchGenre.Checked && catalogSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Genre.Contains($"{catalogSearch.Text}"));
                catalogView.DataSource = books;
            }
            else if (searchYear.Checked && catalogSearch.Text != "")
            {
                var books = db.Book.Local.Where(b => b.Year == Convert.ToInt32(catalogSearch.Text));
                catalogView.DataSource = books;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            add.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            edit = new Edit(id);
            edit.Show();
        }

        private void catalogView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(catalogView.Rows[e.RowIndex].Cells[0].Value);
        }
    }
}
