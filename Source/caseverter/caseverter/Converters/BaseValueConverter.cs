using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace caseverter
{
    /// <summary>
    /// Base Value Converter Allowing XAML Usage
    /// </summary>
    /// <typeparam name="T"> Type of the Value Converter </typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        /// <summary>
        /// Instance of the Value Converter
        /// </summary>
        private static T mConverter = null;

        #endregion

        #region MarkupExtension Methods

        /// <summary>
        /// Provides Static Instance of the Value Converter
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        #endregion

        #region ValueConverter Methods

        /// <summary>
        /// Method to Convert One Type to Another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Method to Convert Back One Type to the Source Type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
