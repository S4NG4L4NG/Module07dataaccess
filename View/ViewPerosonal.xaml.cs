using Module07dataaccess.Services;
using Module07dataaccess.ViewModel;
namespace Module07dataaccess.View;

public partial class ViewPerosonal : ContentPage
{
	public ViewPerosonal()
	{
		InitializeComponent();

		var personalViewModel = new PersonalViewModel();
		BindingContext = personalViewModel;
	}
}