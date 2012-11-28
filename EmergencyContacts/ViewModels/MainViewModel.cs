using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace EmergencyContacts
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.Items2 = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemViewModel> Items2 { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { LineOne = "Richard Whalen", LineTwo = "Greatest Guy Ever", LineThree = "941-343-7458" });
            this.Items.Add(new ItemViewModel() { LineOne = "Andrew Lum", LineTwo = "One of the DEvs", LineThree = "941-343-7458" });
            this.Items.Add(new ItemViewModel() { LineOne = "Jenna", LineTwo = "Also Awesome", LineThree = "111-111-1111" });
            this.Items.Add(new ItemViewModel() { LineOne = "R", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "" });
            this.Items.Add(new ItemViewModel() { LineOne = "sasfwewfef", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458" });
            this.Items.Add(new ItemViewModel() { LineOne = "ewfweqkjqk", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458" });
            this.Items.Add(new ItemViewModel() { LineOne = "sasfwewfef", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458s" });
            this.Items.Add(new ItemViewModel() { LineOne = "ewfweqkjqk", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458" });
            this.Items.Add(new ItemViewModel() { LineOne = "sasfwewfef", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458" });
            this.Items.Add(new ItemViewModel() { LineOne = "ewfweqkjqk", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458" });


            this.Items2.Add(new ItemViewModel() { LineOne = "Poison Control", LineTwo = "Drank Too Much", LineThree = "941-343-7458" ,
            LineFour="Anyone can be a poison victim. In fact, poisoning is the 2nd  leading cause of death in Tennessee. Tennessee Poison Center (TPC) provides immediate first aid treatment advice for poison emergencies by calling the statewide Poison Help hotline at 1-800-222-122. We're available to help 24 hours a day, 7 days a week. TPC also provides information about poisons and poison prevention. Tennessee Poison Center can help you with questions about: household products, chemicals at work or in the environment drugs ( prescription, over-the-counter, herbal and illegal) snake and spider bites chemical terrorism For life-saving treatment advice about any kind of poison, call 1-800-222-1222 first.  A specially trained nurse, pharmacist or doctor will help. All calls are free and confidential. TPC's services are available for people with hearing problems and for non-English speakers. Information about the swine influenza may be found at www.cdc.gov/swineflu."});
            this.Items2.Add(new ItemViewModel() { LineOne = "Vanderbilt Medical", LineTwo = "Hospital", LineThree = "941-343-7458" });
            this.Items2.Add(new ItemViewModel() { LineOne = "P.C.C", LineTwo = "Psychological Counsel Center", LineThree = "111-111-1111" });
            this.Items2.Add(new ItemViewModel() { LineOne = "adfka", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458" });
            this.Items2.Add(new ItemViewModel() { LineOne = "sasfwewfef", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "941-343-7458" });
            
            

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}