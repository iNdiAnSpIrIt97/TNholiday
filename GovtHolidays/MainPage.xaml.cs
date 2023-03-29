namespace GovtHolidays;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void ViewBtn_Clicked(object sender, EventArgs e)
	{
        GovernmentHolidayService holidayService = new GovernmentHolidayService();
        Navigation.PushAsync(new HolidayView(holidayService));
    }
}

