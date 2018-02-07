using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
//using SilverlightMathPad.MathWCFSvc;
using System.Windows.Browser;
using SilverlightMathPad.WCFMathPadSvc;
namespace SilverlightMathPad
{
    public partial class HallofFame : UserControl
    {
        public HallofFame()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        //private void btnHelp_Click(object sender, RoutedEventArgs e)
        //{
        //    Holder holder = this.Parent as Holder;
        //    holder.Navigate(new HelpPage());

        //}

        //private void btnAddition_Click(object sender, RoutedEventArgs e)
        //{
        //    Holder holder = this.Parent as Holder;
        //    holder.Navigate(new QuizPage("Addition"));
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new StartPage());

        }
        void obj_GetEntriesOfHallOfFameCompleted(object sender, GetEntriesOfHallOfFameCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result.Count > 0)
                {
                    // dtScore.DataContext = e.Result();

                    dtScore.ItemsSource = e.Result;


                    //   HtmlPage.Window.Alert("Record Inserted Successfully");
                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        
            MathPadServicesClient obj = new MathPadServicesClient();
            obj.GetEntriesOfHallOfFameCompleted += new EventHandler<GetEntriesOfHallOfFameCompletedEventArgs>(obj_GetEntriesOfHallOfFameCompleted);
            obj.GetEntriesOfHallOfFameAsync();

        //    XDocument myXML = XDocument.Load("HallofFame.xml");

        //    try
        //    {

        //        myXML.Element("Scores").Add(new XElement("Score", new XElement("Name", "Cedric"), new XElement("Level", "10"),
        //            new XElement("Points", "3000"),
        //            new XElement("Time", "310"),
        //            new XElement("Operation", "Subtraction"),
        //              new XElement("Date", System.DateTime.Now.ToString())));
        //        myXML.Save(new FileStream("HallofFame.xml", FileMode.Append));
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    ////myXml.Element( "persons" ).Element( "person" ).Remove();
        //    int i;
        //    try
        //    {
        //        List<Score> ScoreList =
        //            (from Score in myXML.Descendants("Score")
        //           //   where (( string )Score.Element( "address" ).Attribute( "country" )).Equals( "Bulgaria" ) 
        //             select new Score()
        //             {
        //                 Name = Score.Element("Name").Value,
        //              Level =  Score.Element("Level").Value,
        //                 Points = Score.Element("Points").Value,
        //                Time = Score.Element("Time").Value,
        //                 Operation = Score.Element("Operation").Value,
        //                  Date = Score.Element("Date").Value

        //             }).ToList();
        //        i = ScoreList.Count;

        //    }
        //    catch (Exception ex)
        //    {
        //    }

       }



    }

    //public class Score
    //{
    //    public string Name { get; set; }
    //    public string Level { get; set; }
    //    public string Points { get; set; }
    //    public string Time { get; set; }
    //    public string Operation { get; set; }
    //    public string Date { get; set; }

    //}
}
