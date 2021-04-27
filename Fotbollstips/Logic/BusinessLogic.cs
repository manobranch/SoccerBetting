using Fotbollstips.Models;
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
                var theName = $"Before any save: {col["myname"]}";
                Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, theName, "ParticipateInTips");

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

                    Turkiet_Italien = GetGameResult(col, "turita"),
                    Wales_Schweiz = GetGameResult(col, "walsch"),
                    Danmark_Finland = GetGameResult(col, "danfin"),
                    Belgien_Ryssland = GetGameResult(col, "belrys"),
                    England_Kroatien = GetGameResult(col, "engkro"),
                    Österrike_Nordmakedonien = GetGameResult(col, "östnor"),
                    Nederländerna_Ukraina = GetGameResult(col, "nedukr"),
                    Skottland_Tjeckien = GetGameResult(col, "skotje"),
                    Polen_Slovakien = GetGameResult(col, "polslo"),
                    Spanien_Sverige = GetGameResult(col, "spasve"),
                    Ungern_Portugal = GetGameResult(col, "ungpor"),
                    Frankrike_Tyskland = GetGameResult(col, "fratys"),
                    Finland_Ryssland = GetGameResult(col, "finrys"),
                    Turkiet_Wales = GetGameResult(col, "turwal"),
                    Italien_Schweiz = GetGameResult(col, "itasch"),
                    Ukraina_Nordmakedonien = GetGameResult(col, "ukrnor"),
                    Danmark_Belgien = GetGameResult(col, "danbel"),
                    Nederländerna_Österrike = GetGameResult(col, "nedöst"),
                    Sverige_Slovakien = GetGameResult(col, "sveslo"),
                    Kroatien_Tjeckien = GetGameResult(col, "krotje"),
                    England_Skottland = GetGameResult(col, "engsko"),
                    Ungern_Frankrike = GetGameResult(col, "ungfra"),
                    Portugal_Tyskland = GetGameResult(col, "portys"),
                    Spanien_Polen = GetGameResult(col, "spapol"),
                    Italien_Wales = GetGameResult(col, "itawal"),
                    Schweiz_Turkiet = GetGameResult(col, "schtur"),
                    Nordmakedonien_Nederländerna = GetGameResult(col, "norned"),
                    Ukraina_Österrike = GetGameResult(col, "ukröst"),
                    Ryssland_Danmark = GetGameResult(col, "rysdan"),
                    Finland_Belgien = GetGameResult(col, "finbel"),
                    Tjeckien_England = GetGameResult(col, "tjeeng"),
                    Kroatien_Skottland = GetGameResult(col, "krosko"),
                    Slovakien_Spaninen = GetGameResult(col, "slospa"),
                    Sverige_Polen = GetGameResult(col, "svepol"),
                    Tyskland_Ungern = GetGameResult(col, "tysung"),
                    Portugal_Frankrike = GetGameResult(col, "porfra"),




                    // - - - - - BusinessLogic_ ParticipateInTips.txt - Code area ends - - - - - - - 
                };

                // Save to database
                var saveResultOfTipsData = DataLogic.SaveNewTipsData(newTipsData);

                bool emailSent = false;

                var storageWorker = new StorageLogic();

                if (saveResultOfTipsData.SuccessedSave)
                {
                    Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "SuccessedSave, before PdfLogic", "ParticipateInTips");

                    // Create PDF
                    var pdfWorder = new PdfLogic();
                    PdfDocument pdfDocument = pdfWorder.SaveTipsDatas(newTipsData);
                    
                    Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "SuccessedSave, after PdfLogic, before Blob Storager", "ParticipateInTips");

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

                        Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "Saved to Blob Storage", "ParticipateInTips");

                        // Save file path to PDF
                        TipsPathToPDF pathToPdf = new TipsPathToPDF()
                        {
                            PathToPDF = imagePath,
                            TipsData_SoftFK = saveResultOfTipsData.IdOfTipsdata
                        };

                        Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "Before saving image path", "ParticipateInTips");

                        var imagePathSaved = DataLogic.SaveNewTipsDataImagePath(pathToPdf);

                        Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "After saving image path, before email", "ParticipateInTips");

                        //// Send email
                        //string getEmail = col["getemail"];

                        ////MNTODO Ta bort if vid deploy
                        //if (getEmail.ToLower() == "ja")
                        //{


                        var mailWorker = new MailLogic();
                        emailSent = mailWorker.SendMail(newTipsData.Email, pathToPdf.PathToPDF, col["myname"]);

                        Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "After sending email", "ParticipateInTips");

                        //}
                    }
                }
                else
                {
                    Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "Not success save, get to Else", "ParticipateInTips");
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
                Log4NetLogic.Log(Log4NetLogic.LogLevel.INFO, "An error in: ", e.Message);

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

        public static List<TipsDataDisplay> KneadTheData(List<TipsData> rawData)
        {
            var displayList = new List<TipsDataDisplay>();

            foreach (var data in rawData)
            {
                displayList.Add(new TipsDataDisplay(data));
            }

            // Calculate points
            displayList = DataLogic.CalculatePoints(displayList);

            // Sort list by points
            displayList = displayList.OrderByDescending(o => o.Poäng).ToList();

            // Manipulate text string 
            displayList = DataLogic.ManipulateTextStrings(displayList);

            return displayList;
        }
    }
}