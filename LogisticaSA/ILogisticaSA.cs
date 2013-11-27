using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LogisticaSA
{
    [ServiceContract]
    public interface ILogisticaSA
    {

        [OperationContract]
        float GetShipmentValue(float weight, string type);

    }
}
