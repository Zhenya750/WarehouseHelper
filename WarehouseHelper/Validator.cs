using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WarehouseHelper
{
    public static class ValidationExtension
    {
        public static Validator Rules(this TextBox control)
        {
            return new Validator(control, control.Text);
        }
    }


    public class Validator
    {
        private Control _control;
        private string _content;

        private bool _isValid = true;

        public Validator(Control control, string content)
        {
            _control = control;
            _content = content;
        }

        public Validator MaxCharacters(int count)
        {
            if (_content.Length > count)
                _isValid = false;

            return this;
        }

        public Validator MinCharacters(int count)
        {
            if (_content.Length < count)
                _isValid = false;

            return this;
        }

        public bool Validate()
        {
            if (_isValid == false)
            {
                _control.ToolTip = "Invalid field";
                _control.Background = Brushes.Pink;
            }
            else
            {
                _control.Background = Brushes.White;
            }

            return _isValid;
        }
    }
}
