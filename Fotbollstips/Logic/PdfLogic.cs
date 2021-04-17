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

            yCoord = DrawTheString("Frankrike - Sydkorea", tipsData.Frankrike_Sydkorea, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Tyskland - Kina", tipsData.Tyskland_Kina, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Spanien - Sydafrika", tipsData.Spanien_Sydafrika, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Norge - Nigeria", tipsData.Norge_Nigeria, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Australien - Italien", tipsData.Australien_Italien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Brasilien - Jamaica", tipsData.Brasilien_Jamaica, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("England - Skottland", tipsData.England_Skottland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Argentina - Japan", tipsData.Argentina_Japan, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Kanada - Kamerun", tipsData.Kanada_Kamerun, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Nya Zeeland - Nederländ.", tipsData.NyaZeeland_Nederländerna, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Chile - Sverige", tipsData.Chile_Sverige, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Usa - Thailand", tipsData.Usa_Thailand, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Nigeria - Sydkorea", tipsData.Nigeria_Sydkorea, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Tyskland - Spanien", tipsData.Tyskland_Spanien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            
            yCoord = DrawTheString("Frankrike - Norge", tipsData.Frankrike_Norge, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Australien - Brasilien", tipsData.Australien_Brasilien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Sydafrika - Kina", tipsData.Sydafrika_Kina, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Japan - Skottland", tipsData.Japan_Skottland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Jamaica - Italien", tipsData.Jamaica_Italien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("England - Argentina", tipsData.England_Argentina, yCoord, xCoordGame, xCoordResult, graph, fontMedium);

            // Right column
            yCoord = 135;
            xCoordGame = 340;
            xCoordResult = 510;

            yCoord = DrawTheString("Nederländerna - Kamerun", tipsData.Nederländerna_Kamerun, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Kanada - Nya Zeeland", tipsData.Kanada_NyaZeeland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Sverige - Thailand", tipsData.Sverige_Thailand, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Usa - Chile", tipsData.Usa_Chile, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Kina - Spanien", tipsData.Kina_Spanien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Sydafrika - Tyskland", tipsData.Sydafrika_Tyskland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Nigeria - Frankrike", tipsData.Nigeria_Frankrike, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Sydkorea - Norge", tipsData.Sydkorea_Norge, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Italien - Brasilien", tipsData.Italien_Brasilien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Jamaica - Australien", tipsData.Jamaica_Australien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Japan - England", tipsData.Japan_England, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Skottland - Argentina", tipsData.Skottland_Argentina, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Nederländerna - Kanada", tipsData.Nederländerna_Kanada, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Kamerun - Nya Zeeland", tipsData.Kamerun_NyaZeeland, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Sverige - Usa", tipsData.Sverige_Usa, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            yCoord = DrawTheString("Thailand - Chile", tipsData.Thailand_Chile, yCoord, xCoordGame, xCoordResult, graph, fontMedium);

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