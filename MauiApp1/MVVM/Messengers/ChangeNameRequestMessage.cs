using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.MVVM.Messengers;

public class ChangeNameRequestMessage:RequestMessage<string>
{
    public ChangeNameRequestMessage(string newName) => Name =  newName;
    
    public string Name { get; set; }
}