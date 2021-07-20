using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;
using System.ComponentModel;

namespace VkUtilityAvalonia
{
    public partial class InputField : UserControl
    {
        //public static readonly StyledProperty<string> TextProperty =
        //AvaloniaProperty.Register<InputField, string>("Text", string.Empty);
        public static readonly DirectProperty<InputField, string> SetTextProperty =
            AvaloniaProperty.RegisterDirect<InputField, string>(nameof(SetText), 
                o => o.SetText, //Get object
                (o, v) => o.SetText = v); //Set value to object

        string text = "Label";
        public string SetText
        {
            set { SetAndRaise(SetTextProperty, ref text, value); }
            get
            {
                return text;
            }
        }

        public InputField()
        {
            InitializeComponent();
            DataContext = new InputFieldViewModel(SetText);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
    public class InputFieldViewModel : INotifyPropertyChanged
    {
        string text = "default text";
        public string Text
        {
            get => text;
            set
            {
                text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }
        public InputFieldViewModel(string Label)
        {
            text = Label;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
