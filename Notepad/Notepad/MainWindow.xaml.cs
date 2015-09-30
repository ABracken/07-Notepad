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
using Microsoft.Win32;
using System.IO;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Text|*.txt|All|*.*";

            bool? openFile = dialog.ShowDialog();

            if (openFile == true)
            {
                string filename = dialog.FileName;

                string fileContents = File.ReadAllText(filename);

                textBox_Editor.Text = fileContents;
            }
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.OverwritePrompt = true;

            saveFile.Filter = "Text File|*.txt";

            saveFile.FileName = "NewFile";

            if (saveFile.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFile.FileName, textBox_Editor.Text);
            }

        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {
           
            MessageBoxResult result = MessageBox.Show("Do you want to save changes before starting a new file?", "Warning", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog saveFile = new SaveFileDialog();

                    saveFile.OverwritePrompt = true;

                    saveFile.Filter = "Text File|*.txt";

                    saveFile.FileName = "NewFile";

                    if (saveFile.ShowDialog() == true)
                    {
                        System.IO.File.WriteAllText(saveFile.FileName, textBox_Editor.Text);
                    }
                    break;
                case MessageBoxResult.No:
                    textBox_Editor.Clear();
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save changes to this file before closing?", "Warning", MessageBoxButton.YesNoCancel);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog saveFile = new SaveFileDialog();

                    saveFile.OverwritePrompt = true;

                    saveFile.Filter = "Text File|*.txt";

                    saveFile.FileName = "NewFile";

                    if (saveFile.ShowDialog() == true)
                    {
                        System.IO.File.WriteAllText(saveFile.FileName, textBox_Editor.Text);
                    }
                    break;
                case MessageBoxResult.No:
                    Environment.Exit(0);
                    break;
                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

    }
}
    
    

