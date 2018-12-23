﻿using Irony.Parsing;
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
        SuperEscenario[,] matrizLogica = null;
        Boton[,] matrizGrafica = null;
        PictureBox principal = null;
        public String archivo1, archivo2;
        int posXHeroePrincipal = 0;
        int posYHeroePrincipal = 0;
        public Form1()
        {
            InitializeComponent();

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

                try
                {
                    pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }

            }
            else if (personajeSelect <= Recorrido1.milistaHeroes.Count - 1)
            {
                personajeSelect += 1;
                try
                {
                    pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }
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

        }

        private void ejecutarArchivoConfiguracionToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void compilarArchivoDeCargaEscenarioToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void EjecutarJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void ejecutarJuegoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.matrizLogica = Recorrido2.cargarMatrizLogica();
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

            matrizGrafica = new Boton[alto, ancho]; ;
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    Boton miBoton = new Boton(i, j);
                    matrizGrafica[i, j] = miBoton;
                    panelEscenario.Controls.Add(miBoton);

                }
            }

            //for (int i = 0; i < alto; i++)
            //{
            //    for (int j = 0; j < ancho; j++)
            //    {
            //        if (matrizLogica[i, j] != null)
            //        {
            //            if (matrizLogica[i, j].tipo == "heroe")
            //            {
            //                matrizGrafica[i, j].Focus();
            //            }
            //        }
            //    }
            //}

            foreach (SuperEscenario item in Recorrido2.milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "heroe", StringComparison.OrdinalIgnoreCase))
                {
                    int tamanio = 25;

                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        //item.tipoObjeto = 2;
                        //matrizLogica[item.posIniX, item.posIniY] = item;

                        posXHeroePrincipal = item.posIniX;
                        posYHeroePrincipal = item.posIniY;
                        principal = new PictureBox();
                        principal.Left = item.posIniX * tamanio;
                        principal.Top = item.posIniY * tamanio;
                        principal.Width = tamanio;
                        principal.Height = tamanio;

                        try
                        {
                            principal.Image = Image.FromFile(item.personaje.rutaImagen);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ruta no existe");
                            Console.WriteLine("IOException source: {0}", ex.Source);
                        }

                        principal.SizeMode = PictureBoxSizeMode.StretchImage;
                        principal.KeyDown += new KeyEventHandler(moverHeroePrincipal);
                        panelEscenario.Controls.Add(principal);
                        principal.BringToFront();
                        principal.Focus();

                    }
                    else
                    {
                        Console.WriteLine("Semantico, heroe se sale del tablero");
                    }
                }
            }
        }

        private void moverHeroePrincipal(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (posXHeroePrincipal != 0)
                    {
                        if (matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal] == null)
                        {
                            principal.Location = new Point(principal.Location.X - 25, principal.Location.Y);
                            posXHeroePrincipal--;
                            //Si es bomba
                        } else if (matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal].tipoObjeto == 6) {
                            agregarOquitarVida(posXHeroePrincipal - 1, posYHeroePrincipal, "izquierda", "bomba");
                        } //Si es arma
                        else if (matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal].tipoObjeto == 7)
                        {
                            agregarOquitarVida(posXHeroePrincipal - 1, posYHeroePrincipal, "izquierda", "arma");
                        } //Si es bonus
                        else if (matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal].tipoObjeto == 5)
                        {
                            agregarOquitarVida(posXHeroePrincipal - 1, posYHeroePrincipal, "izquierda", "bonus");
                        }
                    }
                    break;

                case Keys.Right:
                    if (posXHeroePrincipal + 1 < Recorrido2.getAltoEscenario())
                    {
                        if (matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal] == null)
                        {
                            posXHeroePrincipal++;
                            principal.Location = new Point(principal.Location.X + 25, principal.Location.Y);
                        }
                        //Si es bomba
                        else if (matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal].tipoObjeto == 6)
                        {
                            agregarOquitarVida(posXHeroePrincipal + 1, posYHeroePrincipal, "derecha", "bomba");
                        }//Si es arma
                        else if (matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal].tipoObjeto == 7)
                        {
                            agregarOquitarVida(posXHeroePrincipal + 1, posYHeroePrincipal, "derecha", "arma");
                        }//Si es bonus
                        else if (matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal].tipoObjeto == 5)
                        {
                            agregarOquitarVida(posXHeroePrincipal + 1, posYHeroePrincipal, "derecha", "bonus");
                        }
                    }

                    break;

                case Keys.Up:
                    if (posYHeroePrincipal != 0)
                    {
                        if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1] == null)
                        {
                            principal.Location = new Point(principal.Location.X, principal.Location.Y - 25);
                            posYHeroePrincipal--;
                        }//Si es bomba
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal -1].tipoObjeto == 6)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal -1, "arriba", "bomba");
                        }//Si es arma
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto == 7)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal - 1, "arriba", "arma");
                        }//Si es bonus
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto == 5)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal - 1, "arriba", "bonus");
                        }
                    }

                    break;

                case Keys.Down:
                    if (posYHeroePrincipal + 1 < Recorrido2.getAnchoEscenario())
                    {
                        if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1] == null)
                        {
                            principal.Location = new Point(principal.Location.X, principal.Location.Y + 25);
                            posYHeroePrincipal++;
                        }//Si es bomba
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal+1].tipoObjeto == 6)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal + 1, "abajo", "bomba");
                        }//Si es arma
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1].tipoObjeto == 7)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal + 1, "abajo", "arma");
                        }//Si es bonus
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1].tipoObjeto == 7)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal + 1, "abajo", "bonus");
                        }
                    }
                    break;
            }
        }

        public void agregarOquitarVida(int posX, int posY, String direccion, String tipo) {
            matrizLogica[posX, posY] = null;
            matrizGrafica[posX, posY].Image = null;

            if (string.Equals(direccion, "arriba", StringComparison.OrdinalIgnoreCase)) {
                principal.Location = new Point(principal.Location.X, principal.Location.Y - 25);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posYHeroePrincipal--;
            }
            else if (string.Equals(direccion, "abajo", StringComparison.OrdinalIgnoreCase))  {
                principal.Location = new Point(principal.Location.X, principal.Location.Y + 25);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posYHeroePrincipal++;
            }
            else if (string.Equals(direccion, "izquierda", StringComparison.OrdinalIgnoreCase)) {
                principal.Location = new Point(principal.Location.X - 25, principal.Location.Y);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posXHeroePrincipal--;
            } else if (string.Equals(direccion, "derecha", StringComparison.OrdinalIgnoreCase)) {
                principal.Location = new Point(principal.Location.X + 25, principal.Location.Y);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posXHeroePrincipal++;
            }


    }



    }
}