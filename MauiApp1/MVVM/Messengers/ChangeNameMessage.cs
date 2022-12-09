using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.MVVM.Messengers;

public class ChangeNameMessage
{
    public ChangeNameMessage(string newName) => Name =  newName;
    
    public string Name { get; set; }
}