using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Validations
{
    /**
     * Basic validation of (xxx) xxx-xxxx expression attribute
     */
    public class PhoneValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string str = value as string;

            str = str.Trim();

            int numBrackets = 0;
            int numHyphens = 0;
            int numNumbers = 0;
            int numSpaces = 0;

            int remainingNumbersLength = str.Length;

            for (int i = 0; i < str.Length; i++)
            {
                char chr = str[i];

                switch (chr)
                {
                    case ' ':
                        numSpaces++;
                        break;
                    case '(':
                    case ')':
                        numBrackets++;
                        break;
                    case '-':
                        numHyphens++;
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        numNumbers++;
                        break;
                }
            }

            remainingNumbersLength -= numBrackets;
            remainingNumbersLength -= numHyphens;
            remainingNumbersLength -= numSpaces;

            return numBrackets == 2 && numHyphens == 1 && numSpaces == 1 && numNumbers == remainingNumbersLength;
        }
    }
}
