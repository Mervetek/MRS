using System;
using Avalonia.Collections;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MRS.ViewModels;

public class ClientInformationViewModel : ViewModelBase
{
    public ClientInformationViewModel()
    {
        AppointmentTypeList = Enum.GetValues(typeof(AppointmentType));

        for (var i = 0; i < 24; i++)
        {
            Hours.Add(i+1);
        }

        Minutes.Add("00");
        Minutes.Add("15");
        Minutes.Add("30");
        Minutes.Add("45");
        
    }

    [Reactive] public string Name { get; set; } = "";
    [Reactive] public string Surname { get; set; } = "";
    [Reactive] public AppointmentType AppointmentType { get; set; }
    [Reactive] public DateTime? AppointmentTime { get; set; }
    [Reactive] public Array AppointmentTypeList { get; set; }

    [Reactive] public int AppointmentHour { get; set; } = 1;
    [Reactive] public string AppointmentMinute { get; set; } = "00";

    [Reactive] public AvaloniaList<int> Hours { get; set; } = new();
    [Reactive] public AvaloniaList<string> Minutes { get; set; } = new();

}