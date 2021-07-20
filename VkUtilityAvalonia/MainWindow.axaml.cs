using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VkUtilityAvalonia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        string buttonText = "Click Me!";
        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonText)));
            }
        }

        string inputText = string.Empty;
        public string InputText
        {
            get => inputText;
            set
            {
                inputText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InputText)));
            }
        }

        public string[] variants = new string[] { "First", "Second", "Третий, короче" };
        public string[] Variants
        {
            get => Variants;
            set
            {
                variants = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Variants)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        int Clicks = 0;
        public void ButtonClicked()
        {
            Clicks++;

            if (Clicks < 10)
            {
                ButtonText = "Yeap, i'm clicked";
            }
            else if (Clicks < 100)
            {
                ButtonText = "Click me stronger, daddy!";
            }
            else
            {
                ButtonText = "YEEEEEAGH";
            }

            InputText = "Али, ули, скоростные пули!";
        }
        public void OpenWindow()
        {
        }
    }
}
