using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace TesterWPF
{
    /// <summary>
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        private List<Test> listTests;
        public PageEdit()
        {
            InitializeComponent();
            listTests = Class1.Deserialize<List<Test>>("Tests.json");
            if (listTests == null)
            {
                listTests = new List<Test>();
                listTests.Add(new Test("", "", "", "", ""));
            }
            MainGrid.ItemsSource = listTests;
        }
        private void PageEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N)
            {
                listTests.Add(new Test("", "", "", "", ""));
                Class1.Serialize(listTests, "Tests.json");
                MainGrid.ItemsSource = null;
                MainGrid.ItemsSource = listTests;
            }
            else if (Keyboard.Modifiers == ModifierKeys.None && e.Key == Key.Back)
            {
                listTests.RemoveAt(listTests.Count - 1);
                Class1.Serialize(listTests, "Tests.json");
                MainGrid.ItemsSource = null;
                MainGrid.ItemsSource = listTests;
            }
            else if (Keyboard.Modifiers == ModifierKeys.None && e.Key == Key.Enter)
                Class1.Serialize(listTests, "Tests.json");
        }
    }
}
