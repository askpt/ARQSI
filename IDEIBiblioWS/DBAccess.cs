using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IDEIBiblioWS
{
    public enum Connection
	{
	    DefaultConnection,
        Gandalf
	}

    public class DBAccess
    {
        private const string DefaultConnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\Shop.mdf;Initial Catalog=IDEIBiblio;Integrated Security=True";
        private const string Gandalf = @"Data Source=gandalf.dei.isep.ipp.pt\sqlexpress;Initial Catalog=ARQSI061;Persist Security Info=True;User ID=ARQSI061;Password=ARQSI061";

        private Connection configuredConnection;

        public DBAccess(Connection configuredConnection)
        {
            this.configuredConnection = configuredConnection;
        }
        
        protected SqlConnection GetConnection(bool open)
        {
            SqlConnection cnx;
            switch (configuredConnection)
            {
                case Connection.DefaultConnection:
                    cnx = new SqlConnection(DefaultConnection);
                    break;
                case Connection.Gandalf:
                    cnx = new SqlConnection(Gandalf);
                    break;
                default:
                    return null;
            }
            if (open)
            {
                cnx.Open();
            }

            return cnx;
        }

        protected void CloseConnection(SqlConnection cnx)
        {
            cnx.Close();
        }

        public float GetBookPriceByID(int idBook)
        {
            string query = "SELECT * FROM Books WHERE BookID=" + idBook;

            return ExecuteQuery(query);
        }

        public float GetBookPriceByISBN(int ISBN)
        {
            string query = "SELECT * FROM Books WHERE ISBN=" + ISBN;

            return ExecuteQuery(query);
        }

        public float GetMagazinePriceByID(int idMagazine)
        {
            string query = "SELECT * FROM Magazines WHERE MagazineID=" + idMagazine;

            return ExecuteQuery(query);
        }

        protected float ExecuteQuery(string query)
        {
            SqlConnection con = GetConnection(true);
            SqlCommand cmd = new SqlCommand(query, con);
            float ret = -1;

            SqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            reader.Read();

            try
            {
                string numToParse = reader["Price"].ToString();
                ret = float.Parse(numToParse);
            }
            catch (Exception)
            {
                ret = -2;
            }
            finally
            {
                CloseConnection(con);
            }
            return ret;
        }
    }
}