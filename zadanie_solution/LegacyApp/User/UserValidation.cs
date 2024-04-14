using System;

namespace LegacyApp;

public class UserValidation
{
    public static bool IsNameValid(string firstName, string lastName)
    {
        return (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName));
    }

    public static bool IsEmailValid(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        var age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age >= 21;
    }
}