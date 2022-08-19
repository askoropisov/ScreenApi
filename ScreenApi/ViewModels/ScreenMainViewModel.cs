using Avalonia.Interactivity;
using ScreenApi.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenApi.ViewModels
{
    public class ScreenMainViewModel : ViewModelBase
    {
        private readonly MainWindow _mainWindow;

        public ScreenMainViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private Bitmap _memoryImage;
        public Bitmap MemoryImage
        {
            get => _memoryImage;
            set => _memoryImage = value;
        }
        public void ScreenShot()
        {
            MemoryImage = new Bitmap((int)_mainWindow.windowSize.X, (int)_mainWindow.windowSize.Y);
            Size s = new Size(MemoryImage.Width, MemoryImage.Height);

            Graphics memoryGraphics = Graphics.FromImage(MemoryImage);

            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            string fileName = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                      @"\Screenshot" + "_" +
                      DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".png");

            MemoryImage.Save(fileName);
        }

        public void TakeAndPostSceenshot(object? sender, RoutedEventArgs args)
        {
            ScreenShot();
        }

    }
}
