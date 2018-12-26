using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.objetosConfiguracion
{
    class Token_
    {
        public string token { get; set; }
        public string lexema { get; set; }
        public int fila { get; set; }
        public int columna { get; set; }
        public string tipo { get; set; }

        public Token_(String token, String lexema, String tipo, int fila, int columna) {
            this.token = token;
            this.lexema = lexema;
            this.fila = fila;
            this.columna = columna;
            this.tipo = tipo;
        }
    }
}
