using CommunityToolkit.Mvvm.DependencyInjection;

namespace MauiApp1.MVVM.SourceGenerators;

public partial class Page : ContentPage
{
	public Page()
	{
		InitializeComponent();
    }

    public PageViewModel ViewModel => (PageViewModel)BindingContext;

}