﻿using System;
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
using ReqPar9;

namespace ReqPer9Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillHop();
            FillMalt();
            FillYeast();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        void FillHop()
        {
            List<Hop> listeHop = DatabaseController.GetHop();
            foreach (Hop h in listeHop)
            {
                HopDrop.Items.Add(h.Name);
            }
        }

        void FillMalt()
        {
            List<Malt> listeMalt = DatabaseController.GetMalt();
            foreach (Malt m in listeMalt)
            {
                MaltDrop.Items.Add(m.Name);
            }
        }

        void FillYeast()
        {
            List<Yeast> listeYeast = DatabaseController.GetYeast();
            foreach (Yeast y in listeYeast)
            {
                YeastDrop.Items.Add(y.Name);
            }
        }
    }
}
