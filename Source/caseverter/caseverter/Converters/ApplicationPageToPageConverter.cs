using System;
using System.Diagnostics;
using System.Globalization;
using caseverter.Core;

namespace caseverter
{
    /// <summary>
    /// Converter To Change <see cref="ApplicationPage"/> (enum) Into Corresponding Page
    /// </summary>
    public class ApplicationPageToPageConverter : BaseValueConverter<ApplicationPageToPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get Appropriate Page Based On Value
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Actions:
                    return new ActionsPage();

                case ApplicationPage.Settings:
                    return new SettingsPage();

                default:
                    //Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

