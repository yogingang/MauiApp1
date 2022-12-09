using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.MVVM.SourceGenerators;

public class ChangeNameMessage
{
    public ChangeNameMessage(string newName) => Name =  newName;
    
    public string Name { get; set; }
}