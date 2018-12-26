using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using Proyecto1_201325674.sol.com.archivoConfiguracion;
using Proyecto1_201325674.sol.com.objetosConfiguracion;

namespace Practica1.sol.com.analyzer
{
    class Recorrido1
    {
        public static List<EscenarioFondo> miListaFondos = new List<EscenarioFondo>();
        public static List<Personaje> milistaHeroes = new List<Personaje>();
        public static List<Personaje> milistaEnemigos = new List<Personaje>();
        public static List<ObjetoEscenario> miListaObjetos = new List<ObjetoEscenario>();
        public static List<Token_> TablaDeSimbolos = new List<Token_>();

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
                        case 3:
                            String tipo = "";
                            String valor = "";
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0)
                            {
                                String posxY = "";
                                tipo = recorrerAST1(root.ChildNodes.ElementAt(0));
                                tipo += "," + root.ChildNodes.ElementAt(1);
                                posxY += root.ChildNodes.ElementAt(1).Span.Location.Line;
                                posxY += ","+root.ChildNodes.ElementAt(1).Span.Location.Column;
                                tipo += "," + root.ChildNodes.ElementAt(2);
                                posxY += ";"+root.ChildNodes.ElementAt(2).Span.Location.Line;
                                posxY += "," + root.ChildNodes.ElementAt(2).Span.Location.Column;
                                agregarEscenarios(splitComa(tipo), posxY);
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
                                agregarPersonajes(listaFigureA, root);
                            }
                            if(ListaFigureB != ""){
                                agregarPersonajes(ListaFigureB, root);
                            }
                            break;
                            // return a + b;
                    }
                    break;

                case "ATRIBUTOS_FIGURE":
                    String atributoFigure = "";
                    String valorFigure = "";
                    switch (root.ChildNodes.Count)
                    {

                        case 0:
                            break;

                        case 3:
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0)
                            {
                                atributoFigure += recorrerAST1(root.ChildNodes.ElementAt(0)) + ";";
                                atributoFigure += root.ChildNodes.ElementAt(1).ToString();
                                if (root.ChildNodes.ElementAt(2).Term.Name == "EXPRESION" ||
                                    root.ChildNodes.ElementAt(2).Term.Name == "FIGURE_TIPO")
                                {
                                    valorFigure = recorrerAST1(root.ChildNodes.ElementAt(2));
                                }
                                else
                                {
                                    valorFigure = root.ChildNodes.ElementAt(2).ToString();
                                }
                                atributoFigure = atributoFigure + "," + valorFigure;
                                return atributoFigure;
                            }
                            else
                            {
                                atributoFigure = root.ChildNodes.ElementAt(1).ToString();
                                atributoFigure += "," + root.ChildNodes.ElementAt(2).ToString();
                                return atributoFigure;
                            }
                    }

                    break;

                case "DESIGN":
                    String design = recorrerAST1(root.ChildNodes.ElementAt(0));
                    break;

                case "LISTA_DESIGN":
                    String atributosDesign;
                    String listaDesign;
                    switch (root.ChildNodes.Count) {
                        case 0:
                            break;
                        case 1:
                             listaDesign= recorrerAST1(root.ChildNodes.ElementAt(0));
                            if (listaDesign != "") {
                                agregarObjetosDeEscenario(listaDesign);
                            }
                            break;
                        case 2:
                            listaDesign = recorrerAST1(root.ChildNodes.ElementAt(0));
                            if (listaDesign != "") {
                                agregarObjetosDeEscenario(listaDesign);
                            }
                            atributosDesign = recorrerAST1(root.ChildNodes.ElementAt(1));
                            if (atributosDesign != "") {
                                agregarObjetosDeEscenario(atributosDesign);
                            }
                            break;
                    }
                    break;

                case "ATRIBUTOS_DESIGN":
                    String design_valores="";
                    switch (root.ChildNodes.Count) {

                        case 0:
                            break;

                        case 1:
                            break;

                        case 3:
                            design_valores+= recorrerAST1(root.ChildNodes.ElementAt(0));
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count != 0)
                            {
                                design_valores += root.ChildNodes.ElementAt(1);
                                if ((root.ChildNodes.ElementAt(2).Term.Name == "EXPRESION") ||
                                  (root.ChildNodes.ElementAt(2).Term.Name == "DESIGN_TIPO"))
                                {
                                    design_valores += "," + recorrerAST1(root.ChildNodes.ElementAt(2))+";";
                                }
                                else
                                {
                                    design_valores += "," + root.ChildNodes.ElementAt(2)+";";
                                }
                            }
                            else {
                                design_valores += root.ChildNodes.ElementAt(1);
                                if ((root.ChildNodes.ElementAt(2).Term.Name == "EXPRESION") ||
                                    (root.ChildNodes.ElementAt(2).Term.Name == "DESIGN_TIPO"))
                                {
                                    design_valores += "," + recorrerAST1(root.ChildNodes.ElementAt(2));
                                }
                                else {
                                    design_valores += "," + root.ChildNodes.ElementAt(2)+";";
                                }
                            }
                            return design_valores;
                        
                    }
                    break;

                case "DESIGN_TIPO":
                    String design_tipo = root.ChildNodes.ElementAt(0).ToString();
                    return design_tipo;

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
                            String a = recorrerAST1(root.ChildNodes.ElementAt(0));
                            String b = recorrerAST1(root.ChildNodes.ElementAt(1));
                            int resultadoFinal = Convert.ToInt32(a) - Convert.ToInt32(b);
                            return resultadoFinal.ToString();
                        case 3:
                            String[] signo = splitEspacio(root.ChildNodes.ElementAt(1).ToString());
                            a = recorrerAST1(root.ChildNodes.ElementAt(0));
                            b = recorrerAST1(root.ChildNodes.ElementAt(2));
                            double resultado=0;
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
                                    return recorrerAST1(root.ChildNodes.ElementAt(1)).ToString();

                            }
                    }
                    break;

            }
            return "";

        }

        private static void agregarEscenarios(String[] lista, String posiciones)
        {
            String id = "";
            String ruta = "";
            Boolean encontrado = false;
            EscenarioFondo miEscenario = new EscenarioFondo();

            for (int i = 0; i < lista.Length; i++)
            {
                String[] term = lista[i].ToString().Split(' ');

                //Console.WriteLine(term[0]);
                //Console.WriteLine(term[1]);

                if (term[1] == "(identificador)")
                {
                    id = term[0];
                }

                if (term[1] == "(cadena)")
                {
                    ruta = term[0];
                }
            }

            //Agregando TOKENS
            String[] posXY = posiciones.ToString().Split(';');
            String[] pos1 = posXY[0].ToString().Split(',');
            String[] pos2 = posXY[1].ToString().Split(',');

            //Verifico si el id del fondo no esta repetido, de lo contrario si ya esta solo, actualiza el path.
            if (miListaFondos.Count != 0)
            {
                foreach (EscenarioFondo item in miListaFondos)
                {
                    //Si encuentra un id repetido lo actualiza
                    if (string.Equals(item.identificador, id, StringComparison.OrdinalIgnoreCase))
                    {
                        item.ruta = ruta;
                        encontrado = true;
                        break;
                    }
                }
                //Si no encuentra ningun id repetido lo agrega
                if (encontrado == false) {
                    miListaFondos.Add(new EscenarioFondo(id, ruta));
                    agregarTokensATablaSimbolos(id, Convert.ToInt16(pos1[0]), Convert.ToInt16(pos1[1]), "background");
                    agregarTokensATablaSimbolos(ruta, Convert.ToInt16(pos2[0]), Convert.ToInt16(pos2[1]), "ruta");
                }

            }
            else
            {
                miListaFondos.Add(new EscenarioFondo(id, ruta));
            }

        }

        private static void agregarTokensATablaSimbolos(String lexema, int fila, int columna, String tipo)
        {
            if (tipo == "background") {
                TablaDeSimbolos.Add(new Token_(tipo, lexema, "", fila, columna));
            } else if (tipo == "ruta") {
                //TablaDeSimbolos.Add(new Token_(tipo, lexema, "", fila, columna));
            }
        }

        //Metodo que agrega heroes y enemigos
        private static void agregarPersonajes(String lista, ParseTreeNode root)
        {
            String nombre = "";
            String vida = "";
            String imagen = "";
            String tipoPersonaje = "";
            String descripcion = "";
            String destruir = "";
            int vidaActual=0;
            int destruirActual = 0;

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
                //Me quede aqui 
                else if (string.Equals(tipo[0], "vida", StringComparison.OrdinalIgnoreCase))
                {
                    vida = valor[0];
                    vidaActual = Convert.ToInt32(vida);
                    if (vidaActual <= 0) {
                        Console.WriteLine("Semantico La vida es " + vidaActual + " y se ha cambiado a 1");
                        vidaActual = 1;
                    } else if (vidaActual > 100) {
                        Console.WriteLine("Semantico La vida es mayor " + vidaActual + " y se ha cambiado a 100");
                        vidaActual = 100;
                    }

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
                    destruirActual = Convert.ToInt32(destruir);
                    if (destruirActual > 100) {
                        Console.WriteLine("Semantico La destruccion es mayor " + destruirActual + " y se ha cambiado a 100");
                        destruirActual = 100;
                    }
                    else if (destruirActual <= 0) {
                        Console.WriteLine("Semantico La destruccion es menor o igual a 0 " + destruirActual + " y se ha cambiado a 1");
                        destruirActual = 1;
                    }
                }
            }

            if (descripcion == "")
            {
                Console.WriteLine("Se le ha agregado descripcion al personaje " + nombre);
                descripcion = "Personaje con las caracteristicas de......";
            }

            if (string.Equals(tipoPersonaje, "heroe", StringComparison.OrdinalIgnoreCase))
            {
                if (milistaHeroes.Count != 0)
                {
                    buscarPersonaje(tipoPersonaje, nombre, vidaActual, imagen, descripcion, destruirActual);
                }
                else
                {
                    milistaHeroes.Add(new Personaje(nombre, vidaActual, imagen, tipoPersonaje, destruirActual, descripcion));
                }
            }
            else if (string.Equals(tipoPersonaje, "enemigo", StringComparison.OrdinalIgnoreCase))
            {

                if (milistaEnemigos.Count != 0)
                {
                    buscarPersonaje(tipoPersonaje, nombre, vidaActual, imagen, descripcion, destruirActual);
                }
                else
                {
                    milistaEnemigos.Add(new Personaje(nombre, vidaActual, imagen, tipoPersonaje, destruirActual, descripcion));
                }
            }
            else {
                Console.WriteLine("Semantico, Tipo incorrecto");
            }
        }

        public static bool buscarPersonaje(String tipo, String id, int vida, String imagen, String descripcion, int destruir) {

            if (string.Equals(tipo, "heroe", StringComparison.OrdinalIgnoreCase))
            {
                foreach (Personaje item in milistaHeroes)
                {
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

                milistaHeroes.Add(new Personaje(id, vida, imagen, tipo, destruir, descripcion));
                return true;

            }
            else if (string.Equals(tipo, "enemigo", StringComparison.OrdinalIgnoreCase))
            {
                foreach (Personaje item in milistaEnemigos)
                {
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

                milistaEnemigos.Add(new Personaje(id, vida, imagen, tipo, destruir, descripcion));
                return true;
            }
            else {
                Console.WriteLine("Tipo incorrecto");
                return false;
            }
        }

        public static void actualizarDatosPersonajes(int vida, String nombre, String imagen, String descripcion, int ptosDestruir, Personaje item, String tipo) {
            if (vida != 0) {
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

        public static Boolean agregarObjetosDeEscenario(String objetos){
            String[] atributoDesign= splitPtoYcoma(objetos);
            String nombre="";
            String ptosDestruccion="";
            String ruta="";
            String tipo="";
            String bonus="";
            int ptosDestruccionActual = 0;
            int bonusActual = 0;

            for (int i =0; i<atributoDesign.Length; i++) {
                String[] tipos = splitComa(atributoDesign[i]);
                String[] token = splitEspacio(tipos[0]);
                if (tipos.Length > 1) {
                    String[] valor = splitEspacio(tipos[1]);
                    if (string.Equals(token[0], "nombre", StringComparison.OrdinalIgnoreCase))
                    {
                        nombre = valor[0];
                    }
                    else if (string.Equals(token[0], "destruir", StringComparison.OrdinalIgnoreCase))
                    {
                        ptosDestruccion = valor[0];
                        if (ptosDestruccion == "") {
                            ptosDestruccion = "0";
                        }
                    }
                    else if (string.Equals(token[0], "imagen", StringComparison.OrdinalIgnoreCase))
                    {
                        ruta = valor[0];
                    }
                    else if (string.Equals(token[0], "tipo", StringComparison.OrdinalIgnoreCase) || string.Equals(token[1], "tipo", StringComparison.OrdinalIgnoreCase))
                    {
                        tipo = valor[0];
                    }
                    else if (string.Equals(token[0], "creditos", StringComparison.OrdinalIgnoreCase))
                    {
                        bonus = valor[0];
                        if (bonus == "")
                        {
                            bonus = "0";
                        }
                    }
                }
                
            }

            if (ptosDestruccion != "") {
                if (Convert.ToInt32(ptosDestruccion) <= 0)
                {
                    Console.WriteLine("Semantico La destruccion total del objeto es negativo o 0 y se ha cambiado a 1");
                    ptosDestruccionActual = 1;
                }
                else if (Convert.ToInt32(ptosDestruccion) > 100)
                {
                    Console.WriteLine("Semantico La destruccion total del arma es mayor a 100 y se ha cambiado a 100");
                    ptosDestruccionActual = 100;
                }
                else {
                    ptosDestruccionActual = Convert.ToInt32(ptosDestruccion);
                }
            }

            if (bonus != "")
            {
                if (Convert.ToInt32(bonus) <= 0)
                {
                    Console.WriteLine("Semantico La destruccion total del objeto es negativo o 0 y se ha cambiado a 1");
                    bonusActual = 1;
                }
                else if (Convert.ToInt32(bonus) > 100)
                {
                    Console.WriteLine("Semantico La destruccion total del arma es mayor a 100 y se ha cambiado a 100");
                    bonusActual = 100;
                }
                else
                {
                    bonusActual = Convert.ToInt32(bonus);
                }
            }


            if (miListaObjetos.Count > 0)
            {
                foreach (ObjetoEscenario item in miListaObjetos) {
                    if (string.Equals(item.nombre, nombre, StringComparison.OrdinalIgnoreCase)) {
                        if (string.Equals(item.tipo, tipo, StringComparison.OrdinalIgnoreCase))
                        {
                            //Si existe un identificador con el mismo tipo, lo actualiza
                            actualizarObjetosEscenario(nombre, ptosDestruccionActual, ruta, tipo, Convert.ToInt32(bonusActual), item);
                            return true;
                        }
                    }
                }

                //Si no existe el nombre lo crea
                miListaObjetos.Add(new ObjetoEscenario(nombre, ptosDestruccionActual, ruta, tipo, Convert.ToInt32(bonusActual)));
                return true;

            }
            else
            {
                miListaObjetos.Add(new ObjetoEscenario(nombre, ptosDestruccionActual, ruta, tipo, Convert.ToInt32(bonusActual)));
                return true;
            }
        }
        
        public static void actualizarObjetosEscenario(String nombre, int ptosDestruccion, String ruta, String tipo, int bonus, ObjetoEscenario item)
        {
            
            if (string.Equals(item.tipo, "bomba", StringComparison.OrdinalIgnoreCase) || string.Equals(item.tipo, "arma", StringComparison.OrdinalIgnoreCase))
            {
                item.creditos = 0;
                if (ptosDestruccion != 0) {
                    item.ptosDestruccion = ptosDestruccion;
                }

                if (ruta != "") {
                    item.rutaImagen = ruta;
                }
            }
            else if (string.Equals(item.tipo, "bonus", StringComparison.OrdinalIgnoreCase))
            {
                item.ptosDestruccion = 0;
                if (ruta != "") {
                    item.rutaImagen = ruta;
                }
                if (bonus != 0) {
                    item.creditos = bonus;
                }

            }
            else if (string.Equals(item.tipo, "meta", StringComparison.OrdinalIgnoreCase) || string.Equals(item.tipo, "bloque", StringComparison.OrdinalIgnoreCase))
            {
                item.creditos = 0;
                item.ptosDestruccion = 0;
                if (ruta != "") {
                    item.rutaImagen = ruta;
                }
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
