using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instalib;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class Depot
    {
        public int _Quantite { get; set; }
        public string _Lieu { get; set; }
        public string DepotId { get; private set; }

        public Depot(string depotidP, int quantiteP, string lieuP)
        {
            this.DepotId = depotidP;
            this._Quantite = quantiteP;
            this._Lieu = lieuP;
        }

        public Depot() { }

        public Depot RecupProduit(int DepotId)
        {
            Depot Dep = new Depot();
            //traitement code

            //creer l'objet de connexion
            MySqlConnection conn = DbCon.GetDBConnection();
            conn.Open();
            // ouvrir la connection


            //preparer la commande

            string sql = "SELECT Quantite, Lieu  FROM depot where(id_depot=" + DepotId + ") ";

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
                            Dep._Quantite = reader.GetInt32(0);
                            Dep._Lieu = reader.GetString(1);

                            //prod.Prix = reader.GetDecimal(2);
                            //prod.Prix = Convert.ToDecimal(reader.GetString(2));

                        }


                    }

                }
                return Dep;
            }

            finally

            {

                conn.Close();
                conn.Dispose();

            }




        }
        public List<Depot> RecupAllDepot()
        {
            MySqlConnection conn = DbCon.GetDBConnection();
            MySqlDataReader read = null;
            conn.Open();
            List<Depot> dep = new List<Depot>();
            if (conn != null)
            {
                string req = "select * from depot";
                MySqlCommand cmd = new MySqlCommand(req, conn);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    dep.Add(new Depot(read[0].ToString(), int.Parse(read[1].ToString()), read[2].ToString()));
                }
            }
            read.Close();
            conn.Close();
            return dep;


        }






        public int insertdepot(Depot depot)
        {

            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("INSERT INTO Depot (Quantite, Lieu)  Values (@Quantite,@Lieu)", con);
                dCmd.CommandType = CommandType.Text;
                try
                {

                    dCmd.Parameters.AddWithValue("@Quantite", depot._Quantite);
                    dCmd.Parameters.AddWithValue("@Lieu", depot._Lieu);
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


        public int DeleteDepot(int DepotId){
            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("DELETE from depot where(id_depot=" + DepotId + ") ", con);
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


        public int updateDepot(Depot depot,int DepotId)
        {

            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("UPDATE Depot set Quantite=@Quantite, Lieu=@Lieu where id_depot=@id_depot" , con);
                dCmd.CommandType = CommandType.Text;
                try
                {
                    dCmd.Parameters.AddWithValue("@id_depot", DepotId);
                    dCmd.Parameters.AddWithValue("@Quantite", depot._Quantite);
                    dCmd.Parameters.AddWithValue("@Lieu", depot._Lieu);
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