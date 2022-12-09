using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.ControlTemplate;
public class MyButtonContentChangeViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public MyButtonContentChangeViewModel()
    {
        RuntimeChangeContentCommand = new Command(
            execute: () =>
            {
                Content = $"Change Content {DateTime.Now}";
                Footer = $"Change Footer {DateTime.Now}";
            });

        Content = "Init Content";
        Footer = "Init Footer";
    }

    private string content;
    public string Content
    {
        private set
        {
            if (content != value)
            {
                content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
            }
        }
        get
        {
            return content;
        }
    }

    private string footer;
    public string Footer
    {
        private set
        {
            if (footer != value)
            {
                footer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Footer"));
            }
        }
        get
        {
            return footer;
        }
    }
    public ICommand RuntimeChangeContentCommand { private set; get; }
}
