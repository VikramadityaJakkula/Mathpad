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
using System.Xml.Linq;
using System.IO.IsolatedStorage;
//using SilverlightMathPad.MathWCFSvc;
using System.Windows.Browser;
using System.IO;
using SilverlightMathPad.WCFMathPadSvc;
using System.Windows.Controls.Primitives;
using SilverlightMathPad.AppCode;

namespace SilverlightMathPad
{
    public partial class GameOver : UserControl
    {
        System.Windows.Threading.DispatcherTimer TimeCount = new System.Windows.Threading.DispatcherTimer();

        //int intLevel;
        //int intScore;
        //int inttime;
        //string strOption;
        string strPage;

        public GameOver()
        {
            InitializeComponent();
            TimeCount.Interval = new TimeSpan(0, 0, 0, 1, 0); // 500 Milliseconds  
            TimeCount.Tick += new EventHandler(TimeCount_Tick);
            TimeCount.Start();
        }
        void TimeCount_Tick(object sender, EventArgs e)
        {

          
            if (txtHallOfFame.Visibility == Visibility.Visible)
                txtHallOfFame.Visibility = Visibility.Collapsed;
            else
                txtHallOfFame.Visibility = Visibility.Visible;
           
        }
        public GameOver(string Category, string option, int intLevel, int intScore, int intTime)
            : this()
        {
         
            //this.strOption = option;
            //this.intLevel = Level;
            //this.intScore = Score;
            //this.inttime = Time;
            //  this.strCategory = Category;
            Score.Content = intScore.ToString();
            Level.Content = intLevel.ToString();
            Game.Content = option;
            Time.Content = intTime.ToString() + " Seconds";
            strPage = option;
            StaticData.Points = intScore.ToString();
            StaticData.Time = intTime.ToString();
            StaticData.Category = option;
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{


        //}

        //private void btnHelp_Click(object sender, RoutedEventArgs e)
        //{
        //    Holder holder = this.Parent as Holder;
        //    holder.Navigate(new HelpPage());

        //}

        //private void btnAddition_Click(object sender, RoutedEventArgs e)
        //{
        //    Holder holder = this.Parent as Holder;
        //    holder.Navigate(new Level("Basic Math","Addition",1,500,0));
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Scoreboard());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new HallofFame());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new StartPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


            Holder holder = this.Parent as Holder;
            holder.Navigate(new Level("Basic Math", "Multiplication", 1, 500, 0));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Level("Basic Math", "Subtraction", 1, 500, 0));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Level("Basic Math", "Division", 1, 500, 0));
        }

        //private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        //{
        //    Holder holder = this.Parent as Holder;
        //    holder.Navigate(new HelpPage());
        //}


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (Level.Content.ToString() == "10")
            {
                //Check for Top Score
                //int TpScore = 0;
                MathPadServicesClient objScore = new MathPadServicesClient();

                objScore.GetTopScoreCompleted += new EventHandler<GetTopScoreCompletedEventArgs>(obj_GetTopScoreCompleted);
                objScore.GetTopScoreAsync();

                image1.Visibility = System.Windows.Visibility.Visible;
                txtHallOfFame.Text = "You have entered HALL OF FAME";
                txtHallOfFame.Visibility = System.Windows.Visibility.Visible;
                Popup p = new Popup();
                PopupEx obj = new PopupEx();
                p.Child = obj;
                // Set where the popup will show up on the screen. 
                p.VerticalOffset = 200;
                p.HorizontalOffset = 200;
                //  StaticData.Data = "0";

                //  Open the popup. 
                p.IsOpen = true;


                //       MathPadServicesClient objSvc = new MathPadServicesClient();
                //     objSvc.AddHallofFameAsync(StaticData.Data, int.Parse(Score.Content.ToString()), int.Parse(Time.Content.ToString()), strCategory);


            }
            else
            {
                image1.Visibility = System.Windows.Visibility.Collapsed;
                txtHallOfFame.Text= "";
            }





        }
        void obj_GetTopScoreCompleted(object sender, GetTopScoreCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (Convert.ToInt16(Score.Content.ToString()) >= e.Result)
                {
                    mediaScore.Play();
                    image1.Visibility = System.Windows.Visibility.Visible;
                  //  label1.Content = "Top Score. You have entered the SCORE BOARD";
                    txtHallOfFame.Text = "You have entered SCORE BOARD";
                    mediaScore.Play();
                    //Add to Score board
                    //   MathPadServicesClient obj = new MathPadServicesClient();
                    // obj.AddScoreBoardAsync(StaticData.Data, int.Parse(Score.Content.ToString()), int.Parse(Time.Content.ToString()), strCategory);


                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            switch (strPage)
            {
                case "Addition":
                    holder.Navigate(new Level("Basic Math", "Addition", 1, 500, 0));
                    break;
                case "Multiplication":
                    holder.Navigate(new Level("Basic Math", "Multiplication", 1, 500, 0));
                    break;
                case "Subtraction":
                    holder.Navigate(new Level("Basic Math", "Subtraction", 1, 500, 0));
                    break;
                case "Division":
                    holder.Navigate(new Level("Basic Math", "Division", 1, 500, 0));
                    break;
                case "Time":
                    holder.Navigate(new Level("Advance Math", "Time", 1, 500, 0));
                    break;
                case "Percentage":
                    holder.Navigate(new Level("Advance Math", "Percentage", 1, 500, 0));
                    break;
                case "SimpleInterest":
                    holder.Navigate(new Level("Basic Math", "SimpleInterest", 1, 500, 0));
                    break;
                case "Discount":
                    holder.Navigate(new Level("Advance Math", "Discount", 1, 500, 0));
                    break;
                case "Currency":
                    holder.Navigate(new Level("Advance Math", "Currency", 1, 500, 0));
                    break;
                case "Rounding":
                    holder.Navigate(new Level("Advance Math", "Rounding", 1, 500, 0));
                    break;
                case "Fractions":
                    holder.Navigate(new Level("Advance Math", "Fractions", 1, 500, 0));
                    break;
                case "SalesTax":
                    holder.Navigate(new Level("Every Day Math", "SalesTax", 1, 500, 0));
                    break;
                case "SalesTaxWithPrice":
                    holder.Navigate(new Level("Every Day Math", "SalesTaxWithPrice", 1, 500, 0));
                    break;
                case "Commission":
                    holder.Navigate(new Level("Every Day Math", "Commission", 1, 500, 0));
                    break;
                case "Shipping":
                    holder.Navigate(new Level("Every Day Math", "Shipping", 1, 500, 0));
                    break;
                case "Tips":
                    holder.Navigate(new Level("Every Day Math", "Tips", 1, 500, 0));
                    break;
                case "Exponents":
                    holder.Navigate(new Level("Every Day Math", "Exponents", 1, 500, 0));
                    break;
            }

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Scoreboard());
        }

        //void obj_ScoreBoardCompleted(object sender,  AddScoreBoardCompletedEventArgs e)
        //{
        //    if (e.Result != null)
        //    {

        //    }
        //}

        //void obj_AddHallofFameCompleted(object sender,  AddHallofFameCompletedEventArgs e)
        //{
        //    if (e.Result != null)
        //    {

        //    }
        //}
    }
}
