using Irony.Parsing;
using Proyecto1_201325674.sol.com.controlDot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.analizador2
{
    class Sintactico2
    {
        public ParseTreeNode analyze(String text)
        {

            Gramatica2 myGrammar = new Gramatica2();
            LanguageData lenguaje = new LanguageData(myGrammar);
            Parser p = new Parser(lenguaje);
            ParseTree tree = p.Parse(text);
            ParseTreeNode root = tree.Root;
            if (root!=null) {
                generarImagen(root);
            }
            return root;
        }

        public static void generarImagen(ParseTreeNode raiz)
        {
            String grafoDot = ControlDot2.getDot(raiz);
            Console.WriteLine(grafoDot);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDot);
            img.Save("AST2.png");
        }
    }
}
