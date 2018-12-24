using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.archivoConfiguracion
{
    class Personaje
    {
        public string nombre { get; set; }
        public int vida { get; set; }
        public string rutaImagen { get; set; }
        public string tipo { get; set; }
        public String ptosDestruccion { get; set; }
        public string descripcion { get; set; }

        public Personaje() {
        }
        
        //Constructor para villano
        public Personaje(String nombre, int vida, String rutaimagen, String tipo, String ptosDestruccion, String descripcion) {
            this.nombre = nombre;
            this.vida = vida;
            this.rutaImagen = rutaimagen;
            this.tipo = tipo;
            this.ptosDestruccion = ptosDestruccion;
            this.descripcion = descripcion;
        }

        //Constructor para heroe
        public Personaje(String nombre, int vida, String rutaimagen, String tipo, String descripcion)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.rutaImagen = rutaimagen;
            this.tipo = tipo;
            this.ptosDestruccion = "";
            this.descripcion = descripcion;
        }

    }
}
