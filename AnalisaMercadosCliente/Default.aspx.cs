using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnalisaMercadosCliente.Model;
using System.Data.SqlClient;
using System.Text;
using AnalisaMercadosCliente.MarketAnalyzesWS;

namespace AnalisaMercadosCliente
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Book> bookList = GetBooks();

            txtBooks.Text = CreateString(bookList);
        }

        protected void btSend_Click(object sender, EventArgs e)
        {
            List<Book> bookList = GetBooks();
            List<Book> bookListUpd = MarketAnalise(bookList);

            txtUpdBooks.Text = CreateString(bookListUpd);
        }

        private List<Book> MarketAnalise(List<Book> bookList)
        {
            List<Book> returnList = new List<Book>();

            foreach (Book item in bookList)
            {
                int id = item.ID;
                string title = item.Title;
                float price = item.Price;

                AnalisaMercadosWSPortTypeClient client = new AnalisaMercadosWSPortTypeClient();
                float newPrice = client.AnalisaMercados(price);
                if (newPrice != price)
                {
                    Book newBook = new Book() { ID = id, Title = title, Price = newPrice };
                    returnList.Add(newBook);
                }
                else
                {
                    returnList.Add(item);
                }

            }

            return returnList;
        }

        protected string CreateString(List<Book> list)
        {
            string camp = "";
            foreach (Book item in list)
            {
                camp += item.ID + " | " + item.Title + " | " + item.Price + "\n";
            }

            return camp;
        }

        protected List<Book> GetBooks()
        {
            DBAccess db = new DBAccess();
            return db.GetBooks();
        }
    }

    public class DBAccess
    {
        private const string Gandalf = @"Data Source=gandalf.dei.isep.ipp.pt\sqlexpress;Initial Catalog=ARQSI061;Persist Security Info=True;User ID=ARQSI061;Password=ARQSI061";

        protected SqlConnection GetConnection(bool open)
        {
            SqlConnection cnx = new SqlConnection(Gandalf);
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

        public List<Book> GetBooks()
        {
            SqlConnection con = GetConnection(true);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);

            SqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            List<Book> books = new List<Book>();

            while (reader.Read())
            {
                try
                {
                    string numToParse = reader["Price"].ToString();
                    float price = float.Parse(numToParse);

                    string idToParse = reader["BookID"].ToString();
                    int id = int.Parse(idToParse);

                    string title = reader["Title"].ToString();

                    Book tmp = new Book() { ID = id, Title = title, Price = price };
                    books.Add(tmp);
                }
                catch (Exception)
                {
                    books = null;
                }
            }

            CloseConnection(con);
            return books;
        }
    }


}