using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace HRManagement.API
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly JsonSerializer _serializer = new();
        public LocalizedString this[string name]
        {
            get
            {
                return new LocalizedString(name, GetString(name));
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var actualValue = this[name];
                return !actualValue.ResourceNotFound ? new LocalizedString(name, string.Format(actualValue.Value, arguments)) : actualValue;
            }
        }
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        private string GetString(string key)
        {
            var filePath = $"Localization/Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            var fullFilePath = Path.GetFullPath(filePath);
            if (!File.Exists(fullFilePath))
            {
                return string.Empty;
            }

            return GetValue(key, fullFilePath);

        }
        private string GetValue(string propertyName, string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(propertyName))
            {
                return string.Empty;
            }
            using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new(stream);
            using JsonTextReader reader = new JsonTextReader(streamReader);
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value as string == propertyName)
                {
                    reader.Read();
                    return _serializer.Deserialize<string>(reader);
                }
            }
            return string.Empty;
        }
    }
}
