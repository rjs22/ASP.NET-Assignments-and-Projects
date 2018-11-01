using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CalcAssign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double operandOne;
        double operandTwo;
        string operation;
        bool finished;

        public MainWindow()
        {
            InitializeComponent();
        }
        // click event handler for all the numbers
        private void btnOperand_Click(object sender, RoutedEventArgs e)
        {
            // resets all fields if equals button was pressed
            if(finished == true)
            {
                lblDisplay.Content = "0";
                operandOne = 0;
                operandTwo = 0;
                lblCalculation.Content = "";
                finished = false;
            }
            // replaces starting 0 with first operand
            else if (lblDisplay.Content.Equals("0"))
            {
                lblDisplay.Content = "";
                Button operand = sender as Button;
                lblDisplay.Content += operand.Content.ToString();
            }
            else
            {
                Button operand = sender as Button;
                lblDisplay.Content += operand.Content.ToString();
            }
        }
        // click event handler for operator actions
        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            if (finished == true)
            {
                lblDisplay.Content = "0";
                operandOne = 0;
                operandTwo = 0;
                lblCalculation.Content = "";
                finished = false;
            }
            // does the same as above but removes trailing operations if any operator is hit more than one time
            else if (lblDisplay.Content.Equals("0") || lblDisplay.Content.Equals(""))
            {
                lblCalculation.Content = "";
                lblDisplay.Content = "";
                Button op = sender as Button;
                operation = op.Content.ToString();
            }
            else
            {
                // grabs content from button press and turns it into a string
                Button op = sender as Button;
                operation = op.Content.ToString();
                // checks to see what is being parsed. Denies anything that isn't a double.
                if (double.TryParse(lblDisplay.Content.ToString(), out operandOne))
                {
                    operandOne = Convert.ToDouble(lblDisplay.Content.ToString());
                }

                lblCalculation.Content += operandOne.ToString() + operation;
                lblDisplay.Content = "";
            }
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            // checks to see what is being parsed. Denies anything that isn't a double.
            if (double.TryParse(lblDisplay.Content.ToString(), out operandTwo))
            {
                operandTwo = Convert.ToDouble(lblDisplay.Content.ToString());
            }
            lblCalculation.Content += operandTwo.ToString();
            // switch statement to handle operation actions
            switch(operation)
            {
                case "/":
                    // denies anyone who thought dividing by zero was a good idea.....
                    if (operandTwo != 0)
                    {
                        lblDisplay.Content = operandOne / operandTwo;
                        finished = true;
                        break;
                    }
                    else
                    {
                        lblDisplay.Content = "DIV/ZERO!";
                        finished = true;
                        break;
                    }
                case "*":
                    lblDisplay.Content = operandOne * operandTwo;
                    finished = true;
                    break;
                case "-":
                    lblDisplay.Content = operandOne - operandTwo;
                    finished = true;
                    break;
                case "+":
                    lblDisplay.Content = operandOne + operandTwo;
                    finished = true;
                    break;
            }
        }
        // click event handler for using the clear entry button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblDisplay.Content = "";

            if (operation != "")
            {
                operandTwo = 0;
            }
            else
            {
                operandOne = 0;
            }
        }
        // click event handler for using the +/- button
        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            double operCalc;
            
            if (double.TryParse(lblDisplay.Content.ToString(), out operCalc))
            {
                operCalc = Convert.ToDouble(lblDisplay.Content.ToString());
            }

            if (operCalc > 0)
                lblDisplay.Content = "-" + lblDisplay.Content;
            else
                lblDisplay.Content = operCalc * -1;
        }
    }
}
