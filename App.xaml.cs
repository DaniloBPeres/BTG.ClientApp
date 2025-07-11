namespace BTG.ClientApp
{
    public partial class App : Application
    {
        private readonly AppShell _shell;

        public static IServiceProvider Services { get; private set; } = null!;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Services = serviceProvider;
            _shell = serviceProvider.GetRequiredService<AppShell>();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(_shell);
        }
    }
}