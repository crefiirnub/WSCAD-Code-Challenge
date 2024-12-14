using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using WSCADCodeChallenge.Controllers;

namespace WSCADCodeChallenge.Views
{
    public partial class MainWindow : Window
    {
        private readonly GraphicController _controller;
        private bool _isFileImported = false;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new GraphicController(GraphicCanvas);
        }

        private void ImportFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    _controller.LoadFile(File.ReadAllText(openFileDialog.FileName));
                    _isFileImported = true;

                    StatusMessage.Text = "File imported successfully!";
                    StatusMessage.Foreground = new SolidColorBrush(Colors.Green);

                    GenerateButton.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    StatusMessage.Text = $"Failed to import file: {ex.Message}";
                    StatusMessage.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if (!_isFileImported) return;
            _controller.GenerateGraphics();

            StatusMessage.Text = "Graphics generated!";
            StatusMessage.Foreground = new SolidColorBrush(Colors.Blue);
        }
    }
}
