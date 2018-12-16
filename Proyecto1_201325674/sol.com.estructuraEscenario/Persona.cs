using Proyecto1_201325674.sol.com.archivoConfiguracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.estructuraEscenario
{
    class Persona
    {
        public string nombre { get; set; }
        public string posicionX { get; set; }
        public string posicionY { get; set; }
        public Personaje tipoPersona { get; set; }

        public Persona() {
        }

        public Persona(String nombre, String posX, String posY) {
            this.nombre = nombre;
            this.posicionX = posX;
            this.posicionY = posY;
        }

    }
}
