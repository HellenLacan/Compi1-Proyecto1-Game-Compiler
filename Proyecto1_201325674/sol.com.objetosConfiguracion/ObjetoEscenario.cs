using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.objetosConfiguracion
{
    class ObjetoEscenario
    {
        public string nombre { get; set; }
        public int ptosDestruccion { get; set; }
        public string rutaImagen { get; set; }
        public string tipo { get; set; }
        public int creditos { get; set; }

        public ObjetoEscenario()
        {
        }

        public ObjetoEscenario(String nombre, int ptosDestruccion, String rutaImagen, String tipo, int creditos) {
            this.nombre = nombre;
            this.ptosDestruccion = ptosDestruccion;
            this.rutaImagen = rutaImagen;
            this.tipo = tipo;
            this.creditos = creditos;
        }

    }
}
