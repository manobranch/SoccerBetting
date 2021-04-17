using Fotbollstips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fotbollstips.Logic
{
    public class DataLogic
    {
        public static string RATT_SVAR = "Rätt svar";

        public static List<TipsData> GetDataForPresentation()
        {
            try
            {
                // Get raw data
                List<TipsData> rawData = GetTipsRawData();

                // Calculate points
                List<TipsData> calculatedPoints = CalculatePoints(rawData);

                // Sort list by points
                List<TipsData> sortedList = calculatedPoints.OrderByDescending(o => o.Poäng).ToList();

                // Manipulate text string 
                List<TipsData> returnList = ManipulateTextStrings(sortedList);

                return returnList;
            }
            catch (Exception e)
            {
                Log4NetLogic.Log(Log4NetLogic.LogLevel.ERROR, "An error in", "GetDataForPresentation", e);

                return null;
            }
        }

        public static string GetRandomValue(string name)
        {
            try
            {
                using (var db = new FotbollsTipsModel())
                {
                    var result = (from hits in db.TipsRandomValues
                                  where hits.Name == name
                                  select hits).FirstOrDefault();

                    return result.Value;
                }
            }
            catch (Exception e)
            {
                Log4NetLogic.Log(Log4NetLogic.LogLevel.ERROR, "An error in", "GetRandomValue", e);

                throw;
            }

        }
        public static bool UpdateRandomValue(string name, string value)
        {
            try
            {
                using (var db = new FotbollsTipsModel())
                {
                    var result = (from hits in db.TipsRandomValues
                                  where hits.Name == name
                                  select hits).FirstOrDefault();

                    result.Value = value;
                    result.Modified = DateTime.Now;

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                Log4NetLogic.Log(Log4NetLogic.LogLevel.ERROR, "An error in", "UpdateRandomValue", e);

                return false;
            }

        }

        private static List<TipsData> GetTipsRawData()
        {
            using (var db = new FotbollsTipsModel())
            {
                var result = (from hits in db.TipsDatas
                              select hits).ToList();

                return result;
            }
        }

        public static TipsData GetRattSvarEntity()
        {
            var result = GetTipsRawData();

            var output = (from hits in result
                          where hits.Namn == RATT_SVAR
                          select hits).FirstOrDefault();

            return output;
        }


        private static List<TipsData> CalculatePoints(List<TipsData> data)
        {
            var correct = (from hits in data
                           where hits.Namn == RATT_SVAR
                           select hits).FirstOrDefault();

            data = (from hits in data
                    where hits.Id == 8 || hits.Id == 23
                    select hits).ToList();

            foreach (var item in data)
            {
                if (item.Namn == RATT_SVAR)
                {
                    item.Poäng = 39;
                    continue;
                }
                int points = 0;

                #region compare games


                // - - - - - DataLogic_CalculatePoints.txt - Code area starts - - - - - - - 

                if (item.Frankrike_Sydkorea == correct.Frankrike_Sydkorea)
                    points++;

                if (item.Tyskland_Kina == correct.Tyskland_Kina)
                    points++;

                if (item.Spanien_Sydafrika == correct.Spanien_Sydafrika)
                    points++;

                if (item.Norge_Nigeria == correct.Norge_Nigeria)
                    points++;

                if (item.Australien_Italien == correct.Australien_Italien)
                    points++;

                if (item.Brasilien_Jamaica == correct.Brasilien_Jamaica)
                    points++;

                if (item.England_Skottland == correct.England_Skottland)
                    points++;

                if (item.Argentina_Japan == correct.Argentina_Japan)
                    points++;

                if (item.Kanada_Kamerun == correct.Kanada_Kamerun)
                    points++;

                if (item.NyaZeeland_Nederländerna == correct.NyaZeeland_Nederländerna)
                    points++;

                if (item.Chile_Sverige == correct.Chile_Sverige)
                    points++;

                if (item.Usa_Thailand == correct.Usa_Thailand)
                    points++;

                if (item.Nigeria_Sydkorea == correct.Nigeria_Sydkorea)
                    points++;

                if (item.Tyskland_Spanien == correct.Tyskland_Spanien)
                    points++;

                if (item.Frankrike_Norge == correct.Frankrike_Norge)
                    points++;

                if (item.Australien_Brasilien == correct.Australien_Brasilien)
                    points++;

                if (item.Sydafrika_Kina == correct.Sydafrika_Kina)
                    points++;

                if (item.Japan_Skottland == correct.Japan_Skottland)
                    points++;

                if (item.Jamaica_Italien == correct.Jamaica_Italien)
                    points++;

                if (item.England_Argentina == correct.England_Argentina)
                    points++;

                if (item.Nederländerna_Kamerun == correct.Nederländerna_Kamerun)
                    points++;

                if (item.Kanada_NyaZeeland == correct.Kanada_NyaZeeland)
                    points++;

                if (item.Sverige_Thailand == correct.Sverige_Thailand)
                    points++;

                if (item.Usa_Chile == correct.Usa_Chile)
                    points++;

                if (item.Kina_Spanien == correct.Kina_Spanien)
                    points++;

                if (item.Sydafrika_Tyskland == correct.Sydafrika_Tyskland)
                    points++;

                if (item.Nigeria_Frankrike == correct.Nigeria_Frankrike)
                    points++;

                if (item.Sydkorea_Norge == correct.Sydkorea_Norge)
                    points++;

                if (item.Italien_Brasilien == correct.Italien_Brasilien)
                    points++;

                if (item.Jamaica_Australien == correct.Jamaica_Australien)
                    points++;

                if (item.Japan_England == correct.Japan_England)
                    points++;

                if (item.Skottland_Argentina == correct.Skottland_Argentina)
                    points++;

                if (item.Nederländerna_Kanada == correct.Nederländerna_Kanada)
                    points++;

                if (item.Kamerun_NyaZeeland == correct.Kamerun_NyaZeeland)
                    points++;

                if (item.Sverige_Usa == correct.Sverige_Usa)
                    points++;

                if (item.Thailand_Chile == correct.Thailand_Chile)
                    points++;








                // - - - - - DataLogic_CalculatePoints.txt - Code area ends - - - - - - - 


                if (CompareFinal(item.Finallag1, correct.Finallag1))
                    points++;

                if (CompareFinal(item.Finallag2, correct.Finallag2))
                    points++;

                if (CompareFinal(item.Vinnare, correct.Vinnare))
                    points++;

                #endregion

                item.Poäng = points;
            }

            return data;
        }

        private static bool CompareFinal(string finalTeam, string correctAnswer)
        {
            var correctTeams = correctAnswer.Split('-').ToList();

            foreach (var item in correctTeams.ToList())
            {
                if (item.ToString() == finalTeam)
                {
                    return true;
                }
            }

            return false;
        }

        private static List<TipsData> ManipulateTextStrings(List<TipsData> data)
        {
            foreach (var item in data)
            {
                // - - - - - DataLogic_ManipulateTextStrings.txt - Code area starts - - - - - - - 

                item.Frankrike_Sydkorea = item.Frankrike_Sydkorea.Insert(1, "-");
                item.Tyskland_Kina = item.Tyskland_Kina.Insert(1, "-");
                item.Spanien_Sydafrika = item.Spanien_Sydafrika.Insert(1, "-");
                item.Norge_Nigeria = item.Norge_Nigeria.Insert(1, "-");
                item.Australien_Italien = item.Australien_Italien.Insert(1, "-");
                item.Brasilien_Jamaica = item.Brasilien_Jamaica.Insert(1, "-");
                item.England_Skottland = item.England_Skottland.Insert(1, "-");
                item.Argentina_Japan = item.Argentina_Japan.Insert(1, "-");
                item.Kanada_Kamerun = item.Kanada_Kamerun.Insert(1, "-");
                item.NyaZeeland_Nederländerna = item.NyaZeeland_Nederländerna.Insert(1, "-");
                item.Chile_Sverige = item.Chile_Sverige.Insert(1, "-");
                item.Usa_Thailand = item.Usa_Thailand.Insert(1, "-");
                item.Nigeria_Sydkorea = item.Nigeria_Sydkorea.Insert(1, "-");
                item.Tyskland_Spanien = item.Tyskland_Spanien.Insert(1, "-");
                item.Frankrike_Norge = item.Frankrike_Norge.Insert(1, "-");
                item.Australien_Brasilien = item.Australien_Brasilien.Insert(1, "-");
                item.Sydafrika_Kina = item.Sydafrika_Kina.Insert(1, "-");
                item.Japan_Skottland = item.Japan_Skottland.Insert(1, "-");
                item.Jamaica_Italien = item.Jamaica_Italien.Insert(1, "-");
                item.England_Argentina = item.England_Argentina.Insert(1, "-");
                item.Nederländerna_Kamerun = item.Nederländerna_Kamerun.Insert(1, "-");
                item.Kanada_NyaZeeland = item.Kanada_NyaZeeland.Insert(1, "-");
                item.Sverige_Thailand = item.Sverige_Thailand.Insert(1, "-");
                item.Usa_Chile = item.Usa_Chile.Insert(1, "-");
                item.Kina_Spanien = item.Kina_Spanien.Insert(1, "-");
                item.Sydafrika_Tyskland = item.Sydafrika_Tyskland.Insert(1, "-");
                item.Nigeria_Frankrike = item.Nigeria_Frankrike.Insert(1, "-");
                item.Sydkorea_Norge = item.Sydkorea_Norge.Insert(1, "-");
                item.Italien_Brasilien = item.Italien_Brasilien.Insert(1, "-");
                item.Jamaica_Australien = item.Jamaica_Australien.Insert(1, "-");
                item.Japan_England = item.Japan_England.Insert(1, "-");
                item.Skottland_Argentina = item.Skottland_Argentina.Insert(1, "-");
                item.Nederländerna_Kanada = item.Nederländerna_Kanada.Insert(1, "-");
                item.Kamerun_NyaZeeland = item.Kamerun_NyaZeeland.Insert(1, "-");
                item.Sverige_Usa = item.Sverige_Usa.Insert(1, "-");
                item.Thailand_Chile = item.Thailand_Chile.Insert(1, "-");

                // - - - - - DataLogic_ManipulateTextStrings.txt - Code area ends - - - - - - - 
            }

            return data;
        }

        public static bool SaveCorrectAnswers(TipsData model)
        {
            using (var db = new FotbollsTipsModel())
            {
                var result = (from hits in db.TipsDatas
                              where hits.Namn == DataLogic.RATT_SVAR
                              select hits).FirstOrDefault();

                result.Finallag1 = model.Finallag1;
                result.Finallag2 = model.Finallag2;
                result.Vinnare = model.Vinnare;

                // - - - - - DataLogic_SaveCorrectAnswers.txt - Code area starts - - - - - - - 
                result.Frankrike_Sydkorea = model.Frankrike_Sydkorea;
                result.Tyskland_Kina = model.Tyskland_Kina;
                result.Spanien_Sydafrika = model.Spanien_Sydafrika;
                result.Norge_Nigeria = model.Norge_Nigeria;
                result.Australien_Italien = model.Australien_Italien;
                result.Brasilien_Jamaica = model.Brasilien_Jamaica;
                result.England_Skottland = model.England_Skottland;
                result.Argentina_Japan = model.Argentina_Japan;
                result.Kanada_Kamerun = model.Kanada_Kamerun;
                result.NyaZeeland_Nederländerna = model.NyaZeeland_Nederländerna;
                result.Chile_Sverige = model.Chile_Sverige;
                result.Usa_Thailand = model.Usa_Thailand;
                result.Nigeria_Sydkorea = model.Nigeria_Sydkorea;
                result.Tyskland_Spanien = model.Tyskland_Spanien;
                result.Frankrike_Norge = model.Frankrike_Norge;
                result.Australien_Brasilien = model.Australien_Brasilien;
                result.Sydafrika_Kina = model.Sydafrika_Kina;
                result.Japan_Skottland = model.Japan_Skottland;
                result.Jamaica_Italien = model.Jamaica_Italien;
                result.England_Argentina = model.England_Argentina;
                result.Nederländerna_Kamerun = model.Nederländerna_Kamerun;
                result.Kanada_NyaZeeland = model.Kanada_NyaZeeland;
                result.Sverige_Thailand = model.Sverige_Thailand;
                result.Usa_Chile = model.Usa_Chile;
                result.Kina_Spanien = model.Kina_Spanien;
                result.Sydafrika_Tyskland = model.Sydafrika_Tyskland;
                result.Nigeria_Frankrike = model.Nigeria_Frankrike;
                result.Sydkorea_Norge = model.Sydkorea_Norge;
                result.Italien_Brasilien = model.Italien_Brasilien;
                result.Jamaica_Australien = model.Jamaica_Australien;
                result.Japan_England = model.Japan_England;
                result.Skottland_Argentina = model.Skottland_Argentina;
                result.Nederländerna_Kanada = model.Nederländerna_Kanada;
                result.Kamerun_NyaZeeland = model.Kamerun_NyaZeeland;
                result.Sverige_Usa = model.Sverige_Usa;
                result.Thailand_Chile = model.Thailand_Chile;



                // - - - - - DataLogic_SaveCorrectAnswers.txt - Code area ends - - - - - - - 

                db.SaveChanges();
            }

            return true;
        }

        public static bool SaveUpdatedPaymentStatus(List<int> idsWhoHasPayed)
        {
            try
            {
                using (var db = new FotbollsTipsModel())
                {
                    foreach (var item in idsWhoHasPayed)
                    {
                        var tipsData = (from hits in db.TipsDatas
                                        where hits.Id == item
                                        select hits).FirstOrDefault();

                        tipsData.HasPayed = true;
                    }

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                Log4NetLogic.Log(Log4NetLogic.LogLevel.ERROR, "An error in", "SaveUpdatedPaymentStatus", e);

                return false;
            }
        }

        public static List<TipsComment> GetComments()
        {
            using (var db = new FotbollsTipsModel())
            {
                var result = (from hits in db.TipsComments
                              select hits).ToList();

                return result;
            }
        }

        public static bool SaveComment(TipsComment model)
        {
            using (var db = new FotbollsTipsModel())
            {
                var comment = new TipsComment()
                {
                    Name = model.Name,
                    Comment = model.Comment,
                    EntryDate = DateTime.Now
                };

                db.TipsComments.Add(comment);
                db.SaveChanges();
            }

            return true;
        }
        private static void SaveTipsDataToLogFile(TipsData t)
        {
            var logText = string.Format("Namn: {0}, Telefon: {1}, mail: {2}. ", t.Namn, t.PhoneNumber, t.Email);

            // - - - - - DataLogic_SaveTipsDataToLogFile.txt - Code area starts - - - - - - - 

            logText += string.Format("Frankrike_Sydkorea: {0},", t.Frankrike_Sydkorea);
            logText += string.Format("Tyskland_Kina: {0},", t.Tyskland_Kina);
            logText += string.Format("Spanien_Sydafrika: {0},", t.Spanien_Sydafrika);
            logText += string.Format("Norge_Nigeria: {0},", t.Norge_Nigeria);
            logText += string.Format("Australien_Italien: {0},", t.Australien_Italien);
            logText += string.Format("Brasilien_Jamaica: {0},", t.Brasilien_Jamaica);
            logText += string.Format("England_Skottland: {0},", t.England_Skottland);
            logText += string.Format("Argentina_Japan: {0},", t.Argentina_Japan);
            logText += string.Format("Kanada_Kamerun: {0},", t.Kanada_Kamerun);
            logText += string.Format("Nya Zeeland_Nederländerna: {0},", t.NyaZeeland_Nederländerna);
            logText += string.Format("Chile_Sverige: {0},", t.Chile_Sverige);
            logText += string.Format("Usa_Thailand: {0},", t.Usa_Thailand);
            logText += string.Format("Nigeria_Sydkorea: {0},", t.Nigeria_Sydkorea);
            logText += string.Format("Tyskland_Spanien: {0},", t.Tyskland_Spanien);
            logText += string.Format("Frankrike_Norge: {0},", t.Frankrike_Norge);
            logText += string.Format("Australien_Brasilien: {0},", t.Australien_Brasilien);
            logText += string.Format("Sydafrika_Kina: {0},", t.Sydafrika_Kina);
            logText += string.Format("Japan_Skottland: {0},", t.Japan_Skottland);
            logText += string.Format("Jamaica_Italien: {0},", t.Jamaica_Italien);
            logText += string.Format("England_Argentina: {0},", t.England_Argentina);
            logText += string.Format("Nederländerna_Kamerun: {0},", t.Nederländerna_Kamerun);
            logText += string.Format("Kanada_Nya Zeeland: {0},", t.Kanada_NyaZeeland);
            logText += string.Format("Sverige_Thailand: {0},", t.Sverige_Thailand);
            logText += string.Format("Usa_Chile: {0},", t.Usa_Chile);
            logText += string.Format("Kina_Spanien: {0},", t.Kina_Spanien);
            logText += string.Format("Sydafrika_Tyskland: {0},", t.Sydafrika_Tyskland);
            logText += string.Format("Nigeria_Frankrike: {0},", t.Nigeria_Frankrike);
            logText += string.Format("Sydkorea_Norge: {0},", t.Sydkorea_Norge);
            logText += string.Format("Italien_Brasilien: {0},", t.Italien_Brasilien);
            logText += string.Format("Jamaica_Australien: {0},", t.Jamaica_Australien);
            logText += string.Format("Japan_England: {0},", t.Japan_England);
            logText += string.Format("Skottland_Argentina: {0},", t.Skottland_Argentina);
            logText += string.Format("Nederländerna_Kanada: {0},", t.Nederländerna_Kanada);
            logText += string.Format("Kamerun_Nya Zeeland: {0},", t.Kamerun_NyaZeeland);
            logText += string.Format("Sverige_Usa: {0},", t.Sverige_Usa);
            logText += string.Format("Thailand_Chile: {0},", t.Thailand_Chile);


            // - - - - - DataLogic_SaveTipsDataToLogFile.txt - Code area ends - - - - - - - 

            Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, logText, "SaveTipsDataToLogFile");
        }
        public static SavedTipsDataResult SaveNewTipsData(TipsData tipsData)
        {
            try
            {
                SaveTipsDataToLogFile(tipsData);
            }
            catch (Exception)
            {
                // Do nothing, since log to textfile does not work
            }

            try
            {
                using (var db = new FotbollsTipsModel())
                {
                    db.TipsDatas.Add(tipsData);
                    db.SaveChanges();

                    return new SavedTipsDataResult()
                    {
                        IdOfTipsdata = tipsData.Id,
                        SuccessedSave = true
                    };
                }
            }
            catch (Exception e)
            {
                Log4NetLogic.Log(Log4NetLogic.LogLevel.ERROR, "An error in", "SaveNewTipsData", e);

                return new SavedTipsDataResult()
                {
                    IdOfTipsdata = 0,
                    SuccessedSave = false
                };
            }
        }

        public static bool SaveNewTipsDataImagePath(TipsPathToPDF path)
        {
            using (var db = new FotbollsTipsModel())
            {
                db.TipsPathToPDFs.Add(path);
                db.SaveChanges();
            }

            return true;
        }
    }
}