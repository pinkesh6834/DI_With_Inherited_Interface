using DI_With_Inherited_Interface.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_With_Inherited_Interface.AnotherDataService
{
    public class AnotherDataService : IAnotherDataService
    {
        private readonly I1 _i1;
        private readonly I2 _i2;

        public AnotherDataService(I1 i1, I2 i2)
        {
            _i1 = i1;
            _i2 = i2;
        }

        public string GetActualData() {
            var testData = _i2.GetData();
            return _i1.GetData();
        }
    }
}
