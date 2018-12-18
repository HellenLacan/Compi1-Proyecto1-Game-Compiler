using Proyecto1_201325674.sol.com.archivoConfiguracion;
using Proyecto1_201325674.sol.com.objetosConfiguracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.estructuraEscenario
{
    class SuperEscenario
    {
        public string tipo { get; set; }
        public EscenarioFondo fondo { get; set; }
        public Personaje personaje { get; set; }
        public ObjetoEscenario objeto { get; set; }
        public int posIniX { get; set; }
        public int posFinX { get; set; }
        public int posIniY { get; set; }
        public int posFinY { get; set; }

        public SuperEscenario() {

        }

        public SuperEscenario(String tipo, Object tipoObjecto, int posIniX, int posFinX, int posIniY, int posFinY) {
            this.tipo = tipo;
            this.posIniX = posIniX;
            this.posFinX = posFinX;
            this.posIniY = posIniY;
            this.posFinY = posFinY;

            if (tipoObjecto.GetType().ToString() == "Proyecto1_201325674.sol.com.archivoConfiguracion.Personaje.EscenarioFondo") {
                this.fondo = (EscenarioFondo)tipoObjecto;
            } else if (tipoObjecto.GetType().ToString() == "Proyecto1_201325674.sol.com.archivoConfiguracion.Personaje.ObjetoEscenario") {
                this.objeto = (ObjetoEscenario)tipoObjecto;
            } else if (tipoObjecto.GetType().ToString() == "Proyecto1_201325674.sol.com.archivoConfiguracion.Personaje") {
                this.personaje = (Personaje)tipoObjecto;
            }
        }

    }
}
