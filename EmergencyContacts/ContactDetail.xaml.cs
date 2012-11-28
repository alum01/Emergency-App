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
using Microsoft.Phone.Tasks;



namespace EmergencyContacts
{
    public partial class ContactDetail : PhoneApplicationPage
    {
        public ContactDetail()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string contactName;
            string number;
            string info;

            if (NavigationContext.QueryString.TryGetValue("name", out contactName))
            {
                PageTitle.Text = contactName;
            }

            if (NavigationContext.QueryString.TryGetValue("info", out info))
            {
                infoTextBlock.Text = info;
            }
            if (NavigationContext.QueryString.TryGetValue("number", out number))
            {
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.PhoneNumber = number;
                phoneCallTask.DisplayName = contactName;
                phoneCallTask.Show();
            }
        }
    }
}