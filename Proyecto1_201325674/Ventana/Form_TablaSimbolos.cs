using Practica1.sol.com.analyzer;
using Proyecto1_201325674.sol.com.archivoConfiguracion;
using Proyecto1_201325674.sol.com.objetosConfiguracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201325674.Ventana
{
    public partial class Form_TablaSimbolos : Form
    {
        public Form_TablaSimbolos()
        {
            InitializeComponent();
        }


        private void Form_TablaSimbolos_Load(object sender, EventArgs e)
        {
            String texto = "";

            texto += "<html>\n";
            texto += "<head><title>Tabla de Simbolos</title></head>\n";
            texto += "<body>\n";
            texto += "<h1> Tabla de Simbolos</h1>\n";
            texto += "<h1> Fondos</h1>\n";
            texto += "<table BORDER CELLPADDING=10 CELLSPACING=0\n";
            texto += "\t<tr>\n";
            texto += "\t<td><strong > tipo </strong ></td>\n";
            texto += "\t<td><strong > Nombre </strong></td>\n";
            texto += "\t<td><strong > Ruta </strong ></td>\n";
            texto += "\t</tr>\n";

            foreach (EscenarioFondo item in Recorrido1.miListaFondos)
            {
                texto += "\t<tr>\n";
                texto += "\t<td>" + "background" + " </td>\n";
                texto += "\t<td>" + item.identificador + " </td>\n";
                texto += "\t<td>" + item.ruta + " </td>\n";
                texto += "\t</tr>\n";
            }
            texto += "</table>\n";

            texto += "<h1> Heroes</h1>\n";
            texto += "<table BORDER CELLPADDING=10 CELLSPACING=0\n";
            texto += "\t<tr>\n";
            texto += "\t<td><strong > tipo </strong ></td>\n";
            texto += "\t<td><strong > Nombre </strong></td>\n";
            texto += "\t<td><strong > vida </strong ></td>\n";
            texto += "\t<td><strong > PtsDestr </strong ></td>\n";
            texto += "\t<td><strong > imagen </strong ></td>\n";
            texto += "\t<td><strong > descripcion </strong ></td>\n";
            texto += "\t</tr>\n";

            foreach (Personaje item in Recorrido1.milistaHeroes)
            {
                texto += "\t<tr>\n";

                if (string.Equals(item.tipo, "heroe", StringComparison.OrdinalIgnoreCase))
                {
                    texto += "\t<td>" + "heroe" + " </td>\n";
                    texto += "\t<td>" + item.nombre + " </td>\n";
                    texto += "\t<td>" + item.vida + " </td>\n";
                    texto += "\t<td>" + "-" + " </td>\n";
                    texto += "\t<td>" + item.rutaImagen + " </td>\n";
                    texto += "\t<td>" + item.descripcion + " </td>\n";
                }
                texto += "\t</tr>\n";
            }

            foreach (Personaje item in Recorrido1.milistaEnemigos)
            {
                texto += "\t<tr>\n";
                if (string.Equals(item.tipo, "enemigo", StringComparison.OrdinalIgnoreCase))
                {
                    texto += "\t<td>" + "enemigo" + " </td>\n";
                    texto += "\t<td>" + item.nombre + " </td>\n";
                    texto += "\t<td>" + "-" + " </td>\n";
                    texto += "\t<td>" + item.ptosDestruccion + " </td>\n";
                    texto += "\t<td>" + item.rutaImagen + " </td>\n";
                    texto += "\t<td>" + item.descripcion + " </td>\n";
                }
                texto += "\t</tr>\n";
            }
            texto += "</table>\n";

            /**********************OBJETOS******************/

            texto += "<h1> Objetos</h1>\n";
            texto += "<table BORDER CELLPADDING=10 CELLSPACING=0\n";
            texto += "\t<tr>\n";
            texto += "\t<td><strong > tipo </strong ></td>\n";
            texto += "\t<td><strong > Nombre </strong></td>\n";
            texto += "\t<td><strong > PtosDestr </strong ></td>\n";
            texto += "\t<td><strong > Creditos </strong ></td>\n";
            texto += "\t<td><strong > imagen </strong ></td>\n";

            texto += "\t</tr>\n";

            foreach (ObjetoEscenario item in Recorrido1.miListaObjetos)
            {
                texto += "\t<tr>\n";
                texto += "\t<td>" + item.tipo + " </td>\n";
                texto += "\t<td>" + item.nombre + " </td>\n";
                if (string.Equals(item.tipo, "arma", StringComparison.OrdinalIgnoreCase))
                {
                    texto += "\t<td>" + item.ptosDestruccion + " </td>\n";
                    texto += "\t<td>" + "-" + " </td>\n";
                }
                else
                {
                    texto += "\t<td>" + "-" + " </td>\n";
                    texto += "\t<td>" + item.creditos + " </td>\n";
                }
                texto += "\t<td>" + item.rutaImagen + " </td>\n";
                texto += "\t</tr>\n";
            }
            texto += "</table>\n";

            texto += "</body>\n";
            texto += "</html>\n";

            webBrowser1.DocumentText = texto;

        }
    }
}
