﻿using System;
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
//using SilverlightMathPad.MathWCFSvc;
using System.Windows.Browser;

namespace SilverlightMathPad
{
    public partial class App : Application
    {

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }
        private static Grid root;
        public void Navigate(UserControl newPage)
        {
           
            UserControl oldPage = root.Children[0] as UserControl; 
            root.Children.Add(newPage);
            root.Children.Remove(oldPage);
        }
        

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.RootVisual = new Holder();

        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
           
            Holder hold = (Holder)this.RootVisual;
            hold.Navigate(new StartPage());
            e.Handled = true;
           
        }
        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
