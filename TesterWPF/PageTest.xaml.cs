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

namespace TesterWPF
{
    /// <summary>
    /// Логика взаимодействия для PageTest.xaml
    /// </summary>
    public partial class PageTest : Page
    {
        private List<Test> _listTests;
        private short _currentQuestion = 0;
        private short _rightAnswers = 0;
        public PageTest()
        {
            InitializeComponent();
            _listTests = Class1.Deserialize<List<Test>>("Tests.json");
            if (_listTests == null)
            {
                _listTests = new List<Test>();
            }

            SwitchAttributesContent();
        }

        private void SwitchAttributesContent()
        {
            NameTextBlock.Text = _listTests[_currentQuestion].Name;
            DescriptionTextBlock.Text = _listTests[_currentQuestion].Description;
            _1.Content = _listTests[_currentQuestion].FirstAnswer;
            _2.Content = _listTests[_currentQuestion].SecondAnswer;
            _3.Content = _listTests[_currentQuestion].ThirdAnswer;
        }

        private void Bt_Cl(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;

            if (Convert.ToInt32(currentButton.Name[1].ToString()) - 1 == (int)_listTests[_currentQuestion].RightAnswer)
            {
                _rightAnswers++;
            }

            _currentQuestion++;
            AnswerResultTextBlock.Text = String.Empty;

            if (_currentQuestion < _listTests.Count)
            {
                SwitchAttributesContent();
            }
            else
            {
                NameTextBlock.Text = $"Тест пройден, вы успешно ответил правльно на {_rightAnswers} из {_listTests.Count}";
                DescriptionTextBlock.Text = String.Empty;
                AnswersGrid.Children.Clear();
            }
        }
    }
}
