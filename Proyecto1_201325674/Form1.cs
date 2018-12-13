using Irony.Parsing;
using Practica1.sol.com.analyzer;
using Proyecto1_201325674.sol.com.analizador2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201325674
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(!(true || false));
            Syntactic mySyntactic = new Syntactic();
            //bool resultado = mySyntactic.analyze(getRichTextBox().Text);
            ParseTreeNode resultado = mySyntactic.analyze(richTextBox1.Text);

            if (resultado != null)
            {
                MessageBox.Show("Analisis Correcto");
                String text = "";
                //String lenguaje = (Recorrido.recorrerAST(resultado.ChildNodes.ElementAt(0), text));
                //getRichTextBox2().Text = lenguaje;
                //Recorrido.traducir(resultado);
                Syntactic.generarImagen(resultado);
            }
            else
            {
                MessageBox.Show("Analisis con errores");

                /*foreach (sol.com.analyzer.Token item in Syntactic.lista)
                {
                    richTextBox1.Text += "\nError " + item.tipo + ": Lexema: \"" + item.lexema + "\"" + ", Linea: " + item.fila + ", Columna: " + item.columna + ", Descripcion: " + item.descripcion;
                }*/

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(!(true || false));
            Sintactico2 mySyntactic = new Sintactico2();
            //bool resultado = mySyntactic.analyze(getRichTextBox().Text);
            ParseTreeNode resultado = mySyntactic.analyze(richTextBox1.Text);

            if (resultado != null)
            {
                MessageBox.Show("Analisis Correcto");
                String text = "";
                Syntactic.generarImagen(resultado);
            }
            else
            {
                MessageBox.Show("Analisis con errores");

                /*foreach (sol.com.analyzer.Token item in Syntactic.lista)
                {
                    richTextBox1.Text += "\nError " + item.tipo + ": Lexema: \"" + item.lexema + "\"" + ", Linea: " + item.fila + ", Columna: " + item.columna + ", Descripcion: " + item.descripcion;
                }*/

            }
        }
    }
}
