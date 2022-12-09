
namespace MauiApp1.DataTemplate;
public class PersonDataTemplateSelector : DataTemplateSelector
{
    public Microsoft.Maui.Controls.DataTemplate ValidTemplate { get; set; }
    public Microsoft.Maui.Controls.DataTemplate InvalidTemplate { get; set; }

    protected override Microsoft.Maui.Controls.DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        return ((Person)item).Age >= 19 ? ValidTemplate : InvalidTemplate;
    }
}
