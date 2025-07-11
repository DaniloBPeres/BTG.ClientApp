using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.ClientApp.Helpers
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        private bool _isChangingText;

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            string newText = e.NewTextValue;

            string filteredText = new string(newText.Where(char.IsDigit).ToArray());

            if (entry.Text != filteredText)
            {
                if (!_isChangingText)
                {
                    _isChangingText = true;
                    entry.Text = filteredText;
                    _isChangingText = false;

                    entry.CursorPosition = filteredText.Length;
                }
            }
        }
    }
}
