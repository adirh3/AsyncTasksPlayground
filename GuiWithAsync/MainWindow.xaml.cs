using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GuiWithAsync
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

        private void NonAsync_OnClick(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = true;
            Thread.Sleep(5000);
            TextBlock.Text = "Success!";
            ProgressBar.IsIndeterminate = false;
        }

        private async void Async_OnClick(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = true;

            // Run heavy workload
            // Using await will allow context switching between the GUI thread and the background thread
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                // This thread will wait for the GUI thread
                Dispatcher.Invoke(() => TextBlock.Text = "Major Success!");
            });

            ProgressBar.IsIndeterminate = false;
        }

        private void Deadlock_OnClick(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = true;

            // Run heavy workload
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                // This thread will wait for the GUI thread, while the gui thread will wait for this thread
                Dispatcher.Invoke(() => TextBlock.Text = "Success!");
            }).Wait();

            ProgressBar.IsIndeterminate = false;
        }
    }
}