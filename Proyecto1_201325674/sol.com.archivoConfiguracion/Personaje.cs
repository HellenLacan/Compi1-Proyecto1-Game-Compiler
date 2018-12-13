using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.archivoConfiguracion
{
    class Personaje
    {
        private String _nombre;
        private String _vida;
        private String _rutaImagen;
        private String _tipo;
        private String _ptosDestruccion; //Si es solo villano
        private String _descripcion;

        public Personaje() {
        }
        
        //Constructor para villano
        public Personaje(String nombre, String vida, String rutaimagen, String tipo, String ptosDestruccion, String descripcion) {
            this._nombre = nombre;
            this._vida = vida;
            this._rutaImagen = rutaimagen;
            this._tipo = tipo;
            this._ptosDestruccion = ptosDestruccion;
            this._descripcion = descripcion;
        }

        //Constructor para heroe
        public Personaje(String nombre, String vida, String rutaimagen, String tipo, String descripcion)
        {
            this._nombre = nombre;
            this._vida = vida;
            this._rutaImagen = rutaimagen;
            this._tipo = tipo;
            this._ptosDestruccion = "";
            this._descripcion = descripcion;
        }

        public string nombre
        {
            get { return this._nombre; }
            private set { this._nombre = value; }
        }

        public string vida
        {
            get { return this._vida; }
            private set { this._vida = value; }
        }

        public string rutaImagen
        {
            get { return this._rutaImagen; }
            private set { this._rutaImagen = value; }
        }

        public string tipo
        {
            get { return this._tipo; }
            private set { this._tipo = value; }
        }

        public string ptosDestruccion
        {
            get { return this._ptosDestruccion; }
            private set { this._ptosDestruccion = value; }
        }

        public string descripcion
        {
            get { return this._descripcion; }
            private set { this._descripcion = value; }
        }
    }
}
