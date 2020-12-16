using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using instalib;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // creation de la chaine de connection
            MySqlConnectionStringBuilder conn = new MySqlConnectionStringBuilder();
            conn.Server = "localhost";
            conn.UserID = "root";
            conn.Password = "";
            conn.Database = "instadb";

            conn.Port = 3306;


            var connString = conn.ToString();

            MessageBox.Show(connString);


            MySqlConnection mySqlConnection = new MySqlConnection(connString);
            mySqlConnection.Open();
            mySqlConnection.ConnectionTimeout.ToString();
            mySqlConnection.State.ToString();
            MessageBox.Show(mySqlConnection.State.ToString());
            MessageBox.Show(mySqlConnection.ConnectionTimeout.ToString());
            mySqlConnection.Close();
            MessageBox.Show(mySqlConnection.State.ToString());

            //préparer la commande
            String query = "select * from article";
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            //executer la commande
            MySqlDataReader result = mySqlCommand.ExecuteReader();
            while (result.Read())
            {
                MessageBox.Show(result[0] + "," + result[1]);
            }
            result.Close();
            mySqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DbCon.GetDBConnection();

            conn.Open();
            MessageBox.Show(conn.State.ToString());
            conn.Close();
            MessageBox.Show(conn.State.ToString());



        }
    }
    }
