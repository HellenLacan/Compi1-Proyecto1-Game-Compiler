using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.analizador2
{
    class Recorrido2
    {
        public static String recorrerAST2(ParseTreeNode root)
        {
            switch (root.Term.Name) {
                case "ESCENARIOS":
                    String atributosEscenario="";
                    String ancho = recorrerAST2(root.ChildNodes.ElementAt(4));
                    String alto = recorrerAST2(root.ChildNodes.ElementAt(6));
                    atributosEscenario += root.ChildNodes.ElementAt(1).ToString() + "," +root.ChildNodes.ElementAt(2).ToString() + ";"+
                                          root.ChildNodes.ElementAt(3).ToString() + "," + ancho +";"+ 
                                          root.ChildNodes.ElementAt(5).ToString() + "," + alto + ";";
                    String cuerpo = recorrerAST2(root.ChildNodes.ElementAt(7));
                    break;

                case "CUERPO_ESCENARIO":
                    String listaEscenario = "";
                    switch (root.ChildNodes.Count) {
                        case 1:
                            break;
                        case 2:
                            listaEscenario = recorrerAST2(root.ChildNodes.ElementAt(0));
                            break;
                    }
                    break;

                case "LISTA_ESCENARIO":
                    String tipoObjeto = "";
                    switch (root.ChildNodes.Count) {
                        case 0:
                            break;

                        case 1:
                            tipoObjeto = recorrerAST2(root.ChildNodes.ElementAt(0));
                            break;

                        case 2:
                            listaEscenario = recorrerAST2(root.ChildNodes.ElementAt(0));
                            tipoObjeto = recorrerAST2(root.ChildNodes.ElementAt(1));
                            break;
                    }
                    break;

                case "TIPO_OBJETOS":
                    tipoObjeto = recorrerAST2(root.ChildNodes.ElementAt(0));
                    return tipoObjeto;

                case "PERSONAJES":
                    String personajes = recorrerAST2(root.ChildNodes.ElementAt(0));
                    break;

                case "LISTA_PERSONAJES":
                    String tipoPersonaje;
                    String listaPersonajes;
                    switch (root.ChildNodes.Count) {
                        case 0:
                            break;
                        case 1:
                            //heroes
                            tipoPersonaje = recorrerAST2(root.ChildNodes.ElementAt(0));
                            break;
                        case 2:
                            listaPersonajes = recorrerAST2(root.ChildNodes.ElementAt(0));
                            tipoPersonaje = recorrerAST2(root.ChildNodes.ElementAt(1));
                            break;
                    }
                    break;

                case "TIPO_PERSONAJES":
                    return recorrerAST2(root.ChildNodes.ElementAt(0));

                case "HEROES":
                    return recorrerAST2(root.ChildNodes.ElementAt(0));

                case "POSICIONES_X_Y_OBJETOS":
                    String heroes = "";
                    String posX = ""; 
                    String posY = "";
                    String listaHeroes = "";
                    switch (root.ChildNodes.Count)
                    {
                        case 3:
                            posX = recorrerAST2(root.ChildNodes.ElementAt(1));
                            posY = recorrerAST2(root.ChildNodes.ElementAt(2));
                            heroes += "heroe;"+"identificador," + root.ChildNodes.ElementAt(0).ToString();
                            heroes += ";" + "posicionX," + posX + ";posicionY," + posY;
                            Console.WriteLine("\n" + heroes);
                            return heroes;

                        case 4:
                            listaHeroes = recorrerAST2(root.ChildNodes.ElementAt(0));
                            posX = recorrerAST2(root.ChildNodes.ElementAt(2));
                            posY = recorrerAST2(root.ChildNodes.ElementAt(3));
                            heroes += "heroe;"+"identificador," + root.ChildNodes.ElementAt(1).ToString()+
                                      ";" + "posicionX," + posX + ";posicionY," + posY;
                            Console.WriteLine("\n" + heroes);
                            return heroes;
                    }
                    break;

                case "VILLANOS":
                    break;

                case "PAREDES":
                    break;

                case "EXTRAS":
                    break;

                case "META":
                    break;

                case "LISTA_PAREDES":
                    break;

                case "ATRIBUTOS_LISTA_PAREDES":
                    break;

                case "LISTA_EXTRAS":
                    break;

                case "ATRIBUTOS_LISTA_EXTRAS":
                    break;

                case "EXPRESION":
                    switch (root.ChildNodes.Count)
                    {
                        case 1:
                            if (root.ChildNodes.ElementAt(0).Term.Name == "EXPRESION")
                            {
                                String terminalExpr = recorrerAST2(root.ChildNodes.ElementAt(0));
                                return terminalExpr;
                            }
                            else
                            {
                                String[] n = splitEspacio(root.ChildNodes.ElementAt(0).ToString());
                                return n[0];
                            }

                        case 2:
                            String a = recorrerAST2(root.ChildNodes.ElementAt(0));
                            String b = recorrerAST2(root.ChildNodes.ElementAt(1));
                            double resultado = Convert.ToDouble(a) - Convert.ToDouble(b);
                            return resultado.ToString();
                        case 3:
                            String[] signo = splitEspacio(root.ChildNodes.ElementAt(1).ToString());
                            a = recorrerAST2(root.ChildNodes.ElementAt(0));
                            b = recorrerAST2(root.ChildNodes.ElementAt(2));
                            switch (signo[0])
                            {
                                case "+":
                                    resultado = Convert.ToDouble(a) + Convert.ToDouble(b);
                                    return resultado.ToString();
                                case "*":
                                    resultado = Convert.ToDouble(a) * Convert.ToDouble(b);
                                    return resultado.ToString();
                                case "/":
                                    resultado = Convert.ToDouble(a) / Convert.ToDouble(b);
                                    return resultado.ToString();
                                //Son parentesis
                                default:
                                    return recorrerAST2(root.ChildNodes.ElementAt(1)).ToString();

                            }
                    }
                    break;
            }
            return "";
        }

        private static String[] splitEspacio(String cadena)
        {
            String[] valor = cadena.ToString().Split(' ');
            return valor;
        }

        private static String[] splitComa(String cadena)
        {
            String[] valor = cadena.ToString().Split(',');
            return valor;
        }

        private static String[] splitPtoYcoma(String cadena)
        {
            String[] valor = cadena.ToString().Split(';');
            return valor;
        }

    }

}