using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201325674.sol.com.analizador2
{
    class Gramatica2 : Grammar
    {
        public Gramatica2() : base(caseSensitive: false)
        {

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
            var guion = ToTerm("-");
            var guionBajo = ToTerm("_");
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var parentAb = ToTerm("(");
            var parentCerr = ToTerm(")");
            var igual = ToTerm("=");
            var ptoYcoma = ToTerm(";");
            var punto = ToTerm(".");

            #endregion

            #region PalabrasReservadas
            KeyTerm _x = ToTerm("x");
            KeyTerm _escenarios = ToTerm("escenarios");
            KeyTerm _background = ToTerm("background");
            KeyTerm _alto = ToTerm("alto");
            KeyTerm _ancho = ToTerm("ancho");
            KeyTerm _personajes = ToTerm("personajes");
            KeyTerm _heroes = ToTerm("heroes");
            KeyTerm _villanos = ToTerm("villanos");
            KeyTerm _paredes = ToTerm("paredes");
            KeyTerm _meta = ToTerm("meta");
            KeyTerm _extras = ToTerm("extras");
            KeyTerm _suelo = ToTerm("suelo");
            KeyTerm _armas = ToTerm("armas");
            KeyTerm _bonus = ToTerm("bonus");
            
            #endregion

            #region No Terminales
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal ESCENARIOS = new NonTerminal("ESCENARIOS");
            NonTerminal CUERPO_ESCENARIO = new NonTerminal("CUERPO_ESCENARIO");
            NonTerminal EXPRESION = new NonTerminal("EXPRESION");
            NonTerminal PERSONAJES = new NonTerminal("PERSONAJES");
            NonTerminal PAREDES = new NonTerminal("PAREDES");
            NonTerminal EXTRAS = new NonTerminal("EXTRAS");
            NonTerminal META = new NonTerminal("META");
            NonTerminal LISTA_ESCENARIO = new NonTerminal("LISTA_ESCENARIO");
            NonTerminal LISTA_PERSONAJES = new NonTerminal("LISTA_PERSONAJES");
            NonTerminal LISTA_PAREDES = new NonTerminal("LISTA_PAREDES");
            NonTerminal TIPO_PERSONAJES = new NonTerminal("TIPO_PERSONAJES");
            NonTerminal HEROES = new NonTerminal("HEROES");
            NonTerminal VILLANOS = new NonTerminal("VILLANOS");
            NonTerminal LISTA_VILLANOS = new NonTerminal("LISTA_VILLANOS");
            NonTerminal LISTA_HEROES = new NonTerminal("LISTA_HEROES");
            NonTerminal POSICIONES_X_Y_OBJETOS = new NonTerminal("POSICIONES_X_Y_OBJETOS");
            NonTerminal ATRIBUTOS_LISTA_PAREDES = new NonTerminal("ATRIBUTOS_LISTA_PAREDES");
            NonTerminal LISTA_EXTRAS = new NonTerminal("LISTA_EXTRAS");
            NonTerminal ATRIBUTOS_LISTA_EXTRAS = new NonTerminal("ATRIBUTOS_LISTA_EXTRAS");
            NonTerminal TIPO_OBJETOS = new NonTerminal("TIPO_OBJETOS");
            NonTerminal FINALESCENARIO = new NonTerminal("FINALESCENARIO");
            NonTerminal ARMAS = new NonTerminal("ARMAS");
            NonTerminal BONUS = new NonTerminal("BONUS");

            #endregion

            #region Gramatica

            INICIO.Rule = ESCENARIOS;

            ESCENARIOS.Rule = menor + _x + guion + _escenarios + _background + igual + identificador + ptoYcoma + _ancho + igual + EXPRESION
                              + ptoYcoma + _alto + igual + EXPRESION + mayor + CUERPO_ESCENARIO;

            CUERPO_ESCENARIO.Rule = LISTA_ESCENARIO + FINALESCENARIO
                                   |FINALESCENARIO;

            FINALESCENARIO.Rule = menor + slash + _x + guion + _escenarios + mayor;

            LISTA_ESCENARIO.Rule = LISTA_ESCENARIO + menor + _x + guion + TIPO_OBJETOS
                      | menor + _x + guion + TIPO_OBJETOS
                      | Empty;

            TIPO_OBJETOS.Rule = PERSONAJES
                               | PAREDES
                               | EXTRAS
                               | META;

            PAREDES.Rule = _paredes + mayor + LISTA_PAREDES + menor + slash + _x + guion + _paredes + mayor;

            EXTRAS.Rule = _extras + mayor + LISTA_EXTRAS + menor + slash + _x + guion + _extras + mayor;

            META.Rule =  _meta + mayor + POSICIONES_X_Y_OBJETOS + menor +  slash + _x + guion + _meta + mayor;

            PERSONAJES.Rule = _personajes + mayor + LISTA_PERSONAJES + menor + slash + _x + guion + _personajes + mayor;

            LISTA_PERSONAJES.Rule = LISTA_PERSONAJES + menor + _x + guion +  TIPO_PERSONAJES
                                   |TIPO_PERSONAJES
                                   |Empty;

            TIPO_PERSONAJES.Rule = HEROES
                                  |VILLANOS;

            HEROES.Rule =  _heroes + mayor + POSICIONES_X_Y_OBJETOS + menor + slash + _x + guion + _heroes + mayor;

            VILLANOS.Rule = _villanos + mayor + POSICIONES_X_Y_OBJETOS + menor + slash + _x + guion + _villanos + mayor;


            POSICIONES_X_Y_OBJETOS.Rule = POSICIONES_X_Y_OBJETOS + identificador + parentAb + EXPRESION + coma + EXPRESION + parentCerr + ptoYcoma
                                             |identificador + parentAb + EXPRESION + coma + EXPRESION + parentCerr + ptoYcoma
                                             |Empty;

            LISTA_PAREDES.Rule = LISTA_PAREDES + ATRIBUTOS_LISTA_PAREDES
                                |ATRIBUTOS_LISTA_PAREDES
                                |Empty;

            ATRIBUTOS_LISTA_PAREDES.Rule =identificador + parentAb + EXPRESION + coma + EXPRESION + parentCerr + ptoYcoma
                                         |identificador + parentAb + EXPRESION + punto + punto +EXPRESION + coma + EXPRESION + parentCerr + ptoYcoma
                                         |identificador + parentAb + EXPRESION + coma + EXPRESION + punto + punto + EXPRESION + parentCerr + ptoYcoma;


            LISTA_EXTRAS.Rule =  LISTA_EXTRAS + ATRIBUTOS_LISTA_EXTRAS
                                |ATRIBUTOS_LISTA_EXTRAS
                                |Empty;

            ARMAS.Rule = menor + _x + guion +_armas + mayor + POSICIONES_X_Y_OBJETOS + menor + slash + _x + guion + _armas + mayor;

            BONUS.Rule = menor + _x + guion + _bonus + mayor + POSICIONES_X_Y_OBJETOS + menor + slash + _x + guion + _bonus + mayor;

            ATRIBUTOS_LISTA_EXTRAS.Rule = ARMAS
                                         |BONUS;

            EXPRESION.Rule = EXPRESION + mas + EXPRESION
                            | EXPRESION + menos + EXPRESION
                            | EXPRESION + por + EXPRESION
                            | EXPRESION + slash + EXPRESION
                            | parentAb + EXPRESION + parentCerr
                            | mas + EXPRESION
                            | menos + EXPRESION
                            | numero;
            #endregion

            #region Preferencias
            this.Root = INICIO;
            #endregion

            MarkPunctuation(mayor, menor, igual, _x, guion, ptoYcoma, parentAb, parentCerr,_personajes,_paredes,_extras,_meta,
                            coma, _heroes, _villanos, _armas, _bonus, _meta);

            }
        }
    }
