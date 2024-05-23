using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class CategSum
    {
        private decimal? suma;
        public string Categorie { get; set; }
        public decimal? Suma
        {
            get { return suma ?? 0; }
            set { suma = value; }
        }
    }
}
