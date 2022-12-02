using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Focus_Nobody
{
    class FocusBehavior : Behavior<TextBoxBase>
    {
        public static readonly DependencyProperty IsControlFocusProperty = DependencyProperty.Register(
            nameof(IsControlFocus),
            typeof(bool),
            typeof(FocusBehavior),
            new PropertyMetadata(false, propertyChangedCallback: IsControlFocusPropertyChanged)
        );

        public bool IsControlFocus
        {
            get;
            set;
        }

        private static void IsControlFocusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FocusBehavior behavior)
            {
                behavior.AssociatedObject.Focus();
                behavior.AssociatedObject.SelectAll();
            }
        }
    }
}
