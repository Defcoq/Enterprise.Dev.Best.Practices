using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise.Architecture.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
    }

}
