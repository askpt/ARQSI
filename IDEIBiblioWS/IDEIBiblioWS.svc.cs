using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IDEIBiblioWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class IDEIBiblioWS : IIDEIBiblioWS
    {
        private Connection ctype = Connection.DefaultConnection;
        public float GetBookPriceByID(int idBook)
        {
            DBAccess db = new DBAccess(ctype);
            return db.GetBookPriceByID(idBook);
        }

        public float GetBookPriceByISBN(int ISBN)
        {
            DBAccess db = new DBAccess(ctype);
            return db.GetBookPriceByISBN(ISBN);
        }

        public float GetMagazinePriceByID(int idMagazine)
        {
            DBAccess db = new DBAccess(ctype);
            return db.GetMagazinePriceByID(idMagazine);
        }

    }
}

