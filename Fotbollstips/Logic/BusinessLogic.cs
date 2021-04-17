using Fotbollstips.Objects;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotbollstips.Logic
{
    public class BusinessLogic
    {
        public static List<TipsData> GetDataForPresentation()
        {
            return DataLogic.GetDataForPresentation();
        }

        public static List<TipsData> RemoveSensitiveData(List<TipsData> tipsData)
        {
            var returnList = new List<TipsData>();

            foreach (var tips in tipsData)
            {
                var newItem = new TipsData();
                newItem.Namn = tips.Namn;
                newItem.HasPayed = tips.HasPayed;

                returnList.Add(newItem);
            }

            return returnList;
        }

        public static ParticipateResult ParticipateInTips(FormCollection col)
        {
            try
            {
                TipsData newTipsData = new TipsData()
                {
                    EntryDate = DateTime.Now,
                    Poäng = 0,
                    HasPayed = false,

                    Namn = col["myname"],
                    PhoneNumber = col["myphonenumber"],
                    Email = col["myemail"],

                    Finallag1 = col["finalteam1"],
                    Finallag2 = col["finalteam2"],
                    Vinnare = col["winner"],

                    // - - - - - BusinessLogic_ParticipateInTips.txt - Code area starts - - - - - - - 

                    Frankrike_Sydkorea = GetGameResult(col, "frasyd"),
                    Tyskland_Kina = GetGameResult(col, "tyskin"),
                    Spanien_Sydafrika = GetGameResult(col, "spasyd"),
                    Norge_Nigeria = GetGameResult(col, "nornig"),
                    Australien_Italien = GetGameResult(col, "ausita"),
                    Brasilien_Jamaica = GetGameResult(col, "brajam"),
                    England_Skottland = GetGameResult(col, "engsko"),
                    Argentina_Japan = GetGameResult(col, "argjap"),
                    Kanada_Kamerun = GetGameResult(col, "kankam"),
                    NyaZeeland_Nederländerna = GetGameResult(col, "nyaned"),
                    Chile_Sverige = GetGameResult(col, "chisve"),
                    Usa_Thailand = GetGameResult(col, "usatha"),
                    Nigeria_Sydkorea = GetGameResult(col, "nigsyd"),
                    Tyskland_Spanien = GetGameResult(col, "tysspa"),
                    Frankrike_Norge = GetGameResult(col, "franor"),
                    Australien_Brasilien = GetGameResult(col, "ausbra"),
                    Sydafrika_Kina = GetGameResult(col, "sydkin"),
                    Japan_Skottland = GetGameResult(col, "japsko"),
                    Jamaica_Italien = GetGameResult(col, "jamita"),
                    England_Argentina = GetGameResult(col, "engarg"),
                    Nederländerna_Kamerun = GetGameResult(col, "nedkam"),
                    Kanada_NyaZeeland = GetGameResult(col, "kannya"),
                    Sverige_Thailand = GetGameResult(col, "svetha"),
                    Usa_Chile = GetGameResult(col, "usachi"),
                    Kina_Spanien = GetGameResult(col, "kinspa"),
                    Sydafrika_Tyskland = GetGameResult(col, "sydtys"),
                    Nigeria_Frankrike = GetGameResult(col, "nigfra"),
                    Sydkorea_Norge = GetGameResult(col, "sydnor"),
                    Italien_Brasilien = GetGameResult(col, "itabra"),
                    Jamaica_Australien = GetGameResult(col, "jamaus"),
                    Japan_England = GetGameResult(col, "japeng"),
                    Skottland_Argentina = GetGameResult(col, "skoarg"),
                    Nederländerna_Kanada = GetGameResult(col, "nedkan"),
                    Kamerun_NyaZeeland = GetGameResult(col, "kamnya"),
                    Sverige_Usa = GetGameResult(col, "sveusa"),
                    Thailand_Chile = GetGameResult(col, "thachi"),




                    // - - - - - BusinessLogic_ ParticipateInTips.txt - Code area ends - - - - - - - 
                };

                // Save to database
                var saveResultOfTipsData = DataLogic.SaveNewTipsData(newTipsData);

                bool emailSent = false;

                var storageWorker = new StorageLogic();

                if (saveResultOfTipsData.SuccessedSave)
                {
                    // Create PDF
                    var pdfWorder = new PdfLogic();
                    PdfDocument pdfDocument = pdfWorder.SaveTipsDatas(newTipsData);

                    #region During development
                    //// During development - Store locally on computer

                    //string filePath = GetFileNameAndPath("", false);
                    //pdfDocument.Save(filePath);

                    //Process.Start(filePath);

                    //return true;
                    #endregion

                    if (pdfDocument != null)
                    {
                        // Store in blob storage
                        string imagePath = storageWorker.SavePDF(pdfDocument, newTipsData.Namn);

                        // Save file path to PDF
                        TipsPathToPDF pathToPdf = new TipsPathToPDF()
                        {
                            PathToPDF = imagePath,
                            TipsData_SoftFK = saveResultOfTipsData.IdOfTipsdata
                        };

                        var imagePathSaved = DataLogic.SaveNewTipsDataImagePath(pathToPdf);

                        //// Send email
                        //string getEmail = col["getemail"];

                        ////MNTODO Ta bort if vid deploy
                        //if (getEmail.ToLower() == "ja")
                        //{
                        var mailWorker = new MailLogic();
                        emailSent = mailWorker.SendMail(newTipsData.Email, pathToPdf.PathToPDF, col["myname"]);
                        //}
                    }
                }

                //var sendSms = GetRandomValue("SendSms");
                //if (sendSms == "1")
                //{
                //    string message = string.Format("'{0}' har lämnat en tipsrad. Mail skickat: {1}. Mailadress: {2}.", col["myname"], emailSent, col["myemail"]);

                //    storageWorker.SendSms(message);
                //}

                //return new ParticipateResult(true, emailSent, newTipsData.Email);

                return new ParticipateResult(saveResultOfTipsData.SuccessedSave, emailSent, newTipsData.Email);
            }
            catch (Exception e)
            {
                Log4NetLogic.Log(Log4NetLogic.LogLevel.ERROR, "An error in: ", "ParticipateInTips", e);

                return new ParticipateResult(false, false, "");
            }
        }

        public static string GetRandomValue(string name)
        {
            return DataLogic.GetRandomValue(name);
        }
        public static bool UpdateRandomValue(string name, string value)
        {
            return DataLogic.UpdateRandomValue(name, value);
        }
        private static string GetFileNameAndPath(string type, bool tomorrow)
        {
            DateTime date = DateTime.Now;

            string time = string.Format(date.ToString());
            time = time.Replace(':', '-');
            time = time.Replace(' ', '_');
            string pdfFilename = string.Format("{0}.pdf", time);

            string filePath = "";

            filePath = @"C:\Tips\" + "Tips_" + pdfFilename;

            return filePath;
        }

        private static string GetGameResult(FormCollection col, string game)
        {
            string home = game + "1";
            string away = game + "2";

            return col[home] + col[away];
        }

        public static string GetFileFromFileStorage()
        {
            var blobWorker = new StorageLogic();
            return blobWorker.GetFileFromFileStorage();
        }
    }
}