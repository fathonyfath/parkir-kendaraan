using System;
using System.ComponentModel;
using System.Windows;

namespace ParkirKendaraan
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }

        public static void DoWorkWithModal(Action<IProgress<string>> work)
        {
            LoadingWindow window = new LoadingWindow();
            window.Loaded += (_, args) =>
            {
                BackgroundWorker worker = new BackgroundWorker();

                Progress<String> progress = new Progress<String>(data => window.Title = data);

                worker.DoWork += (s, workerArgs) => work(progress);
                worker.RunWorkerCompleted += (s, workerArgs) => window.Close();
                worker.RunWorkerAsync();
            };

            window.ShowDialog();
        }
    }
}
