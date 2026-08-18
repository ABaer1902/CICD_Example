using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial int nEntries { get; set; }  = 0;
}
