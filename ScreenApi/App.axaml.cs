using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using DryIoc;
using ReactiveUI;
using ScreenApi.ViewModels;
using ScreenApi.Views;
using Splat;
using Splat.DryIoc;

namespace ScreenApi
{
    public class App : Application
    {

        protected IContainer? Container;

        public override void Initialize()
        {
            InitializeDI();
            AvaloniaXamlLoader.Load(this);
        }

        private void InitializeDI()
        {
            var container = new Container();

            container.Register<ViewModelFactory>(Reuse.Singleton);

            container.Register<ScreenMain>(Reuse.Singleton);
            container.Register<MainWindow>(Reuse.Singleton);
            container.Register<MainWindowViewModel>(Reuse.Singleton);
            container.Register<ScreenMainViewModel>(Reuse.Singleton);

            var resolver = new DryIocDependencyResolver(container);
            Locator.SetLocator(resolver);
            container.RegisterInstance(resolver);

            resolver.InitializeSplat();
            resolver.InitializeReactiveUI();
            resolver.RegisterConstant(new AvaloniaActivationForViewFetcher(), typeof(IActivationForViewFetcher));
            resolver.RegisterConstant(new AutoDataTemplateBindingHook(), typeof(IPropertyBindingHook));
            RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;

            Container = container;
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = Container?.Resolve<MainWindowViewModel>(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
