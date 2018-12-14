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
        public static List<Personaje> miListaHeroes = new List<Personaje>();
        public static List<Personaje> miListaEnemigos = new List<Personaje>();

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

                case "LISTA_BACKGROUND":
                    switch (root.ChildNodes.Count) {
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
                        case 3:
                            String tipo = "";
                            String valor = "";
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0)
                            {
                                tipo = recorrerAST1(root.ChildNodes.ElementAt(0));
                                tipo += "," + root.ChildNodes.ElementAt(1);
                                tipo += "," + root.ChildNodes.ElementAt(2);
                                agregarEscenarios(splitComa(tipo));
                            }
                            else
                            {
                                tipo = root.ChildNodes.ElementAt(1).ToString();
                                valor = "," + root.ChildNodes.ElementAt(2).ToString();

                            }

                            String atributosBackground = tipo + valor;
                            return atributosBackground;
                    }
                    break;

                case "FIGURE":
                    String figure = recorrerAST1(root.ChildNodes.ElementAt(0));
                    break;

                case "LISTA_FIGURE":
                    switch (root.ChildNodes.Count) {
                        case 0:
                            break;
                        case 1:
                            String a = recorrerAST1(root.ChildNodes.ElementAt(0));
                            return a;
                        case 2:
                            String listaFigureA =recorrerAST1(root.ChildNodes.ElementAt(0));
                            agregarPersonajes(listaFigureA);
                            String ListaFigureB = recorrerAST1(root.ChildNodes.ElementAt(1));
                            agregarPersonajes(ListaFigureB);
                            break;
                            // return a + b;
                    }
                    break;

                case "ATRIBUTOS_FIGURE":
                    String atributoFigure="";
                    String valorFigure="";

                    if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0)
                    {
                        atributoFigure = recorrerAST1(root.ChildNodes.ElementAt(0));
                        atributoFigure += ";" + root.ChildNodes.ElementAt(1);
                        if (root.ChildNodes.ElementAt(2).Term.Name == "FIGURE_TIPO")
                        {
                            atributoFigure += "," + recorrerAST1(root.ChildNodes.ElementAt(2));

                        }
                        else {
                            atributoFigure += "," + root.ChildNodes.ElementAt(2);
                        }
                    }
                    else {
                        atributoFigure = root.ChildNodes.ElementAt(1).ToString();
                        valorFigure = "," + root.ChildNodes.ElementAt(2).ToString();
                    }

                    String atribFigura = atributoFigure + valorFigure;
                    return atribFigura;
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
                    switch (root.ChildNodes.Count) {
                        case 1:
                            String[] terminalExpr = splitEspacio(root.ChildNodes.ElementAt(0).ToString());
                            return (terminalExpr[0]);
                        case 2:
                            switch (root.ChildNodes.ElementAt(1).ToString()) {
                                case "+":
                                    break;
                                case "-":
                                    break;
                                case "*":
                                    break;
                                case "/":
                                    break;
                            }
                            break;
                        case 3:
                            break;

                    }
                    break;


            }
            return "";
            
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

            //Verifico si el id del fondo no esta repetido, de lo contrario si ya esta solo, actualiza el path.
            if (miListaFondos.Count != 0){
                foreach (EscenarioFondo item in miListaFondos)
                {
                    if (string.Equals(item.identificador, id, StringComparison.OrdinalIgnoreCase)) {
                        item.ruta = ruta;
                        break;
                    }else{
                        miListaFondos.Add(new EscenarioFondo(id, ruta));
                        break;
                    }
                }
            }else {
                miListaFondos.Add(new EscenarioFondo(id, ruta));
            }

        }

        //Metodo que agrega heroes y enemigos
        private static void agregarPersonajes(String lista) {
            String nombre="";
            String vida="";
            String imagen="";
            String tipoPersonaje = "";
            String descripcion = "";
            String destruir = "";

            String[] personaje = splitPtoYcoma(lista);

            for (int i = 0; i < personaje.Length; i++){
                String[] datos = splitComa(personaje[i]);

                String[] tipo = splitEspacio(datos[0]);
                String[] valor = splitEspacio(datos[1]);

                if (string.Equals(tipo[0], "nombre", StringComparison.OrdinalIgnoreCase)) {
                    nombre = valor[0];
                } else if (string.Equals(tipo[0], "vida", StringComparison.OrdinalIgnoreCase)) {
                    vida = valor[0];
                }
                else if (string.Equals(tipo[0], "imagen", StringComparison.OrdinalIgnoreCase)){
                    imagen = valor[0];
                }
                else if (string.Equals(tipo[0], "tipo", StringComparison.OrdinalIgnoreCase)){
                    tipoPersonaje = valor[0];
                }
                else if (string.Equals(tipo[0], "descripcion", StringComparison.OrdinalIgnoreCase)) {
                    descripcion = valor[0];
                }
                else if (string.Equals(tipo[0], "destruir", StringComparison.OrdinalIgnoreCase)){
                    destruir = valor[0];
                }

            }


            if (string.Equals(tipoPersonaje, "heroe", StringComparison.OrdinalIgnoreCase))
            {
                if (miListaHeroes.Count != 0)
                {

                }
                else
                {
                    miListaHeroes.Add(new Personaje(nombre, vida, imagen, tipoPersonaje, descripcion));
                }
            }
            else
            {
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
