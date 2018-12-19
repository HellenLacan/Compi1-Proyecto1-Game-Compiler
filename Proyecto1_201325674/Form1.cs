using Irony.Parsing;
using Practica1.sol.com.analyzer;
using Proyecto1_201325674.sol.com.analizador2;
using Proyecto1_201325674.sol.com.archivoConfiguracion;
using Proyecto1_201325674.sol.com.estructuraEscenario;
using Proyecto1_201325674.sol.com.objetosConfiguracion;
using Proyecto1_201325674.Ventana;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201325674
{
    public partial class Form1 : Form
    {
        int[,] matrizLogica = null;
        public String archivo1, archivo2;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("C:/Users/Hellen/Documents/Cursos/COMPI1_VACAS_DIC_2018/Proyecto1_201325674/PruebaArchivoEntrada1.txt"))
            {
                archivo1 = reader.ReadToEnd();
            }
            Syntactic mySyntactic = new Syntactic();
            //bool resultado = mySyntactic.analyze(getRichTextBox().Text);
            ParseTreeNode resultado = mySyntactic.analyze(archivo1);

            if (resultado != null)
            {
                MessageBox.Show("Analisis correcto");
                String text = "";
                richTextBox2.Text = "";
                Recorrido1.recorrerAST1(resultado.ChildNodes.ElementAt(0));

                text += "          *****FONDOS DEL JUEGO*****\n";
                foreach (EscenarioFondo item in Recorrido1.miListaFondos)
                {
                    text += "Nombre: " + item.identificador + "   ,   " + "Ruta: " + item.ruta + "\n";
                }

                text += "\n          *****HEROES DEL JUEGO*****\n";
                foreach (Personaje item in Recorrido1.milistaHeroes)
                {
                    text += "Nombre: " + item.nombre + "   ,   " + " vida: " + item.vida + " tipo: " + item.tipo + ", destruir: " + item.ptosDestruccion +
                            " path: " + item.rutaImagen + "\n";
                }

                text += "\n          *****ENEMIGOS DEL JUEGO*****\n";
                foreach (Personaje item in Recorrido1.milistaEnemigos)
                {
                    text += "Nombre: " + item.nombre + "   ,   " + " vida: " + item.vida + " tipo: " + item.tipo + ", destruir: " + item.ptosDestruccion +
                            " path: " + item.rutaImagen + "\n";
                }

                text += "\n          *****OBJETOS *****\n";
                foreach (ObjetoEscenario item in Recorrido1.miListaObjetos)
                {
                    text += "Nombre: " + item.nombre + "   ,   " + " ptosDestruccion: " + item.ptosDestruccion + ", tipo: " + item.tipo + " creditos: " + item.creditos +
                            " path: " + item.rutaImagen + "\n";
                }

                richTextBox2.Text = text;
            }
            else
            {
                MessageBox.Show("Analisis incorrecto");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("C:/Users/Hellen/Documents/Cursos/COMPI1_VACAS_DIC_2018/Proyecto1_201325674/PruebaArchivoEntrada2.txt"))
            {
                archivo2 = reader.ReadToEnd();
            }

            //Console.WriteLine(!(true || false));
            Sintactico2 mySyntactic = new Sintactico2();
            //bool resultado = mySyntactic.analyze(getRichTextBox().Text);
            ParseTreeNode resultado = mySyntactic.analyze(archivo2);

            if (resultado != null)
            {
                MessageBox.Show("Analisis correcto");
                Syntactic.generarImagen(resultado);
                Recorrido2.recorrerAST2(resultado.ChildNodes.ElementAt(0));
            }
            else
            {
                MessageBox.Show("Analisis incorrecto");

            }
        }

        int personajeSelect = -1;
        //Boton Anterior heroes
        private void button3_Click(object sender, EventArgs e)
        {
            if (personajeSelect == -1)
            {
                personajeSelect = 0;
                pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
            }
            else if (personajeSelect >= 0)
            {
                personajeSelect -= 1;
                pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
            }

            habilitarBotonesHeroes(personajeSelect);
        }

        //Boton Siguiente heroes
        private void button4_Click(object sender, EventArgs e)
        {
            if (personajeSelect == -1)
            {
                personajeSelect = 0;
                pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
            }
            else if (personajeSelect <= Recorrido1.milistaHeroes.Count - 1)
            {
                personajeSelect += 1;
                pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
            }

            habilitarBotonesHeroes(personajeSelect);

        }

        private void habilitarBotonesHeroes(int id)
        {
            if (id == 0 && (id != Recorrido1.milistaHeroes.Count - 1))
            {
                button3.Enabled = false;
                button4.Enabled = true;
            }
            else if (id != 0 && (id == Recorrido1.milistaHeroes.Count - 1))
            {
                button3.Enabled = true;
                button4.Enabled = false;

            }
            else
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SuperEscenario[,] matrizLogica = Recorrido2.cargarMatrizLogica();
            int ancho = 0;
            int alto = 0;

            foreach (SuperEscenario item in Recorrido2.milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "background", StringComparison.OrdinalIgnoreCase))
                {
                    ancho = item.ancho + 1;
                    alto = item.alto + 1;

                    Image image1 = Image.FromFile(item.fondo.ruta);

                    panelEscenario.BackgroundImage = image1;
                    panelEscenario.BackgroundImageLayout = ImageLayout.Stretch;

                }
            }

            Boton[,] matrizGrafica = new Boton[alto, ancho]; ;
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    Boton miBoton = new Boton(i, j);
                    matrizGrafica[i, j] = miBoton;
                    panelEscenario.Controls.Add(miBoton);
                }
            }

            //for (int i = 0; i < alto; i++) {
            //    for (int j = 0; j < ancho; j++) {
            //        PictureBox miBotoncito = new PictureBox();
            //        int tamanio = 25;
            //        miBotoncito.Left = i * tamanio;
            //        miBotoncito.Top = j * tamanio;
            //        miBotoncito.Width = tamanio;
            //        miBotoncito.Height = tamanio;
            //        if (matrizLogica[i, j] != null) {
            //            miBotoncito.Image = Image.FromFile(matrizLogica[i, j].objeto.rutaImagen);
            //            miBotoncito.SizeMode = PictureBoxSizeMode.StretchImage;
            //        }
            //        miBotoncito.BorderStyle = BorderStyle.FixedSingle;
            //        miBotoncito.BackColor = Color.Transparent;
            //        panelEscenario.Controls.Add(miBotoncito);
            //    }
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
