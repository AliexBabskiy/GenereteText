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

namespace TesterWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EditTest_Click(object sender, RoutedEventArgs e)
        {
            if (MainWind.RowDefinitions.Count == 2)
            {
                MainWind.RowDefinitions.Add(new RowDefinition());
                TextBox textBox1 = new TextBox()
                {
                    Text = "Введите кодовое слово для админа",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                textBox1.SelectionChanged += TextBox1_SelectionChanged;
                textBox1.KeyDown += TextBox1_KeyDown;
                Grid.SetRow(textBox1, 2);
                MainWind.Children.Add(textBox1);
            }
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(false);
            window.Show();
            Close();
        }

        private void TextBox1_KeyDown(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "админ")
            {
                Window1 window = new Window1(true);
                window.Show();
                Close();
            }
        }

        private void TextBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите кодовое слово для админа")
            {
                textBox.Text = "";
            }
        }
    }
}
