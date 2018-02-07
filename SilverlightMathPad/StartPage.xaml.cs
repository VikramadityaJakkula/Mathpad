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
using SilverlightMathPad.WCFMathPadSvc;
using System.Windows.Browser;
using System.IO;
using System.Windows.Controls.Primitives;
using SilverlightMathPad.AppCode;

namespace SilverlightMathPad
{
    public partial class StartPage : UserControl
    {
        public StartPage()
        {
            InitializeComponent();
            //SilverlightMathPad.WCFMathPadSvc.MathPadServicesClient cl = new MathPadServicesClient();
            //cl.GetTopScoreAsync();
            //cl.GetTopScoreCompleted +=new EventHandler<GetTopScoreCompletedEventArgs>(cl_GetTopScoreCompleted);
            
        }
        //private void cl_GetTopScoreCompleted(object sender, GetTopScoreCompletedEventArgs e)
        //{
        //    MessageBox.Show(e.Result.ToString());
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MathPadServicesClient obj = new MathPadServicesClient();
            //obj.GetEntriesOfHallOfFameCompleted += new EventHandler<GetEntriesOfHallOfFameCompletedEventArgs>(obj_GetEntriesOfHallOfFameCompleted);
            //obj.GetEntriesOfHallOfFameAsync();

          
          //  MessageBox.Show(obj.Message);
            
            Holder holder = this.Parent as Holder;
            holder.Navigate(new BasicMath());

        }
        //void obj_GetEntriesOfHallOfFameCompleted(object sender, GetEntriesOfHallOfFameCompletedEventArgs e)
        //{
        //    if (e.Result != null)
        //    {
        //        if (e.Result.Count > 0)
        //        {
        //            HtmlPage.Window.Alert("Record Inserted Successfully");
        //        }
        //    }
        //}
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(StaticData.Data);
            //string urlstr = @"background.wmv";
            //media.Source = new Uri(urlstr, UriKind.RelativeOrAbsolute);
            
       //   media.MediaFailed +=new EventHandler<ExceptionRoutedEventArgs>(media_MediaFailed);
           // media.Play();
           // mediaCry.Play();
                Holder holder = this.Parent as Holder;
                holder.Navigate(new HelpPage("StartPage"));

            
        }

        private void btnAdvMath_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new AdvMath());
        }

        private void btnEvDayMath_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new EveryDayMath());
        }
        //private void media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        //{
        //    MessageBox.Show(e.ErrorException.Message);
        //}
        private void btnScoreboard_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Scoreboard());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new HallofFame());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

       
    }
}
