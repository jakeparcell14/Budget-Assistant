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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Budget_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Expense> expenses;

        public MainWindow()
        {
            RetrieveExpenses();
            InitializeComponent();
        }

        private void RetrieveExpenses()
        {

            //retrieve expense data from file or create new file if it does not exist
            Stream stream = new FileStream("ExpenseStorage.dat", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();

            if (stream.Length != 0)
            {
                expenses = (List<Expense>)b.Deserialize(stream);
            }
            else
            {
                expenses = new List<Expense>();
            }

            stream.Close();
        }

        private void CreateExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            AddExpenseWindow ew = new AddExpenseWindow();
            ew.ShowDialog();

            //check if valid expense was created
            if (ew.expense != null)
            {
                //add valid expense
                expenses.Add(ew.expense);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //save updated expenses to file
            Stream stream = new FileStream("ExpenseStorage.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(stream, expenses);
            stream.Close();
        }
    }
}
