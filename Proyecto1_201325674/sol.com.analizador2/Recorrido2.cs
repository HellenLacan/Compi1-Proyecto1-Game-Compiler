using Irony.Parsing;
using Practica1.sol.com.analyzer;
using Proyecto1_201325674.sol.com.archivoConfiguracion;
using Proyecto1_201325674.sol.com.estructuraEscenario;
using Proyecto1_201325674.sol.com.objetosConfiguracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.analizador2
{
    class Recorrido2
    {
        //null no hay pared, 1 pared, 2 heroe, 3 meta, 4 enemigos, 5 bonus, 6 bomba, 7 arma
        public static List<SuperEscenario> milistaObjetosEscenario = new List<SuperEscenario>();
        public static SuperEscenario[,] matrizLogica = null;

        public static int getAnchoEscenario() {
            int ancho=0;
            foreach (SuperEscenario item in milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "background", StringComparison.OrdinalIgnoreCase))
                {
                     ancho = item.ancho + 1;
                }
            }
            return ancho;
        }

        public static int getAltoEscenario()
        {
            int alto = 0;
            foreach (SuperEscenario item in milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "background", StringComparison.OrdinalIgnoreCase))
                {
                    alto = item.alto + 1;
                }
            }
            return alto;
        }

        public static SuperEscenario[,] cargarMatrizLogica() {
            int ancho = 0;
            int alto = 0;

            foreach (SuperEscenario item in milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "background", StringComparison.OrdinalIgnoreCase))
                {
                    alto = item.alto + 1;
                    ancho = item.ancho + 1;
                    matrizLogica = new SuperEscenario[alto, ancho];
                }
            }
            //1 bloque 
            foreach (SuperEscenario item in milistaObjetosEscenario) {
                if (string.Equals(item.tipo, "bloque", StringComparison.OrdinalIgnoreCase))
                {
                    if (item.posIniX == item.posFinX && item.posIniY == item.posFinY)
                    {
                        if (item.posIniX < alto)
                        {
                            if (item.posIniY < ancho)
                            {
                                if (validarPosicionEnMatrizLogica(item.posIniX, item.posIniY))
                                {
                                    item.tipoObjeto = 1;
                                    matrizLogica[item.posIniX, item.posIniY] = item;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Semantico, posicion en Y se sale de la dimension");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Semantico, posicion en X se sale de la dimension");
                        }
                    }
                    else if (item.posIniX == item.posFinX && item.posIniY != item.posFinY)
                    {
                        for (int i = item.posIniY; i < item.posFinY+1; i++)
                        {
                            if (item.posIniX < alto && item.posIniX > -1)
                            {
                                if (item.posIniY > -1 && item.posFinY <= ancho)
                                {
                                    if (validarPosicionEnMatrizLogica(item.posIniX, i))
                                    {
                                        item.tipoObjeto = 1;
                                        matrizLogica[item.posIniX, i] = item;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Semantico, posicion en Y se sale de la dimension");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Semantico, posicion en X se sale de la dimension");
                            }
                        }

                    }
                    else if (item.posIniX != item.posFinX && item.posIniY == item.posFinY)
                    {
                        for (int i = item.posIniX; i < item.posFinX+1; i++)
                        {
                            if (item.posIniX >= 0 && item.posFinX < alto)
                            {
                                if (item.posIniY >= 0 && item.posIniY < ancho)
                                {
                                    if (validarPosicionEnMatrizLogica(i, item.posIniY))
                                    {
                                        item.tipoObjeto = 1;
                                        matrizLogica[i, item.posIniY] = item;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Semantico, posicion en Y se sale de la dimension " + "(" + "," + ")");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Semantico, posicion en X se sale de la dimension");
                            }
                        }

                    }
                }
                else if (string.Equals(item.tipo, "meta", StringComparison.OrdinalIgnoreCase))
                {
                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        if (validarPosicionEnMatrizLogica(item.posIniX, item.posIniY))
                        {
                            item.tipoObjeto = 3;
                            matrizLogica[item.posIniX, item.posIniY] = item;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Semantico, +" + item.objeto + " meta se sale del tablero");
                    }
                }
                else if (string.Equals(item.tipo, "enemigo", StringComparison.OrdinalIgnoreCase))
                {
                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        if (validarPosicionEnMatrizLogica(item.posIniX, item.posIniY))
                        {
                            item.tipoObjeto = 4;
                            matrizLogica[item.posIniX, item.posIniY] = item;
                        }
         
                    }
                    else
                    {
                        Console.WriteLine("Semantico, enemigo se sale del tablero");
                    }
                }
                else if (string.Equals(item.tipo, "bonus", StringComparison.OrdinalIgnoreCase))
                {
                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        if (validarPosicionEnMatrizLogica(item.posIniX, item.posIniY)) {
                            item.tipoObjeto = 5;
                            matrizLogica[item.posIniX, item.posIniY] = item;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Semantico, bonus se sale del tablero");
                    }
                }
                else if (string.Equals(item.tipo, "bomba", StringComparison.OrdinalIgnoreCase))
                {
                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        if (validarPosicionEnMatrizLogica(item.posIniX, item.posIniY))
                        {
                            item.tipoObjeto = 6;
                            matrizLogica[item.posIniX, item.posIniY] = item;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Semantico, bomba se sale del tablero");
                    }
                }
                else if (string.Equals(item.tipo, "arma", StringComparison.OrdinalIgnoreCase))
                {
                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        if (validarPosicionEnMatrizLogica(item.posIniX, item.posIniY)) {
                            item.tipoObjeto = 7;
                            matrizLogica[item.posIniX, item.posIniY] = item;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Semantico, bomba se sale del tablero");
                    }
                }
                else
                {
                    Console.WriteLine(item.tipo + "no se agrego al tablero");
                }
            }
            return matrizLogica;
        }

        public static Boolean validarPosicionEnMatrizLogica(int posX, int posY) {
            if (matrizLogica[posX, posY] == null)
            {
                return true;
            }
            else {
                Console.WriteLine( "Semantico, casilla ya ocupada" + posX + "," + posY);
                return false;
            }
        }

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
                    almacenarFondo("background", root.ChildNodes.ElementAt(2).ToString() , ancho, alto);
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
                    almacenarHeroes("heroe;" + heroes);
                    //Console.WriteLine("heroe;" + heroes);
                    return "heroe;" + heroes;

                case "VILLANOS":
                    String villano = "";
                    villano += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarVillanos("villano;" + villano);
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
                    almacenarObjetosDeDisenio("arma;" + extras);
                    return "arma;" + extras;

                case "BONUS":
                    extras = "";
                    extras += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarObjetosDeDisenio("bonus;" + extras);
                    return "bonus;" + extras;

                case "META":
                    extras = "";
                    extras += recorrerAST2(root.ChildNodes.ElementAt(0));
                    almacenarObjetosDeDisenio("meta;" + extras);
                    return "meta;" + extras;

                case "PAREDES":
                    String paredes = recorrerAST2(root.ChildNodes.ElementAt(0));
                    break;

                case "LISTA_PAREDES":
                    String atribListaParedes ="";
                    String listaParedes;
                    switch (root.ChildNodes.Count) {
                        case 1:
                            atribListaParedes = recorrerAST2(root.ChildNodes.ElementAt(0));
                            break;
                        case 2:
                            listaParedes = recorrerAST2(root.ChildNodes.ElementAt(0));
                            atribListaParedes = recorrerAST2(root.ChildNodes.ElementAt(1));
                            break;
                    }
                    break;

                case "ATRIBUTOS_LISTA_PAREDES":
                    String id = root.ChildNodes.ElementAt(0).ToString();
                    switch (root.ChildNodes.Count) {

                        case 3:
                            atribListaParedes = root.ChildNodes.ElementAt(0).ToString();
                            posX = recorrerAST2(root.ChildNodes.ElementAt(1));
                            posY = recorrerAST2(root.ChildNodes.ElementAt(2));
                            String atributosParedes = "id," + id + ";posXIni," + posX + ";posXFin," + posX +
                                                         ";posYIni," + posY + ";posYFin," + posY;
                            almacenarParedes(atributosParedes);
                            return atributosParedes;

                        case 6:
                            id = root.ChildNodes.ElementAt(0).ToString();
                            //id(2..10,8);
                            if (root.ChildNodes.ElementAt(1).Term.Name == "EXPRESION" && root.ChildNodes.ElementAt(4).Term.Name == "EXPRESION"
                                && root.ChildNodes.ElementAt(5).Term.Name == "EXPRESION") {
                                String posXIni = recorrerAST2(root.ChildNodes.ElementAt(1));
                                String posXFin = recorrerAST2(root.ChildNodes.ElementAt(4));
                                String posYIni = recorrerAST2(root.ChildNodes.ElementAt(5));
                                String posYFin = recorrerAST2(root.ChildNodes.ElementAt(5));
                                atributosParedes = "id," + id + ";posXIni," + posXIni + ";posXFin," + posXFin+
                                                          ";posYIni," + posYIni + ";posYFin," + posYFin;
                                almacenarParedes(atributosParedes);
                                return atributosParedes;
                            }
                            //id(8,3..5)
                            else if (root.ChildNodes.ElementAt(1).Term.Name == "EXPRESION" && root.ChildNodes.ElementAt(2).Term.Name == "EXPRESION"
                                && root.ChildNodes.ElementAt(5).Term.Name == "EXPRESION") {
                                String posXIni = recorrerAST2(root.ChildNodes.ElementAt(1));
                                String posXFin = recorrerAST2(root.ChildNodes.ElementAt(1));
                                String posYIni = recorrerAST2(root.ChildNodes.ElementAt(2));
                                String posYFin = recorrerAST2(root.ChildNodes.ElementAt(5));
                                atributosParedes = "id," + id + ";posXIni," + posXIni + ";posXFin," + posXFin +
                                                          ";posYIni," + posYIni + ";posYFin," + posYFin;
                                almacenarParedes(atributosParedes);
                                return atributosParedes;
                            }
                            break;
                    }
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

        private static void almacenarHeroes(String listaPersonaje) {
            String posXIni ="";
            String posYIni = "";
            String[] lista = spliArroba(listaPersonaje);
            for (int i = 1; i < lista.Length; i++)
            {
                String[] token = splitPtoYcoma(lista[i]);
                String[] identificador = splitComa(token[0]);

                String[] posX = splitComa(token[1]);
                String[] posY = splitComa(token[2]);
                String[] id = splitEspacio(identificador[1]);
                posXIni = posX[1];
                posYIni = posY[1];

                Personaje heroe = verificarSiExistePersonaje("heroe", id[0]);

                //Agregando heroes a la super lista, para cargar el escenario
                if (heroe != null)
                {
                    milistaObjetosEscenario.Add(new SuperEscenario("heroe",heroe, Convert.ToInt32(posXIni), Convert.ToInt32(posXIni), Convert.ToInt32(posYIni), Convert.ToInt32(posYIni)));
                    Console.WriteLine("heroe id => " + id[0] + " agregado a la lista super");
                }
                else {
                    Console.WriteLine("Sematico, no existe heroe con el id =>" + id[0]);
                }
            }
        }

        private static void almacenarVillanos(String listaPersonaje)
        {
            String posXIni = "";
            String posYIni = "";
            String[] lista = spliArroba(listaPersonaje);
            for (int i = 1; i < lista.Length; i++)
            {
                String[] token = splitPtoYcoma(lista[i]);
                String[] identificador = splitComa(token[0]);
                    String[] posX = splitComa(token[1]);
                    String[] posY = splitComa(token[2]);
                    String[]id = splitEspacio(identificador[1]);
                    posXIni = posX[1];
                    posYIni = posY[1];

                Personaje enemigo= verificarSiExistePersonaje("enemigo", id[0]);
                if (enemigo != null)
                {
                    milistaObjetosEscenario.Add(new SuperEscenario("enemigo", enemigo, Convert.ToInt32(posXIni), Convert.ToInt32(posXIni), Convert.ToInt32(posYIni), Convert.ToInt32(posYIni)));
                    Console.WriteLine(" enemigo con id => " + id[0] + " agregado a la lista super");
                }
                else {
                    Console.WriteLine(" enemigo con id => " + id[0] + " No existe");
                }
            }
        }

        public static void almacenarParedes(String listaParedes) {
            String id="";
            String posXIni="";
            String posXFin="";
            String posYIni="";
            String posYFin="";

            String[] lista = splitPtoYcoma(listaParedes);

            for (int i =0; i< lista.Length; i++) {
                String[] token = splitComa(lista[i]);
                if (token[0] == "id") {
                    id = token[1];
                } else if (token[0] == "posXIni") {
                    posXIni = token[1];
                } else if (token[0] == "posXFin") {
                    posXFin = token[1];
                } else if (token[0] == "posYIni") {
                    posYIni = token[1];
                } else if (token[0] == "posYFin") {
                    posYFin = token[1];
                }
            }
            String[] identificador = splitEspacio(id);
            ObjetoEscenario objeto = verificarSiExisteObjeto("bloque", identificador[0]);

            if (objeto != null)
            {
                milistaObjetosEscenario.Add(new SuperEscenario("bloque", objeto, Convert.ToInt32(posXIni), Convert.ToInt32(posXFin), Convert.ToInt32(posYIni), Convert.ToInt32(posYFin)));
                Console.WriteLine(" bloque con id => " + identificador[0] + " agregado a la lista super");
            }
            else
            {
                Console.WriteLine(" bloque con id => " + identificador[0] + " No existe");
            }

            //Console.WriteLine(id + " => posXIni, " + posXIni + ";posXFin, " + posXFin +" ;posYIni, " + posYIni +"; posYFin " + posYFin);
        }

        private static void almacenarObjetosDeDisenio(String listaPersonaje)
        {
            String posXIni = "";
            String posYIni = "";
            String[] lista = spliArroba(listaPersonaje);
            String[] tipo = splitPtoYcoma(lista[0]);
            for (int i = 1; i < lista.Length; i++)
            {
                String[] token = splitPtoYcoma(lista[i]);
                String[] identificador = splitComa(token[0]);

                String[] posX = splitComa(token[1]);
                String[] posY = splitComa(token[2]);
                String[] id = splitEspacio(identificador[1]);
                posXIni = posX[1];
                posYIni = posY[1];

                ObjetoEscenario objeto = verificarSiExisteObjeto(tipo[0], id[0]);

                //Agregando heroes a la super lista, para cargar el escenario
                if (objeto != null)
                {
                    milistaObjetosEscenario.Add(new SuperEscenario(objeto.tipo, objeto , Convert.ToInt32(posXIni), Convert.ToInt32(posXIni), Convert.ToInt32(posYIni), Convert.ToInt32(posYIni)));
                    Console.WriteLine("<design> id => " + id[0] + " agregado a la lista super");
                }
                else
                {
                    Console.WriteLine("Sematico, no existe arma con el id =>" + id[0]);
                }
            }
        }

        public static void almacenarFondo(String tipo, String nombre, String ancho, String alto) {
            String[] fondo = splitEspacio(nombre);
            Boolean encontrado = false;
            EscenarioFondo escenario = null;
            if (string.Equals(tipo, "background", StringComparison.OrdinalIgnoreCase))
            {
                foreach (EscenarioFondo item in Recorrido1.miListaFondos) {
                    if (string.Equals(item.identificador, fondo[0], StringComparison.OrdinalIgnoreCase)) {
                        encontrado = true;
                        escenario = item;
                        break;
                    }
                }

                if (encontrado == true)
                {
                    if (Convert.ToInt32(ancho) == Convert.ToInt32(alto))
                    {
                        milistaObjetosEscenario.Add(new SuperEscenario(tipo, escenario, Convert.ToInt32(ancho), Convert.ToInt32(alto)));
                        Console.WriteLine("Fondo id => " + nombre + " agregado a la lista super");
                    }
                    else if (Convert.ToInt32(ancho) > Convert.ToInt32(alto))
                    {
                        milistaObjetosEscenario.Add(new SuperEscenario(tipo, escenario, Convert.ToInt32(ancho), Convert.ToInt32(ancho)));
                        Console.WriteLine("Fondo id => " + nombre + " agregado a la lista super");
                        Console.WriteLine("Semantico, no es n x n alto es menor que ancho.. alto = ancho");
                    }
                    else if (Convert.ToInt32(ancho) < Convert.ToInt32(alto))
                    {
                        milistaObjetosEscenario.Add(new SuperEscenario(tipo, escenario, Convert.ToInt32(alto), Convert.ToInt32(alto)));
                        Console.WriteLine("Fondo id => " + nombre + " agregado a la lista super");
                        Console.WriteLine("Semantico, no es nxn ancho es menor que alto, ahora ancho=alto");
                    }
                }
                else {
                    Console.WriteLine("Sematico, no existe fondo con el id =>" + fondo[0]);
                }
            }
        }

        public static ObjetoEscenario verificarSiExisteObjeto(String tipo, String id) {
            if (string.Equals(tipo, "bloque", StringComparison.OrdinalIgnoreCase))
            {
                foreach (ObjetoEscenario item in Recorrido1.miListaObjetos)
                {
                    if (string.Equals(item.nombre, id, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
            }else if (string.Equals(tipo, "arma", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(tipo, "bomba", StringComparison.OrdinalIgnoreCase))
            {
                foreach (ObjetoEscenario item in Recorrido1.miListaObjetos)
                {
                    if (string.Equals(item.nombre, id, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
            }else if (string.Equals(tipo, "bonus", StringComparison.OrdinalIgnoreCase))
            {
                foreach (ObjetoEscenario item in Recorrido1.miListaObjetos)
                {
                    if (string.Equals(item.nombre, id, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
            } else if (string.Equals(tipo, "meta", StringComparison.OrdinalIgnoreCase))
            {
                foreach (ObjetoEscenario item in Recorrido1.miListaObjetos)
                {
                    if (string.Equals(item.nombre, id, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public static Personaje verificarSiExistePersonaje(String tipo, String id)
        {
            if (string.Equals(tipo, "heroe", StringComparison.OrdinalIgnoreCase))
            {
                foreach (Personaje item in Recorrido1.milistaHeroes)
                {
                    if (string.Equals(item.nombre, id, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
            }
            else if (string.Equals(tipo, "enemigo", StringComparison.OrdinalIgnoreCase))
            {
                foreach (Personaje item in Recorrido1.milistaEnemigos)
                {
                    if (string.Equals(item.nombre, id, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
            }

            return null;
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