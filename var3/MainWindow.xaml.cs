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

namespace var3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GaiEntities context;      
        public MainWindow()
        {
            InitializeComponent();
            context = new GaiEntities();
        }
        int count = 0;
        private void EnterClick(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int tabNum = Convert.ToInt32(login.Text);
                int pass = Convert.ToInt32(password.Text);
                
                
                Inspector inspector = context.Inspector.ToList().Find(x => x.tabNum == tabNum);               
                if (inspector == null)
                {
                    MessageBox.Show("Инспектора с таким номером не существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    count += 1;
                }
                else
                {
                    if (inspector.password.Equals(pass))
                    {
                        MessageBox.Show("Успешная авторизация!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        count += 1;
                    }
                }               
                if (count == 3)
                {
                    enter.IsEnabled = false;
                    login.IsEnabled = false;
                    password.IsEnabled = false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Не введен пароль или логин!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }          
        }
    }
}
