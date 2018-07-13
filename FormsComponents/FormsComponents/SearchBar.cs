using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsComponents
{
    public class SearchBar : Xamarin.Forms.SearchBar
    {
        public static readonly BindableProperty TextChangedCommandProperty =
          BindableProperty.Create(nameof(TextChangedCommand),
                            typeof(ICommand),
                            typeof(SearchBar),
                            null);

        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        public static readonly BindableProperty AutoSearchdProperty =
          BindableProperty.Create(nameof(AutoSearch),
                            typeof(bool),
                            typeof(SearchBar),false);

        public bool AutoSearch
        {
            get { return (bool)GetValue(AutoSearchdProperty); }
            set { SetValue(AutoSearchdProperty, value); }
        }

        public SearchBar()
        {
            TextChanged += (e, a) =>
            {
                if (TextChangedCommand != null && TextChangedCommand.CanExecute(null))
                    TextChangedCommand.Execute(null);
            };

            TextChanged += (e, a) =>
            {
                if (AutoSearch)
                {
                    if (SearchCommand != null && SearchCommand.CanExecute(null))
                        SearchCommand.Execute(null);

                }
            };
        }
    }
}
