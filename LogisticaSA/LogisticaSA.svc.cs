using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LogisticaSA
{
    public class LogisticaSA : ILogisticaSA
    {
        public float GetShipmentValue(float weight, string type)
        {
            if (type == "National")
            {
                return GetShipmentValue(weight);
            }

            if (type == "International")
            {
                return GetShipmentValue(weight) * 2;
            }
            if (type == "National Urgent")
            {
                return GetShipmentValue(weight) + 1.5f;
            }
            if (type == "International Urgent")
            {
                return (GetShipmentValue(weight) + 1.5f) * 2;
            }

            return -1;
        }

        private float GetShipmentValue(float weight)
        {
            if (weight > 0 && weight < 0.5) 
            {
                return 2;
            }
            if (weight >= 0.5 && weight < 1)
            {
                return 4.5f;
            }
            if (weight >= 1 && weight < 5)
            {
                return 15;
            }
            if (weight >= 5 && weight < 15)
            {
                return 35;
            }
            if (weight >= 15)
            {
                return 60;
            }

            return -1;
        }
    }
}
