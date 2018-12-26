using Practica1.sol.com.analyzer;
using Proyecto1_201325674.sol.com.objetosConfiguracion;
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
    public partial class Form_TablaSimbolos : Form
    {
        public Form_TablaSimbolos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Token_ item in Recorrido1.TablaDeSimbolos) {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item.token;
                dataGridView1.Rows[n].Cells[1].Value = item.fila;
                dataGridView1.Rows[n].Cells[2].Value = item.columna;
                dataGridView1.Rows[n].Cells[3].Value = item.lexema;
            }
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }
    }
}
