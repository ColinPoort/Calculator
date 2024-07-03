using System;
using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    public partial class MainWindow : Window
    {
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                input += button.Content.ToString();
                ResultTextBox.Text = input;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (!string.IsNullOrEmpty(operand1) && !string.IsNullOrEmpty(input))
                {
                    // If there's already an operation in progress, evaluate it first
                    operand2 = input;
                    EvaluateExpression();
                    operand1 = result.ToString(); // Store result as operand1 for chaining operations
                }
                else
                {
                    operand1 = input; // Store current input as operand1 for first operation
                }

                operation = Convert.ToChar(button.Content);
                input = string.Empty;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(operand1) && !string.IsNullOrEmpty(input))
            {
                operand2 = input;
                EvaluateExpression();
                operand1 = result.ToString(); // Store result as operand1 for chaining operations
                input = string.Empty;
                operand2 = string.Empty;
            }
        }

        private void EvaluateExpression()
        {
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        MessageBox.Show("Cannot divide by zero");
                    break;
                default:
                    break;
            }

            ResultTextBox.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
            ResultTextBox.Text = input;
        }
    }
}
