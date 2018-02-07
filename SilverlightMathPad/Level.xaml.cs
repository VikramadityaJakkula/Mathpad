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

namespace SilverlightMathPad
{
    public partial class Level : UserControl
    {
        int intLevel;
        int intScore;
        int intTime;
        string strOption, strCategory;
        public Level()
        {
            InitializeComponent();

        }
        public Level(string Category, string option, int Level, int Score, int TimeSec)
            : this()
        {
            this.strOption = option;
            this.intLevel = Level;
            this.intScore = Score;
            this.intTime = TimeSec;
            this.strCategory = Category;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new QuizPage(strCategory, strOption, intLevel,intScore,intTime));
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            label1.Content ="Level " +  intLevel.ToString();
            btnOperation.Content = strOption;
        }


    }
}
