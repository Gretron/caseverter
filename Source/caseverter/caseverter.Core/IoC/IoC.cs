using caseverter;
using Ninject;

namespace caseverter.Core
{
    /// <summary>
    /// IoC for Application
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// Kernel for IoC
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel(); 
        
        #endregion



        #region Construction

        /// <summary>
        /// Sets Up IoC by Binding All Information Required
        /// </summary>
        public static void Setup()
        {
            // Bind All Required Singletons
            BindSingletons();
        }

        /// <summary>
        /// Binds All Singletons to Kernel
        /// </summary>
        public static void BindSingletons()
        {
            // Bind to Single Instance of ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        /// <summary>
        /// Gets Object of Specified Type From IoC
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
