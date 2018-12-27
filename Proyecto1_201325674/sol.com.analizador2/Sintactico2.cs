using Irony.Parsing;
using Proyecto1_201325674.sol.com.controlDot2;
using Proyecto1_201325674.sol.com.objetosConfiguracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.analizador2
{
    class Sintactico2
    {
        public static List<Error> listaErroresSintacticos2 = new List<Error>();
        public ParseTreeNode analyze(String text)
        {

            Gramatica2 myGrammar = new Gramatica2();
            LanguageData lenguaje = new LanguageData(myGrammar);
            Parser p = new Parser(lenguaje);
            ParseTree tree = p.Parse(text);
            ParseTreeNode root = tree.Root;
            if (root != null)
            {
                generarImagen(root);
                listaErroresSintacticos2 = new List<Error>();
                for (int i = 0; i < tree.ParserMessages.Count(); i++)
                {
                    String texto = tree.ParserMessages[i].Message;
                    String tipo = texto.Substring(0, 7);
                    if (tipo == "Invalid")
                    {
                        listaErroresSintacticos2.Add(new Error("Lexico", tree.ParserMessages[i].Message + "Linea, " + (Convert.ToInt32(tree.ParserMessages[i].Location.Line) + 1) + "; columna," + (Convert.ToInt32(tree.ParserMessages[i].Location.Column) + 1)));
                    }
                    else
                    {
                        listaErroresSintacticos2.Add(new Error("Sintactico", tree.ParserMessages[i].Message + "Linea, " + (Convert.ToInt32(tree.ParserMessages[i].Location.Line) + 1) + "; columna," + (Convert.ToInt32(tree.ParserMessages[i].Location.Column + 1))));
                    }
                    //Console.WriteLine(tree.ParserMessages[i].Message + "Linea, " + tree.ParserMessages[0].Location.Line + "; columna," + tree.ParserMessages[0].Location.Column);
                }
            }
            else
            {
                listaErroresSintacticos2 = new List<Error>();
                for (int i = 0; i < tree.ParserMessages.Count(); i++)
                {
                    String texto = tree.ParserMessages[i].Message;
                    String tipo = texto.Substring(0, 7);
                    if (tipo == "Invalid")
                    {
                        listaErroresSintacticos2.Add(new Error("Lexico", tree.ParserMessages[i].Message + "Linea, " + (Convert.ToInt32(tree.ParserMessages[i].Location.Line) + 1) + "; columna," + (Convert.ToInt32(tree.ParserMessages[i].Location.Column) + 1)));
                    }
                    else
                    {
                        listaErroresSintacticos2.Add(new Error("Sintactico", tree.ParserMessages[i].Message + "Linea, " + (Convert.ToInt32(tree.ParserMessages[i].Location.Line) + 1) + "; columna," + (Convert.ToInt32(tree.ParserMessages[i].Location.Column + 1))));
                    }
                    //Console.WriteLine(tree.ParserMessages[i].Message + "Linea, " + tree.ParserMessages[0].Location.Line + "; columna," + tree.ParserMessages[0].Location.Column);
                }
            }

            return root;
        }

        public static void generarImagen(ParseTreeNode raiz)
        {
            String grafoDot = ControlDot2.getDot(raiz);
            //Console.WriteLine(grafoDot);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDot);
            img.Save("AST2.png");
        }
    }
}
