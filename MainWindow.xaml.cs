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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        SelectedOperator selectedOperator;
        double result;

        public MainWindow()
        {
            InitializeComponent();
        }

        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        public class SimpleMath
        {
            public static double Add(double n1, double n2)
            {
                return n1 + n2;
            }
            public static double Subtract(double n1, double n2)
            {
                return n1 - n2;
            }
            public static double Multiple(double n1, double n2)
            {
                return n1 * n2;
            }
            public static double Division(double n1, double n2)
            {
                return n1 / n2;
            }
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.FontSize = 100;
            int selectedValue = 0;

            // sender 구별
            if (sender == zeroButton)
            {
                selectedValue = 0;
            }
            else if (sender == oneButton)
            {
                selectedValue = 1;
            }
            else if (sender == twoButton)
            {
                selectedValue = 2;
            }
            else if (sender == threeButton)
            {
                selectedValue = 3;
            }
            else if (sender == fourButton)
            {
                selectedValue = 4;
            }
            else if (sender == fiveButton)
            {
                selectedValue = 5;
            }
            else if (sender == sixButton)
            {
                selectedValue = 6;
            }
            else if (sender == sevenButton)
            {
                selectedValue = 7;
            }
            else if (sender == eightButton)
            {
                selectedValue = 8;
            }
            else if (sender == nineButton)
            {
                selectedValue = 9;
            }

            // 기존 label이 0이면 (아무것도 입력x) 눌러진 숫자, 아니면 "이전숫자" + "눌러진 숫자"
            if (resultLabel.Content.ToString() == "0" || resultLabel.Content.ToString() == "0 으로 나눌 수 없습니다.")
            {
                resultLabel.Content = selectedValue.ToString();
            }
            else
            {
                resultLabel.Content += selectedValue.ToString();
            }

        }

        private void operatorButton_Click(object sender, RoutedEventArgs e)
        {
            // parse 사용해서 string을 숫자로 형변환
            lastNumber = double.Parse(resultLabel.Content.ToString());
            resultLabel.Content = "0";

            // 선택된 operator 저장
            if (sender == plusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == minusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            else if (sender == multipleButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            else if (sender == divideButton)
            {
                selectedOperator = SelectedOperator.Division;
            }
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.FontSize = 100;
            resultLabel.Content = "0";
        }

        private void plusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber *= -1;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void percentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber *= 0.01;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean isInDot;
            isInDot = resultLabel.Content.ToString().Contains(".");
            if (resultLabel.Content.ToString() == "0")
            {
                return;
            }
            else
            {
                if (isInDot == false)
                    resultLabel.Content += ".";
            }
        }

        private void equlButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            bool divisionZero = false;
            newNumber = double.Parse(resultLabel.Content.ToString());

            switch(selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;

                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, newNumber);
                    break;

                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiple(lastNumber, newNumber);
                    break;

                case SelectedOperator.Division:
                    if (newNumber != 0)
                    {
                        result = SimpleMath.Division(lastNumber, newNumber);
                    }
                    else
                    {
                        divisionZero = true;
                        lastNumber = 0;
                    }
                    break;
            }

            if (divisionZero)
            {
                resultLabel.FontSize = 30;
                resultLabel.Content = "0 으로 나눌 수 없습니다.";
            }
            else
                resultLabel.Content = result.ToString();
        }
    }

}
