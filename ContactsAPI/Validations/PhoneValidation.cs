using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Validations
{
    /**
     * Criteria
     * 
     * 10 numbers
     * All numbers
     * No spaces
     * Without 0 or 15
     */
    public class PhoneValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string str = value as string;

            str = str.Trim();

            bool isValidNumber = str.Length == 10;

            if (isValidNumber)
            {
                isValidNumber = !str.StartsWith("0") && !str.StartsWith("15");

                bool areOnlyNumbers = isValidNumber;
                int i = 0;

                while (areOnlyNumbers && i < str.Length)
                {
                    areOnlyNumbers = char.IsDigit(str[i]);
                    i++;
                }

                isValidNumber = areOnlyNumbers;
            }

            return isValidNumber;
        }
    }
}
