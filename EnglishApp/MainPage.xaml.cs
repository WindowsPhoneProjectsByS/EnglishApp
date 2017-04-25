using EnglishApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace EnglishApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private FlipViewService viewService;
        private DispatcherTimer timer;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 2);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewService = new FlipViewService();
            PrepeareFlipViewNoPL();
            
        }

        private void TransledRB_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Checked");
            PrepareFlipViewPL();
        }

        private void TransledRB_Unchecked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("UnChecked");
            PrepeareFlipViewNoPL();
        }

        public void PrepeareFlipViewNoPL()
        {
            viewService.initItemsWithoutPL();
            WordView.ItemsSource = viewService.Items;
        }

        public void PrepareFlipViewPL()
        {
            viewService.initItems();
            WordView.ItemsSource = viewService.Items;
        }

        

        private void AutoSliderRB_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Checked dla autoprzewijania");
            timer.Tick += ChangeItem;
            timer.Start();
        }

        private void AutoSliderRB_Unchecked(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Tick -= ChangeItem;
        }

        private void ChangeItem(object sender, object o)
        {
            int totalItems = viewService.Items.Count;

            int newIndex = WordView.SelectedIndex + 1;

            Debug.WriteLine("Wybrany indeks: " + newIndex + "/" + totalItems);

            if (newIndex >= totalItems)
            {
                newIndex = 0;
            }

            WordView.SelectedIndex = newIndex;
            Debug.WriteLine("Powinno pyknąć jeśli nie pyka to jest problem");
        }

    }
}
