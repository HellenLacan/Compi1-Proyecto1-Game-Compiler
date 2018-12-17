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
                    tipoPersonaje = recorrerAST2(root.ChildNodes.ElementAt(0));
                    //Console.WriteLine("tipo_personaje " + tipoPersonaje);
                    return tipoPersonaje;

                case "HEROES":
                    String heroes  = "";
                    heroes += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarPersonajes("villano;" + heroes);
                    //Console.WriteLine("heroe;" + heroes);
                    return "Mheroe;" + heroes;

                case "VILLANOS":
                    String villano = "";
                    villano += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarPersonajes("villano;" + villano);
                    return "villano;" + villano;

                case "POSICIONES_X_Y_OBJETOS":
                    heroes = "";
                    String posX = ""; 
                    String posY = "";
                    listaPersonajes = "";
                    switch (root.ChildNodes.Count)
                    {
                        case 3:
                            posX = recorrerAST2(root.ChildNodes.ElementAt(1));
                            posY = recorrerAST2(root.ChildNodes.ElementAt(2));
                            listaPersonajes += "@identificador," + root.ChildNodes.ElementAt(0).ToString();
                            listaPersonajes += ";" + "posicionX," + posX + ";posicionY," + posY;
                            return listaPersonajes;

                        case 4:
                            listaPersonajes += recorrerAST2(root.ChildNodes.ElementAt(0));
                            posX = recorrerAST2(root.ChildNodes.ElementAt(2));
                            posY = recorrerAST2(root.ChildNodes.ElementAt(3));
                            listaPersonajes += "@identificador," + root.ChildNodes.ElementAt(1).ToString()+
                                      ";" + "posicionX," + posX + ";posicionY," + posY;
                            return listaPersonajes;
                    }
                    break;

                case "EXTRAS":
                    String listaExtras = recorrerAST2(root.ChildNodes.ElementAt(0));
                    break;

                case "LISTA_EXTRAS":
                    String atributosLitas;
                    switch (root.ChildNodes.Count) {
                        case 1:
                            listaExtras = recorrerAST2(root.ChildNodes.ElementAt(0));
                            break;
                        case 2:
                            listaExtras = recorrerAST2(root.ChildNodes.ElementAt(0));
                            atributosLitas = recorrerAST2(root.ChildNodes.ElementAt(1));
                            break;
                    }
                    break;
                    
                case "ATRIBUTOS_LISTA_EXTRAS":
                    atributosLitas = recorrerAST2(root.ChildNodes.ElementAt(0));
                    break;

                case "ARMAS":
                    String extras = "";
                    extras += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarPersonajes("armas;" + extras);
                    return "armas;" + extras;

                case "BONUS":
                    extras = "";
                    extras += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarPersonajes("bonus;" + extras);
                    return "bonus;" + extras;

                case "PAREDES": 
                    break;

                case "META":
                    extras = "";
                    extras += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarPersonajes("meta;" + extras);
                    return "meta;" + extras;

                case "LISTA_PAREDES":
                    break;

                case "ATRIBUTOS_LISTA_PAREDES":
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

        private static void almacenarPersonajes(String listaPersonaje) {
            //String[] lista = spliArroba(listaPersonaje);
            //for (int i =0; i<lista.Length;i++) {
            //    String[] token = splitPtoYcoma(lista[i]) ;
            //    String[] identificador= splitComa(token[0]);
            //    if (string.Equals(token[0], "heroe", StringComparison.OrdinalIgnoreCase) || string.Equals(token[0], "villano", StringComparison.OrdinalIgnoreCase))
            //    {

            //    }
            //    else {
            //        String[] posX = splitComa(token[1]);
            //        String[] posY = splitComa(token[2]);
            //        Console.WriteLine(" Token: " + identificador[0]);
            //        Console.WriteLine(" Valor:" + identificador[1]);
            //        Console.WriteLine(" PosX:" + posX[0]);
            //        Console.WriteLine(" Valor:" + posX[1]);
            //        Console.WriteLine(" PosY:" + posY[0]);
            //        Console.WriteLine(" Valor:" + posY[1] + "\n");
            //    }
                
            //}

        }

        private static String[] spliArroba(String cadena)
        {
            String[] valor = cadena.ToString().Split('@');
            return valor;
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