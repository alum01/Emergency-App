using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Devices;
using System.IO.IsolatedStorage;


namespace EmergencyContacts
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Initialize VideoCamera objects;
        private VideoCamera _videoCamera;
        private VideoCameraVisualizer _videoCameraVisualizer;
        bool flashOn = false;
        bool flashInitialized = false;
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

     
        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (flashInitialized == false)
            {
                // Check to see if the camera is available on the device.
                if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary))
                {
                    // Use standard camera on back of device.
                    _videoCamera = new VideoCamera();

                    // Event is fired when the video camera object has been initialized.
                    _videoCamera.Initialized += VideoCamera_Initialized;

                    // Add the photo camera to the video source
                    _videoCameraVisualizer = new VideoCameraVisualizer();
                    _videoCameraVisualizer.SetSource(_videoCamera);
                }
                flashInitialized = true;
            }

            if (settings.Contains("myInfo"))
            {
                iceText.Text = settings["myInfo"].ToString();
            }
            else
            {
                settings.Add("myInfo", "IMPORTANT IN CASE OF EMERGENCY INFORMATION: PLEASE CHANGE");
            }
        }


        private void VideoCamera_Initialized(object sender, EventArgs e)
        {
           // _videoCamera.LampEnabled = true;
           // _videoCamera.StartRecording();

        }

    

        private void Flashlight_Tap(object sender, GestureEventArgs e)
        {
            if (flashOn == false)
            {
                _videoCamera.LampEnabled = true;
                _videoCamera.StartRecording();
                flashOn = true;
            }
            else
            {
                _videoCamera.StopRecording();
                flashOn = false;
            }
        }

        private void Alarm_Tap(object sender, GestureEventArgs e)
        {
            App myCurrentApp = (App)Application.Current;
            myCurrentApp.ToggleAlarmSound();
        }


        private void ContactsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedName = App.ViewModel.Items.ElementAt(ContactsListBox.SelectedIndex).LineOne;
            string selectedNumber = App.ViewModel.Items.ElementAt(ContactsListBox.SelectedIndex).LineThree;
            NavigationService.Navigate(new Uri("/ContactDetail.xaml?name=" + selectedName + "&number=" + selectedNumber, UriKind.Relative));
        }

        private void iceText_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings["myInfo"] = iceText.Text;
        }

        private void ResourcesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedName2 = App.ViewModel.Items2.ElementAt(ResourcesListBox.SelectedIndex).LineOne;
            string selectedNumber2 = App.ViewModel.Items2.ElementAt(ResourcesListBox.SelectedIndex).LineThree;
            string info = App.ViewModel.Items2.ElementAt(ResourcesListBox.SelectedIndex).LineFour;
            NavigationService.Navigate(new Uri("/ContactDetail.xaml?name=" + selectedName2 + "&number=" + selectedNumber2 +"&info=" + info, UriKind.Relative));
        }
    }
}