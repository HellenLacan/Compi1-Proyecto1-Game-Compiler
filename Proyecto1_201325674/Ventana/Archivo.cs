using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.Ventana
{
    class Archivo
    {
        public string path { get; set; }
        public string contenido { get; set; }

        public Archivo(String path, String contenido) {
            this.path = path;
            this.contenido = contenido;
        }
    }
}
