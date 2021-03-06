﻿using EnglishApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using System.Threading;

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
            PrepareActualDate();
            PrepareButtonContent();
            PrepareProperLayout();
            PrepeareFlipViewNoTranslation();
        }

        private void PrepareActualDate()
        {
            DateTime dt = DateTime.Now;
            CultureInfo ci = CultureInfo.CurrentCulture;
            ActualDate.Text = dt.ToString("d", ci);
        }

        private void PrepareButtonContent()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            AutoSliderRB.Content = loader.GetString("SliderCheckButton");
        }

        private void PrepareProperLayout()
        {
            if (CultureInfo.CurrentCulture.Name == "en-US")
            {
                viewService = new FlipViewService(false);
                
                TransledRB.Visibility = Visibility.Collapsed;
            }
            else
            {
                viewService = new FlipViewService(true);
            }
        }

        private void TransledRB_Checked(object sender, RoutedEventArgs e)
        {
            int currpos = WordView.SelectedIndex;
            PrepareFlipViewWitTranslation();
            WordView.SelectedIndex = currpos;
        }

        private void TransledRB_Unchecked(object sender, RoutedEventArgs e)
        {
            int currpos = WordView.SelectedIndex;
            PrepeareFlipViewNoTranslation();
            WordView.SelectedIndex = currpos;
        }

        public void PrepeareFlipViewNoTranslation()
        {
            viewService.initItemsWithoutTranslation();
            WordView.ItemsSource = viewService.Items;
        }

        public void PrepareFlipViewWitTranslation()
        {
            viewService.initItems();
            WordView.ItemsSource = viewService.Items;
        }

        

        private void AutoSliderRB_Checked(object sender, RoutedEventArgs e)
        {
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

            if (newIndex >= totalItems)
            {
                newIndex = 0;
            }

            WordView.SelectedIndex = newIndex;
        }

    }
}
