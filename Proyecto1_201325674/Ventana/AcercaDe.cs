using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201325674.Ventana
{
    public partial class AcercaDe : Form
    {
        public AcercaDe()
        {
            InitializeComponent();
        }

        private void AcercaDe_Load(object sender, EventArgs e)
        {
            String texto = "";
            texto+= "Hellen Alexandra Lacan Hernandez\n";
            texto += "201325674\n";
            texto += "Organizacion de Lenguajes Y Compiladores 1\n";
            texto += "Game Compiler V.1.0\n";
            label1.Text = texto;

        }
    }
}
