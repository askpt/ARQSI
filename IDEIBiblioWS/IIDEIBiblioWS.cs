using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IDEIBiblioWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIDEIBiblioWS" in both code and config file together.
    [ServiceContract]
    public interface IIDEIBiblioWS
    {
        [OperationContract]
        float GetBookPriceByID(int idBook);

        [OperationContract]
        float GetBookPriceByISBN(int ISBN);

        [OperationContract]
        float GetMagazinePriceByID(int idMagazine);
    }
    
}

