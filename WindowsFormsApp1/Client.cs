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
    public class Client
    {
        //variable
        public int _Id { get; set; }
        public string _Nom { get; set; }
        public string _Prenom { get; set; }
        public int _Numero { get; set; }
        public string _Email { get; set; }

        /* numeor client lecture, 
         * nom prenom email
         * id non modifiable en lecture
        */
        public Client(int IdC, string NomC, string PrenomC, int NumeroC, string EmailC)
        {
            this._Id = IdC;
            this._Nom = NomC;
            this._Prenom = PrenomC;
            this._Numero = NumeroC;
            this._Email = EmailC;
        }
        public Client() { }


        public Client RecupProduit(int clientId)
        {
            Client prod = new Client();
            //traitement code

            //creer l'objet de connexion
            MySqlConnection conn = DbCon.GetDBConnection();
            conn.Open();
            // ouvrir la connection


            //preparer la commande

            string sql = "SELECT nom, prenom, numero, email FROM client where(id_client=" + clientId + ") ";

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
                            prod._Nom = reader.GetString(0);
                            prod._Prenom = reader.GetString(1);
                            prod._Numero = reader.GetInt32(2);
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


        public List<Client> RecupAllClient()
        {
            MySqlConnection conn = DbCon.GetDBConnection();
            MySqlDataReader read = null;
            conn.Open();
            List<Client> cli = new List<Client>();
            if (conn != null)
            {
                string req = "select * from client";
                MySqlCommand cmd = new MySqlCommand(req, conn);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cli.Add(new Client(int.Parse(read[0].ToString()), read[1].ToString(), read[2].ToString(), int.Parse(read[3].ToString()), read[4].ToString()));
                }
            }
            read.Close();
            conn.Close();
            return cli;


        }


        public int insertclient(Client client)
        {

            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("INSERT INTO client (Nom,Prenom,Numero,Email)  Values (@Nom,@Prenom,@Numero,@Email)", con);
                dCmd.CommandType = CommandType.Text;
                try
                {

                    dCmd.Parameters.AddWithValue("@Nom", client._Nom);
                    dCmd.Parameters.AddWithValue("@Prenom", client._Prenom);
                    dCmd.Parameters.AddWithValue("@Numero", client._Numero);
                    dCmd.Parameters.AddWithValue("@Email", client._Email);
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
        public int DeleteClient(int ClientId)
        {
            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("DELETE from Client where(id_client=" + ClientId + ") ", con);
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


        public int updateClient(Client client, int ClientId)
        {

            using (MySqlConnection con = DbCon.GetDBConnection())
            {
                con.Open();
                MySqlCommand dCmd = new MySqlCommand("UPDATE client set nom=@nom, prenom=@prenom,numero=@numero, email=@email  where id_client=@id_client", con);
                dCmd.CommandType = CommandType.Text;
                try
                {
                    dCmd.Parameters.AddWithValue("@id_client", ClientId);
                    dCmd.Parameters.AddWithValue("@nom", client._Nom);
                    dCmd.Parameters.AddWithValue("@prenom", client._Prenom);
                    dCmd.Parameters.AddWithValue("@numero", client._Numero);
                    dCmd.Parameters.AddWithValue("@email", client._Email);
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