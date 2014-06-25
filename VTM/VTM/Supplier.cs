using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    class Supplier
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Supplier(int SupplierId, string SupplierNaam) {
            this.Id = SupplierId;
            this.Naam = SupplierNaam;
        }
    }
}
