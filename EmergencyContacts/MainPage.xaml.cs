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


namespace EmergencyContacts
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Initialize VideoCamera objects;
        private VideoCamera _videoCamera;
        private VideoCameraVisualizer _videoCameraVisualizer;
        bool flashLightOn = false;
        bool alarmOn = false;


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

        private void VideoCamera_Initialized(object sender, EventArgs e)
        {
            _videoCamera.LampEnabled = true;
            _videoCamera.StartRecording();

        }

        private void Flashlight_Tap(object sender, GestureEventArgs e)
        {
            if (!flashLightOn)
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
                flashLightOn = true;
            }
            else
            {
                _videoCamera = null;
            }
        }

        private void Alarm_Tap(object sender, GestureEventArgs e)
        {
            // Turn the alarm on.
           /* if (!alarmOn)
            {

            }
            else // Turn dat alarm off
            {

            }*/
            //AlarmSound.Play();
            App myCurrentApp = (App)Application.Current;
            myCurrentApp.ToggleAlarmSound();
        }

    }
}