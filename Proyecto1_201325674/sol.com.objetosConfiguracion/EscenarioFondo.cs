using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.archivoConfiguracion
{
    class EscenarioFondo
    {

        public string identificador { get; set; }
        public string ruta { get; set; }


        public EscenarioFondo() {

        }

        public EscenarioFondo(String identificador, String ruta) {
            this.identificador = identificador;
            this.ruta = ruta;
        }

        
    }
}
