using MakersMarkt.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace MakersMarkt
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static Frame MainRootFrame { get; private set; }
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var window = new MainWindow();
            var rootFrame = new Frame();

            window.Content = rootFrame;
            MainRootFrame = rootFrame; // Store the root frame reference
            rootFrame.Navigate(typeof(LoginPage));

            window.Activate();
        }
    }
}
