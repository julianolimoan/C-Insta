using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pro PForm = new Pro();

            //PForm.Show();
            PForm.ShowDialog();
        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListeClient PForm = new FormListeClient();

            PForm.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'instadbDataSet.client'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.clientTableAdapter.Fill(this.instadbDataSet.client);
            Client cli = new Client();
            dataGridView1.DataSource = cli.RecupAllClient();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Nom.Text) == true) MessageBox.Show("Nom vide");
            else if (String.IsNullOrEmpty(Prenom.Text) == true) MessageBox.Show("Prenom vide");
            else if (String.IsNullOrEmpty(Numero.Text) == true) MessageBox.Show("Numero vide");
            else if (String.IsNullOrEmpty(Email.Text) == true) MessageBox.Show("Email vide");


            else
            {
                Client cli = new Client();
                cli._Nom = Nom.Text.ToString();
                cli._Prenom = Prenom.Text.ToString();
                cli._Numero = Int32.Parse(Numero.Text);
                cli._Email = Email.Text.ToString();
                cli.insertclient(cli);
                MessageBox.Show("Client ajoute Client: " + Nom.Text + " Prenom " + Prenom.Text);




                //DataTable dt = new DataTable();
                //dt = cli.RecupAllClient();
                dataGridView1.DataSource = cli.RecupAllClient();
                Prenom.Clear();
                Nom.Clear();
                Numero.Clear();
                Email.Clear();
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Age_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listProduitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListeProduit frmP = new FormListeProduit();
            frmP.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()) == true) MessageBox.Show("Id vide");
            else if (dataGridView1.CurrentRow.Cells[0].Value.ToString().All(char.IsDigit))
            {
                Client cli = new Client();
                cli.DeleteClient(Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = cli.RecupAllClient();
            }
            else
            {
                MessageBox.Show("Ce n'est pas un chiffre");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Nom.Text) == true) MessageBox.Show("Nom vide");
            else if (String.IsNullOrEmpty(Prenom.Text) == true) MessageBox.Show("Prenom vide");
            else if (String.IsNullOrEmpty(Numero.Text) == true) MessageBox.Show("Numero vide");
            else if (String.IsNullOrEmpty(Email.Text) == true) MessageBox.Show("Email vide");

            else if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()) == true) MessageBox.Show("Id vide");
            else if (dataGridView1.CurrentRow.Cells[0].Value.ToString().All(char.IsDigit))
            {
                Client cli = new Client();
                cli._Numero = Int32.Parse(Numero.Text);
                cli._Nom = Nom.Text.ToString();
                cli._Prenom = Prenom.Text.ToString();
                cli._Email = Email.Text.ToString();
                cli.updateClient(cli, Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = cli.RecupAllClient();
            }
            else
            {
                MessageBox.Show("Ce n'est pas un chiffre");
            }
        }

        private void listeDepotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListDepot PForm = new FormListDepot();

            PForm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Nom.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Prenom.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Numero.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Email.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()) == true) MessageBox.Show("Id vide");
            else if (dataGridView1.CurrentRow.Cells[0].Value.ToString().All(char.IsDigit))
            {
                Client cli = new Client();
                cli.DeleteClient(Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = cli.RecupAllClient();
            }
            else
            {
                MessageBox.Show("Ce n'est pas un chiffre");
            }

        }
    }
}
