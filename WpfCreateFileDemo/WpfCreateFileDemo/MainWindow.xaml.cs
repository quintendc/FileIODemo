using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace WpfCreateFileDemo
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

        string path = "";

        private void btnSelectPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            path = dialog.SelectedPath;
            lblPath.Content = path;
        }

        private void btnCreateFile_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (!File.Exists(path + $@"\\{txtFileName.Text}{txtFileExtension.Text}"))
                {
                    string file = path + @"\\" + txtFileName.Text + txtFileExtension.Text;
                    FileStream stream = new FileStream(file, FileMode.Create);
                }
                else
                {
                    MessageBox.Show("File already exists!");
                }
            }
            else
            {
                MessageBox.Show("No path selected!");
            }
        }
    }
}
