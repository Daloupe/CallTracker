using System;

using PropertyChanged;
using ProtoBuf;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class DateFilterItem
    {
        [ProtoMember(1)]
        public DateTime LongDate { get; set; }
        [ProtoMember(2)]
        public string ShortDate { get; set; }

        public DateFilterItem()
        {
            LongDate = DateTime.Today;
            ShortDate = LongDate.ToString("dd/MM");
        }

        public DateFilterItem(DateTime systemDate)
        {
            LongDate = systemDate;
            ShortDate = LongDate.ToString("dd/MM");
        }

        public DateFilterItem(string displayString)
        {
            LongDate = DateTime.Today;
            ShortDate = displayString;
        }
    }
}
