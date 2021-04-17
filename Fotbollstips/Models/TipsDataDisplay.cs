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

        public string Frankrike_Sydkorea { get; set; }
        public string Tyskland_Kina { get; set; }
        public string Spanien_Sydafrika { get; set; }
        public string Norge_Nigeria { get; set; }
        public string Australien_Italien { get; set; }
        public string Brasilien_Jamaica { get; set; }
        public string England_Skottland { get; set; }
        public string Argentina_Japan { get; set; }
        public string Kanada_Kamerun { get; set; }
        public string NyaZeeland_Nederländerna { get; set; }
        public string Chile_Sverige { get; set; }
        public string Usa_Thailand { get; set; }
        public string Nigeria_Sydkorea { get; set; }
        public string Tyskland_Spanien { get; set; }
        public string Frankrike_Norge { get; set; }
        public string Australien_Brasilien { get; set; }
        public string Sydafrika_Kina { get; set; }
        public string Japan_Skottland { get; set; }
        public string Jamaica_Italien { get; set; }
        public string England_Argentina { get; set; }
        public string Nederländerna_Kamerun { get; set; }
        public string Kanada_NyaZeeland { get; set; }
        public string Sverige_Thailand { get; set; }
        public string Usa_Chile { get; set; }
        public string Kina_Spanien { get; set; }
        public string Sydafrika_Tyskland { get; set; }
        public string Nigeria_Frankrike { get; set; }
        public string Sydkorea_Norge { get; set; }
        public string Italien_Brasilien { get; set; }
        public string Jamaica_Australien { get; set; }
        public string Japan_England { get; set; }
        public string Skottland_Argentina { get; set; }
        public string Nederländerna_Kanada { get; set; }
        public string Kamerun_NyaZeeland { get; set; }
        public string Sverige_Usa { get; set; }
        public string Thailand_Chile { get; set; }



        // - - - - - TipsDataDisplay_Properities.txt - Code area ends - - - - - - - 

        public TipsDataDisplay(TipsData td)
        {
            Namn = td.Namn;
            Poäng = td.Poäng;
            Finallag1 = td.Finallag1;
            Finallag2 = td.Finallag2;
            Vinnare = td.Vinnare;

            // - - - - - TipsDataDisplay_Constructor.txt - Code area starts - - - - - - - 
            Frankrike_Sydkorea = td.Frankrike_Sydkorea;
            Tyskland_Kina = td.Tyskland_Kina;
            Spanien_Sydafrika = td.Spanien_Sydafrika;
            Norge_Nigeria = td.Norge_Nigeria;
            Australien_Italien = td.Australien_Italien;
            Brasilien_Jamaica = td.Brasilien_Jamaica;
            England_Skottland = td.England_Skottland;
            Argentina_Japan = td.Argentina_Japan;
            Kanada_Kamerun = td.Kanada_Kamerun;
            NyaZeeland_Nederländerna = td.NyaZeeland_Nederländerna;
            Chile_Sverige = td.Chile_Sverige;
            Usa_Thailand = td.Usa_Thailand;
            Nigeria_Sydkorea = td.Nigeria_Sydkorea;
            Tyskland_Spanien = td.Tyskland_Spanien;
            Frankrike_Norge = td.Frankrike_Norge;
            Australien_Brasilien = td.Australien_Brasilien;
            Sydafrika_Kina = td.Sydafrika_Kina;
            Japan_Skottland = td.Japan_Skottland;
            Jamaica_Italien = td.Jamaica_Italien;
            England_Argentina = td.England_Argentina;
            Nederländerna_Kamerun = td.Nederländerna_Kamerun;
            Kanada_NyaZeeland = td.Kanada_NyaZeeland;
            Sverige_Thailand = td.Sverige_Thailand;
            Usa_Chile = td.Usa_Chile;
            Kina_Spanien = td.Kina_Spanien;
            Sydafrika_Tyskland = td.Sydafrika_Tyskland;
            Nigeria_Frankrike = td.Nigeria_Frankrike;
            Sydkorea_Norge = td.Sydkorea_Norge;
            Italien_Brasilien = td.Italien_Brasilien;
            Jamaica_Australien = td.Jamaica_Australien;
            Japan_England = td.Japan_England;
            Skottland_Argentina = td.Skottland_Argentina;
            Nederländerna_Kanada = td.Nederländerna_Kanada;
            Kamerun_NyaZeeland = td.Kamerun_NyaZeeland;
            Sverige_Usa = td.Sverige_Usa;
            Thailand_Chile = td.Thailand_Chile;



            // - - - - - TipsDataDisplay_Constructor.txt - Code area ends - - - - - - - 
        }
    }
}