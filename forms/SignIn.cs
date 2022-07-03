using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Librarian.forms
{
    public partial class SignIn : Form
    {
        //Подключение БД
        DBContext db = new DBContext();

        public SignIn()
        {
            InitializeComponent();
        }
        private void SignIn_Load(object sender, EventArgs e)
        {

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
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void openLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (signInLogin.Text != "" && signInPassword.Text != "" && signInRepeatPassword.Text != "" && signInPassword.Text == signInRepeatPassword.Text)
                {
                    var newUser = db.User.Where(u => u.Login == signInLogin.Text).FirstOrDefault();
                    if (newUser == null)
                    {
                        db.User.Add(new User { Name = "Пользователь", Login = signInLogin.Text, Password = signInPassword.Text, Status = "user" });
                        db.SaveChanges();
                        MessageBox.Show("Аккаунт успешно создан.", "Регистрация", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Данный логин уже существует.", "Регистрация", MessageBoxButtons.OK);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка", $"{ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
