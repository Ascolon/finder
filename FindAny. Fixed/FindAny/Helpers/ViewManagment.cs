using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FindAny.Helpers
{
    public class ViewManagment
    {
        public void RedirectUrl(string url)
        {
            var w = Application.Current.Windows.OfType<MainWindow>().First();
            w.Frame.Source = new Uri("View/" + url, UriKind.Relative);
        }

        public void Back()
        {
            var w = Application.Current.Windows.OfType<MainWindow>().First();
            w.Frame.GoBack();
        }
    }
}
