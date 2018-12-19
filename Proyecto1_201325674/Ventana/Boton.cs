using Proyecto1_201325674.sol.com.analizador2;
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
    class Boton : System.Windows.Forms.PictureBox

    {
        SuperEscenario[,] matrizLogica = Recorrido2.cargarMatrizLogica();
        public Boton(int i, int j) {

            int tamanio = 25;
            this.Left = i * tamanio;
            this.Top = j * tamanio;
            this.Width = tamanio;
            this.Height = tamanio;
            if (matrizLogica[i, j] != null)
            {
                this.Image = Image.FromFile(matrizLogica[i, j].objeto.rutaImagen);
                this.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else {
            }
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.Transparent;
        }
    }
}
