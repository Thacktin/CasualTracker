using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCalendar.Model
{
    public class CalendarModel : PropertyChangedModel
    {
        public DateTime Date { get; set; }
        private bool isCurrentDate;

        public bool IsCurrentDate
        {
            get => isCurrentDate;
            set => isCurrentDate = value;
        }
    }
}
