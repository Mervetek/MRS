using System.Reactive;
using System.Windows.Input;
using MRS.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MRS.ViewModels;

public class MainWindowViewModel : ViewModelBase
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
   }

   [Reactive] public ClientInformationViewModel NewClient { get; set; } = new();

  public ReactiveCommand<Unit, Unit> CreateAppointment { get; }
  public ReactiveCommand<Unit, Unit> ListAppointments { get; }
  public ReactiveCommand<Unit, Unit> DeleteAppointment { get; }
}