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
    public partial class FormListDepot : Form
    {
        public FormListDepot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Depot dep = new Depot();

            var lisprod = new List<Depot>();
            lisprod.Add(dep.RecupProduit(1));

            foreach (var article in lisprod)
            {
                MessageBox.Show(article._Quantite.ToString());
                //MessageBox.Show(prod.ProduitId.ToString());
                MessageBox.Show(article._Lieu);

            }
        }

        private void FormListDepot_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'instadbDataSet.depot'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.depotTableAdapter.Fill(this.instadbDataSet.depot);
            Depot dep = new Depot();
            dataGridView1.DataSource = dep.RecupAllDepot();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) == true) MessageBox.Show("Quantite vide");
            if (String.IsNullOrEmpty(textBox2.Text) == true) MessageBox.Show("Depot vide");



            if ((String.IsNullOrEmpty(textBox3.Text) == false) && (String.IsNullOrEmpty(textBox2.Text) == false))
            {
                Depot dep = new Depot();
                dep._Quantite = Int32.Parse(textBox3.Text);
                dep._Lieu = textBox2.Text.ToString();
                dep.insertdepot(dep);
                MessageBox.Show("Depot ajoute Quantite: " + textBox3.Text + " Lieu " + textBox2.Text);



          
                //DataTable dt = new DataTable();
                //dt = cli.RecupAllClient();
                dataGridView1.DataSource = dep.RecupAllDepot();
                textBox3.Clear();
                textBox2.Clear();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Depot dp = new Depot();
           
        
            dataGridView1.DataSource =dp.RecupAllDepot();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[2].Value.ToString()) == true) MessageBox.Show("Id vide");
            else if (dataGridView1.CurrentRow.Cells[2].Value.ToString().All(char.IsDigit))
            {
                Depot dp = new Depot();
                dp.DeleteDepot (Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
                dataGridView1.DataSource = dp.RecupAllDepot();
            }
            else
            {
                MessageBox.Show("Ce n'est pas un chiffre");
            }
         

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) == true) MessageBox.Show("Quantite vide");
            else if (String.IsNullOrEmpty(textBox2.Text) == true) MessageBox.Show("Lieu vide");
        
          
            else if (dataGridView1.CurrentRow.Cells[2].Value.ToString().All(char.IsDigit))
            {
                Depot dp = new Depot();
                dp._Quantite = Int32.Parse(textBox3.Text);
                dp._Lieu = textBox2.Text.ToString();
                dp.updateDepot(dp,Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
                dataGridView1.DataSource = dp.RecupAllDepot();
            }
            else
            {
                MessageBox.Show("Ce n'est pas un chiffre");
            }

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
