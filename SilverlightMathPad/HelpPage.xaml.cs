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
    public partial class HelpPage : UserControl
    {
        string strPage;
        public HelpPage()
        {
            InitializeComponent();
            ;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            switch (strPage)
            {
                case "StartPage":
                    holder.Navigate(new StartPage());
                    break;
                case "EveryDayMath":
                    holder.Navigate(new EveryDayMath());
                    break;
                case "BasicMath":
                    holder.Navigate(new BasicMath());
                    break;
                case "AdvMath":
                    holder.Navigate(new AdvMath());
                    break;
            }



        }



        public HelpPage(string PageName)
            : this()
        {
            this.strPage = PageName;

        }


    }
}
