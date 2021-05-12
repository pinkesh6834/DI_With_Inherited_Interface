using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_With_Inherited_Interface.DataService
{
    public interface I2 : I1
    {
        public string SetData { set; }
    }
}
