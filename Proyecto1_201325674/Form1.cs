using Irony.Parsing;
using Practica1.sol.com.analyzer;
using Proyecto1_201325674.sol.com.analizador2;
using Proyecto1_201325674.sol.com.archivoConfiguracion;
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
                richTextBox2.Text = "";
                Recorrido1.recorrerAST1(resultado.ChildNodes.ElementAt(0));
                //getRichTextBox2().Text = lenguaje;
                //Recorrido.traducir(resultado);
                text += "          *****FONDOS DEL JUEGO*****\n";
                foreach (EscenarioFondo item in Recorrido1.miListaFondos) {
                    text += "Nombre: " + item.identificador + "   ,   " + "Ruta: " + item.ruta + "\n";
                }

                text += "\n          *****HEROES Y ENEMIGOS DEL JUEGO*****\n";
                foreach (Personaje item in Recorrido1.miListaPersonajes)
                {
                    text += "Nombre: " + item.nombre + "   ,   " + " vida: " + item.vida + " tipo: " + item.tipo + " destruir: " + item.ptosDestruccion +
                            " path: " + item.rutaImagen +  "\n";
                }

                richTextBox2.Text = text;
            }
            else
            {
                MessageBox.Show("Analisis con errores");

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

            }
        }
    }
}
