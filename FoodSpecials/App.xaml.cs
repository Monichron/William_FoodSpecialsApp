using FoodSpecials.MVVM.Views;

namespace FoodSpecials;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new SpecialsView();
	}
}
