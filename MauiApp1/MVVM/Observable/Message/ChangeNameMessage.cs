using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.MVVM.Observable;

public class ChangeNameMessage:RequestMessage<string>
{
    public ChangeNameMessage(string newName) => Name =  newName;
    
    public string Name { get; set; }
}