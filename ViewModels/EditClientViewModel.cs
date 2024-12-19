using ReactiveUI.Fody.Helpers;

namespace MRS.ViewModels;

public class EditClientViewModel : ViewModelBase
{
    [Reactive] public ClientSummaryCardViewModel ClientSummary { get; set; }
  //  [Reactive] public Array AppointmentTypeList { get; set; }
}