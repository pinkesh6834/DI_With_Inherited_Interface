using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_With_Inherited_Interface.DataService
{
    public class DataServiceLayer : Base, I2
    {
        public string SetData { set => myData = value; }

        public string GetData()
        {
            return this.myData;
        }
    }
}
