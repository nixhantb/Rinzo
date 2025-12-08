using Microsoft.VisualBasic.FileIO;

namespace JobLeet.WebApi.JobLeet.Api.Exceptions
{
    public static class ErrorMessageManager
    {
        private static readonly Dictionary<string, string> _messages;

        static ErrorMessageManager()
        {
            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "JobLeet.Resources",
                "Localizations",
                "ErrorMessageManager.csv"
            );
            _messages = LoadErrorMessages(filePath);
        }

        private static Dictionary<string, string> LoadErrorMessages(string filePath)
        {
            var errorMessages = new Dictionary<string, string>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Skip header row
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length == 2)
                    {
                        errorMessages[fields[0]] = fields[1];
                    }
                }
            }

            return errorMessages;
        }

        public static string GetErrorMessage(string key)
        {
            if (_messages.TryGetValue(key, out var message))
            {
                return message;
            }
            throw new KeyNotFoundException($"The error message key '{key}' was not found.");
        }
    }
}
