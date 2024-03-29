﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabelsControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LabelsControl : UserControl, INotifyPropertyChanged
    {
        private static string[] split = {" ", ",", ";"};
        private static string defaultSplit = ", ";

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private ObservableCollection<string> labels = new ObservableCollection<string>();

        public LabelsControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<string> Labels
        {
            get { return labels; }
        }

        private string source = "";
        public string Source
        {
            get { return source; }
            set 
            {
                if (Source == value)
                    return;

                source = value;

                RaisePropertyChanged("Source");
            }
        }

        public static DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(LabelsControl), new PropertyMetadata("", SourceChanged));

        private static void SourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
 	        (d as LabelsControl).SourceChanged();
        }

        private void SourceChanged()
        {
            source = GetValue(SourceProperty) as string;
            UpdateLabels();
        }

        public ICommand Update
        {
            get { return GetValue(UpdateCommand) as ICommand; }
            set { SetValue(UpdateCommand, value); }
        }

        //public object CommandParameter
        //{
        //    get { return GetValue(CommandParameterProperty); }
        //    set { SetValue(CommandParameterProperty, value); }
        //}

        public static DependencyProperty UpdateCommand = DependencyProperty.Register("Update", typeof(ICommand), typeof(LabelsControl));
        //public static DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(LabelsControl));

        private void LabelTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            StartEdit(null);
        }

        private void LabelTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            EndEdit();
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label l = sender as Label;
            LabelTextBox.Focus();
            StartEdit(l.Content as string);
        }

        private void StartEdit(string hit)
        {
            LabelList.Visibility = Visibility.Collapsed;
            LabelTextBox.Text = string.Join(defaultSplit, labels.ToArray());
            if (hit == null)
            {
                if (labels.Count > 0)
                   LabelTextBox.Text += defaultSplit;
                LabelTextBox.CaretIndex = LabelTextBox.Text.Length;
            }
            else
            {
                int position = LabelTextBox.Text.IndexOf(hit + defaultSplit);
                if (position < 0)
                {
                    LabelTextBox.CaretIndex = LabelTextBox.Text.Length - hit.Length;
                    LabelTextBox.SelectionStart = LabelTextBox.Text.Length - hit.Length;
                    LabelTextBox.SelectionLength = hit.Length;
                }
                else
                {
                    LabelTextBox.CaretIndex = position;
                    LabelTextBox.SelectionStart = position;
                    LabelTextBox.SelectionLength = hit.Length;
                }
            }
        }

        private void EndEdit()
        {
            bool shallNotify = false;
            if (Source != LabelTextBox.Text)
                shallNotify = true;
            Source = LabelTextBox.Text;
            UpdateLabels();
            if (shallNotify && Update != null && Update.CanExecute(this))
                Update.Execute(labels.ToArray());
        }

        private void UpdateLabels()
        {
            if (Source == null)
                return;
            var labelStrings = Source.Split(split, StringSplitOptions.RemoveEmptyEntries);
            labels.Clear();
            foreach (var label in labelStrings)
            {
                labels.Add(label);
            }
            LabelList.Visibility = Visibility.Visible;
            LabelTextBox.Text = "";
        }
    }
}
