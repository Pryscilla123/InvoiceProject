using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Business.Models
{
    public class RelatorioCliente
    {
        public string Cliente { get; set; }
        public int QuantidadeFaturas { get; set; }
        public RelatorioCliente()
        {
        }
    }
}
