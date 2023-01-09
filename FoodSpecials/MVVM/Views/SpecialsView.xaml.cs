using FoodSpecials.MVVM.ViewModels;

namespace FoodSpecials.MVVM.Views;

public partial class SpecialsView : ContentPage
{
	public SpecialsView()
	{
		InitializeComponent();
		BindingContext = new SpecialsViewModel();
	}

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {

    }
}