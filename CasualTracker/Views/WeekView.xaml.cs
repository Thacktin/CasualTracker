using CasualTracker.Persistence.Models;
using System.Globalization;

namespace CasualTracker.Views;

public partial class WeekView : ContentView
{
    List<Day> Week
    {
        get => (List<Day>)GetValue(WeekProperty);
        set => SetValue(WeekProperty, value);
    }

    public static readonly BindableProperty WeekProperty
        = BindableProperty.Create("Text", typeof(string), typeof(WeekView), "", BindingMode.OneWay, null,
            (b, o, n) => (b as WeekView).OnWeekChanged(n as List<Day>));

    public WeekView()
    {
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        Calendar calendar = cultureInfo.Calendar;
        var week = ISOWeek.GetWeekOfYear(DateTime.Now);



        var today = DateTime.Now;
        var currentDay = today.DayOfWeek;
        int days = (int)currentDay;
        DateTime monday = today.AddDays(-days - 6);
        var daysThisWeek = Enumerable.Range(0, 7)
    .Select(d => monday.AddDays(d))
    .ToList();
        Week = new List<Day>();
        for (int i = 0; i < 7; i++)
        {
            Week[i].Date = daysThisWeek[i];
            Week[i].NameofDay = daysThisWeek.ToString();
        }
        InitializeComponent();

        //weekLbl.Text = week.ToString();
        //weekList.BindingContext = Week;
    }

    private void OnWeekChanged(List<Day> week)
    {
        weekLbl.Text = ISOWeek.GetWeekOfYear(DateTime.Now).ToString();
        weekList.BindingContext = week;
    }

}