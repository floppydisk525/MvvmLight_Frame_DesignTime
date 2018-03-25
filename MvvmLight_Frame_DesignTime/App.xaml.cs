using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace MvvmLight_Frame_DesignTime
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
