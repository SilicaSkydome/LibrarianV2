using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Librarian.forms
{
    public partial class Login : Form
    {
        //Подключение БД
        DBContext db = new DBContext();

        SignIn signin;

        public Login(SignIn signin)
        {
            InitializeComponent();
            this.signin = signin;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            db.User.Load();
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
            App.Current.MainWindow.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (loginLogin.Text != "" && loginPassword.Text != "")
            {
                var user = db.User.Local.Where(u => u.Login == loginLogin.Text && u.Password == loginPassword.Text).FirstOrDefault();
                if (user != null)
                {

                    ActiveUser.ID = user.ID;
                    ActiveUser.Name = user.Name;
                    ActiveUser.Login = user.Login;
                    ActiveUser.Password = user.Password;
                    ActiveUser.Status = user.Status;

                    Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль", $"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void openSignIn_Click(object sender, EventArgs e)
        {
            signin.ShowDialog();
        }
    }
}
