using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;

namespace Practica1.sol.com.analyzer
{
    class Recorrido
    {

        public static String recorrerAST1(ParseTreeNode root, String lenguajeCS) {
            switch (root.Term.Name) {
                case "CONFIGURACION":
                    break;

                case "LISTA_CONFIGURACION":
                    break;

                case "BACKGROUND":
                    break;

                case "FIGURE":
                    break;

                case "DESIGN":
                    break;

                case "LISTA_BACKGROUND":
                    break;

                case "LISTA_FIGURE":
                    break;

                case "LISTA_DESIGN":
                    break;

                case "ATRIBUTOS_BACKGROUND":
                    break;

                case "ATRIBUTOS_FIGURE":
                    break;

                case "ATRIBUTOS_DESIGN":
                    break;

                case "FIGURE_TIPO":
                    break;

                case "DESIGN_TIPO":
                    break;

                case "EXPRESION":
                    break;
            }
            return lenguajeCS;
        }
    }
}
