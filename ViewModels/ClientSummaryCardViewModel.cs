using System;
using System.Reactive;
using MRS.Utils;
using MRS.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MRS.ViewModels;

public class ClientSummaryCardViewModel : ViewModelBase
{
    private static Converter _converter = new();

    public ClientSummaryCardViewModel()
    {
        EditAppointment = ReactiveCommand.Create(() =>
        {
            var newWindow = new ClientInformation
            {
                DataContext = _converter.ConvertToClientInformation(this)
            };
            newWindow.Show();
        });
    }

    [Reactive] public string Name { get; set; } = "";
    [Reactive] public string Surname { get; set; } = "";
    [Reactive] public AppointmentType Type { get; set; }
    [Reactive] public DateTime AppointmentTime { get; set; }
    [Reactive] public string Time { get; set; } = "";
    
    
    public ReactiveCommand<Unit, Unit> EditAppointment { get; }
}