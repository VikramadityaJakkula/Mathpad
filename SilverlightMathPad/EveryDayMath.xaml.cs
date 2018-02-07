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
    public partial class EveryDayMath : UserControl
    {
        public EveryDayMath()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new HelpPage("EveryDayMath"));

        }

        private void btnAddition_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Level("Every Day Math", "SalesTax", 1, 500, 0));
        }

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
            holder.Navigate(new Level("Every Day Math", "SalesTaxWithPrice", 1, 500, 0));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Level("Every Day Math", "Commission", 1, 500, 0));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Level("Every Day Math", "Shipping", 1, 500, 0));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new Level("Every Day Math", "Tips", 1, 500, 0));
       
        }
    }
}
