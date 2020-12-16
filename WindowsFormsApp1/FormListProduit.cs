using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using instalib;

namespace WindowsFormsApp1
{
    public partial class FormListeProduit : Form
    {
        public FormListeProduit()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Produit prod = new Produit();

            var lisprod = new List<Produit>();
            lisprod.Add(prod.RecupProduit(1));

            foreach (var article in lisprod)
            {   MessageBox.Show(article.Quantite.ToString());
                //MessageBox.Show(prod.ProduitId.ToString());
                MessageBox.Show(article.Description);
             
                MessageBox.Show(article.Categorie);
            }
        }

        private void FormListeDepot_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'instadbDataSet.produit'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.produitTableAdapter.Fill(this.instadbDataSet.produit);
           Produit pro = new Produit();
            dataGridView1.DataSource = pro.RecupAllProduit();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == true) MessageBox.Show("Quantite vide");
            else if (String.IsNullOrEmpty(textBox2.Text) == true) MessageBox.Show("description vide");
            else if (String.IsNullOrEmpty(textBox3.Text) == true) MessageBox.Show("prix vide");
            else if (String.IsNullOrEmpty(textBox4.Text) == true) MessageBox.Show("categorie vide");


            else
            {
                Produit pro = new Produit();
                pro.Quantite = Int32.Parse(textBox1.Text);
                pro.Description = textBox2.Text.ToString();
                pro.Prix = Int32.Parse(textBox3.Text);
                pro.Categorie = textBox4.Text.ToString();
                pro.insertproduit(pro);
                MessageBox.Show("Produit ajoute quantite: " + textBox1.Text + " description " + textBox2.Text);




                //DataTable dt = new DataTable();
                //dt = cli.RecupAllClient();
                dataGridView1.DataSource = pro.RecupAllProduit();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[2].Value.ToString()) == true) MessageBox.Show("Id vide");
            else if (dataGridView1.CurrentRow.Cells[2].Value.ToString().All(char.IsDigit))
            {
                Depot dp = new Depot();
                dp.DeleteDepot(Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
                dataGridView1.DataSource = dp.RecupAllDepot();
            }
            else
            {
                MessageBox.Show("Ce n'est pas un chiffre");
            }

        }
    }
}
