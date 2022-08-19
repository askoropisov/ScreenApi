using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenApi.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ViewModelFactory _vmFactory;

        public MainWindowViewModel(ViewModelFactory viewModelFactory)
        {
            _vmFactory = viewModelFactory;

            ScreenMainDataContext = _vmFactory.Create<ScreenMainViewModel>();
        }

        public ScreenMainViewModel ScreenMainDataContext { get; }
    }
}
