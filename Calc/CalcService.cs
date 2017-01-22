using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calc
{
    class CalcService
    {
        private static readonly Lazy<CalcService> lazy =
        new Lazy<CalcService>(() => new CalcService());

        public string Name { get; private set; }

        public Calc Calculator { get; private set; }

        private void LoadOperation(string pathToDll) {
        }

        

        private List<IOperation> operations { get; set; }

        private CalcService()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static CalcService GetInstance()
        {
            return lazy.Value;
        }
    }
}
