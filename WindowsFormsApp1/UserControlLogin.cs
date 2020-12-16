using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
        }

        private string userid;
        public string Login { get { return userid; } set { userid = value; } }

        private string password;
        public string Password { get { return password; } set { password = value; } }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Login == txtLogin.Text & Password == txtPassword.Text)
            {
                MessageBox.Show("Login réussi");
            }
            else
            {
                MessageBox.Show("rejeter");
            }
        }
    }
}
