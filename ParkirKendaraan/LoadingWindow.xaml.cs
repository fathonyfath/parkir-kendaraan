using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

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
