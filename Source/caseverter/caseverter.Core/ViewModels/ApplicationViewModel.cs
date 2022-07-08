namespace caseverter.Core
{
    /// <summary>
    /// ViewModel for Application
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// Current Page of the Application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.None;
    }
}
