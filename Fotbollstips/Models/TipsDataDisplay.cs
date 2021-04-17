using Fotbollstips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fotbollstips.Models
{
    public class TipsDataDisplay
    {
        public string Namn { get; set; }
        public int? Poäng { get; set; }
        public string Finallag1 { get; set; }
        public string Finallag2 { get; set; }
        public string Vinnare { get; set; }

        // - - - - - TipsDataDisplay_Properities.txt - Code area starts - - - - - - - 
        public string Turkiet_Italien { get; set; }
        public string Wales_Schweiz { get; set; }
        public string Danmark_Finland { get; set; }
        public string Belgien_Ryssland { get; set; }
        public string England_Kroatien { get; set; }
        public string Österrike_Nordmakedonien { get; set; }
        public string Nederländerna_Ukraina { get; set; }
        public string Skottland_Tjeckien { get; set; }
        public string Polen_Slovakien { get; set; }
        public string Spanien_Sverige { get; set; }
        public string Ungern_Portugal { get; set; }
        public string Frankrike_Tyskland { get; set; }
        public string Finland_Ryssland { get; set; }
        public string Turkiet_Wales { get; set; }
        public string Italien_Schweiz { get; set; }
        public string Ukraina_Nordmakedonien { get; set; }
        public string Danmark_Belgien { get; set; }
        public string Nederländerna_Österrike { get; set; }
        public string Sverige_Slovakien { get; set; }
        public string Kroatien_Tjeckien { get; set; }
        public string England_Skottland { get; set; }
        public string Ungern_Frankrike { get; set; }
        public string Portugal_Tyskland { get; set; }
        public string Spanien_Polen { get; set; }
        public string Italien_Wales { get; set; }
        public string Schweiz_Turkiet { get; set; }
        public string Nordmakedonien_Nederländerna { get; set; }
        public string Ukraina_Österrike { get; set; }
        public string Ryssland_Danmark { get; set; }
        public string Finland_Belgien { get; set; }
        public string Tjeckien_England { get; set; }
        public string Kroatien_Skottland { get; set; }
        public string Slovakien_Spaninen { get; set; }
        public string Sverige_Polen { get; set; }
        public string Tyskland_Ungern { get; set; }
        public string Portugal_Frankrike { get; set; }



        // - - - - - TipsDataDisplay_Properities.txt - Code area ends - - - - - - - 

        public TipsDataDisplay(TipsData td)
        {
            Namn = td.Namn;
            Poäng = td.Poäng;
            Finallag1 = td.Finallag1;
            Finallag2 = td.Finallag2;
            Vinnare = td.Vinnare;

            // - - - - - TipsDataDisplay_Constructor.txt - Code area starts - - - - - - - 
            Turkiet_Italien = td.Turkiet_Italien;
            Wales_Schweiz = td.Wales_Schweiz;
            Danmark_Finland = td.Danmark_Finland;
            Belgien_Ryssland = td.Belgien_Ryssland;
            England_Kroatien = td.England_Kroatien;
            Österrike_Nordmakedonien = td.Österrike_Nordmakedonien;
            Nederländerna_Ukraina = td.Nederländerna_Ukraina;
            Skottland_Tjeckien = td.Skottland_Tjeckien;
            Polen_Slovakien = td.Polen_Slovakien;
            Spanien_Sverige = td.Spanien_Sverige;
            Ungern_Portugal = td.Ungern_Portugal;
            Frankrike_Tyskland = td.Frankrike_Tyskland;
            Finland_Ryssland = td.Finland_Ryssland;
            Turkiet_Wales = td.Turkiet_Wales;
            Italien_Schweiz = td.Italien_Schweiz;
            Ukraina_Nordmakedonien = td.Ukraina_Nordmakedonien;
            Danmark_Belgien = td.Danmark_Belgien;
            Nederländerna_Österrike = td.Nederländerna_Österrike;
            Sverige_Slovakien = td.Sverige_Slovakien;
            Kroatien_Tjeckien = td.Kroatien_Tjeckien;
            England_Skottland = td.England_Skottland;
            Ungern_Frankrike = td.Ungern_Frankrike;
            Portugal_Tyskland = td.Portugal_Tyskland;
            Spanien_Polen = td.Spanien_Polen;
            Italien_Wales = td.Italien_Wales;
            Schweiz_Turkiet = td.Schweiz_Turkiet;
            Nordmakedonien_Nederländerna = td.Nordmakedonien_Nederländerna;
            Ukraina_Österrike = td.Ukraina_Österrike;
            Ryssland_Danmark = td.Ryssland_Danmark;
            Finland_Belgien = td.Finland_Belgien;
            Tjeckien_England = td.Tjeckien_England;
            Kroatien_Skottland = td.Kroatien_Skottland;
            Slovakien_Spaninen = td.Slovakien_Spaninen;
            Sverige_Polen = td.Sverige_Polen;
            Tyskland_Ungern = td.Tyskland_Ungern;
            Portugal_Frankrike = td.Portugal_Frankrike;



            // - - - - - TipsDataDisplay_Constructor.txt - Code area ends - - - - - - - 
        }
    }
}