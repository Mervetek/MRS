using System.IO;
using System.Reactive;
using System.Windows.Input;
using MRS.Interfaces;
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
       });

       EditAppointments = ReactiveCommand.Create(() =>
       {
            
       });

       DeleteAppointment = ReactiveCommand.Create(() =>
       {
           
       });
       
       /*
        * Var olan dosyanın okunması
        * Dosya kayıt
        * Edit
        * Delete
        */

   }

    [Reactive] public ClientInformationViewModel NewClient { get; set; } = new();

   [Reactive] public ClientInformationViewModel? SelectedClient { get; set; }


   public ReactiveCommand<Unit, Unit> CreateAppointment { get; }
   public ReactiveCommand<Unit, Unit> EditAppointments { get; }
   public ReactiveCommand<Unit, Unit> DeleteAppointment { get; }
}