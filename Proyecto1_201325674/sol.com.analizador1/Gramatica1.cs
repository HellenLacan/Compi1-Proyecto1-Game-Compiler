using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

/*
 Listas sin simbolo de separacion
              palabras.Rule = MakePlusRule(palabras, palabra);             
              Reconoce: palabra palabra1 palabra2  palabra3

              Listas con simbolo de separacion

            l_ids.Rule = this.MakeListRule(l_ids, ToTerm(","), ID);
            Reconoce: id, id, id , id
*/

namespace Practica1.sol.com.analizador
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false) {

            #region ER
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[+|-]?[0-9]+");
            RegexBasedTerminal numeroDecimal = new RegexBasedTerminal("numeroDecimal", "[0-9]+[.][0-9]+");
            RegexBasedTerminal identificador = new RegexBasedTerminal("identificador", "[a-zA-Z](_?[a-zA-Z0-9])*");
            StringLiteral cadena = new StringLiteral("cadena", "\"", StringOptions.IsTemplate);
            #endregion

            #region Simbolos
            var menor = ToTerm("<");
            var mayor = ToTerm(">");
            var slash = ToTerm("/");
            var coma = ToTerm(",");
            var llaveAb = ToTerm("{");
            var llaveCerr = ToTerm("}");
            var guion = ToTerm("-");
            var igual = ToTerm("=");
            var ptoYComa = ToTerm(";");
            var mas = ToTerm("+");
            var signoMas = ToTerm("+");
            var signoMenos = ToTerm("-");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var parentAb = ToTerm("(");
            var parentCerr = ToTerm(")");

            #endregion

            #region PalabrasReservadas
            KeyTerm _configuration = ToTerm("configuration");
            KeyTerm _background = ToTerm("background");
            KeyTerm _figure = ToTerm("figure");
            KeyTerm _design = ToTerm("design");
            KeyTerm _nombre = ToTerm("nombre");
            KeyTerm _imagen = ToTerm("imagen");
            KeyTerm _tipo = ToTerm("tipo");
            KeyTerm _x = ToTerm("x");
            KeyTerm _vida = ToTerm("vida");
            KeyTerm _descripcion = ToTerm("descripcion");
            KeyTerm _heroe = ToTerm("heroe");
            KeyTerm _enemigo = ToTerm("enemigo");
            KeyTerm _destruir = ToTerm("destruir");
            KeyTerm _meta = ToTerm("meta");
            KeyTerm _bloque = ToTerm("bloque");
            KeyTerm _bonus = ToTerm("bonus");
            KeyTerm _bomba = ToTerm("bomba");
            KeyTerm _arma = ToTerm("arma");
            KeyTerm _creditos = ToTerm("creditos");

            #endregion

            #region No Terminales
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal CONFIGURACION = new NonTerminal("CONFIGURACION");
            NonTerminal BACKGROUND = new NonTerminal("BACKGROUND");
            NonTerminal FIGURE = new NonTerminal("FIGURE");
            NonTerminal DESIGN = new NonTerminal("DESIGN");
            NonTerminal LISTA_CONFIGURACION = new NonTerminal("LISTA_CONFIGURACION");
            NonTerminal LISTA_BACKGROUND = new NonTerminal("LISTA_BACKGROUND");
            NonTerminal LISTA_FIGURE = new NonTerminal("LISTA_FIGURE");
            NonTerminal LISTA_DESIGN = new NonTerminal("LISTA_DESIGN");
            NonTerminal ATRIBUTOS_BACKGROUND = new NonTerminal("ATRIBUTOS_BACKGROUND");
            NonTerminal ATRIBUTOS_FIGURE = new NonTerminal("ATRIBUTOS_FIGURE");
            NonTerminal ATRIBUTOS_DESIGN = new NonTerminal("ATRIBUTOS_DESIGN");
            NonTerminal EXPRESION = new NonTerminal("EXPRESION");
            NonTerminal FIGURE_TIPO = new NonTerminal("FIGURE_TIPO");
            NonTerminal DESIGN_TIPO = new NonTerminal("DESIGN_TIPO");

            #endregion

            #region Gramatica

            INICIO.Rule = CONFIGURACION;

            CONFIGURACION.Rule = menor + _configuration + mayor + LISTA_CONFIGURACION + menor + slash + _configuration + mayor;

            LISTA_CONFIGURACION.Rule = LISTA_CONFIGURACION + BACKGROUND
                                      | LISTA_CONFIGURACION + FIGURE
                                      | LISTA_CONFIGURACION + DESIGN
                                      | BACKGROUND
                                      | FIGURE
                                      | DESIGN
                                      | Empty;

            BACKGROUND.Rule = menor + _background + mayor + LISTA_BACKGROUND + menor + slash + _background + mayor;

            FIGURE.Rule = menor + _figure + mayor + LISTA_FIGURE + menor + slash + _figure + mayor;

            DESIGN.Rule = menor + _design + mayor + LISTA_DESIGN + menor + slash + _design + mayor;

            LISTA_BACKGROUND.Rule = LISTA_BACKGROUND + coma + llaveAb + ATRIBUTOS_BACKGROUND + llaveCerr
                                | llaveAb + ATRIBUTOS_BACKGROUND + llaveCerr
                                | Empty;

            LISTA_FIGURE.Rule = LISTA_FIGURE + coma + llaveAb + ATRIBUTOS_FIGURE +llaveCerr
                                | llaveAb + ATRIBUTOS_FIGURE + llaveCerr
                                | Empty;

            LISTA_DESIGN.Rule = LISTA_DESIGN + coma + llaveAb + ATRIBUTOS_DESIGN +llaveCerr
                                | llaveAb + ATRIBUTOS_DESIGN + llaveCerr
                                | Empty;

            ATRIBUTOS_BACKGROUND.Rule = ATRIBUTOS_BACKGROUND + _x + guion + _nombre + igual + identificador + ptoYComa
                                       | ATRIBUTOS_BACKGROUND + _x + guion + _imagen + igual + cadena + ptoYComa
                                       | Empty;

            ATRIBUTOS_FIGURE.Rule = ATRIBUTOS_FIGURE + _x + guion + _nombre + igual + identificador + ptoYComa
                                   |ATRIBUTOS_FIGURE + _x + guion + _imagen + igual + cadena + ptoYComa
                                   |ATRIBUTOS_FIGURE + _x + guion + _vida + igual + EXPRESION + ptoYComa
                                   |ATRIBUTOS_FIGURE + _x + guion + _tipo + igual + _x + guion + FIGURE_TIPO + ptoYComa
                                   |ATRIBUTOS_FIGURE + _x + guion + _descripcion + igual + cadena + ptoYComa
                                   |ATRIBUTOS_FIGURE + _x + guion + _destruir + igual + EXPRESION + ptoYComa
                                   | Empty;

            ATRIBUTOS_DESIGN.Rule = ATRIBUTOS_DESIGN + _x + guion + _nombre + igual + identificador + ptoYComa
                                       | ATRIBUTOS_DESIGN + _x + guion + _destruir + igual + EXPRESION + ptoYComa
                                       | ATRIBUTOS_DESIGN + _x + guion + _imagen + igual + cadena + ptoYComa
                                       | ATRIBUTOS_DESIGN + _x + guion + _tipo + igual + _x + guion + DESIGN_TIPO + ptoYComa
                                       | ATRIBUTOS_DESIGN + _x + guion + _creditos + igual + EXPRESION + ptoYComa
                                       | Empty;

            FIGURE_TIPO.Rule = _heroe
                              |_enemigo
                              |identificador;

            DESIGN_TIPO.Rule = _meta
                             | _bloque
                             | _bomba
                             | _arma
                             | _bonus
                             | identificador;

            EXPRESION.Rule = EXPRESION + mas + EXPRESION
                             | EXPRESION + menos + EXPRESION
                             | EXPRESION + por + EXPRESION
                             | EXPRESION + slash + EXPRESION
                             | parentAb + EXPRESION + parentCerr
                             | signoMenos + EXPRESION
                             | signoMas + EXPRESION
                             | numero;

            #endregion

            #region Preferencias
            this.Root = INICIO;
            #endregion
         
            MarkPunctuation(menor, mayor,coma, llaveAb, llaveCerr, igual, ptoYComa, slash, parentAb, parentCerr );
            MarkPunctuation(_configuration, _background, _figure, _design,_x, guion);

            this.RegisterOperators(1, Associativity.Left, "+", "-");

            this.RegisterOperators(2, Associativity.Left, "*", "/");

            this.RegisterOperators(3, Associativity.Left, "-", "+");

        }
    }
}
