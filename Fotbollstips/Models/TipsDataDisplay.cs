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
        public string Finallag1_Color { get; set; }
        public string Finallag2 { get; set; }
        public string Finallag2_Color { get; set; }
        public string Vinnare { get; set; }
        public string Vinnare_Color { get; set; }

        // - - - - - TipsDataDisplay_Properities.txt - Code area starts - - - - - - - 
        public string Turkiet_Italien { get; set; }
        public string Turkiet_Italien_Color { get; set; }
        public string Wales_Schweiz { get; set; }
        public string Wales_Schweiz_Color { get; set; }
        public string Danmark_Finland { get; set; }
        public string Danmark_Finland_Color { get; set; }
        public string Belgien_Ryssland { get; set; }
        public string Belgien_Ryssland_Color { get; set; }
        public string England_Kroatien { get; set; }
        public string England_Kroatien_Color { get; set; }
        public string Österrike_Nordmakedonien { get; set; }
        public string Österrike_Nordmakedonien_Color { get; set; }
        public string Nederländerna_Ukraina { get; set; }
        public string Nederländerna_Ukraina_Color { get; set; }
        public string Skottland_Tjeckien { get; set; }
        public string Skottland_Tjeckien_Color { get; set; }
        public string Polen_Slovakien { get; set; }
        public string Polen_Slovakien_Color { get; set; }
        public string Spanien_Sverige { get; set; }
        public string Spanien_Sverige_Color { get; set; }
        public string Ungern_Portugal { get; set; }
        public string Ungern_Portugal_Color { get; set; }
        public string Frankrike_Tyskland { get; set; }
        public string Frankrike_Tyskland_Color { get; set; }
        public string Finland_Ryssland { get; set; }
        public string Finland_Ryssland_Color { get; set; }
        public string Turkiet_Wales { get; set; }
        public string Turkiet_Wales_Color { get; set; }
        public string Italien_Schweiz { get; set; }
        public string Italien_Schweiz_Color { get; set; }
        public string Ukraina_Nordmakedonien { get; set; }
        public string Ukraina_Nordmakedonien_Color { get; set; }
        public string Danmark_Belgien { get; set; }
        public string Danmark_Belgien_Color { get; set; }
        public string Nederländerna_Österrike { get; set; }
        public string Nederländerna_Österrike_Color { get; set; }
        public string Sverige_Slovakien { get; set; }
        public string Sverige_Slovakien_Color { get; set; }
        public string Kroatien_Tjeckien { get; set; }
        public string Kroatien_Tjeckien_Color { get; set; }
        public string England_Skottland { get; set; }
        public string England_Skottland_Color { get; set; }
        public string Ungern_Frankrike { get; set; }
        public string Ungern_Frankrike_Color { get; set; }
        public string Portugal_Tyskland { get; set; }
        public string Portugal_Tyskland_Color { get; set; }
        public string Spanien_Polen { get; set; }
        public string Spanien_Polen_Color { get; set; }
        public string Italien_Wales { get; set; }
        public string Italien_Wales_Color { get; set; }
        public string Schweiz_Turkiet { get; set; }
        public string Schweiz_Turkiet_Color { get; set; }
        public string Nordmakedonien_Nederländerna { get; set; }
        public string Nordmakedonien_Nederländerna_Color { get; set; }
        public string Ukraina_Österrike { get; set; }
        public string Ukraina_Österrike_Color { get; set; }
        public string Ryssland_Danmark { get; set; }
        public string Ryssland_Danmark_Color { get; set; }
        public string Finland_Belgien { get; set; }
        public string Finland_Belgien_Color { get; set; }
        public string Tjeckien_England { get; set; }
        public string Tjeckien_England_Color { get; set; }
        public string Kroatien_Skottland { get; set; }
        public string Kroatien_Skottland_Color { get; set; }
        public string Slovakien_Spaninen { get; set; }
        public string Slovakien_Spaninen_Color { get; set; }
        public string Sverige_Polen { get; set; }
        public string Sverige_Polen_Color { get; set; }
        public string Tyskland_Ungern { get; set; }
        public string Tyskland_Ungern_Color { get; set; }
        public string Portugal_Frankrike { get; set; }
        public string Portugal_Frankrike_Color { get; set; }




        // - - - - - TipsDataDisplay_Properities.txt - Code area ends - - - - - - - 

        public TipsDataDisplay(TipsData td)
        {
            Namn = td.Namn;
            Poäng = td.Poäng;
            Finallag1 = td.Finallag1;
            Finallag1_Color = string.Empty;
            Finallag2 = td.Finallag2;
            Finallag2_Color = string.Empty;
            Vinnare = td.Vinnare;
            Vinnare_Color = string.Empty;

            // - - - - - TipsDataDisplay_Constructor.txt - Code area starts - - - - - - - 
            Turkiet_Italien = td.Turkiet_Italien;
            Turkiet_Italien_Color = string.Empty;
            Wales_Schweiz = td.Wales_Schweiz;
            Wales_Schweiz_Color = string.Empty;
            Danmark_Finland = td.Danmark_Finland;
            Danmark_Finland_Color = string.Empty;
            Belgien_Ryssland = td.Belgien_Ryssland;
            Belgien_Ryssland_Color = string.Empty;
            England_Kroatien = td.England_Kroatien;
            England_Kroatien_Color = string.Empty;
            Österrike_Nordmakedonien = td.Österrike_Nordmakedonien;
            Österrike_Nordmakedonien_Color = string.Empty;
            Nederländerna_Ukraina = td.Nederländerna_Ukraina;
            Nederländerna_Ukraina_Color = string.Empty;
            Skottland_Tjeckien = td.Skottland_Tjeckien;
            Skottland_Tjeckien_Color = string.Empty;
            Polen_Slovakien = td.Polen_Slovakien;
            Polen_Slovakien_Color = string.Empty;
            Spanien_Sverige = td.Spanien_Sverige;
            Spanien_Sverige_Color = string.Empty;
            Ungern_Portugal = td.Ungern_Portugal;
            Ungern_Portugal_Color = string.Empty;
            Frankrike_Tyskland = td.Frankrike_Tyskland;
            Frankrike_Tyskland_Color = string.Empty;
            Finland_Ryssland = td.Finland_Ryssland;
            Finland_Ryssland_Color = string.Empty;
            Turkiet_Wales = td.Turkiet_Wales;
            Turkiet_Wales_Color = string.Empty;
            Italien_Schweiz = td.Italien_Schweiz;
            Italien_Schweiz_Color = string.Empty;
            Ukraina_Nordmakedonien = td.Ukraina_Nordmakedonien;
            Ukraina_Nordmakedonien_Color = string.Empty;
            Danmark_Belgien = td.Danmark_Belgien;
            Danmark_Belgien_Color = string.Empty;
            Nederländerna_Österrike = td.Nederländerna_Österrike;
            Nederländerna_Österrike_Color = string.Empty;
            Sverige_Slovakien = td.Sverige_Slovakien;
            Sverige_Slovakien_Color = string.Empty;
            Kroatien_Tjeckien = td.Kroatien_Tjeckien;
            Kroatien_Tjeckien_Color = string.Empty;
            England_Skottland = td.England_Skottland;
            England_Skottland_Color = string.Empty;
            Ungern_Frankrike = td.Ungern_Frankrike;
            Ungern_Frankrike_Color = string.Empty;
            Portugal_Tyskland = td.Portugal_Tyskland;
            Portugal_Tyskland_Color = string.Empty;
            Spanien_Polen = td.Spanien_Polen;
            Spanien_Polen_Color = string.Empty;
            Italien_Wales = td.Italien_Wales;
            Italien_Wales_Color = string.Empty;
            Schweiz_Turkiet = td.Schweiz_Turkiet;
            Schweiz_Turkiet_Color = string.Empty;
            Nordmakedonien_Nederländerna = td.Nordmakedonien_Nederländerna;
            Nordmakedonien_Nederländerna_Color = string.Empty;
            Ukraina_Österrike = td.Ukraina_Österrike;
            Ukraina_Österrike_Color = string.Empty;
            Ryssland_Danmark = td.Ryssland_Danmark;
            Ryssland_Danmark_Color = string.Empty;
            Finland_Belgien = td.Finland_Belgien;
            Finland_Belgien_Color = string.Empty;
            Tjeckien_England = td.Tjeckien_England;
            Tjeckien_England_Color = string.Empty;
            Kroatien_Skottland = td.Kroatien_Skottland;
            Kroatien_Skottland_Color = string.Empty;
            Slovakien_Spaninen = td.Slovakien_Spaninen;
            Slovakien_Spaninen_Color = string.Empty;
            Sverige_Polen = td.Sverige_Polen;
            Sverige_Polen_Color = string.Empty;
            Tyskland_Ungern = td.Tyskland_Ungern;
            Tyskland_Ungern_Color = string.Empty;
            Portugal_Frankrike = td.Portugal_Frankrike;
            Portugal_Frankrike_Color = string.Empty;




            // - - - - - TipsDataDisplay_Constructor.txt - Code area ends - - - - - - - 
        }
    }
}