using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AverinApp.Classes
{
    class HelperClass
    {
        /// <summary>
        /// Метод для запрета ввода в текстовое поле чего-либо, кроме цифр
        /// </summary>
        /// <param name="e">Символ из TextBox из эвента "PreviewTextInput"</param>
        public void InputOnlyDigit(TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }
    }
}
