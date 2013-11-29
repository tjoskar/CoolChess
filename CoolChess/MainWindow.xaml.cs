﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Diagnostics;

namespace CoolChess
{
    /*
     * Interaction logic for MainWindow.xaml
     * A bridge between GUI and logic 
    */
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // A string contains either "Black" or "White", depending on whose turn it is.
        private string whoseTurn = "";
        public string WhoseTurn
        {
            get
            {
                return whoseTurn;
            }
            set
            {
                whoseTurn = value;
                NotifyPropertyChanged();
            }
        }
        // A reference to the board class that contain all logic
        private Board borad;

        public MainWindow()
        {
            InitializeComponent();
            WhoseTurnControl.DataContext = this;

            this.borad = new Board(this);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            this.borad.createNewBorad();
        }

        /*
         * Calculate which cell the user click on and forward the call
        */
        private void Board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Board_MouseRightButtonDown");
            Point point = e.GetPosition(this.Board);
            Position p = new Position(Math.Min((int)(point.X / this.borad.getCellWidth()), 7), Math.Min((int)(point.Y / this.borad.getCellHeight()), 7));
            Debug.WriteLine("point.x: " + point.X);
            Debug.WriteLine("CellWidth: " + this.borad.getCellWidth());
            Debug.WriteLine("point.X / this.borad.getCellWidth(): " + point.X / this.borad.getCellWidth());
            Debug.WriteLine(p.m);
            Debug.WriteLine(p.n);
            borad.mouseClick(p);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}