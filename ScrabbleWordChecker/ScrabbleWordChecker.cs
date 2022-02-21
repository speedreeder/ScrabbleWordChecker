using System.Reflection;

namespace ScrabbleWordChecker
{
    public class ScrabbleWordChecker
    {
        public static readonly List<string> _SOWPODSDictionary = new();
        public static readonly List<string> _TWLDictionary = new();
        private ScrabbleWordChecker() { }

        private async Task<ScrabbleWordChecker> InitializeAsync()
        {
            await Task.WhenAll(ReadInDictionaryAsync(_SOWPODSDictionary, "ScrabbleWordChecker.sowpods.txt"),
                               ReadInDictionaryAsync(_TWLDictionary, "ScrabbleWordChecker.twl06.txt"));
            
            return this;
        }

        private async Task ReadInDictionaryAsync(List<string> dictionary, string fileName)
        {
            await using var sowpodsStream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(fileName);
            if (sowpodsStream != null)
            {
                sowpodsStream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new(sowpodsStream))
                {
                    string currentLine;
                    while ((currentLine = await reader.ReadLineAsync()) != null)
                    {
                        dictionary.Add(currentLine);
                    }
                }
            }
            else
            {
                throw new Exception("Unable to find SOWPODS dictionary.");
            }
        }

        public static Task<ScrabbleWordChecker> CreateAsync()
        {
            var ret = new ScrabbleWordChecker();
            return ret.InitializeAsync();
        }

        public bool Check(string wordToCheck, ScrabbleDictionaryEnum dictionary = ScrabbleDictionaryEnum.SOWPODS)
        {
            if (string.IsNullOrWhiteSpace(wordToCheck))
            {
                return false;
            }

            if(dictionary == ScrabbleDictionaryEnum.SOWPODS)
            {
                if(_SOWPODSDictionary.Count == 0)
                {
                    throw new Exception("SOWPODS dictionary has not been initialized.");
                }

                if (_SOWPODSDictionary.Contains(wordToCheck.ToLowerInvariant()))
                {
                    return true;
                }
            }

            if (dictionary == ScrabbleDictionaryEnum.TWL)
            {
                if (_TWLDictionary.Count == 0)
                {
                    throw new Exception("SOWPODS dictionary has not been initialized.");
                }

                if (_TWLDictionary.Contains(wordToCheck.ToLowerInvariant()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}