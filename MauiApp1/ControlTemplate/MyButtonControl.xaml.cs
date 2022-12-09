namespace MauiApp1.ControlTemplate;

public partial class MyButtonControl : ContentView
{
    public static readonly BindableProperty ButtonTitleProperty = BindableProperty.Create(nameof(ButtonTitle), typeof(string), typeof(MyButtonControl), string.Empty);
    public static readonly BindableProperty ButtonContentProperty = BindableProperty.Create(nameof(ButtonContent), typeof(string), typeof(MyButtonControl), string.Empty);
    public static readonly BindableProperty ButtonFooterProperty = BindableProperty.Create(nameof(ButtonFooter), typeof(string), typeof(MyButtonControl), string.Empty);
    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MyButtonControl), Colors.Aqua);
    public static readonly BindableProperty StrokeProperty = BindableProperty.Create(nameof(Stroke), typeof(string), typeof(MyButtonControl), string.Empty);
    public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(nameof(StrokeThickness), typeof(string), typeof(MyButtonControl), string.Empty);

    public string Stroke
    {
        get => (string)GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }
    public string StrokeThickness
    {
        get => (string)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }
    public string ButtonTitle
    {
        get => (string)GetValue(ButtonTitleProperty);
        set => SetValue(ButtonTitleProperty, value);
    }
    public string ButtonContent
    {
        get => (string)GetValue(ButtonContentProperty);
        set => SetValue(ButtonContentProperty, value);
    }
    public string ButtonFooter
    {
        get => (string)GetValue(ButtonFooterProperty);
        set => SetValue(ButtonFooterProperty, value);
    }
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
    public MyButtonControl()
    {
        InitializeComponent();
    }
}