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
        public static List<Personaje> miListaPersonajes = new List<Personaje>();

        public static String recorrerAST1(ParseTreeNode root)
        {
            switch (root.Term.Name)
            {
                case "CONFIGURACION":
                    return recorrerAST1(root.ChildNodes.ElementAt(0));

                case "LISTA_CONFIGURACION":
                    switch (root.ChildNodes.Count)
                    {
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

                case "LISTA_BACKGROUND":
                    switch (root.ChildNodes.Count)
                    {
                        case 0:
                            break;
                        case 1:
                            recorrerAST1(root.ChildNodes.ElementAt(0));
                            break;
                        case 2:
                            recorrerAST1(root.ChildNodes.ElementAt(0));
                            recorrerAST1(root.ChildNodes.ElementAt(1));
                            break;
                    }
                    break;

                case "ATRIBUTOS_BACKGROUND":
                    switch (root.ChildNodes.Count)
                    {
                        case 0:
                            break;
                        case 4:
                            String tipo = "";
                            String valor = "";
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0)
                            {
                                tipo = recorrerAST1(root.ChildNodes.ElementAt(0));
                                tipo += "," + root.ChildNodes.ElementAt(2);
                                tipo += "," + root.ChildNodes.ElementAt(3);
                                agregarEscenarios(splitComa(tipo));
                            }
                            else
                            {
                                tipo = root.ChildNodes.ElementAt(2).ToString();
                                valor = "," + root.ChildNodes.ElementAt(3).ToString();

                            }

                            String atributosBackground = tipo + valor;
                            return atributosBackground;
                    }
                    break;

                case "FIGURE":
                    String figure = recorrerAST1(root.ChildNodes.ElementAt(0));
                    break;

                case "LISTA_FIGURE":
                    switch (root.ChildNodes.Count)
                    {
                        case 0:
                            break;
                        case 1:
                            String a = recorrerAST1(root.ChildNodes.ElementAt(0));
                            return a;
                        case 2:
                            String listaFigureA = recorrerAST1(root.ChildNodes.ElementAt(0));
                            String ListaFigureB = recorrerAST1(root.ChildNodes.ElementAt(1));

                            if (listaFigureA != "") {
                                agregarPersonajes(listaFigureA);
                            }
                            if(ListaFigureB != ""){
                                agregarPersonajes(ListaFigureB);
                            }
                            break;
                            // return a + b;
                    }
                    break;

                case "ATRIBUTOS_FIGURE":
                    String atributoFigure = "";
                    String valorFigure = "";
                    String cadenaFigure;
                    switch (root.ChildNodes.Count)
                    {

                        case 0:
                            break;

                        case 4:
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0)
                            {
                                atributoFigure += recorrerAST1(root.ChildNodes.ElementAt(0)) + ";";
                                atributoFigure += root.ChildNodes.ElementAt(2).ToString();
                                if (root.ChildNodes.ElementAt(3).Term.Name == "EXPRESION")
                                {
                                    valorFigure = recorrerAST1(root.ChildNodes.ElementAt(3));
                                }
                                else
                                {
                                    valorFigure = root.ChildNodes.ElementAt(3).ToString();
                                }
                                atributoFigure = atributoFigure + "," + valorFigure;
                                return atributoFigure;
                            }
                            else
                            {
                                atributoFigure = root.ChildNodes.ElementAt(2).ToString();
                                atributoFigure += "," + root.ChildNodes.ElementAt(3).ToString();
                                return atributoFigure;
                            }
                        case 5:
                            atributoFigure = recorrerAST1(root.ChildNodes.ElementAt(0));
                            atributoFigure += ";" + root.ChildNodes.ElementAt(2).ToString();
                            atributoFigure += "," + recorrerAST1(root.ChildNodes.ElementAt(4));
                            return atributoFigure;
                    }

                    break;

                case "DESIGN":
                    break;

                case "LISTA_DESIGN":
                    break;

                case "ATRIBUTOS_DESIGN":
                    break;

                case "DESIGN_TIPO":
                    break;

                case "FIGURE_TIPO":
                    return root.ChildNodes.ElementAt(0).ToString();

                case "EXPRESION":
                    switch (root.ChildNodes.Count)
                    {
                        case 1:
                            if (root.ChildNodes.ElementAt(0).Term.Name == "EXPRESION")
                            {
                                String terminalExpr = recorrerAST1(root.ChildNodes.ElementAt(0));
                                return terminalExpr;
                            }
                            else
                            {
                                String[] n = splitEspacio(root.ChildNodes.ElementAt(0).ToString());
                                return n[0];
                            }

                        case 2:
                            String numero = root.ChildNodes.ElementAt(0).ToString() + root.ChildNodes.ElementAt(1).ToString();
                            return numero;
                        case 3:
                            int resultado;
                            String[] signo = splitEspacio(root.ChildNodes.ElementAt(1).ToString());
                            String a = recorrerAST1(root.ChildNodes.ElementAt(0));
                            String b = recorrerAST1(root.ChildNodes.ElementAt(2));
                            switch (signo[0])
                            {
                                case "+":
                                    resultado = Convert.ToInt32(a) + Convert.ToInt32(b);
                                    return resultado.ToString();
                                case "-":
                                    resultado = Convert.ToInt32(a) - Convert.ToInt32(b);
                                    return resultado.ToString();
                                case "*":
                                    resultado = Convert.ToInt32(a) * Convert.ToInt32(b);
                                    return resultado.ToString();
                                case "/":
                                    resultado = Convert.ToInt32(a) / Convert.ToInt32(b);
                                    return resultado.ToString();
                                //Son parentesis
                                default:
                                    return recorrerAST1(root.ChildNodes.ElementAt(1)).ToString();

                            }

                    }
                    break;


            }
            return "";

        }

        private static void agregarEscenarios(String[] lista)
        {
            String id = "";
            String ruta = "";

            EscenarioFondo miEscenario = new EscenarioFondo();
            for (int i = 0; i < lista.Length; i++)
            {
                String[] term = lista[i].ToString().Split(' ');
                Console.WriteLine(term[0]);
                Console.WriteLine(term[1]);

                if (term[1] == "(identificador)")
                {
                    id = term[0];
                }

                if (term[1] == "(cadena)")
                {
                    ruta = term[0];
                }
            }

            //Verifico si el id del fondo no esta repetido, de lo contrario si ya esta solo, actualiza el path.
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
            else
            {
                miListaFondos.Add(new EscenarioFondo(id, ruta));
            }

        }

        //Metodo que agrega heroes y enemigos
        private static void agregarPersonajes(String lista)
        {
            Boolean encontrado = false;
            String nombre = "";
            String vida = "";
            String imagen = "";
            String tipoPersonaje = "";
            String descripcion = "";
            String destruir = "";

            String[] personaje = splitPtoYcoma(lista);

            for (int i = 0; i < personaje.Length; i++)
            {
                String[] datos = splitComa(personaje[i]);

                String[] tipo = splitEspacio(datos[0]);
                String[] valor = splitEspacio(datos[1]);

                if (string.Equals(tipo[0], "nombre", StringComparison.OrdinalIgnoreCase))
                {
                    nombre = valor[0];
                }
                else if (string.Equals(tipo[0], "vida", StringComparison.OrdinalIgnoreCase))
                {
                    vida = valor[0];
                }
                else if (string.Equals(tipo[0], "imagen", StringComparison.OrdinalIgnoreCase))
                {
                    imagen = valor[0];
                }
                else if (string.Equals(tipo[0], "tipo", StringComparison.OrdinalIgnoreCase))
                {
                    tipoPersonaje = valor[0];
                }
                else if (string.Equals(tipo[0], "descripcion", StringComparison.OrdinalIgnoreCase))
                {
                    descripcion = datos[1];
                }
                else if (string.Equals(tipo[0], "destruir", StringComparison.OrdinalIgnoreCase))
                {
                    destruir = valor[0];
                }
            }


            if (string.Equals(tipoPersonaje, "heroe", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(tipoPersonaje, "enemigo", StringComparison.OrdinalIgnoreCase))
            {
                if (miListaPersonajes.Count != 0)
                {
                        buscarPersonaje(tipoPersonaje, nombre, vida, imagen, descripcion, destruir);
                }
                else
                {
                    miListaPersonajes.Add(new Personaje(nombre, vida, imagen, tipoPersonaje, destruir,descripcion));
                }
            }
            else
            {
                Console.WriteLine("Tipo incorrecto");
            }
        }

        public static bool buscarPersonaje(String tipo, String id, String vida, String imagen, String descripcion, String destruir) {

            foreach (Personaje item in miListaPersonajes) {
                if (string.Equals(item.nombre, id, StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Equals(item.tipo, tipo, StringComparison.OrdinalIgnoreCase))
                    {
                        actualizarDatosPersonajes(vida, id, imagen, descripcion, destruir, item, tipo);
                        return true;
                    }
                    else
                    {
                        Console.Write("Identificador duplicado");
                        return false;
                    }
                }
            }

            miListaPersonajes.Add(new Personaje(id, vida, imagen, tipo, destruir, descripcion));
            return true;
        }

        public static void actualizarDatosPersonajes(String vida, String nombre, String imagen, String descripcion, String ptosDestruir, Personaje item, String tipo) {
            if (vida != "") {
                item.vida = vida;
            }
            if (imagen != "")
            {
                item.rutaImagen = imagen;
            }
            if (descripcion != "")
            {
                item.descripcion = descripcion;
            }
            if (!(string.Equals(tipo, "heroe", StringComparison.OrdinalIgnoreCase)))
            {
                item.ptosDestruccion = ptosDestruir;
            }
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
