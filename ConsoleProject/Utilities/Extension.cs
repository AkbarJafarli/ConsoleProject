namespace ConsoleProject.Utilities;

public static class Extension
{
    public static bool PasswordChecker(this string password)
    {
        bool IsUpperLetter = false;
        bool IsLowerLetter = false;
        bool IsDigit = false;

        if (password.Length < 8)
        {
            return false;
        }
        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                IsUpperLetter = true;
            }
            if (char.IsLower(c))
            {
                IsLowerLetter = true;
            }
            if (char.IsDigit(c))
            {
                IsDigit = true;
            }
        }
        return IsUpperLetter && IsLowerLetter && IsDigit;
    }

    public static bool EmailChecker(this string email)
    {
        if (email.Contains("@"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
