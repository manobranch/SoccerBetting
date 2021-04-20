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


                return rawData;
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


        public static List<TipsDataDisplay> CalculatePoints(List<TipsDataDisplay> rows)
        {
            var correct = (from hits in rows
                           where hits.Namn == RATT_SVAR
                           select hits).FirstOrDefault();

            foreach (var row in rows)
            {
                int points = 0;
                Tuple<int, string> theTuple;

                #region compare games

                // - - - - - DataLogic_CalculatePoints.txt - Code area starts - - - - - - - 
                theTuple = CalculateGamePoints(row.Turkiet_Italien, correct.Turkiet_Italien);
                points += theTuple.Item1;
                row.Turkiet_Italien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Wales_Schweiz, correct.Wales_Schweiz);
                points += theTuple.Item1;
                row.Wales_Schweiz_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Danmark_Finland, correct.Danmark_Finland);
                points += theTuple.Item1;
                row.Danmark_Finland_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Belgien_Ryssland, correct.Belgien_Ryssland);
                points += theTuple.Item1;
                row.Belgien_Ryssland_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.England_Kroatien, correct.England_Kroatien);
                points += theTuple.Item1;
                row.England_Kroatien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Österrike_Nordmakedonien, correct.Österrike_Nordmakedonien);
                points += theTuple.Item1;
                row.Österrike_Nordmakedonien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Nederländerna_Ukraina, correct.Nederländerna_Ukraina);
                points += theTuple.Item1;
                row.Nederländerna_Ukraina_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Skottland_Tjeckien, correct.Skottland_Tjeckien);
                points += theTuple.Item1;
                row.Skottland_Tjeckien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Polen_Slovakien, correct.Polen_Slovakien);
                points += theTuple.Item1;
                row.Polen_Slovakien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Spanien_Sverige, correct.Spanien_Sverige);
                points += theTuple.Item1;
                row.Spanien_Sverige_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Ungern_Portugal, correct.Ungern_Portugal);
                points += theTuple.Item1;
                row.Ungern_Portugal_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Frankrike_Tyskland, correct.Frankrike_Tyskland);
                points += theTuple.Item1;
                row.Frankrike_Tyskland_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Finland_Ryssland, correct.Finland_Ryssland);
                points += theTuple.Item1;
                row.Finland_Ryssland_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Turkiet_Wales, correct.Turkiet_Wales);
                points += theTuple.Item1;
                row.Turkiet_Wales_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Italien_Schweiz, correct.Italien_Schweiz);
                points += theTuple.Item1;
                row.Italien_Schweiz_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Ukraina_Nordmakedonien, correct.Ukraina_Nordmakedonien);
                points += theTuple.Item1;
                row.Ukraina_Nordmakedonien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Danmark_Belgien, correct.Danmark_Belgien);
                points += theTuple.Item1;
                row.Danmark_Belgien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Nederländerna_Österrike, correct.Nederländerna_Österrike);
                points += theTuple.Item1;
                row.Nederländerna_Österrike_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Sverige_Slovakien, correct.Sverige_Slovakien);
                points += theTuple.Item1;
                row.Sverige_Slovakien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Kroatien_Tjeckien, correct.Kroatien_Tjeckien);
                points += theTuple.Item1;
                row.Kroatien_Tjeckien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.England_Skottland, correct.England_Skottland);
                points += theTuple.Item1;
                row.England_Skottland_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Ungern_Frankrike, correct.Ungern_Frankrike);
                points += theTuple.Item1;
                row.Ungern_Frankrike_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Portugal_Tyskland, correct.Portugal_Tyskland);
                points += theTuple.Item1;
                row.Portugal_Tyskland_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Spanien_Polen, correct.Spanien_Polen);
                points += theTuple.Item1;
                row.Spanien_Polen_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Italien_Wales, correct.Italien_Wales);
                points += theTuple.Item1;
                row.Italien_Wales_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Schweiz_Turkiet, correct.Schweiz_Turkiet);
                points += theTuple.Item1;
                row.Schweiz_Turkiet_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Nordmakedonien_Nederländerna, correct.Nordmakedonien_Nederländerna);
                points += theTuple.Item1;
                row.Nordmakedonien_Nederländerna_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Ukraina_Österrike, correct.Ukraina_Österrike);
                points += theTuple.Item1;
                row.Ukraina_Österrike_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Ryssland_Danmark, correct.Ryssland_Danmark);
                points += theTuple.Item1;
                row.Ryssland_Danmark_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Finland_Belgien, correct.Finland_Belgien);
                points += theTuple.Item1;
                row.Finland_Belgien_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Tjeckien_England, correct.Tjeckien_England);
                points += theTuple.Item1;
                row.Tjeckien_England_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Kroatien_Skottland, correct.Kroatien_Skottland);
                points += theTuple.Item1;
                row.Kroatien_Skottland_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Slovakien_Spaninen, correct.Slovakien_Spaninen);
                points += theTuple.Item1;
                row.Slovakien_Spaninen_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Sverige_Polen, correct.Sverige_Polen);
                points += theTuple.Item1;
                row.Sverige_Polen_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Tyskland_Ungern, correct.Tyskland_Ungern);
                points += theTuple.Item1;
                row.Tyskland_Ungern_Color = theTuple.Item2;

                theTuple = CalculateGamePoints(row.Portugal_Frankrike, correct.Portugal_Frankrike);
                points += theTuple.Item1;
                row.Portugal_Frankrike_Color = theTuple.Item2;




                // - - - - - DataLogic_CalculatePoints.txt - Code area ends - - - - - - - 

                theTuple = CompareFinal(row.Finallag1, correct.Finallag1);
                points += theTuple.Item1;
                row.Finallag1_Color = theTuple.Item2;

                theTuple = CompareFinal(row.Finallag2, correct.Finallag2);
                points += theTuple.Item1;
                row.Finallag2_Color = theTuple.Item2;

                theTuple = CompareFinal(row.Vinnare, correct.Vinnare);
                points += theTuple.Item1;
                row.Vinnare_Color = theTuple.Item2;

                #endregion

                row.Poäng = points;
            }

            return rows;
        }

        private static Tuple<int, string> CalculateGamePoints(string row, string corr)
        {
            if (row == corr)
                return Tuple.Create(3, "background-color:#00D600");

            else if (CorrectWinner(row, corr))
                return Tuple.Create(1, "background-color:#b3ffb3");

            else
                return Tuple.Create(0, string.Empty);
        }

        private static bool CorrectWinner(string row, string corr)
        {
            try
            {
                var rowWinner = GetWinner(row);
                var corrWinner = GetWinner(corr);

                return rowWinner == corrWinner;

            }
            catch
            {
                return false;
            }
        }

        private static WinningTeam GetWinner(string result)
        {
            var home = Convert.ToInt32(result[0].ToString());
            var away = Convert.ToInt32(result[1].ToString());

            if (home > away)
                return WinningTeam.Home;
            else if (home == away)
                return WinningTeam.Draw;
            else
                return WinningTeam.Away;
        }

        enum WinningTeam
        {
            Home,
            Draw,
            Away,
        }

        private static Tuple<int, string> CompareFinal(string finalTeam, string correctAnswer)
        {
            var correctTeams = correctAnswer.Split('-').ToList();

            foreach (var item in correctTeams.ToList())
            {
                if (item.ToString() == finalTeam)
                {
                    return Tuple.Create(3, "background-color:#00D600");
                }
            }

            return Tuple.Create(0, string.Empty);
        }

        public static List<TipsDataDisplay> ManipulateTextStrings(List<TipsDataDisplay> data)
        {
            foreach (var item in data)
            {
                // - - - - - DataLogic_ManipulateTextStrings.txt - Code area starts - - - - - - - 
                item.Turkiet_Italien = item.Turkiet_Italien.Insert(1, "-");
                item.Wales_Schweiz = item.Wales_Schweiz.Insert(1, "-");
                item.Danmark_Finland = item.Danmark_Finland.Insert(1, "-");
                item.Belgien_Ryssland = item.Belgien_Ryssland.Insert(1, "-");
                item.England_Kroatien = item.England_Kroatien.Insert(1, "-");
                item.Österrike_Nordmakedonien = item.Österrike_Nordmakedonien.Insert(1, "-");
                item.Nederländerna_Ukraina = item.Nederländerna_Ukraina.Insert(1, "-");
                item.Skottland_Tjeckien = item.Skottland_Tjeckien.Insert(1, "-");
                item.Polen_Slovakien = item.Polen_Slovakien.Insert(1, "-");
                item.Spanien_Sverige = item.Spanien_Sverige.Insert(1, "-");
                item.Ungern_Portugal = item.Ungern_Portugal.Insert(1, "-");
                item.Frankrike_Tyskland = item.Frankrike_Tyskland.Insert(1, "-");
                item.Finland_Ryssland = item.Finland_Ryssland.Insert(1, "-");
                item.Turkiet_Wales = item.Turkiet_Wales.Insert(1, "-");
                item.Italien_Schweiz = item.Italien_Schweiz.Insert(1, "-");
                item.Ukraina_Nordmakedonien = item.Ukraina_Nordmakedonien.Insert(1, "-");
                item.Danmark_Belgien = item.Danmark_Belgien.Insert(1, "-");
                item.Nederländerna_Österrike = item.Nederländerna_Österrike.Insert(1, "-");
                item.Sverige_Slovakien = item.Sverige_Slovakien.Insert(1, "-");
                item.Kroatien_Tjeckien = item.Kroatien_Tjeckien.Insert(1, "-");
                item.England_Skottland = item.England_Skottland.Insert(1, "-");
                item.Ungern_Frankrike = item.Ungern_Frankrike.Insert(1, "-");
                item.Portugal_Tyskland = item.Portugal_Tyskland.Insert(1, "-");
                item.Spanien_Polen = item.Spanien_Polen.Insert(1, "-");
                item.Italien_Wales = item.Italien_Wales.Insert(1, "-");
                item.Schweiz_Turkiet = item.Schweiz_Turkiet.Insert(1, "-");
                item.Nordmakedonien_Nederländerna = item.Nordmakedonien_Nederländerna.Insert(1, "-");
                item.Ukraina_Österrike = item.Ukraina_Österrike.Insert(1, "-");
                item.Ryssland_Danmark = item.Ryssland_Danmark.Insert(1, "-");
                item.Finland_Belgien = item.Finland_Belgien.Insert(1, "-");
                item.Tjeckien_England = item.Tjeckien_England.Insert(1, "-");
                item.Kroatien_Skottland = item.Kroatien_Skottland.Insert(1, "-");
                item.Slovakien_Spaninen = item.Slovakien_Spaninen.Insert(1, "-");
                item.Sverige_Polen = item.Sverige_Polen.Insert(1, "-");
                item.Tyskland_Ungern = item.Tyskland_Ungern.Insert(1, "-");
                item.Portugal_Frankrike = item.Portugal_Frankrike.Insert(1, "-");


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
                result.Turkiet_Italien = model.Turkiet_Italien;
                result.Wales_Schweiz = model.Wales_Schweiz;
                result.Danmark_Finland = model.Danmark_Finland;
                result.Belgien_Ryssland = model.Belgien_Ryssland;
                result.England_Kroatien = model.England_Kroatien;
                result.Österrike_Nordmakedonien = model.Österrike_Nordmakedonien;
                result.Nederländerna_Ukraina = model.Nederländerna_Ukraina;
                result.Skottland_Tjeckien = model.Skottland_Tjeckien;
                result.Polen_Slovakien = model.Polen_Slovakien;
                result.Spanien_Sverige = model.Spanien_Sverige;
                result.Ungern_Portugal = model.Ungern_Portugal;
                result.Frankrike_Tyskland = model.Frankrike_Tyskland;
                result.Finland_Ryssland = model.Finland_Ryssland;
                result.Turkiet_Wales = model.Turkiet_Wales;
                result.Italien_Schweiz = model.Italien_Schweiz;
                result.Ukraina_Nordmakedonien = model.Ukraina_Nordmakedonien;
                result.Danmark_Belgien = model.Danmark_Belgien;
                result.Nederländerna_Österrike = model.Nederländerna_Österrike;
                result.Sverige_Slovakien = model.Sverige_Slovakien;
                result.Kroatien_Tjeckien = model.Kroatien_Tjeckien;
                result.England_Skottland = model.England_Skottland;
                result.Ungern_Frankrike = model.Ungern_Frankrike;
                result.Portugal_Tyskland = model.Portugal_Tyskland;
                result.Spanien_Polen = model.Spanien_Polen;
                result.Italien_Wales = model.Italien_Wales;
                result.Schweiz_Turkiet = model.Schweiz_Turkiet;
                result.Nordmakedonien_Nederländerna = model.Nordmakedonien_Nederländerna;
                result.Ukraina_Österrike = model.Ukraina_Österrike;
                result.Ryssland_Danmark = model.Ryssland_Danmark;
                result.Finland_Belgien = model.Finland_Belgien;
                result.Tjeckien_England = model.Tjeckien_England;
                result.Kroatien_Skottland = model.Kroatien_Skottland;
                result.Slovakien_Spaninen = model.Slovakien_Spaninen;
                result.Sverige_Polen = model.Sverige_Polen;
                result.Tyskland_Ungern = model.Tyskland_Ungern;
                result.Portugal_Frankrike = model.Portugal_Frankrike;


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
            logText += string.Format("Turkiet_Italien: {0},", t.Turkiet_Italien);
            logText += string.Format("Wales_Schweiz: {0},", t.Wales_Schweiz);
            logText += string.Format("Danmark_Finland: {0},", t.Danmark_Finland);
            logText += string.Format("Belgien_Ryssland: {0},", t.Belgien_Ryssland);
            logText += string.Format("England_Kroatien: {0},", t.England_Kroatien);
            logText += string.Format("Österrike_Nordmakedonien: {0},", t.Österrike_Nordmakedonien);
            logText += string.Format("Nederländerna_Ukraina: {0},", t.Nederländerna_Ukraina);
            logText += string.Format("Skottland_Tjeckien: {0},", t.Skottland_Tjeckien);
            logText += string.Format("Polen_Slovakien: {0},", t.Polen_Slovakien);
            logText += string.Format("Spanien_Sverige: {0},", t.Spanien_Sverige);
            logText += string.Format("Ungern_Portugal: {0},", t.Ungern_Portugal);
            logText += string.Format("Frankrike_Tyskland: {0},", t.Frankrike_Tyskland);
            logText += string.Format("Finland_Ryssland: {0},", t.Finland_Ryssland);
            logText += string.Format("Turkiet_Wales: {0},", t.Turkiet_Wales);
            logText += string.Format("Italien_Schweiz: {0},", t.Italien_Schweiz);
            logText += string.Format("Ukraina_Nordmakedonien: {0},", t.Ukraina_Nordmakedonien);
            logText += string.Format("Danmark_Belgien: {0},", t.Danmark_Belgien);
            logText += string.Format("Nederländerna_Österrike: {0},", t.Nederländerna_Österrike);
            logText += string.Format("Sverige_Slovakien: {0},", t.Sverige_Slovakien);
            logText += string.Format("Kroatien_Tjeckien: {0},", t.Kroatien_Tjeckien);
            logText += string.Format("England_Skottland: {0},", t.England_Skottland);
            logText += string.Format("Ungern_Frankrike: {0},", t.Ungern_Frankrike);
            logText += string.Format("Portugal_Tyskland: {0},", t.Portugal_Tyskland);
            logText += string.Format("Spanien_Polen: {0},", t.Spanien_Polen);
            logText += string.Format("Italien_Wales: {0},", t.Italien_Wales);
            logText += string.Format("Schweiz_Turkiet: {0},", t.Schweiz_Turkiet);
            logText += string.Format("Nordmakedonien_Nederländerna: {0},", t.Nordmakedonien_Nederländerna);
            logText += string.Format("Ukraina_Österrike: {0},", t.Ukraina_Österrike);
            logText += string.Format("Ryssland_Danmark: {0},", t.Ryssland_Danmark);
            logText += string.Format("Finland_Belgien: {0},", t.Finland_Belgien);
            logText += string.Format("Tjeckien_England: {0},", t.Tjeckien_England);
            logText += string.Format("Kroatien_Skottland: {0},", t.Kroatien_Skottland);
            logText += string.Format("Slovakien_Spaninen: {0},", t.Slovakien_Spaninen);
            logText += string.Format("Sverige_Polen: {0},", t.Sverige_Polen);
            logText += string.Format("Tyskland_Ungern: {0},", t.Tyskland_Ungern);
            logText += string.Format("Portugal_Frankrike: {0},", t.Portugal_Frankrike);


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