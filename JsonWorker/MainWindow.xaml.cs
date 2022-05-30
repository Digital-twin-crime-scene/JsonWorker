using JsonParser;
using Microsoft.Win32;
using System;
using System.Windows;

namespace JsonWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _pathToFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Json files (*.json)|*.json";

            if (ofd.ShowDialog() == true)
            {
                _pathToFile = ofd.FileName;
                var objectInfo = JsonParser<ObjectModel>.ParseFromFile(_pathToFile);
                objectName.Text = objectInfo.Name;
                objectDate.Text = objectInfo.Date.ToString("D");
                objectDescription.Text = objectInfo.Description;
            }
        }

        private void saveInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var obj = new ObjectModel();
            obj.Name = objectName.Text;
            obj.Date = DateTime.Parse(objectDate.Text);
            obj.Description = objectDescription.Text;

            JsonParser<ObjectModel>.WriteJsonToFile(_pathToFile, obj);
        }
    }
}
