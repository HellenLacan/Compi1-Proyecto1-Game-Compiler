using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.archivoConfiguracion
{
    class EscenarioFondo
    {
        private String _identificador;
        private String _ruta;

        public EscenarioFondo() {

        }

        public EscenarioFondo(String identificador, String ruta) {
            this._identificador = identificador;
            this._ruta = ruta;
        }

        public string identificador
        {
            get { return this._identificador; }
            private set { this._identificador = value; }
        }

        public string ruta
        {
            get { return this._ruta; }
            private set { this._ruta = value; }
        }
    }
}
