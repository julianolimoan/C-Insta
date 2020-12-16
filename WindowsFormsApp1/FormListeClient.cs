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
    public partial class FormListeClient : Form
    {
        public FormListeClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client cli = new Client();

            var lisprod = new List<Client>();
            lisprod.Add(cli.RecupProduit(1));

            foreach (var article in lisprod)
            {
                MessageBox.Show(article._Nom.ToString());
                //MessageBox.Show(prod.ProduitId.ToString());
                MessageBox.Show(article._Prenom);
                MessageBox.Show(article._Numero.ToString());

                MessageBox.Show(article._Email);
            }
        }

        private void FormListeClient_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'instadbDataSet.client'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.clientTableAdapter.Fill(this.instadbDataSet.client);

        }
    }
}
