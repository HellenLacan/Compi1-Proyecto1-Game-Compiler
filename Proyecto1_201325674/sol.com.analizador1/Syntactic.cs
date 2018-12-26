using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using Practica1.sol.com.analizador;
using Practica1.sol.com.controlDot;

namespace Practica1.sol.com.analyzer
{
    class Syntactic : Grammar
    {
        public ParseTreeNode analyze(String text) {

            Gramatica myGrammar = new Gramatica();
            LanguageData lenguaje = new LanguageData(myGrammar);
            Parser p = new Parser(lenguaje);
            ParseTree tree = p.Parse(text);
            ParseTreeNode root = tree.Root;
            if (root != null)
            {
                generarImagen(root);
            }
            else {
                if (tree.Status == ParseTreeStatus.Error)
                {
                    if (tree.ParserMessages.Count >= 0) {
                        Console.WriteLine(tree.ParserMessages[0].Message + "Linea, " + tree.ParserMessages[0].Location.Line + "; columna,"+tree.ParserMessages[0].Location.Column);
                    }                    
                }


            }
            return root;

        }

        public static String generarImagen(ParseTreeNode raiz) {
            String grafoDot = ControlDot.getDot(raiz);
            //Console.WriteLine(grafoDot);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDot);
            img.Save("AST.png");
            return grafoDot;
        }
    }
}
