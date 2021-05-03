using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AverinApp.Classes
{
    public class MessagesClass
    {
        public MessageBoxResult Error(string message)
        {
            return MessageBox.Show(message, "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public MessageBoxResult Info(string message)
        {
            return MessageBox.Show(message, "Информация", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult Warning(string message)
        {
            return MessageBox.Show(message, "Внимание", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public MessageBoxResult Question(string message)
        {
            return MessageBox.Show(message, "Вопрос", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public MessageBoxResult NotConnect()
        {
            return MessageBox.Show("Отсутсвует подключение к базе данных. Пожалуйста, свяжитесь с системным администратором.",
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public MessageBoxResult NotFunctional()
        {
            return MessageBox.Show("Данный функционал пока недоступен.", 
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
