using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Day17App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void launchURIBing_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uriBing = new Uri(@"http://www.bing.com");

            // Set the option to show a warning
            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;
            //promptOptions.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
        }

        private async void launchMsCall_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uriBing = new Uri("ms-call:settings");

            // Set the option to show a warning
            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;
            //promptOptions.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
        }

        private async void launchEmail_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uriBing = new Uri("mailto:");

            // Set the option to show a warning
            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;
            //promptOptions.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
        }

        private async void launchSDKSampleURIScheme_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uriBing = new Uri("alsdk:");

            // Set the option to show a warning
            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;
            //promptOptions.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
        }

        async Task<string> LaunchAppForResults()
        {
            var testAppUri = new Uri("test-app2app:"); // The protocol handled by the launched app
            var options = new LauncherOptions();
            options.TargetApplicationPackageFamilyName = "67d987e1-e842-4229-9f7c-98cf13b5da45_yd7nk54bq29ra";

            var inputData = new ValueSet();
            inputData["TestData"] = "Test data";

            string theResult = "";
            LaunchUriResult result = await Windows.System.Launcher.LaunchUriForResultsAsync(testAppUri, options, inputData);
            if (result.Status == LaunchUriStatus.Success &&
                result.Result != null &&
                result.Result.ContainsKey("ReturnedData"))
            {
                ValueSet theValues = result.Result;
                theResult = theValues["ReturnedData"] as string;
            }
            return theResult;
        }

        private async void LaunchAnAppForResults_Click(object sender, RoutedEventArgs e)
        {
            await LaunchAppForResults();
        }
    }
}
