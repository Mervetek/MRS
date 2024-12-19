using System.IO;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Collections;
using MRS.Interfaces;
using MRS.Services;
using MRS.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MRS.ViewModels;

public class MainWindowViewModel : ViewModelBase, IAppointmentOperations
{
    public MainWindowViewModel()
    {
        CreateAppointment = ReactiveCommand.Create(() =>
        {
            var newWindow = new ClientInformation
            {
                DataContext = NewClient
            };
            newWindow.Show();

            ClientCards = new ClientCardsViewModel();
        });

        EditAppointments = ReactiveCommand.Create(() =>
        {
            var editWindow = new ClientCards
            {
                DataContext = ClientCards
            };
            editWindow.Show();
        });

        DeleteAppointment = ReactiveCommand.Create(() => { });

        /*
         * Edit
         * Delete
         */
    }

    [Reactive] public ClientInformationViewModel NewClient { get; set; } = new();
    [Reactive] public ClientCardsViewModel ClientCards { get; set; } = new();
    public ReactiveCommand<Unit, Unit> CreateAppointment { get; }
    public ReactiveCommand<Unit, Unit> EditAppointments { get; }
    public ReactiveCommand<Unit, Unit> DeleteAppointment { get; }
}