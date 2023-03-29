using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GovtHolidays;

public partial class HolidayView : ContentPage
{
    private readonly GovernmentHolidayService _service;

    public HolidayView()
    {
        GovernmentHolidayService holidayService = new();
        HolidayView holidayView = new HolidayView(holidayService);
    }

    public HolidayView(GovernmentHolidayService service)
    {
        _service = service;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var holidays = await _service.GetGovernmentHolidaysAsync();
        HolidayCollectionView.ItemsSource = holidays;
    }
}