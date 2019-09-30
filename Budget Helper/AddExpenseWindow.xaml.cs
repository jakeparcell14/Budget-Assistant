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
using System.Text.RegularExpressions;


namespace Budget_Helper
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddExpenseWindow: Window
    {
        public AddExpenseWindow()
        {
            InitializeComponent();
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            Double costTest;

            if (nameTextBox.Text != "" && datePicker.SelectedDate.HasValue && Double.TryParse(costTextBox.Text, out costTest))
            { 
                //all values are valid
                Expense expense = new Expense(nameTextBox.Text, datePicker.SelectedDate.Value, costTest);

                this.Close();
            }
        }
    }
}
