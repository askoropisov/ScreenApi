using Avalonia.Controls;

namespace ScreenApi.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (VisualRoot != null)
            {
                Window w = (Window)VisualRoot;
                var screen = w.Screens.All[0];
                windowSize = new Avalonia.Point(screen.Bounds.Width, screen.Bounds.Height);
            }
        }

        public Avalonia.Point windowSize { get; set; }
    }
}
