using CustomCalendar.Model;
using System.Windows.Input;

namespace CustomCalendar;

public partial class CalendarView
{

    Dictionary<int, List<CalendarModel>> weeks;
    //List<WeekModel> weeks = new List<WeekModel>();
    DateTime SelectedDay { get; set; }

    public CalendarView()
    {
        InitializeComponent();
        BindingContext = this;
    }

    //creating bindableProperty
    public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
       nameof(SelectedDay),
       typeof(DateTime),
       typeof(CalendarView),
       DateTime.Now,
       BindingMode.TwoWay,
       propertyChanged: SelectedDatePropertyChanged);

    public static readonly BindableProperty SelectedDateCommandProperty = BindableProperty.Create(
  nameof(SelectedDateCommand),
  typeof(ICommand),
  typeof(CalendarView)
    );

    public ICommand SelectedDateCommand { get => (ICommand)GetValue(SelectedDateCommandProperty); set => SetValue(SelectedDateCommandProperty, value); }
    public ICommand CurrentDateCommand => new Command<CalendarModel>((currentDate) =>
    {
        SelectedDay = currentDate.Date;
        SelectedDateCommand?.Execute(currentDate.Date);
    });

    public ICommand NextMonthCommand => new Command(() =>
    {
        SelectedDay.AddMonths(1);
        BindDates(SelectedDay);
    });

    public ICommand PreviousMonthCommand => new Command(() =>
    {
        SelectedDay.AddMonths(-1);
        BindDates(SelectedDay);
    });


    //propetyChanged event
    private static void SelectedDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (CalendarView)bindable;
        if (newValue != null)
        {
            var newDate = (DateTime)newValue;

            //if (controls._bufferDate.Month == newDate.Month && controls._bufferDate.Year == newDate.Year)
            //{
            //    var currentDate = controls.Weeks.FirstOrDefault(f => f.Value.FirstOrDefault(x => x.Date == newDate.Date) != null).Value.FirstOrDefault(f => f.Date == newDate.Date);
            //    if (currentDate != null)
            //    {
            //        controls.Weeks.ToList().ForEach(x => x.Value.ToList().ForEach(y => y.IsCurrentDate = false));
            //        currentDate.IsCurrentDate = true;
            //    }
            //}

            controls.BindDates(newDate);
        }
    }

    public void BindDates(DateTime date)
    {
        SetWeeks(date);
        var choosenDate = weeks.SelectMany(w => w.Value).FirstOrDefault(w => w.Date.Date == date.Date);

        if (choosenDate != null)
        {
            SelectedDay = choosenDate.Date;
            choosenDate.IsCurrentDate = true;
        }
    }



    //populate week list
    private void SetWeeks(DateTime date)
    {
        DateTime firstday = new(date.Year, date.Month, 1);
        int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        int currentweek = 1;

        weeks = new();

        //dates from previous months end
        for (int i = 1; i < (int)firstday.DayOfWeek; i++)
        {
            DateTime dateFromWeek = firstday.AddDays(-(int)firstday.DayOfWeek - i);

            //weeks[currentweek - 1].Days.Add(new CalendarModel() { Date = dateFromWeek });
            if (weeks.ContainsKey(currentweek))
            {
                weeks.Add(currentweek, new());
            }
            weeks[currentweek].Add(new CalendarModel() { Date = dateFromWeek });
        }

        for (int i = 1; i <= daysInMonth; i++)
        {
            DateTime dateInMonth = new(date.Year, date.Month, i);
            if (dateInMonth.DayOfWeek == DayOfWeek.Monday && daysInMonth != 1)
            {
                currentweek++;
            }
            //weeks[currentweek - 1].Days.Add(new CalendarModel() { Date = dateInMonth });

            if (weeks.ContainsKey(currentweek))
            {
                weeks.Add(currentweek, new());
            }
            weeks[currentweek].Add(new CalendarModel() { Date = dateInMonth });
        }

        DateTime lastDayOfMonth = new(date.Year, date.Month, daysInMonth);
        for (int i = 1; i <= 6 - (int)lastDayOfMonth.DayOfWeek; i++)
        {
            DateTime lastDate = lastDayOfMonth.AddDays(i);
            //weeks[currentweek - 1].Days.Add(new CalendarModel() { Date = lastDate });

            if (weeks.ContainsKey(currentweek))
            {
                weeks.Add(currentweek, new());
            }
            weeks[currentweek].Add(new CalendarModel() { Date = lastDate });
        }
    }
}