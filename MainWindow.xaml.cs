using System.Net.Http.Headers;
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
using System.Windows.Threading;

namespace kisauto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Random r = new Random();
        private double celvonal = 650;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Mozog(pinimobil);
            Mozog(Ferrari);
            Mozog(Ford);
        }

        private void Mozog(Button sender)
        {
            double akktuálispoz = Canvas.GetLeft(sender);
            double sebesség = r.Next(1, 6);
            if (sender.Content == "Pinimobil")
            {
                sebesség -=1;
            }
            double ujpoz = akktuálispoz + sebesség;
            Canvas.SetLeft(sender, ujpoz);
            if(ujpoz >= celvonal)
            {
                timer.Stop();
                MessageBox.Show("A játék véget ért! a kört nyerte:"+ sender.Content);
            }
        }

        private void bt_start_Click_1(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(pinimobil, 20);
            Canvas.SetLeft(Ferrari, 20);
            Canvas.SetLeft(Ford, 20);
            timer.Start();
        }
    }
}