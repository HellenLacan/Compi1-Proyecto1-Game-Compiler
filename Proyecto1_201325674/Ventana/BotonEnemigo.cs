using Proyecto1_201325674.sol.com.analizador2;
using Proyecto1_201325674.sol.com.archivoConfiguracion;
using Proyecto1_201325674.sol.com.estructuraEscenario;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201325674.Ventana
{
    class BotonEnemigo : System.Windows.Forms.PictureBox
    {
        public string identificador { get; set; }
        public string ruta { get; set; }

        public int posX { get; set; }
        public int posY { get; set; }
        public int tipoObjeto { get; set; }
        SuperEscenario[,] matrizLogica = Recorrido2.matrizLogica;
        Personaje personaje;

        public BotonEnemigo(int i, int j, int tamanioMatriz)
        {

            int tamanioPanel = 629;
            this.Left = i * (tamanioPanel / tamanioMatriz);
            this.Top = j * (tamanioPanel / tamanioMatriz);
            this.Width = tamanioPanel / tamanioMatriz;
            this.Height = tamanioPanel / tamanioMatriz;
            this.posX = i;
            this.posY = j;

            if (matrizLogica[i, j] != null)
            {
                if (matrizLogica[i, j].tipo == "enemigo")
                {
                    try
                    {
                        this.Image = Image.FromFile(matrizLogica[i, j].personaje.rutaImagen);
                        this.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.posX = matrizLogica[i, j].posIniX;
                        this.posY = matrizLogica[i, j].posIniY;
                        this.tipoObjeto = matrizLogica[i, j].tipoObjeto;
                        this.personaje = matrizLogica[i, j].personaje;

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ruta no existe");
                        Console.WriteLine("IOException source: {0}", e.Source);
                    }
                }

            }

            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.Transparent;
        }

    }
}
