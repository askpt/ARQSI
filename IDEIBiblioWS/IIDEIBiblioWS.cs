using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IDEIBiblioWS
{
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
