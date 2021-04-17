using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeGenerator
{
    class Program
    {
        static string FOLDERPATH = @"C:\asdf\";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Program");

            StartWork();

            Console.WriteLine("Ending Program");
            Thread.Sleep(500);
        }

        private static void StartWork()
        {
            List<string> teams = CreateTeamsListInAlphabeticOrder();
            List<string> games = CreateGamesList();

            string rootFolder = @"C:\asdf";
            DeleteOldFilesInDirectory(rootFolder);

            CreateTextFilesWithCode(teams, games);
        }

        private static List<string> CreateGamesList()
        {
            return new List<string>
            {
                "Turkiet_Italien",
                "Wales_Schweiz",
                "Danmark_Finland",
                "Belgien_Ryssland",
                "England_Kroatien",
                "Österrike_Nordmakedonien",
                "Nederländerna_Ukraina",
                "Skottland_Tjeckien",
                "Polen_Slovakien",
                "Spanien_Sverige",
                "Ungern_Portugal",
                "Frankrike_Tyskland",
                "Finland_Ryssland",
                "Turkiet_Wales",
                "Italien_Schweiz",
                "Ukraina_Nordmakedonien",
                "Danmark_Belgien",
                "Nederländerna_Österrike",
                "Sverige_Slovakien",
                "Kroatien_Tjeckien",
                "England_Skottland",
                "Ungern_Frankrike",
                "Portugal_Tyskland",
                "Spanien_Polen",
                "Italien_Wales",
                "Schweiz_Turkiet",
                "Nordmakedonien_Nederländerna",
                "Ukraina_Österrike",
                "Ryssland_Danmark",
                "Finland_Belgien",
                "Tjeckien_England",
                "Kroatien_Skottland",
                "Slovakien_Spaninen",
                "Sverige_Polen",
                "Tyskland_Ungern",
                "Portugal_Frankrike"
            };
        }

        private static List<string> CreateTeamsListInAlphabeticOrder()
        {
            var list = new List<string>
            {
                "Belgien",
                "Danmark",
                "England",
                "Finland",
                "Frankrike",
                "Italien",
                "Kroatien",
                "Nederländerna",
                "Nordmakedonien",
                "Polen",
                "Portugal",
                "Ryssland",
                "Schweiz",
                "Skottland",
                "Slovakien",
                "Spanien",
                "Sverige",
                "Tjeckien",
                "Turkiet",
                "Tyskland",
                "Ukraina",
                "Ungern",
                "Wales",
                "Österrike"
            };

            list = list.OrderBy(l => l).ToList();

            return list;
        }

        private static void DeleteOldFilesInDirectory(string rootFolder)
        {
            string[] files = Directory.GetFiles(rootFolder);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        private static void CreateTextFilesWithCode(List<string> teams, List<string> games)
        {
            CreateTestFile();

            CreateSqlScriptForDataBaseTable(games);
            CreateSqlScriptForCorrectAnswer(games);

            BusinessLogic_ParticipateInTips(games);
            DataLogic_CalculatePoints(games);
            DataLogic_ManipulateTextStrings(games);
            DataLogic_SaveCorrectAnswers(games);
            DataLogic_SaveTipsDataToLogFile(games);
            PdfLogic_SaveTipsDatas(games);
            TipsDataDisplay_Properties(games);
            TipsDataDisplay_Constructor(games);
            IndexCshtml_OnlyTh(games);
            IndexCshtml_ForeachItemInModel(games);
            IndexCshtml_TrTd(games);
            ParticipateCshtml_Matches(games);
            ParticipateCshtml_Teams(teams);
            IndexCshtml_SaveResultsTh(games);
            IndexCshtml_SaveResultsTextBoxFor(games);
        }

        private static void CreateSqlScriptForCorrectAnswer(List<string> games)
        {
            /*
              INSERT INTO TipsDatas (Namn, PhoneNumber,Email,HasPayed,Poäng,Finallag1,Finallag2,Vinnare,
              [Sverige-Danmark],
              [Norge-Finland],
              [Sverige-Norge],
              [Danmark-Finland],
              [Sverige-Finland],
              [Norge-Danmark],
              [EntryDate])
              VALUES('Rätt svar','0','0','1','0','-','-','-',
              '-',
              '-',
              '-',
              '-',
              '-',
              '-',
              GETDATE())
             */
            string filename = FOLDERPATH + "CreateSqlScriptForCorrectAnswer.sql";
            using (var tw = new StreamWriter(filename, true))
            {
                tw.WriteLine($"INSERT INTO TipsDatas (Namn, PhoneNumber,Email,HasPayed,Poäng,Finallag1,Finallag2,Vinnare,");
                foreach (var game in games)
                {
                    var gameString = game.Replace('_', '-');
                    tw.WriteLine($"[{gameString}],");
                }
                tw.WriteLine($"[EntryDate])");
                tw.WriteLine($"VALUES('Rätt svar','0','0','1','0','-','-','-',");
                foreach (var game in games)
                {
                    tw.WriteLine($"'-',");
                }
                tw.WriteLine($"GETDATE())");
            }
        }

        private static void IndexCshtml_SaveResultsTextBoxFor(List<string> games)
        {
            //  < th >
            //      @Html.TextBoxFor(m => m.Ryssland_Saudiarabien)
            //  </ th >

            string filename = FOLDERPATH + "IndexCshtml_SaveResultsTextBoxFor.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    tw.WriteLine($"<th>");
                    tw.WriteLine($"@Html.TextBoxFor(m => m.{game})");
                    tw.WriteLine($"</th>");
                }
            }
        }

        private static void IndexCshtml_SaveResultsTh(List<string> games)
        {
            // < th >
            //     Rys - Sau
            // </ th >     

            string filename = FOLDERPATH + "IndexCshtml_SaveResultsTh.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    string[] split = game.Split('_');

                    string firstTeam = split[0].Substring(0, 3);
                    string secondTeam = split[1].Substring(0, 3);

                    tw.WriteLine($"<th>");
                    tw.WriteLine($"{firstTeam} - {secondTeam}");
                    tw.WriteLine($"</th>");
                }
            }
        }

        private static void ParticipateCshtml_Teams(List<string> teams)
        {
            /*
             * <option value="Argentina" selected="selected">
                   Argentina
               </option>
               --------------------------
               <option value="Australien">
                   Australien
               </option>
             */
            string filename = FOLDERPATH + "ParticipateCshtml_Teams.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                bool firstEntry = true;
                foreach (var team in teams)
                {
                    if (firstEntry)
                    {
                        firstEntry = false;
                        tw.WriteLine($"<option value=\"{team}\" selected=\"selected\">");
                    }
                    else
                    {
                        tw.WriteLine($"<option value=\"{team}\">");
                    }
                    tw.WriteLine($"{team}");
                    tw.WriteLine($"</option>");
                }
            }
        }

        private static void ParticipateCshtml_Matches(List<string> games)
        {
            //<tr>
            //    <td class="pw">Ryssland – Saudiarabien</td>
            //    <td>
            //        <select size="1" name="ryssau1"><option value="0" selected="selected">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select>
            //        - <select size="1" name="ryssau2"><option value="0" selected="selected">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select>
            //    </td>
            //</tr>
            string filename = FOLDERPATH + "ParticipateCshtml_Matches.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    var gameString = game.Replace('_', '-');
                    var index = gameString.IndexOf('-');

                    gameString = gameString.Insert(index + 1, " ");
                    gameString = gameString.Insert(index, " ");

                    string[] split = game.Split('_');

                    string firstTeam = split[0].Substring(0, 3).ToLower();
                    string secondTeam = split[1].Substring(0, 3).ToLower();

                    tw.WriteLine($"<tr>");
                    tw.WriteLine($"<td class=\"pw\">{gameString}</td>");
                    tw.WriteLine($"<td>");
                    tw.WriteLine($"<select size=\"1\" name=\"{firstTeam}{secondTeam}1\" ><option value=\"0\" selected=\"selected\" >0</option><option value=\"1\" >1</option><option value=\"2\" >2</option><option value=\"3\" >3</option><option value=\"4\" >4</option><option value=\"5\" >5</option><option value=\"6\" >6</option><option value=\"7\" >7</option><option value=\"8\" >8</option><option value=\"9\" >9</option></select>");
                    tw.WriteLine($"- <select size=\"1\" name=\"{firstTeam}{secondTeam}2\"><option value=\"0\" selected=\"selected\" >0</option><option value=\"1\" >1</option><option value=\"2\" >2</option><option value=\"3\" >3</option><option value=\"4\" >4</option><option value=\"5\" >5</option><option value=\"6\" >6</option><option value=\"7\" >7</option><option value=\"8\" >8</option><option value=\"9\" >9</option></select>");
                    tw.WriteLine($"</td>");
                    tw.WriteLine($"</tr>");
                }
            }
        }

        private static void IndexCshtml_TrTd(List<string> games)
        {
            // <td style = "@ryssau">
            //     @item.Ryssland_Saudiarabien
            // </ td >
            string filename = FOLDERPATH + "IndexCshtml_TrTd.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    string[] split = game.Split('_');

                    string firstTeam = split[0].Substring(0, 3).ToLower();
                    string secondTeam = split[1].Substring(0, 3).ToLower();

                    tw.WriteLine($"<td style = \"@{firstTeam}{secondTeam}\">");
                    tw.WriteLine($"@item.{game}");
                    tw.WriteLine($"</td>");
                }
            }
        }

        private static void IndexCshtml_ForeachItemInModel(List<string> games)
        {
            //var argisl = (item.Argentina_Island == Model[0].Argentina_Island) ? "color:#00D600" : "";
            string filename = FOLDERPATH + "IndexCshtml_ForeachItemInModel.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    string[] split = game.Split('_');

                    string firstTeam = split[0].Substring(0, 3).ToLower();
                    string secondTeam = split[1].Substring(0, 3).ToLower();

                    tw.WriteLine($"var {firstTeam}{secondTeam} = (item.{game} == Model[0].{game}) ? \"color:#00D600\" : \"\";");
                }
            }
        }

        private static void IndexCshtml_OnlyTh(List<string> games)
        {
            string filename = FOLDERPATH + "IndexCshtml_OnlyTh.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    /*
                        <th>
                            Rys-Sau
                        </th>
                     */
                    string[] split = game.Split('_');

                    string firstTeam = split[0].Substring(0, 3);
                    string secondTeam = split[1].Substring(0, 3);
                    tw.WriteLine($"<th>");
                    tw.WriteLine($"{firstTeam}-{secondTeam}");
                    tw.WriteLine($"</th>");
                }
            }
        }

        private static void TipsDataDisplay_Constructor(List<string> games)
        {
            //Ryssland_Saudiarabien = td.Ryssland_Saudiarabien;
            string filename = FOLDERPATH + "TipsDataDisplay_Constructor.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    tw.WriteLine($"{game} = td.{game};");
                }
            }
        }

        private static void TipsDataDisplay_Properties(List<string> games)
        {
            //public string Ryssland_Saudiarabien { get; set; }
            string filename = FOLDERPATH + "TipsDataDisplay_Properties.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    tw.WriteLine($"public string {game} {{ get; set; }}");
                }
            }
        }

        private static void PdfLogic_SaveTipsDatas(List<string> games)
        {
            //yCoord = DrawTheString("Ryssland - Saudiarabien", tipsData.Ryssland_Saudiarabien, yCoord, xCoordGame, xCoordResult, graph, fontMedium);
            string filename = FOLDERPATH + "PdfLogic_SaveTipsDatas.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    var gameString = game.Replace('_', '-');
                    var index = gameString.IndexOf('-');

                    gameString = gameString.Insert(index + 1, " ");
                    gameString = gameString.Insert(index, " ");

                    tw.WriteLine($"yCoord = DrawTheString(\"{gameString}\", tipsData.{game}, yCoord, xCoordGame, xCoordResult, graph, fontMedium);");
                }
            }
        }

        private static void DataLogic_SaveTipsDataToLogFile(List<string> games)
        {
            //logText += string.Format("Ryssland_Saudiarabien: {0},", t.Ryssland_Saudiarabien);
            string filename = FOLDERPATH + "DataLogic_SaveTipsDataToLogFile.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    tw.WriteLine($"logText += string.Format(\"{game}: {{0}},\", t.{game});");
                }
            }
        }

        private static void DataLogic_SaveCorrectAnswers(List<string> games)
        {
            //result.Argentina_Island = model.Argentina_Island;
            string filename = FOLDERPATH + "DataLogic_SaveCorrectAnswers.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    tw.WriteLine($"result.{game} = model.{game};");
                }
            }
        }

        private static void DataLogic_ManipulateTextStrings(List<string> games)
        {
            //  item.Argentina_Island = item.Argentina_Island.Insert(1, "-");
            string filename = FOLDERPATH + "DataLogic_ManipulateTextStrings.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    tw.WriteLine($"item.{game} = item.{game}.Insert(1, \"-\");");
                }
            }
        }

        private static void DataLogic_CalculatePoints(List<string> games)
        {
            //if (item.Argentina_Island == correct.Argentina_Island)
            //    points++;
            //

            string filename = FOLDERPATH + "DataLogic_CalculatePoints.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    tw.WriteLine($"if (item.{game} == correct.{game})");
                    tw.WriteLine($"points++;");
                    tw.WriteLine($"");
                }
            }
        }

        private static void BusinessLogic_ParticipateInTips(List<string> games)
        {
            //Argentina_Island = GetGameResult(col, "argisl"),
            string filename = FOLDERPATH + "BusinessLogic_ParticipateInTips.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                foreach (var game in games)
                {
                    string[] split = game.Split('_');

                    string sixChar = split[0].Substring(0, 3).ToLower() + split[1].Substring(0, 3).ToLower();

                    tw.WriteLine($"{game} = GetGameResult(col, \"{sixChar}\"),");
                }
            }
        }

        private static void CreateSqlScriptForDataBaseTable(List<string> games)
        {
            string filename = FOLDERPATH + "tblTipsDatas.sql";
            using (var tw = new StreamWriter(filename, true))
            {
                tw.WriteLine("USE[MartinDatabase]");
                tw.WriteLine("GO");
                tw.WriteLine("SET ANSI_NULLS ON");
                tw.WriteLine("GO");
                tw.WriteLine("SET QUOTED_IDENTIFIER ON");
                tw.WriteLine("GO");

                tw.WriteLine("CREATE TABLE [dbo].[TipsDatas](	[Id] [int] IDENTITY(1,1) NOT NULL,[Namn] [nvarchar](50) NULL,");
                tw.WriteLine("[PhoneNumber] [nvarchar](50) NULL,	[Email] [nvarchar](50) NULL,	[HasPayed] [bit] NULL,");
                tw.WriteLine("[Poäng] [int] NULL,	[Finallag1] [nvarchar](50) NULL, [Finallag2] [nvarchar](50) NULL,");
                tw.WriteLine("[Vinnare] [nvarchar](50) NULL,");

                foreach (var game in games)
                {
                    var gameString = game.Replace('_', '-');
                    //"[Ryssland-Saudiarabien] [nvarchar](50) NULL,";

                    tw.WriteLine($"[{gameString}] [nvarchar](50) NULL,");
                }

                tw.WriteLine("[EntryDate] [datetime2] (7) NULL,");
                tw.WriteLine("CONSTRAINT [PK_TipsDatas] PRIMARY KEY CLUSTERED (	[Id] ASC");
                tw.WriteLine(")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)");
                tw.WriteLine(")");
                tw.WriteLine("GO");


            }
        }

        private static void CreateTestFile()
        {
            string filename = FOLDERPATH + "testFile.txt";
            using (var tw = new StreamWriter(filename, true))
            {
                tw.WriteLine("The next line!");
                tw.WriteLine("The next line!");
                tw.WriteLine("The next line!");
            }
        }



    }
}
