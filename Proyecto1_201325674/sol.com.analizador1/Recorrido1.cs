using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using Proyecto1_201325674.sol.com.archivoConfiguracion;

namespace Practica1.sol.com.analyzer
{
    class Recorrido1
    {
        public static List<EscenarioFondo> miListaFondos = new List<EscenarioFondo>();

        public static String recorrerAST1(ParseTreeNode root) {
            switch (root.Term.Name) {
                case "CONFIGURACION":
                    return recorrerAST1(root.ChildNodes.ElementAt(0));

                case "LISTA_CONFIGURACION":
                    switch (root.ChildNodes.Count){
                        case 1:
                            String lista_configuracion = recorrerAST1(root.ChildNodes.ElementAt(0));
                            return lista_configuracion;
                        case 2:
                            recorrerAST1(root.ChildNodes.ElementAt(0));
                            recorrerAST1(root.ChildNodes.ElementAt(1));
                            break;
                    }
                    break;

                case "BACKGROUND":
                    String listaBackground = recorrerAST1(root.ChildNodes.ElementAt(0));
                    return listaBackground;

                case "FIGURE":
                    break;

                case "DESIGN":
                    break;

                case "LISTA_BACKGROUND":
                    switch (root.ChildNodes.Count) {
                        case 0:
                            break;
                        case 1:
                            String atributosBackground = recorrerAST1(root.ChildNodes.ElementAt(0));
                            //agregarEscenarios(splitCadena(atributosBackground));
                            return atributosBackground;
                        case 2:
                            listaBackground = recorrerAST1(root.ChildNodes.ElementAt(0));
                            //Aqui agrego el fondo a la lista
                            atributosBackground = recorrerAST1(root.ChildNodes.ElementAt(1));

                            return listaBackground + "," + atributosBackground ;
                    }
                    break;

                case "LISTA_FIGURE":
                    break;

                case "LISTA_DESIGN":
                    break;

                case "ATRIBUTOS_BACKGROUND":
                    switch (root.ChildNodes.Count) {
                        case 0:
                            break;
                        case 3:
                            String tipo="";
                            String valor="";
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0) {
                                tipo = recorrerAST1(root.ChildNodes.ElementAt(0));
                                tipo+= "," + root.ChildNodes.ElementAt(1);
                                tipo += "," + root.ChildNodes.ElementAt(2);
                                agregarEscenarios(splitCadena(tipo));
                            }
                            else {
                                tipo = root.ChildNodes.ElementAt(1).ToString();
                                valor = ","+ root.ChildNodes.ElementAt(2).ToString();

                            }

                            String atributosBackground = tipo  + valor;
                            return atributosBackground;
                    }
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
            return "";
            
        }

        private static String[] retornarValor(ParseTreeNode root) {
            string[] array = new string[root.ChildNodes.Count-1];
            switch (root.Term.Name) {
                case "ATRIBUTOS_BACKGROUND":
                    array[0] = root.ChildNodes.ElementAt(1).ToString();
                    array[1] = root.ChildNodes.ElementAt(2).ToString();
                    return array;
            }
            return array;
        }

        private static String[] splitCadena(String cadena)
        {
            String[] valor = cadena.ToString().Split(',');
            return valor;
        }

        private static void agregarEscenarios(String[] lista) {
            String id="";
            String ruta="";

            EscenarioFondo miEscenario = new EscenarioFondo();
            for(int i=0; i < lista.Length; i++) { 
                String[] term = lista[i].ToString().Split(' ') ;
                Console.WriteLine(term[0]);
                Console.WriteLine(term[1]);

                if (term[1] == "(identificador)") {
                    id = term[0];
                }

                if (term[1] == "(cadena)")
                {
                    ruta = term[0];
                }
            }

            if (miListaFondos.Count != 0)
            {
                foreach (EscenarioFondo item in miListaFondos)
                {
                    if (string.Equals(item.identificador, id, StringComparison.OrdinalIgnoreCase))
                    {
                        item.ruta = ruta;
                        break;
                    }
                    else
                    {
                        miListaFondos.Add(new EscenarioFondo(id, ruta));
                        break;
                    }
                }
            }
            else {
                miListaFondos.Add(new EscenarioFondo(id, ruta));
            }

        }
    }
}
