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
        public float GetBookPriceByID(int idBook)
        {
            throw new NotImplementedException();
        }

        public float GetBookPriceByISBN(int ISBN)
        {
            throw new NotImplementedException();
        }

        public float GetMagazinePriceByID(int idMagazine)
        {
            throw new NotImplementedException();
        }

    }
}

