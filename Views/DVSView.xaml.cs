﻿using DVS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DVS.Views
{
    /// <summary>
    /// Interaktionslogik für DVSView.xaml
    /// </summary>
    public partial class DVSView : UserControl
    {
        public DVSView()
        {
            InitializeComponent();

            DataContext = new DVSViewModel();

        }

        //readonly AddClothesView addClothesView = new();

        //public void OpenAddClothesView(object sender, RoutedEventArgs e)
        //    => addClothesView._AddClothesView.Visibility = Visibility.Visible;
    }
}
