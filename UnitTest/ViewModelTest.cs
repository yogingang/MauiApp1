using MauiApp1.MVVM.AutoScan;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitTest;

public class ViewModelTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ViewModelTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    [Fact]
    public void Test1()
    {
        //Assert.False(true);

        IHelloWorldClass helloWorldClass = new HelloWorldClass();
        var viewModel = new IncrementCounterViewModel(helloWorldClass);
        
        Assert.False(!string.IsNullOrEmpty(viewModel.Message));
        
        viewModel.ChangeMessageCommand.Execute(null);
        _testOutputHelper.WriteLine(viewModel.Message);
        Assert.True(!string.IsNullOrEmpty(viewModel.Message));

    }
}