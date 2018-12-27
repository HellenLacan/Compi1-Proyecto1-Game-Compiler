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
using System.Diagnostics;

namespace Proyecto1_201325674
{
    public partial class Form1 : Form
    {
        static List<Archivo> listaArchivos = new List<Archivo>();
        SuperEscenario[,] matrizLogica = null;
        Boton[,] matrizGrafica = null;
        BotonHeroe principal = null;
        public String archivo1, archivo2;
        int posXHeroePrincipal = 0;
        int posYHeroePrincipal = 0;
        int tamanioPanel = 629;
        int noPasos = 0;
        int ancho = 0;
        int alto = 0;
        int noArmas = 0;
        int vidaHeroePrincipal = 0;
        String contenidoArchivo1 = "";
        String contenidoArchivo2 = "";
        BotonEnemigo[] enemigos = null;
        public static System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
            panelSelectPersonaje.Visible = false;
            panelSelectFondos.Visible = false;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSeleccionarOtroPersonaje.Visible = false;
            btnSelectOTroFondo.Visible = false;
            lblGanancia.Visible = false;
            lblPerdida.Visible = false;
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

        public void abrirArchivo1Configuracion() {
            String content = "";
            String path = "";
            String name = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = (System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                openFileDialog.Filter = "psc files (*.xconf; *.xesc;)| *.xconf; *.xesc;";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    name = openFileDialog.SafeFileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        content = reader.ReadToEnd();
                        contenidoArchivo1 = content;
                    }
                }

                getRichTextBox().Text = content;

                Boolean encontrado = false;
                foreach (Archivo item in listaArchivos) {
                    if (item.path == path) {
                        item.contenido = contenidoArchivo1;
                        encontrado = true; ;
                    }
                }

