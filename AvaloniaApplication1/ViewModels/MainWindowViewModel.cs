using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private int _count;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _username;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _password;

    [ObservableProperty]
    private string _greeting = "hey";

    partial void OnGreetingChanged(string value)
    {
        _count++;
    }

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task Login()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        Greeting = "yay";
    }

    private bool CanLogin() => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

    [RelayCommand]
    private void SetGreeting(string name)
    {
        Greeting += $" {name}";
    }
}
