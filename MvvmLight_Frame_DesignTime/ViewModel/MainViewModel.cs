using GalaSoft.MvvmLight;
using MvvmLight_Frame_DesignTime.Model;
using System;
using System.Windows.Controls;

namespace MvvmLight_Frame_DesignTime.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// The <see cref="FrameUri" /> property's name.
        /// </summary>
        public const string FrameUriPropertyName = "FrameUri";

        private Uri _frameUri;

        /// <summary>
        /// Sets and gets the FrameUri property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri FrameUri
        {
            get
            {
                return _frameUri;
            }
            set
            {
                Set(FrameUriPropertyName, ref _frameUri, value);
                System.Diagnostics.Debug.WriteLine(_frameUri.ToString(), "_frameUri");
                System.Diagnostics.Debug.WriteLine(FrameUri.ToString(), "FrameUri");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
            FrameUri = ViewModelLocator.IntroPageUri;

#if DEBUG
            if (IsInDesignModeStatic)
            {
                //var page = ServiceLocator.Current.GetInstance<IntroViewModel>();
                //IntroPage introPage = new IntroPage();
                //Frame frame = new Frame();
                //Page page = new Page();
                
                

                //FrameUri = new Uri(ViewModelLocator.IntroPageUri.ToString(), UriKind.Relative);
            }
#endif
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}