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
using System.Windows.Shapes;

namespace TesterWPF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(bool IsEditable)
        {
            InitializeComponent();
            if (!IsEditable)
            {
                Bt_Edit.IsEnabled = false;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageEdit();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTestExist()) MainFrame.Content = new PageTest();
            else MainFrame.Content = new PageEror();
        }

        private bool CheckTestExist()
        {
            List<Test> listTests = Class1.Deserialize<List<Test>>("Tests.json");
            if (listTests == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
