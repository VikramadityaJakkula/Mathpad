using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.IO;
using System.Globalization;

namespace SilverlightMathPad.Web
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MathPadServices" in code, svc and config file together.
    public class MathPadServices : IMathPadServices
    {
        IFormatProvider culture = new CultureInfo("en-US", true);

        #region IMathService Members
        public void AddEntryToHallOfFame(HallOfFameEntry objEntry)
        {
            XmlDocument objDoc = new XmlDocument();
            objDoc.Load("HallofFame.xml");
        }

        public HallOfFameEntry[] GetEntriesOfHallOfFame()
        {
            string strPath = "";
            try
            {
                
        //        WriteToLog("GetEntriesOfHallOfFame called");
                XmlDocument objDoc = new XmlDocument();
                strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\HallofFame.xml");
                objDoc.Load(strPath);
                XmlNodeList lst = objDoc.SelectNodes("//Scores");
                HallOfFameEntry[] arr = new HallOfFameEntry[lst.Count];
                int cnt = 0;
                foreach (XmlNode nd in lst)
                {
                    arr[cnt] = new HallOfFameEntry();
                    arr[cnt].Name = nd.SelectSingleNode("Name").InnerText;
                    arr[cnt].QuizType = nd.SelectSingleNode("Operation").InnerText;
                    arr[cnt].Score = int.Parse(nd.SelectSingleNode("Points").InnerText);
                   // arr[cnt].Date = DateTime.ParseExact(nd.SelectSingleNode("Date").InnerText,"MM/dd/yyyy H:m:s", culture).ToShortDateString();
                    arr[cnt].Date = Convert.ToDateTime(nd.SelectSingleNode("Date").InnerText, culture).ToShortDateString();
                    arr[cnt].Time = nd.SelectSingleNode("Time").InnerText;
                    cnt++;
                }
                return arr;
            }
            catch (Exception ex)
            {
                WriteToLog("strPath: " + strPath);
                WriteToLog("Locale: "+System.Globalization.CultureInfo.CurrentCulture.Name);
                WriteToLog(ex,"Error in GetEntriesOfHallOfFame");
                return null;
            }

        }

        public void AddHallofFame(string strName, int intPoints, int intTime, string strOperation)
        {
            XmlDocument xmlDoc = default(XmlDocument);
            XmlNodeList list;
            XmlNode NewData;
            //  NewData = new XmlNode(
            xmlDoc = new XmlDocument();
            XmlNodeList l;
            int max = 0;
            try
            {
                xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\HallofFame.xml"));
                l = xmlDoc.GetElementsByTagName("Score");
                if (xmlDoc.SelectNodes("Score/Scores").Count >= 10)
                {
                    //Delete on of the child node
                    l[0].RemoveChild(xmlDoc.SelectNodes("Score/Scores")[0]);
                }



                //create main node    
                XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, "Scores", null);
                //create the nodes first child   
                XmlNode Name = xmlDoc.CreateElement("Name");
                //set the value    
                Name.InnerText = strName;
                //create the nodes second child    
                XmlNode Level = xmlDoc.CreateElement("Level");
                //set the value   
                Level.InnerText = "10";

                XmlNode Points = xmlDoc.CreateElement("Points");
                //set the value   
                Points.InnerText = intPoints.ToString();

                XmlNode Time = xmlDoc.CreateElement("Time");
                //set the value   
                Time.InnerText = intTime.ToString();

                XmlNode Operation = xmlDoc.CreateElement("Operation");
                //set the value   
                Operation.InnerText = strOperation.ToString();

                XmlNode Date = xmlDoc.CreateElement("Date");
                //set the value   
                Date.InnerText = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                // add childes to father    
                node.AppendChild(Name);
                node.AppendChild(Level);
                node.AppendChild(Points);
                node.AppendChild(Time);
                node.AppendChild(Operation);
                node.AppendChild(Date);


                // append the new node   
                l[0].AppendChild(node);

                xmlDoc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\HallofFame.xml"));
            }

            catch (Exception exCatchedError)
            {
                WriteToLog(exCatchedError, "Error in AddHallofFame");
            }


        }

        public void AddScoreBoard(string strName, int intPoints, int intTime, string strOperation)
        {
            XmlDocument xmlDoc = default(XmlDocument);
            xmlDoc = new XmlDocument();
            XmlNodeList l;
            string dateNew;
            XmlNodeList ScoreData;
            DateTime ScoreDate;
            XmlNode ChildNode;
            int count;
            try
            {
                xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\ScoreBoard.xml"));
                l = xmlDoc.GetElementsByTagName("Score");
                if (xmlDoc.SelectNodes("Score/Scores").Count >= 10)
                {
                    //Delete on of the child node ith Lowest Score
                    ScoreData = xmlDoc.SelectNodes("Score/Scores[Points=" + GetTopScore().ToString() + "]");
                    count = 0;
                    if (ScoreData.Count > 1)
                    {
                        ScoreDate = Convert.ToDateTime(ScoreData[0].SelectSingleNode("Date").InnerText);
                        for (int i = ScoreData.Count - 1; i > 0; i--)
                            if (Convert.ToDateTime(ScoreData[0].SelectSingleNode("Date").InnerText) < ScoreDate)
                            {
                                ScoreDate = Convert.ToDateTime(ScoreData[0].SelectSingleNode("Date").InnerText.ToString(), culture);
                                count = i;
                            }
                    }
                    l[0].RemoveChild(ScoreData[count]);
                }
                //create main node    
                XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, "Scores", null);

                //create the nodes first child   
                XmlNode Name = xmlDoc.CreateElement("Name");
                Name.InnerText = strName;

                //create the nodes second child    

                XmlNode Level = xmlDoc.CreateElement("Level");
                Level.InnerText = "10";

                XmlNode Points = xmlDoc.CreateElement("Points");
                Points.InnerText = intPoints.ToString();

                XmlNode Time = xmlDoc.CreateElement("Time");
                Time.InnerText = intTime.ToString();

                XmlNode Operation = xmlDoc.CreateElement("Operation");
                Operation.InnerText = strOperation.ToString();

                XmlNode Date = xmlDoc.CreateElement("Date");
                Date.InnerText = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                // add childes to father    
                node.AppendChild(Name);
                node.AppendChild(Level);
                node.AppendChild(Points);
                node.AppendChild(Time);
                node.AppendChild(Operation);
                node.AppendChild(Date);


                // append the new node   
                l[0].AppendChild(node);

                xmlDoc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\ScoreBoard.xml"));
            }

            catch (Exception exCatchedError)
            {
                WriteToLog(exCatchedError, "Error in AddScoreBoard");
            }
        }

        public int GetTopScore()
        {
            XmlDocument xmlDoc = default(XmlDocument);
            XmlNodeList list;
            xmlDoc = new XmlDocument();

            int max = 0;
            try
            {
                xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\ScoreBoard.xml"));
                list = xmlDoc.SelectNodes("Score/Scores");

                if (list.Count > 0)
                    max = Convert.ToInt32(list[0].SelectSingleNode("Points").InnerText);

                for (int i = list.Count - 1; i > 0; i--)
                    if (Convert.ToInt64(list[i].SelectSingleNode("Points").InnerText) < max)
                        max = Convert.ToInt32(list[i].SelectSingleNode("Points").InnerText);
            }
            catch (Exception exCatchedError)
            {
                WriteToLog(exCatchedError, "Error in GetTopScore");
            }

            return max;
        }

        public HallOfFameEntry[] GetEntriesOfScoreBoard()
        {
            try
            {
                XmlDocument objDoc = new XmlDocument();
                objDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\ScoreBoard.xml"));
                XmlNodeList lst = objDoc.SelectNodes("//Scores");
                HallOfFameEntry[] arr = new HallOfFameEntry[lst.Count];
                int cnt = 0;
                foreach (XmlNode nd in lst)
                {
                    arr[cnt] = new HallOfFameEntry();
                    arr[cnt].Name = nd.SelectSingleNode("Name").InnerText;
                    arr[cnt].QuizType = nd.SelectSingleNode("Operation").InnerText;
                    arr[cnt].Score = int.Parse(nd.SelectSingleNode("Points").InnerText);
                    arr[cnt].Date = Convert.ToDateTime(nd.SelectSingleNode("Date").InnerText.ToString(), culture).ToShortDateString();
                    arr[cnt].Time = nd.SelectSingleNode("Time").InnerText;
                    cnt++;
                }
                return arr;
            }
            catch (Exception exCatchedError)
            {
                WriteToLog(exCatchedError, "Error in GetTopScore");
                return null;
            }
            

        }

        public void WriteToLog(Exception errError, string strMessageDesc)
        {
            // Write to Error Logger 
            try
            {

                FileStream oFile = File.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLogger.txt"), FileMode.Append);
                System.IO.StreamWriter oWrite = new StreamWriter(oFile);
                oWrite.WriteLine("Date : " + DateTime.Now.ToString(), "ErrDescription");
                oWrite.WriteLine("Message : " + errError.Message, "ErrDescription");
                oWrite.WriteLine("Details : " + errError.StackTrace, "ErrDescription");
                oWrite.WriteLine();
                oWrite.Close();
            }
            catch
            {
                throw;
            }
        }
        public void WriteToLog(string strMessageDesc)
        {
            // Write to Error Logger 
            try
            {

                FileStream oFile = File.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLogger.txt"), FileMode.Append);
                System.IO.StreamWriter oWrite = new StreamWriter(oFile);
                oWrite.WriteLine("Date : " + DateTime.Now.ToString(), "ErrDescription");
                oWrite.WriteLine("Message : " + strMessageDesc);
                oWrite.WriteLine();
                oWrite.Close();
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
