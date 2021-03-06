﻿using Proyecto1_201325674.sol.com.analizador2;
using Proyecto1_201325674.sol.com.estructuraEscenario;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201325674.Ventana
{
    class Boton : System.Windows.Forms.PictureBox

    {
        public int posX { get; set; }
        public int posY { get; set; }

        SuperEscenario[,] matrizLogica = Recorrido2.matrizLogica;
        public Boton(int i, int j, int tamanioMatriz)
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
                if (matrizLogica[i, j].tipo == "bloque" || matrizLogica[i, j].tipo == "bonus" || matrizLogica[i, j].tipo == "bomba" || matrizLogica[i, j].tipo == "arma")
                {
                    capturarRuta(i, j, matrizLogica[i, j].tipo);
                }
                else if (matrizLogica[i, j].tipo == "meta")
                {
                    capturarRuta(i, j, matrizLogica[i, j].tipo);
                }
                else if (matrizLogica[i, j].tipo == "enemigo")
                {
                    //capturarRuta(i, j, matrizLogica[i, j].tipo);
                   // Console.WriteLine("Enemigo en: " + this.Location.X + "," + this.Location.Y);
                }

            }

            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.Transparent;
        }

        public void capturarRuta(int i, int j, string tipo)
        {
            if (tipo == "enemigo")
            {
                try
                {
                    this.Image = Image.FromFile(matrizLogica[i, j].personaje.rutaImagen);
                    this.SizeMode = PictureBoxSizeMode.StretchImage;
                    Console.WriteLine("El enemigo esta en la posicion " + this.Location.X + "," + this.Location.Y);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", e.Source);
                }
            }
            else if ((string.Equals(tipo, "meta", StringComparison.OrdinalIgnoreCase)) || 
                     (string.Equals(tipo, "bonus", StringComparison.OrdinalIgnoreCase)) ||
                     (string.Equals(tipo, "bloque", StringComparison.OrdinalIgnoreCase)) ||
                     (string.Equals(tipo, "arma", StringComparison.OrdinalIgnoreCase)) ||
                     (string.Equals(tipo, "bomba", StringComparison.OrdinalIgnoreCase)))
            {
                try
                {
                    this.Image = Image.FromFile(matrizLogica[i, j].objeto.rutaImagen);
                    this.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ruta no existe");
                    Console.WriteLine("IOException source: {0}", e.Source);
                }

            }
        }
        
    }
}