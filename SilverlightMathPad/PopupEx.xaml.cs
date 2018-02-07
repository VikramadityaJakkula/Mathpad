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
using SilverlightMathPad.AppCode;
using SilverlightMathPad.WCFMathPadSvc;
using System.Text.RegularExpressions;

namespace SilverlightMathPad
{
    public partial class PopupEx : UserControl
    {
        public string Message
        {
            set
            {
                txtName.Text = value;
            }
            get
            {
                return txtName.Text;
            }
        }
        void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || IsValidAlphaKey(e.Key))// || IsValidOtherKey(e.Key))
            {
                e.Handled = false;
                //return true;

            }
            else
                e.Handled = false;
            //return false;
            //txtName.Text = txtName.Text.ToString().Remove(txtName.Text.Length - 1);
            //  txtName.Text = txtName.Text.
        }
        private static bool IsValidOtherKey(Key key)
        {
            // allow control keys
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                return true;
            }
            // allow
            // Back, Tab, Enter, Shift, Ctrl, Alt, CapsLock, Escape, PageUp, PageDown
            // End, Home, Left, Up, Right, Down, Insert, Delete 
            // except for space!
            // allow all Fx keys
            if (
                (key < Key.D0 && key != Key.Space)
                || (key > Key.Z && key < Key.NumPad0))
            {
                return true;
            }
            // we need to examine all others!
            return false;
        }

        private static bool IsValidAlphaKey(Key key)
        {
            if (Key.A <= key && key <= Key.Z)
            {
                return true;
            }
            return false;
        }
        public PopupEx()
        {
            InitializeComponent();
            txtName.Focus();
            //  txtName.KeyUp += new KeyEventHandler(txtName_KeyUp);

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //validate name
            string strName = txtName.Text;
            if (strName.Length > 40)
            {
                MessageBox.Show("Name cannot be more that 40 character", "Error", MessageBoxButton.OK);
                return;
            }
            if (!(Regex.IsMatch(strName, "^([ \u00c0-\u01ffa-zA-Z'])+$")))
            {
                MessageBox.Show("Please enter valid Name", "Error", MessageBoxButton.OK);
                return;
            }




            media.Play();
            StaticData.Name = Message;

            MathPadServicesClient objScore = new MathPadServicesClient();
            objScore.GetTopScoreCompleted += new EventHandler<GetTopScoreCompletedEventArgs>(obj_GetTopScoreCompleted);
            objScore.GetTopScoreAsync();

            MathPadServicesClient objSvc = new MathPadServicesClient();
            objSvc.AddHallofFameAsync(StaticData.Name, int.Parse(StaticData.Points), int.Parse(StaticData.Time), StaticData.Category);


            this.Visibility = Visibility.Collapsed;

        }

        void obj_GetTopScoreCompleted(object sender, GetTopScoreCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (int.Parse(StaticData.Points) >= e.Result)
                {
                    //Add to Score board
                    MathPadServicesClient obj = new MathPadServicesClient();
                    obj.AddScoreBoardAsync(StaticData.Name, int.Parse(StaticData.Points), int.Parse(StaticData.Time), StaticData.Category);


                }

            }
        }

    }
}
