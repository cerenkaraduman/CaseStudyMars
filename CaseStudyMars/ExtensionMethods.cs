using System;

namespace CaseStudyMars
{
    public static class ExtensionMethods
    {
        public static bool IsPossitiveVariable(this int variable)
        {
            bool posstiveResult = true;
            if (variable <= 0)
            {
                posstiveResult = false;
            }

            return posstiveResult;
        }
        public static bool IsInt(this string variable)
        {
            int output;
            bool validateResult = int.TryParse(variable, out output);

            if (!validateResult)
            {
                validateResult = false;
            }

            return validateResult;
        }
        public static string FormatInput(this string variable)
        {
            if (string.IsNullOrWhiteSpace(variable))
            {
                Console.WriteLine("Invalid input. You can't type a null input.");
                Environment.Exit(0);
            }
            return variable.Trim().ToUpper();
        }
        public static int ConvertInt(this string variable)
        {
            int output;
            int.TryParse(variable, out output);

            if (!variable.IsInt())
            {
                Console.WriteLine("Invalid input. You must type int.");
                Environment.Exit(0);
            }

            if (!output.IsPossitiveVariable())
            {
                Console.WriteLine("Invalid input. You must type possitive int.");
                Environment.Exit(0);
            }

            return output;
        }
    }
}
