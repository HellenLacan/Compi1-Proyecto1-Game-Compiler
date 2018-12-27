using Practica1.sol.com.analyzer;
using Proyecto1_201325674.sol.com.analizador2;
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
    public partial class FormErrores : Form
    {
        public FormErrores()
        {
            InitializeComponent();
        }

        private void FormErrores_Load(object sender, EventArgs e)
        {

            String texto = "";

            texto += "<html>\n";
            texto += "<head><title>Tabla de Errores</title></head>\n";
            texto += "<body>\n";
            texto += "<h1> Tabla de Errores Archivo 1</h1>\n";
            texto += "<table BORDER CELLPADDING=10 CELLSPACING=0\n";
            texto += "\t<tr>\n";
            texto += "\t<td><strong > Tipo </strong></td>\n";
            texto += "\t<td><strong > Descripcion </strong ></td>\n";
            texto += "\t</tr>\n";

            foreach (Error item in Recorrido2.listaErrores)
            {
                texto += "\t<tr>\n";
                texto += "\t<td>" + item.tipo + " </td>\n";
                texto += "\t<td>" + item.descripcion + " </td>\n";
                texto += "\t</tr>\n";
            }

            foreach (Error item in Syntactic.listaErroresSintacticos1)
            {
                texto += "\t<tr>\n";
                texto += "\t<td>" + item.tipo + " </td>\n";
                texto += "\t<td>" + item.descripcion + " </td>\n";
                texto += "\t</tr>\n";
            }
            texto += "</table>\n";

            texto += "<h1> Tabla de Errores Archivo 2</h1>\n";
            texto += "<table BORDER CELLPADDING=10 CELLSPACING=0\n";
            texto += "\t<tr>\n";
            texto += "\t<td><strong > Tipo </strong></td>\n";
            texto += "\t<td><strong > Descripcion </strong ></td>\n";
            texto += "\t</tr>\n";

            foreach (Error item in Sintactico2.listaErroresSintacticos2)
            {
                texto += "\t<tr>\n";
                texto += "\t<td>" + item.tipo + " </td>\n";
                texto += "\t<td>" + item.descripcion + " </td>\n";
                texto += "\t</tr>\n";
            }
            texto += "</table>\n";

            texto += "<h1> Tabla de Errores Semanticos</h1>\n";
            texto += "<table BORDER CELLPADDING=10 CELLSPACING=0\n";
            texto += "\t<tr>\n";
            texto += "\t<td><strong > Tipo </strong></td>\n";
            texto += "\t<td><strong > Descripcion </strong ></td>\n";
            texto += "\t</tr>\n";

            foreach (Error item in Recorrido2.listaErrores)
            {
                texto += "\t<tr>\n";
                texto += "\t<td>" + item.tipo + " </td>\n";
                texto += "\t<td>" + item.descripcion + " </td>\n";
                texto += "\t</tr>\n";
            }

            texto += "</table>\n";


            texto += "</body>\n";
            texto += "</html>\n";

            webBrowser1.DocumentText = texto;
        }
    }
}
