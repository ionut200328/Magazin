using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class DataSuma
    {
        private decimal? suma;
        private DateTime? data;
        public DateTime? Data
        {
            get { return data; }
            set { data = value; }
        }
        public decimal? Suma
        {
            get { return suma ?? 0; }
            set { suma = value; }
        }
    }
}
