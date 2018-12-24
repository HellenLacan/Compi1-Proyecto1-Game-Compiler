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
using System.Threading;

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
        int tamanioPanel = 629;
        int noPasos = 0;
        int ancho = 0;
        int alto = 0;

        public Form1()
        {
            InitializeComponent();
            panelSelectPersonaje.Visible = false;
            panelSelectFondos.Visible = false;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSeleccionarOtroPersonaje.Visible = false;
            btnSelectOTroFondo.Visible = false;

        }

        int personajeSelect = -1;
        int fondoPrincipalSelect = -1;

        //Boton Anterior heroes


        private void BtnSeleccionarOtroPersonaje_Click(object sender, EventArgs e)
        {
            try
            {
                principal.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
                lblNombrePersonaje.Text = Recorrido1.milistaHeroes[personajeSelect].nombre;
                lblVidaPersonaje.Text = Recorrido1.milistaHeroes[personajeSelect].vida.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ruta no existe");
                Console.WriteLine("IOException source: {0}", ex.Source);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (personajeSelect == -1)
            {
                personajeSelect = 0;

                try
                {
                    pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
                    NombrePersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].nombre;
                    vidaPersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].vida.ToString();
                    richTextBox1.Text = Recorrido1.milistaHeroes[personajeSelect].descripcion;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }

            }
            else if (personajeSelect >= 0)
            {
                personajeSelect -= 1;
                try
                {
                    pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
                    NombrePersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].nombre;
                    vidaPersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].vida.ToString();
                    richTextBox1.Text = Recorrido1.milistaHeroes[personajeSelect].descripcion;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }
            }

            habilitarBotonesHeroes(personajeSelect);
            BtnSeleccionarOtroPersonaje.Visible = true;
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
                    NombrePersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].nombre;
                    vidaPersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].vida.ToString();
                    richTextBox1.Text = Recorrido1.milistaHeroes[personajeSelect].descripcion;
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
                    NombrePersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].nombre;
                    vidaPersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].vida.ToString();
                    richTextBox1.Text = Recorrido1.milistaHeroes[personajeSelect].descripcion;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }
            }

            habilitarBotonesHeroes(personajeSelect);
            BtnSeleccionarOtroPersonaje.Visible = true;
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

        private void habilitarBotonesFondo(int id)
        {
            if (id == 0 && (id != Recorrido1.miListaFondos.Count - 1))
            {
                btnFondoAnterior.Enabled = false;
                btnFondoSiguiente.Enabled = true;
            }
            else if (id != 0 && (id == Recorrido1.miListaFondos.Count - 1))
            {
                btnFondoAnterior.Enabled = true;
                btnFondoSiguiente.Enabled = false;

            }
            else
            {
                btnFondoAnterior.Enabled = true;
                btnFondoSiguiente.Enabled = true;
            }
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

            foreach (SuperEscenario item in Recorrido2.milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "background", StringComparison.OrdinalIgnoreCase))
                {
                    ancho = item.ancho + 1;
                    alto = item.alto + 1;
                    noPasos = (629 / ancho);
                    try
                    {
                        Image image1 = Image.FromFile(item.fondo.ruta);
                        panelEscenario.BackgroundImage = image1;

                        //Cargando el fondo para la lista de fondos a seleccionar
                        pictureBoxFondoSelect.Image = Image.FromFile(item.fondo.ruta);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ruta no existe");
                        Console.WriteLine("IOException source: {0}", ex.Source);
                    }

                    panelEscenario.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }

            matrizGrafica = new Boton[alto, ancho]; ;
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    Boton miBoton = new Boton(i, j, alto);
                    matrizGrafica[i, j] = miBoton;
                    panelEscenario.Controls.Add(miBoton);

                }
            }

            foreach (SuperEscenario item in Recorrido2.milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "heroe", StringComparison.OrdinalIgnoreCase))
                {
                    //int tamanio = 25;

                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        //item.tipoObjeto = 2;
                        //matrizLogica[item.posIniX, item.posIniY] = item;

                        posXHeroePrincipal = item.posIniX;
                        posYHeroePrincipal = item.posIniY;
                        principal = new PictureBox();
                        principal.Left = item.posIniX * (tamanioPanel/ancho);
                        principal.Top = item.posIniY * (tamanioPanel / ancho);
                        principal.Width = (tamanioPanel / ancho);
                        principal.Height = (tamanioPanel / ancho);

                        try
                        {
                            principal.Image = Image.FromFile(item.personaje.rutaImagen);
                            lblNombrePersonaje.Text = item.personaje.nombre;
                            lblVidaPersonaje.Text = item.personaje.vida.ToString();

                            //Para la imagen de los personajes que se seleccionan
                            pictureBox1.Image = Image.FromFile(item.personaje.rutaImagen);
                            NombrePersonajeSelect.Text = item.personaje.nombre;
                            vidaPersonajeSelect.Text = item.personaje.vida.ToString();
                            richTextBox1.Text = item.personaje.descripcion;

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

            panelSelectPersonaje.Visible = true;
            panelSelectFondos.Visible = true;
            //try
            //{
            //    pictureBox1.Image = Image.FromFile(Recorrido1.milistaHeroes[personajeSelect].rutaImagen);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Ruta no existe");
            //    Console.WriteLine("IOException source: {0}", ex.Source);
            //}

            //Thread misEnemigos = new Thread(moverEnemigo);
            //misEnemigos.Start();
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
                            principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
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
                            principal.Location = new Point(principal.Location.X + noPasos, principal.Location.Y);
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
                            principal.Location = new Point(principal.Location.X, principal.Location.Y - noPasos);
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
                            principal.Location = new Point(principal.Location.X, principal.Location.Y + noPasos);
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
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1].tipoObjeto == 5)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal + 1, "abajo", "bonus");
                        }
                    }
                    break;
            }
        }

        public void moverEnemigo()
        {

            while (matrizLogica[Recorrido2.getPosXMeta(), Recorrido2.getPosYMeta()] != null)
            {
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        if (matrizLogica[i, j] != null)
                        {
                            if (matrizLogica[i, j].tipoObjeto == 4)
                            {
                                Random rnd = new Random();
                                if (rnd.Next(99) + 1 > 60)
                                    return;
                                int dx = (posXHeroePrincipal*(tamanioPanel/ancho)) - matrizGrafica[i,j].Location.X;
                                int dy = (posYHeroePrincipal*(tamanioPanel/ancho)) - matrizGrafica[i, j].Location.Y;

                                if (Math.Abs(dx) > Math.Abs(dy))
                                {
                                    int posXEnemigo = matrizGrafica[i, j].Location.X - Math.Sign(dx);
                                    Console.WriteLine("Enemigo esta en X:" + posXEnemigo);
                                }
                                else {
                                    int posYEnemigo = matrizGrafica[i, j].Location.Y - Math.Sign(dy);
                                    Console.WriteLine("Enemigo esta en Y en: " +posYEnemigo);
                                }

                                //if (matrizLogica[i, j + 1] == null)
                                //{

                                //    try
                                //    {
                                //        matrizGrafica[i, j + 1].Image = Image.FromFile(matrizLogica[i, j].personaje.rutaImagen);
                                //        matrizLogica[i, j + 1] = matrizLogica[i, j];
                                //        matrizGrafica[i, j + 1].SizeMode = PictureBoxSizeMode.StretchImage;
                                //        matrizLogica[i, j] = null;
                                //        matrizGrafica[i, j].Image = null;
                                //        matrizGrafica[i, j].BackColor = Color.Transparent;
                                //        Thread.Sleep(1000);
                                //    }
                                //    catch (Exception e)
                                //    {
                                //        Console.WriteLine("Ruta no existe");
                                //        Console.WriteLine("IOException source: {0}", e.Source);
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //int noEnemigos= 0;
            //for (int i= 0; i < Recorrido2.getAltoEscenario(); i++) {
            //    for (int j = 0; j < Recorrido2.getAltoEscenario(); j++)
            //    {
            //        if (matrizLogica[i, j] != null) {

            //            if (matrizLogica[i, j].tipoObjeto == 4)
            //            {
                             Thread misEnemigos = new Thread(moverEnemigo);
                            misEnemigos.Start();
                //            noEnemigos++;
                ////        }
                ////    }
                ////}
            //}

            //Thread[] misEnemigos = new Thread[noEnemigos];

            //for (int i = 0; i < Recorrido2.getAltoEscenario(); i++)
            //{
            //    for (int j = 0; j < Recorrido2.getAltoEscenario(); j++)
            //    {
            //        if (matrizLogica[i, j] != null)
            //        {
            //            if (matrizLogica[i, j].tipoObjeto == 4)
            //            {
            //                if (noEnemigos > 0) {
            //                    misEnemigos[noEnemigos-1] = new Thread(moverEnemigo);
            //                    misEnemigos[noEnemigos-1].Start();
            //                    noEnemigos--;
            //                }
            //            }
            //        }
            //    }
            //}

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            principal.Focus();
        }

        private void panelEscenario_MouseClick(object sender, MouseEventArgs e)
        {
            principal.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFondoAnterior_Click(object sender, EventArgs e)
        {
            if (fondoPrincipalSelect == -1)
            {
                fondoPrincipalSelect = 0;

                try
                {
                    pictureBoxFondoSelect.Image = Image.FromFile(Recorrido1.miListaFondos[fondoPrincipalSelect].ruta);
                    //NombrePersonajeSelect.Text = Recorrido1.miListaFondos[fondoPrincipalSelect].identificador;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }

            }
            else if (fondoPrincipalSelect >= 0)
            {
                fondoPrincipalSelect -= 1;
                try
                {
                    pictureBoxFondoSelect.Image = Image.FromFile(Recorrido1.miListaFondos[fondoPrincipalSelect].ruta);
                    //NombrePersonajeSelect.Text = Recorrido1.milistaHeroes[personajeSelect].nombre;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }
            }

            habilitarBotonesFondo(fondoPrincipalSelect);
            btnSelectOTroFondo.Visible = true;
        }

        private void panelSelectFondos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFondoSiguiente_Click(object sender, EventArgs e)
        {
            if (fondoPrincipalSelect == -1)
            {
                fondoPrincipalSelect = 0;

                try
                {
                    pictureBoxFondoSelect.Image = Image.FromFile(Recorrido1.miListaFondos[fondoPrincipalSelect].ruta);
                    //NombrePersonajeSelect.Text = Recorrido1.milistaHeroes[fondoPrincipalSelect].nombre;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }

            }
            else if (fondoPrincipalSelect <= Recorrido1.miListaFondos.Count - 1)
            {
                fondoPrincipalSelect += 1;
                try
                {
                    pictureBoxFondoSelect.Image = Image.FromFile(Recorrido1.miListaFondos[fondoPrincipalSelect].ruta);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", ex.Source);
                }
            }

            habilitarBotonesFondo(fondoPrincipalSelect);
            btnSelectOTroFondo.Visible = true;
        }

        private void btnSelectOTroFondo_Click(object sender, EventArgs e)
        {

        }

        private void panelSelectPersonaje_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelectOTroFondo_Click_1(object sender, EventArgs e)
        {
            try
            {
                panelEscenario.BackgroundImage = Image.FromFile(Recorrido1.miListaFondos[fondoPrincipalSelect].ruta);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ruta no existe");
                Console.WriteLine("IOException source: {0}", ex.Source);
            }
        }

        public void agregarOquitarVida(int posX, int posY, String direccion, String tipo) {
            matrizLogica[posX, posY] = null;
            matrizGrafica[posX, posY].Image = null;

            if (string.Equals(direccion, "arriba", StringComparison.OrdinalIgnoreCase)) {
                principal.Location = new Point(principal.Location.X, principal.Location.Y - noPasos);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posYHeroePrincipal--;
            }
            else if (string.Equals(direccion, "abajo", StringComparison.OrdinalIgnoreCase))  {
                principal.Location = new Point(principal.Location.X, principal.Location.Y + noPasos);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posYHeroePrincipal++;
            }
            else if (string.Equals(direccion, "izquierda", StringComparison.OrdinalIgnoreCase)) {
                principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posXHeroePrincipal--;
            } else if (string.Equals(direccion, "derecha", StringComparison.OrdinalIgnoreCase)) {
                principal.Location = new Point(principal.Location.X + noPasos, principal.Location.Y);
                Console.WriteLine("Heroe ha pasado por" + tipo);
                posXHeroePrincipal++;
            }


    }



    }
}