using System;
using System.ComponentModel.DataAnnotations;

public class UserNameAttribute : ValidationAttribute
{
    public UserNameAttribute()
    {
        // You can set a default error message if you want
        ErrorMessage = "User Name must be at least 5 characters long and cannot contain special characters.";
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var userName = value as string;

        // Check for null or empty
        if (string.IsNullOrWhiteSpace(userName))
        {
            return new ValidationResult("User Name is required.");
        }

        // Check the length
        if (userName.Length < 5)
        {
            return new ValidationResult("User Name must be at least 5 characters long.");
        }

        // Check for special characters (you can customize this regex)
        if (!System.Text.RegularExpressions.Regex.IsMatch(userName, @"^[a-zA-Z0-9]*$"))
        {
            return new ValidationResult("User Name cannot contain special characters.");
        }

        // If all validations pass
        return ValidationResult.Success;
    }
}
