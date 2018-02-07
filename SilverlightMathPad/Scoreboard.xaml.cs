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
using SilverlightMathPad.WCFMathPadSvc;
namespace SilverlightMathPad
{
    public partial class Scoreboard : UserControl
    {
        public Scoreboard()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        //private void btnHelp_Click(object sender, RoutedEventArgs e)
        //{
        //    Holder holder = this.Parent as Holder;
        //    holder.Navigate(new HelpPage(""));

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
        void obj_GetEntriesOfScoreBoardCompleted(object sender, GetEntriesOfScoreBoardCompletedEventArgs e)
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
            obj.GetEntriesOfScoreBoardCompleted += new EventHandler<GetEntriesOfScoreBoardCompletedEventArgs>(obj_GetEntriesOfScoreBoardCompleted);
            obj.GetEntriesOfScoreBoardAsync();

        }



    }
}
