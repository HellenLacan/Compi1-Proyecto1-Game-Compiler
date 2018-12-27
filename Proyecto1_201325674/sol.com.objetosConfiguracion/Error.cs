using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.objetosConfiguracion
{
    class Error
    {
        public string tipo { get; set; }
        public string descripcion { get; set; }

        public Error(String tipo, String descripcion) {
            this.tipo = tipo;
            this.descripcion = descripcion;
        }

    }
}
