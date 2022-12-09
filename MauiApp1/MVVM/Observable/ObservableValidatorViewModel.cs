using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.ComponentModel.DataAnnotations;

namespace MauiApp1.MVVM.Observable;
public partial class ObservableValidatorViewModel : ObservableValidator
{
    public ObservableValidatorViewModel()
    {
        Name = "Yogingang";
    }

    private string _name;

    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    //[CustomValidation(typeof(ObservableValidatorViewModel), nameof(ValidateName))]
    [IsLetterOrDigitOrSpace]
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public static ValidationResult ValidateName(string name, ValidationContext context)
    {
        bool isInValid =name.ToArray().Any(c => !char.IsLetterOrDigit(c));

        if (!isInValid)
        {
            return ValidationResult.Success;
        }

        return new("The name was not validated (Not Letter of Digit)");
    }

    [ObservableProperty]
    private string message;

    public ObservableUser User { get; } = new();

    [RelayCommand]
    private void ChangeName() 
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            Message = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
        }
        else
        {
            Message = String.Empty;
            Name = $"{DateTime.Now} {Name}";
        }
    }

    public sealed class IsLetterOrDigitOrSpaceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isInValid = (value as string).ToArray().Any(c => !(char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)));

            if (!isInValid)
            {
                return ValidationResult.Success;
            }

            return new("The name was not validated (Not Letter of Digit)");
        }
    }

}
