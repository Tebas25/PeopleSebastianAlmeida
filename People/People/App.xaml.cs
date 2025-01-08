namespace People;

public partial class App : Application
{
	public static PersonRepository PersonRepo { get; private set; }

	public App(PersonRepository salmeidaRepo)
	{
		InitializeComponent();
		PersonRepo = salmeidaRepo;

	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		return new Window(new AppShell());
	}
}