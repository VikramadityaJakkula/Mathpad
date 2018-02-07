/****************************************************************************

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

-- A Digitial Clock in c#
-- Copyright 2009 Terence Tsang
-- admin@shinedraw.com
-- http://www.shinedraw.com
-- Your Flash vs Silverlight Repository

****************************************************************************/


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
    public partial class Counter : UserControl
    {
        private const double GRID_HEIGHT = 60;
        private int _lastValue = -1;

        public Counter()
        {
            InitializeComponent();
        }

        // create an animation to swap to another value
        public void AnimateTo(int value)
        {
            if (value!= _lastValue)
            {
                // update the value
                TranslateTransform translate = MyCounter.RenderTransform as TranslateTransform;
                translate.Y = -GRID_HEIGHT;
                OldValue.Content = NewValue.Content;
                NewValue.Content = value;

                DoubleAnimation doubleAnimation = new DoubleAnimation()
                {
                    From = -GRID_HEIGHT,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                };

                // create storyboard
                Storyboard sb1 = new Storyboard();
                Storyboard.SetTarget(doubleAnimation, translate);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(TranslateTransform.Y)"));
                sb1.Children.Add(doubleAnimation);
                sb1.Begin();
            }

            _lastValue = value;

        }
    }
}
