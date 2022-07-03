using System;
using System.Windows.Forms;

namespace Librarian.forms
{
    public partial class MakeRequest : Form
    {
        //Подключение БД
        DBContext db = new DBContext();

        public MakeRequest()
        {
            InitializeComponent();
        }
        private void MakeRequest_Load(object sender, EventArgs e)
        {

        }

        private void requestMake_Click(object sender, EventArgs e)
        {
            try
            {
                if (requestName.Text != "" || requestAuthor.Text != "" || requestDescription.Text != "")
                {
                    db.Request.Add(new Request { UserID = ActiveUser.ID, BookName = requestName.Text, BookAuthor = requestAuthor.Text, BookDescription = requestDescription.Text });
                    db.SaveChanges();
                    MessageBox.Show("Ваш запрос был добавлен в базу данных", "Готово", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Введите хоть что-то!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        
    }
}
