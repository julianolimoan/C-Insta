using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace instalib
{
    public class Produit
    {
        

        public int ProduitID { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }

        public int Quantite { get; set; }
        public string Categorie { get; set; }


        //constructeur
        public Produit()
        {

        }

        public Produit(int ProduitIDP,string DescriptionP, decimal PrixP, int QuantiteP, string CategorieP )
        {
            this.ProduitID = ProduitIDP;
            this.Description = DescriptionP;
            this.Prix = PrixP;
            this.Quantite = QuantiteP;
            this.Categorie = CategorieP;
        }

        ///methodes

        public void AjouterProduit()
        {

        }
        public Produit RecupProduit(int produitId)
        {
            Produit prod = new Produit();
            //traitement code

            //creer l'objet de connexion
            MySqlConnection conn = DbCon.GetDBConnection();
            conn.Open();
            // ouvrir la connection


            //preparer la commande

            string sql = "SELECT Quantite, description, prix FROM produit where(id_produit=" + produitId + ") ";

            // creer un objet command



            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            //
            try
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //prod.ProduitId = Convert.ToInt32(reader.GetString(1));
                            prod.Quantite= reader.GetInt32(0);
                            prod.Description = reader.GetString(1);
                            //prod.Prix = reader.GetDecimal(2);
                            //prod.Prix = Convert.ToDecimal(reader.GetString(2));

                        }


                    }

                }
                return prod;
            }

            finally

            {

                conn.Close();
                conn.Dispose();

            }

        }

        public List<Produit> RecupAllProduit()
        {
            MySqlConnection conn = DbCon.GetDBConnection();
            MySqlDataReader read = null;
            conn.Open();
            List<Produit> prod = new List<Produit>();
            if (conn != null)
            {
                string req = "select * from produit";
                MySqlCommand cmd = new MySqlCommand(req, conn);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    prod.Add(new Produit(int.Parse(read[0].ToString()), read[1].ToString(), decimal.Parse(read[2].ToString()), int.Parse(read[3].ToString()), read[4].ToString()));
                    //prod.Add(new Produit(int.Parse(read[0].ToString()), read[1].ToString(), decimal.Parse(read[2].ToString()), read[3].ToString()), read[4].ToString());
                }
            }
            read.Close();
            conn.Close();
            return prod;


        }
        public int insertproduit(Produit produit)
        {

            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("INSERT INTO produit (Quantite, description, prix, categorie)  Values (@Quantite,@description,@prix,@categorie)", con);
                dCmd.CommandType = CommandType.Text;
                try
                {

                    dCmd.Parameters.AddWithValue("@Quantite", produit.Quantite);
                    dCmd.Parameters.AddWithValue("@description", produit.Description);
                    dCmd.Parameters.AddWithValue("@prix", produit.Prix);
                    dCmd.Parameters.AddWithValue("@categorie", produit.Categorie);
                    return dCmd.ExecuteNonQuery();
                }



                catch (Exception e)
                {
                    throw e;

                }

                finally
                {
                    dCmd.Dispose();

                    con.Close();

                    con.Dispose();

                }
            }
        }

        public int Deleteproduit(int ProduitId)
        {
            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("DELETE from produit where(id_produit=" + ProduitId + ") ", con);
                dCmd.CommandType = CommandType.Text;
                try
                {


                    return dCmd.ExecuteNonQuery();
                }



                catch (Exception e)
                {
                    throw e;

                }

                finally
                {
                    dCmd.Dispose();

                    con.Close();

                    con.Dispose();

                }

            }

        }
        public int updateproduit(Produit produit, int ProduitId)
        {

            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("UPDATE Produit set Quantite=@Quantite, description=@description, prix=@prix, categorie=@categorie where id_produit=@id_produit", con);
                dCmd.CommandType = CommandType.Text;
                try
                {
                    dCmd.Parameters.AddWithValue("@id_produit", ProduitId);
                    dCmd.Parameters.AddWithValue("@Quantite", produit.Quantite);
                    dCmd.Parameters.AddWithValue("@prix", produit.Prix);
                    dCmd.Parameters.AddWithValue("@categorie", produit.Categorie);

                    return dCmd.ExecuteNonQuery();
                }



                catch (Exception e)
                {
                    throw e;

                }

                finally
                {
                    dCmd.Dispose();

                    con.Close();

                    con.Dispose();

                }
            }
        }


    }
}
