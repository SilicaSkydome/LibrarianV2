using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Librarian.forms
{
    public partial class Profile : Form
    {
        //Подключение БД
        DBContext db = new DBContext();

        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Change_MouseDown(object sender, MouseEventArgs e)
        {
            Profile_Change.BackColor = Color.FromArgb(224, 158, 58);
        }

        private void Profile_Change_MouseUp(object sender, MouseEventArgs e)
        {
            Profile_Change.BackColor = Color.FromArgb(152, 22, 22);
        }

        private void Profile_Change_MouseEnter(object sender, EventArgs e)
        {
            Profile_Change.BackColor = Color.FromArgb(152, 22, 22);
        }

        private void Profile_Change_MouseLeave(object sender, EventArgs e)
        {
            Profile_Change.BackColor = Color.FromArgb(224, 58, 58);
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            textName.Text = ActiveUser.Name;
            textLogin.Text = ActiveUser.Login;
            textPassword.Text = ActiveUser.Password;
            textStatus.Text = ActiveUser.Status;

            var history = db.Orders.Where(o => o.UserID == ActiveUser.ID).ToList();
            profileHistory.DataSource = history;
            
        }

        private void Profile_Change_Click(object sender, EventArgs e)
        {
            var user = db.User.First(u => u.ID == ActiveUser.ID);
            user = new User{ Name = textName.Text, Login = textLogin.Text, Password = textPassword.Text, Status = textStatus.Text };
            db.SaveChanges();

            ActiveUser.Name = textName.Text;
            ActiveUser.Login = textLogin.Text;
            ActiveUser.Password = textPassword.Text;
            ActiveUser.Status = textStatus.Text;

            MessageBox.Show("Данные изменены.", "Профиль", MessageBoxButtons.OK);
        }

        private void historyUpdate_Click(object sender, EventArgs e)
        {
            var history = db.Orders.Where(o => o.UserID == ActiveUser.ID).ToList();
            profileHistory.DataSource = history;
        }
    }
}