                if (encontrado == false) {
                    listaArchivos.Add(new Archivo(path, contenidoArchivo1));
                }

            }
        }

        public void abrirArchivo2Escenarios()
        {
            String content = "";
            String path = "";
            String name = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = (System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                openFileDialog.Filter = "psc files (*.xesc)|*.xesc";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    name = openFileDialog.SafeFileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        content = reader.ReadToEnd();
                        contenidoArchivo2 = content;
                    }
                }

                getRichTextBox().Text = content;
            }
        }

        private RichTextBox getRichTextBox()
        {
            RichTextBox richTextBox = null;
            TabPage tp = tabControl1.SelectedTab;
            var tab = tabControl1.SelectedTab;

            if (tp != null)
            {
                richTextBox = tp.Controls[0] as RichTextBox;
            }

            return richTextBox;
        }

        private void ejecutarArchivoConfiguracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("C:/Users/Hellen/Documents/Cursos/COMPI1_VACAS_DIC_2018/Proyecto1_201325674/PruebaArchivoEntrada1.xconf"))
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
                MessageBox.Show("Analisis con errores");

            }
        }

        private void compilarArchivoDeCargaEscenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (StreamReader reader = new StreamReader("C:/Users/Hellen/Documents/Cursos/COMPI1_VACAS_DIC_2018/Proyecto1_201325674/PruebaArchivoEntrada2.xesc"))
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
                MessageBox.Show("Analisis con errores");

            }
        }

        private void ejecutarJuegoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            limpiarEscenario();
            
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
            
            agregarHeroeAlEscenario();
            panelSelectPersonaje.Visible = true;
            panelSelectFondos.Visible = true;
            agregarEnemigos();

        }

        private void limpiarEscenario(){
            principal = null;
            posXHeroePrincipal = 0;
            posYHeroePrincipal = 0;
            tamanioPanel = 629;
            noPasos = 0;
            ancho = 0;
            alto = 0;
            noArmas = 0;
            vidaHeroePrincipal = 0;
            contenidoArchivo1 = "";
            contenidoArchivo2 = "";
            this.matrizLogica = Recorrido2.cargarMatrizLogica();

            if (enemigos != null) {
                for (int i = 0; i < enemigos.Length; i++)
                {
                    enemigos[i].Image = null;
                    enemigos[i] = null;
                }
            }

            if (principal != null)
            {
                principal.Image = null;
                principal = null;
            }
 
        }

        private void agregarHeroeAlEscenario() {
            foreach (SuperEscenario item in Recorrido2.milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "heroe", StringComparison.OrdinalIgnoreCase))
                {
                    //int tamanio = 25;

                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        //item.tipoObjeto = 2;
                        matrizLogica[item.posIniX, item.posIniY] = item;

                        posXHeroePrincipal = item.posIniX;
                        posYHeroePrincipal = item.posIniY;
                        principal = new BotonHeroe(item.posIniX, item.posIniY, ancho);
                        vidaHeroePrincipal = item.personaje.vida;

                        try
                        {
                            //principal.Image = Image.FromFile(item.personaje.rutaImagen);
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

        private void agregarEnemigos() {
            enemigos = new BotonEnemigo[0];
            foreach (SuperEscenario item in Recorrido2.milistaObjetosEscenario)
            {
                if (string.Equals(item.tipo, "enemigo", StringComparison.OrdinalIgnoreCase))
                {
                    if ((item.posIniX >= 0 && item.posIniX < alto) &&
                        (item.posIniY >= 0 && item.posIniY < ancho))
                    {
                        Array.Resize(ref enemigos, enemigos.Count() + 1);
                        enemigos[enemigos.Count()-1] = new BotonEnemigo(item.posIniX, item.posIniY,ancho);
                        panelEscenario.Controls.Add(enemigos[enemigos.Count()-1]);
                        enemigos[enemigos.Count()-1].BringToFront();
                    }
                    else
                    {
                        Console.WriteLine("Semantico, enemigo se sale del tablero");
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
                            principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                            matrizLogica[posXHeroePrincipal-1, posYHeroePrincipal] = matrizLogica[posXHeroePrincipal, posYHeroePrincipal];
                            matrizLogica[posXHeroePrincipal, posYHeroePrincipal] = null;
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
                        }//meta
                        else if (matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal].tipoObjeto == 3)
                        {
                            llegarAlaMeta(posXHeroePrincipal - 1, posYHeroePrincipal, "izquierda");
                        }//enemigo
                        else if (matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal].tipoObjeto == 4)
                        {
                            agregarOquitarVida(posXHeroePrincipal - 1, posYHeroePrincipal, "izquierda", "enemigo");
                        }
                        else
                        {
                            Console.WriteLine(matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal].tipoObjeto);
                        }
                    }
                    break;

                case Keys.Right:
                    if (posXHeroePrincipal + 1 < Recorrido2.getAltoEscenario())
                    {
                        if (matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal] == null)
                        {
                            principal.Location = new Point(principal.Location.X + noPasos, principal.Location.Y);
                            matrizLogica[posXHeroePrincipal+1, posYHeroePrincipal] = matrizLogica[posXHeroePrincipal, posYHeroePrincipal];
                            matrizLogica[posXHeroePrincipal, posYHeroePrincipal] = null;
                            posXHeroePrincipal++;
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
                        }//Si es meta
                        else if (matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal].tipoObjeto == 3)
                        {
                            llegarAlaMeta(posXHeroePrincipal + 1, posYHeroePrincipal, "derecha");

                        }//Si es enemigo
                        else if (matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal].tipoObjeto == 4)
                        {
                            agregarOquitarVida(posXHeroePrincipal + 1, posYHeroePrincipal, "derecha", "enemigo");

                        }
                        else
                        {
                            Console.WriteLine(matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal].tipoObjeto);
                        }
                    }

                    break;

                case Keys.Up:
                    if (posYHeroePrincipal != 0)
                    {
                        if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1] == null)
                        {
                            principal.Location = new Point(principal.Location.X, principal.Location.Y - noPasos);
                            matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1] = matrizLogica[posXHeroePrincipal, posYHeroePrincipal];
                            matrizLogica[posXHeroePrincipal, posYHeroePrincipal] = null;
                            posYHeroePrincipal--;
                        }//Si es bomba
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto == 6)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal - 1, "arriba", "bomba");
                        }//Si es arma
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto == 7)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal - 1, "arriba", "arma");
                        }//Si es bonus
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto == 5)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal - 1, "arriba", "bonus");
                        }//Si es meta
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto == 3)
                        {
                            llegarAlaMeta(posXHeroePrincipal + 1, posYHeroePrincipal, "arriba");
                        }//Si es enemigo
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto == 4)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal - 1, "arriba", "enemigo");
                        }
                        else {
                            Console.WriteLine(matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].tipoObjeto);
                        }
                    }

                    break;

                case Keys.Down:
                    if (posYHeroePrincipal + 1 < Recorrido2.getAnchoEscenario())
                    {
                        if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1] == null)
                        {
                            principal.Location = new Point(principal.Location.X, principal.Location.Y + noPasos);
                            matrizLogica[posXHeroePrincipal, posYHeroePrincipal+1] = matrizLogica[posXHeroePrincipal, posYHeroePrincipal];
                            matrizLogica[posXHeroePrincipal, posYHeroePrincipal] = null;
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
                        }//Si es meta
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1].tipoObjeto == 3)
                        {
                            llegarAlaMeta(posXHeroePrincipal, posYHeroePrincipal + 1, "abajo");
                        }//Si es enemigo
                        else if (matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1].tipoObjeto == 4)
                        {
                            agregarOquitarVida(posXHeroePrincipal, posYHeroePrincipal + 1, "abajo", "enemigo");
                        }
                        else
                        {
                            Console.WriteLine(matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1].tipoObjeto);
                        }
                    }
                    break;
            }
        }

        public void moverEnemigo()
        {
            var random = new Random();
            for (int i = 0; i < enemigos.Length; i++)
            {
                int value = random.Next(0, 100);
                Console.WriteLine("Nueva Heroe=" + principal.Location.X + "," + principal.Location.Y);

                var dx = ((principal.Location.X)/(tamanioPanel/ancho)) - (enemigos[i].Location.X/(tamanioPanel/ancho));
                var dy = ((principal.Location.Y)/(tamanioPanel/ancho)) - (enemigos[i].Location.Y/(tamanioPanel/ancho));

                int posXEnemigo = enemigos[i].Location.X / (tamanioPanel / ancho);
                int posYEnemigo = enemigos[i].Location.Y / (tamanioPanel / ancho);

                Console.WriteLine("nueva pos" + dx +"," + dy);
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    int X = (enemigos[i].Location.X) + (Math.Sign(dx) * (tamanioPanel / ancho));

                    int posX = X / (tamanioPanel / ancho);
                    int posY = (enemigos[i].Location.Y / (tamanioPanel / ancho));

                    //Console.WriteLine("posicion a ocupar " + posX+ ", " + posY);

                    if (matrizLogica[posX, posY] == null)
                    {
                        enemigos[i].Location = new Point(X, enemigos[i].Location.Y);
                        matrizLogica[posX, posY] = matrizLogica[posXEnemigo, posYEnemigo];
                        matrizLogica[posXEnemigo, posYEnemigo] = null;
                    }
                    else
                    {
                        moverEnemigoRandom(posXEnemigo, posYEnemigo, i);
                    }
                }
                else
                {
                    int Y = (enemigos[i].Location.Y) + (Math.Sign(dy) * (tamanioPanel / ancho));
                    int posX = enemigos[i].Location.X / (tamanioPanel / ancho);
                    int posY = (Y / (tamanioPanel / ancho));

                    if (matrizLogica[posX, posY] == null)
                    {
                        enemigos[i].Location = new Point(enemigos[i].Location.X, Y);
                        matrizLogica[posX, posY] = matrizLogica[posXEnemigo, posYEnemigo];
                        matrizLogica[posXEnemigo, posYEnemigo] = null;
                    }
                    else 
                    {
                        moverEnemigoRandom(posXEnemigo, posYEnemigo, i);
                    }
                }

            }    

        }

        private void moverEnemigoRandom(int posXEnemigo, int posYEnemigo, int i) {
            var random = new Random();
            Boolean encontrado = false;
            while (encontrado == false) {
                int value = random.Next(1, 5);
                if (value == 1)
                {
                    if (matrizLogica[posXEnemigo + 1, posYEnemigo] == null)
                    {
                        moverEnemigoIzq(posXEnemigo + 1, posYEnemigo, i);
                        matrizLogica[posXEnemigo + 1, posYEnemigo] = matrizLogica[posXEnemigo, posYEnemigo];
                        matrizLogica[posXEnemigo, posYEnemigo] = null;
                        encontrado = true;
                    }
                    else
                    {
                        if (matrizLogica[posXEnemigo + 1, posYEnemigo] != null) {
                            if (matrizLogica[posXEnemigo + 1, posYEnemigo].tipoObjeto == 2) {
                                vidaHeroePrincipal = vidaHeroePrincipal - (enemigos[i].personaje.ptosDestruccion);
                                validarVidaDeHeroe();
                            }
                        }
                    }
                }
                else if (value == 2)
                {
                    if (matrizLogica[posXEnemigo - 1, posYEnemigo] == null)
                    {
                        moverEnemigoIzq(posXEnemigo - 1, posYEnemigo, i);
                        matrizLogica[posXEnemigo - 1, posYEnemigo] = matrizLogica[posXEnemigo, posYEnemigo];
                        matrizLogica[posXEnemigo, posYEnemigo] = null;
                        encontrado = true;
                    }
                    else
                    {
                        if (matrizLogica[posXEnemigo - 1, posYEnemigo] != null)
                        {
                            if (matrizLogica[posXEnemigo - 1, posYEnemigo].tipoObjeto == 2)
                            {
                                vidaHeroePrincipal = vidaHeroePrincipal - (enemigos[i].personaje.ptosDestruccion);
                                validarVidaDeHeroe();
                            }
                        }
                    }

                }
                else if (value == 3)
                {
                    if (matrizLogica[posXEnemigo, posYEnemigo + 1] == null)
                    {
                        moverEnemigoIzq(posXEnemigo, posYEnemigo + 1, i);
                        matrizLogica[posXEnemigo, posYEnemigo + 1] = matrizLogica[posXEnemigo, posYEnemigo];
                        matrizLogica[posXEnemigo, posYEnemigo] = null;
                        encontrado = true;
                    }
                    else
                    {
                        if (matrizLogica[posXEnemigo, posYEnemigo+1] != null)
                        {
                            if (matrizLogica[posXEnemigo, posYEnemigo+1].tipoObjeto == 2)
                            {
                                vidaHeroePrincipal = vidaHeroePrincipal - (enemigos[i].personaje.ptosDestruccion);
                                validarVidaDeHeroe();
                            }
                        }
                    }

                }
                else if (value == 4)
                {
                    if (matrizLogica[posXEnemigo, posYEnemigo - 1] == null)
                    {
                        moverEnemigoIzq(posXEnemigo, posYEnemigo - 1, i);
                        matrizLogica[posXEnemigo, posYEnemigo - 1] = matrizLogica[posXEnemigo, posYEnemigo];
                        matrizLogica[posXEnemigo, posYEnemigo] = null;
                        encontrado = true;
                    }
                    else
                    {
                        if (matrizLogica[posXEnemigo, posYEnemigo-1] != null)
                        {
                            if (matrizLogica[posXEnemigo, posYEnemigo-1].tipoObjeto == 2)
                            {
                                vidaHeroePrincipal = vidaHeroePrincipal - (enemigos[i].personaje.ptosDestruccion);
                                validarVidaDeHeroe();
                            }
                        }
                    }
                }

            }

        }


        private void moverEnemigoIzq(int posX, int posY, int i) {
            enemigos[i].Location = new Point(posX*(tamanioPanel/ancho), posY*(tamanioPanel/ancho));
        }

        private void moverEnemigoArriba(int posX, int posY, int i)
        {
            enemigos[i].Location = new Point(posX * (tamanioPanel / ancho), posY * (tamanioPanel / ancho));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    if (matrizLogica[i, j] != null)
                    {
                        if (matrizLogica[i, j].tipoObjeto == 4)
                        {
                            //timer = new System.Timers.Timer();
                            //timer.Interval = 1000; //one second
                            //timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                            //timer.Enabled = true;
                            //timer.Start();
                            //timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
                            timer1.Enabled = true;
                            timer1.Start();
                        }
                    }
                }
            }

        }



        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            moverEnemigo();
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
            CheckForIllegalCrossThreadCalls = false;

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

        public void llegarAlaMeta(int posX, int posY, String direccion) {
            if (string.Equals(direccion, "arriba", StringComparison.OrdinalIgnoreCase))
            {
                principal.Location = new Point(principal.Location.X, principal.Location.Y - noPasos);
                MessageBox.Show("WIN!!");
                vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                timer1.Stop();
            }
            else if (string.Equals(direccion, "abajo", StringComparison.OrdinalIgnoreCase))
            {
                principal.Location = new Point(principal.Location.X, principal.Location.Y + noPasos);
                MessageBox.Show("WIN!!");
                timer1.Stop();
                vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
            }
            else if (string.Equals(direccion, "izquierda", StringComparison.OrdinalIgnoreCase))
            {
                principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                MessageBox.Show("WIN!!");
                timer1.Stop();
                vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
            }
            else if (string.Equals(direccion, "derecha", StringComparison.OrdinalIgnoreCase))
            {
                principal.Location = new Point(principal.Location.X + noPasos, principal.Location.Y);
                MessageBox.Show("WIN!!");
                timer1.Stop();
                vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
            }
        }

        public void agregarOquitarVida(int posX, int posY, String direccion, String tipo) {
            //int ptosDestruccion = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
            int ptosDestruccion = 0;
            int bonus = 0;
            if (tipo == "bomba") {
                if (string.Equals(direccion, "arriba", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X, principal.Location.Y - noPasos);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                    posYHeroePrincipal--;
                    ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX, posY + 1];
                    matrizGrafica[posX, posY].Image = null;
                    matrizLogica[posX, posY + 1] = null;

                }
                else if (string.Equals(direccion, "abajo", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X, principal.Location.Y + noPasos);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                    posYHeroePrincipal++;
                    ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX, posY - 1];
                    matrizLogica[posX, posY - 1] = null;
                    matrizGrafica[posX, posY].Image = null;
                }
                else if (string.Equals(direccion, "izquierda", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                    posXHeroePrincipal--;
                    ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX + 1, posY];
                    matrizLogica[posX + 1, posY] = null;
                    matrizGrafica[posX, posY].Image = null;

                }
                else if (string.Equals(direccion, "derecha", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X + noPasos, principal.Location.Y);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                    posXHeroePrincipal++;
                    ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX - 1, posY];
                    matrizLogica[posX - 1, posY] = null;
                    matrizGrafica[posX, posY].Image = null;
                }
                /***************************************BONUS*************************************************/
            }
            else if (tipo == "bonus") {
                if (string.Equals(direccion, "arriba", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X, principal.Location.Y - noPasos);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal + matrizLogica[posX, posY].objeto.creditos;
                    posYHeroePrincipal--;
                    bonus = matrizLogica[posX, posY].objeto.creditos;
                    matrizLogica[posX, posY] = matrizLogica[posX, posY + 1];
                    matrizLogica[posX, posY + 1] = null;
                    matrizGrafica[posX, posY].Image = null;
                }
                else if (string.Equals(direccion, "abajo", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X, principal.Location.Y + noPasos);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal + matrizLogica[posX, posY].objeto.creditos;
                    posYHeroePrincipal++;
                    bonus = matrizLogica[posX, posY].objeto.creditos;
                    matrizLogica[posX, posY] = matrizLogica[posX, posY - 1];
                    matrizLogica[posX, posY - 1] = null;
                    matrizGrafica[posX, posY].Image = null;

                }
                else if (string.Equals(direccion, "izquierda", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal + matrizLogica[posX, posY].objeto.creditos;
                    posXHeroePrincipal--;
                    bonus = matrizLogica[posX, posY].objeto.creditos;
                    matrizLogica[posX, posY] = matrizLogica[posX + 1, posY];
                    matrizLogica[posX + 1, posY] = null;
                    matrizGrafica[posX, posY].Image = null;

                }
                else if (string.Equals(direccion, "derecha", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X + noPasos, principal.Location.Y);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    vidaHeroePrincipal = vidaHeroePrincipal + matrizLogica[posX, posY].objeto.creditos;
                    posXHeroePrincipal++;
                    bonus = matrizLogica[posX, posY].objeto.creditos;
                    matrizLogica[posX, posY] = matrizLogica[posX - 1, posY];
                    matrizLogica[posX - 1, posY] = null;
                    matrizGrafica[posX, posY].Image = null;
                }
                /***************************************ENEMIGOS*************************************************/
            } else if (tipo == "enemigo") {
                if (string.Equals(direccion, "derecha", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Heroe ha pasado por enemigo");
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posXHeroePrincipal + 1, posYHeroePrincipal].personaje.ptosDestruccion;
                }
                else if (string.Equals(direccion, "izquierda", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Heroe ha pasado por enemigo");
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posXHeroePrincipal - 1, posYHeroePrincipal].personaje.ptosDestruccion;
                }
                else if (string.Equals(direccion, "arriba", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Heroe ha pasado por enemigo");
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posXHeroePrincipal, posYHeroePrincipal - 1].personaje.ptosDestruccion;
                    //principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                    //posXHeroePrincipal++;
                    //bonus = matrizLogica[posX, posY].objeto.creditos;
                    //matrizLogica[posX, posY] = matrizLogica[posX - 1, posY];
                    //matrizLogica[posX - 1, posY] = null;
                    //matrizGrafica[posX, posY].Image = null;
                }
                else if (string.Equals(direccion, "abajo", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Heroe ha pasado por enemigo");
                    vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posXHeroePrincipal, posYHeroePrincipal + 1].personaje.ptosDestruccion;
                    //principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                    //posXHeroePrincipal++;
                    //bonus = matrizLogica[posX, posY].objeto.creditos;
                    //matrizLogica[posX, posY] = matrizLogica[posX - 1, posY];
                    //matrizLogica[posX - 1, posY] = null;
                    //matrizGrafica[posX, posY].Image = null;
                }
                /***************************************ARMAS*************************************************/
            } else if (tipo == "arma") {
                if (string.Equals(direccion, "arriba", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X, principal.Location.Y - noPasos);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    posYHeroePrincipal--;
                    noArmas += 1;
                    lblNoArmas.Text = noArmas.ToString();
                    //ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX, posY + 1];
                    matrizGrafica[posX, posY].Image = null;
                    matrizLogica[posX, posY + 1] = null;

                }
                else if (string.Equals(direccion, "abajo", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X, principal.Location.Y + noPasos);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    //vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                    posYHeroePrincipal++;
                    noArmas += 1;
                    lblNoArmas.Text = noArmas.ToString();
                    ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX, posY - 1];
                    matrizLogica[posX, posY - 1] = null;
                    matrizGrafica[posX, posY].Image = null;
                }
                else if (string.Equals(direccion, "izquierda", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X - noPasos, principal.Location.Y);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    //vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                    posXHeroePrincipal--;
                    noArmas += 1;
                    lblNoArmas.Text = noArmas.ToString();
                    ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX + 1, posY];
                    matrizLogica[posX + 1, posY] = null;
                    matrizGrafica[posX, posY].Image = null;

                }
                else if (string.Equals(direccion, "derecha", StringComparison.OrdinalIgnoreCase))
                {
                    principal.Location = new Point(principal.Location.X + noPasos, principal.Location.Y);
                    Console.WriteLine("Heroe ha pasado por" + tipo);
                    //vidaHeroePrincipal = vidaHeroePrincipal - matrizLogica[posX, posY].objeto.ptosDestruccion;
                    posXHeroePrincipal++;
                    noArmas += 1;
                    lblNoArmas.Text = noArmas.ToString();
                    ptosDestruccion = matrizLogica[posX, posY].objeto.ptosDestruccion;
                    matrizLogica[posX, posY] = matrizLogica[posX - 1, posY];
                    matrizLogica[posX - 1, posY] = null;
                    matrizGrafica[posX, posY].Image = null;
                }
            }

            validarVidaDeHeroe();
        }

        public Boolean validarVidaDeHeroe()
        {

            if (vidaHeroePrincipal <= 0 || 
                (principal.posX == Recorrido2.getPosXMeta() && principal.posY == Recorrido2.getPosYMeta()) )
            {
                MessageBox.Show("GAME OVER");
                timer1.Stop();
                lblVidaPersonaje.Text = "0";
                return false;
            }
            if (vidaHeroePrincipal > 100)
            {
                vidaHeroePrincipal = 100;
                lblVidaPersonaje.Text = vidaHeroePrincipal.ToString();
                return true;
            }
            else
            {
                lblVidaPersonaje.Text = vidaHeroePrincipal.ToString();
                return true;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TABPANEL1
            TabPage newTabPage = new TabPage("New Document");
            newTabPage.Font = new Font("Verdana", 18);

            RichTextBox newTextBox = new RichTextBox();
            newTextBox.Dock = DockStyle.Fill;
            newTextBox.Font = new Font("Verdana", 10);
            newTextBox.BackColor = Color.White;
            newTextBox.BorderStyle = BorderStyle.None;

            newTabPage.Controls.Add(newTextBox);
            tabControl1.TabPages.Add(newTabPage);

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArchivo1Configuracion();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(getRichTextBox().Text);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe miAcercaDe = new AcercaDe();
            miAcercaDe.Show();
        }

        private void panelEscenario_Click(object sender, EventArgs e)
        {
            try
            {
                principal.Focus();
            }
            catch (Exception ex)
            {
                Console.WriteLine("IOException source: {0}", ex.Source);
            }
        }

        private void Form1_Click_1(object sender, EventArgs e)
        {
            try
            {
                principal.Focus();
            }
            catch (Exception ex)
            {
                Console.WriteLine("IOException source: {0}", ex.Source);
            }
        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormErrores miFormeErrores = new FormErrores();
            miFormeErrores.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moverEnemigo();
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Users\\Hellen\\Desktop\\ManualDeUsuario.pdf");
            Process.Start(startInfo);
        }

        private void manualTecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Users\\Hellen\\Desktop\\ManualTecnico.pdf");
            Process.Start(startInfo);
        }

        private void tablaDeSimbolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TablaSimbolos miForm = new Form_TablaSimbolos();
            miForm.Show();
        }

    }
}