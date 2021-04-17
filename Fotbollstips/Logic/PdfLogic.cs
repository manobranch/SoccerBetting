using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fotbollstips.Logic
{
    public class PdfLogic
    {
        public PdfLogic()
        {

        }

        public PdfDocument SaveTipsDatas(TipsData tipsData)
        {
            PdfDocument pdf = new PdfDocument();

            PdfPage pdfPage = pdf.AddPage();

            XFont fontBig = new XFont("Times New Roman", 20, XFontStyle.Regular);
            XFont fontMedium = new XFont("Times New Roman", 16, XFontStyle.Regular);
            XFont fontSmall = new XFont("Times New Roman", 12, XFontStyle.Regular);

            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            // Set beginning coordinates
            int xCoordGame = 60;
            int xCoordResult = 230;
            //int yCoordGeneral = 35;
            int yCoord = 35;

            // Write initial information
            graph.DrawString("Namn:", fontBig, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordGame, yCoord, XStringFormats.TopLeft);
            graph.DrawString(tipsData.Namn, fontBig, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordResult, yCoord, XStringFormats.TopLeft);
            yCoord += SpaceAfterText();

            graph.DrawString("Telefonnummer:", fontBig, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordGame, yCoord, XStringFormats.TopLeft);
            graph.DrawString(tipsData.PhoneNumber, fontBig, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordResult, yCoord, XStringFormats.TopLeft);
            yCoord += SpaceAfterText();

            graph.DrawString("Mailadress:", fontBig, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordGame, yCoord, XStringFormats.TopLeft);
            graph.DrawString(tipsData.Email, fontBig, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordResult, yCoord, XStringFormats.TopLeft);
            yCoord += SpaceAfterText();
            yCoord += SpaceAfterText();

            // Write games

            // - - - - - PdfLogic_SaveTipsDatas.txt - Code area starts - - - - - - - 
            // ****** NOTE: one+three lines of code in the middle to make another column
            // Right column
            //yCoord = 135;
            //xCoordGame = 340;
            //xCoordResult = 510;


            yCoord = DrawTheString("Turkiet - Italien", tipsData.Turkiet_Italien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Wales - Schweiz", tipsData.Wales_Schweiz, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Danmark - Finland", tipsData.Danmark_Finland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Belgien - Ryssland", tipsData.Belgien_Ryssland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("England - Kroatien", tipsData.England_Kroatien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Österrike - Nordmak.", tipsData.Österrike_Nordmakedonien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Nederländerna - Ukraina", tipsData.Nederländerna_Ukraina, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Skottland - Tjeckien", tipsData.Skottland_Tjeckien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Polen - Slovakien", tipsData.Polen_Slovakien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Spanien - Sverige", tipsData.Spanien_Sverige, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Ungern - Portugal", tipsData.Ungern_Portugal, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Frankrike - Tyskland", tipsData.Frankrike_Tyskland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Finland - Ryssland", tipsData.Finland_Ryssland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Turkiet - Wales", tipsData.Turkiet_Wales, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Italien - Schweiz", tipsData.Italien_Schweiz, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Ukraina - Nordmak.", tipsData.Ukraina_Nordmakedonien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Danmark - Belgien", tipsData.Danmark_Belgien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Nederländerna - Österrike", tipsData.Nederländerna_Österrike, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Sverige - Slovakien", tipsData.Sverige_Slovakien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Kroatien - Tjeckien", tipsData.Kroatien_Tjeckien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
                        
            // Right column
            yCoord = 135;
            xCoordGame = 340;
            xCoordResult = 510;

            yCoord = DrawTheString("England - Skottland", tipsData.England_Skottland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Ungern - Frankrike", tipsData.Ungern_Frankrike, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Portugal - Tyskland", tipsData.Portugal_Tyskland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Spanien - Polen", tipsData.Spanien_Polen, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Italien - Wales", tipsData.Italien_Wales, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Schweiz - Turkiet", tipsData.Schweiz_Turkiet, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Nordmak. - Nederländ.", tipsData.Nordmakedonien_Nederländerna, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Ukraina - Österrike", tipsData.Ukraina_Österrike, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Ryssland - Danmark", tipsData.Ryssland_Danmark, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Finland - Belgien", tipsData.Finland_Belgien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Tjeckien - England", tipsData.Tjeckien_England, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Kroatien - Skottland", tipsData.Kroatien_Skottland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Slovakien - Spaninen", tipsData.Slovakien_Spaninen, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Sverige - Polen", tipsData.Sverige_Polen, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Tyskland - Ungern", tipsData.Tyskland_Ungern, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Portugal - Frankrike", tipsData.Portugal_Frankrike, yCoord, xCoordGame, xCoordResult, graph, fontMedium);


            // - - - - - PdfLogic_SaveTipsDatas.txt - Code area ends - - - - - - - 

            xCoordGame = 340;
            xCoordResult = 440;

            graph.DrawString("Finallag 1", fontMedium, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordGame, yCoord, XStringFormats.TopLeft);
            graph.DrawString(tipsData.Finallag1, fontMedium, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordResult, yCoord, XStringFormats.TopLeft);
            yCoord += SpaceAfterText();

            graph.DrawString("Finallag 2", fontMedium, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordGame, yCoord, XStringFormats.TopLeft);
            graph.DrawString(tipsData.Finallag2, fontMedium, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordResult, yCoord, XStringFormats.TopLeft);
            yCoord += SpaceAfterText();

            graph.DrawString("Vinnare", fontMedium, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordGame, yCoord, XStringFormats.TopLeft);
            graph.DrawString(tipsData.Vinnare, fontMedium, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordResult, yCoord, XStringFormats.TopLeft);
            yCoord += SpaceAfterText();

            return pdf;
        }

        private int DrawTheString(string game, string result, int yCoord, int xCoordGame, int xCoordResult, XGraphics graph, XFont font)
        {
            graph.DrawString(game, font, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordGame, yCoord, XStringFormats.TopLeft);
            graph.DrawString(ManipulateResult(result), font, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 100)), xCoordResult, yCoord, XStringFormats.TopLeft);
            return yCoord += SpaceAfterText();
        }

        private static int SpaceAfterText()
        {
            return 25;
        }
        private static string ManipulateResult(string resultText)
        {
            return resultText.Insert(1, "-");
        }

        //public static void DoStuff()
        //{
        //    // Create a new PDF document
        //    PdfDocument document = new PdfDocument();

        //    // Create an empty page
        //    PdfPage page = document.AddPage();

        //    // Get an XGraphics object for drawing
        //    XGraphics gfx = XGraphics.FromPdfPage(page);

        //    // Create a font
        //    XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

        //    // Draw the text
        //    gfx.DrawString("Med SendGrid", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);


        //    var blobWorker = new BlobStorageLogic();
        //    blobWorker.SavePDF(document, );

        //    //SendGridLogic.SendEmail();


        //    // Save the document...
        //    //string filename = "HelloWorld.pdf";
        //    //document.Save(filename);


        //    //// ...and start a viewer.
        //    //Process.Start(filename);

        //}
    }
}