using NUnit.Framework;
using System.Threading.Tasks;

namespace ScrabbleWordChecker.Test
{
    public class ScrabbleWordCheckerTests
    {

        [Test]
        [TestCase("pyjamaed", ScrabbleDictionaryEnum.SOWPODS, true)]
        [TestCase("pyjamaed", ScrabbleDictionaryEnum.TWL, false)]
        [TestCase("aaa", ScrabbleDictionaryEnum.SOWPODS, false)]
        [TestCase("aaa", ScrabbleDictionaryEnum.TWL, false)]
        [TestCase("mantelpiece", ScrabbleDictionaryEnum.SOWPODS, true)]
        [TestCase("mantelpiece", ScrabbleDictionaryEnum.TWL, true)]
        [TestCase("", ScrabbleDictionaryEnum.SOWPODS, false)]
        [TestCase("", ScrabbleDictionaryEnum.TWL, false)]
        [TestCase("   ", ScrabbleDictionaryEnum.SOWPODS, false)]
        [TestCase("   ", ScrabbleDictionaryEnum.TWL, false)]
        [TestCase(" ", ScrabbleDictionaryEnum.SOWPODS, false)]
        [TestCase(" ", ScrabbleDictionaryEnum.TWL, false)]
        [TestCase(null, ScrabbleDictionaryEnum.SOWPODS, false)]
        [TestCase(null, ScrabbleDictionaryEnum.TWL, false)]
        public async Task Check_HasCorrectOutput(string wordToCheck, ScrabbleDictionaryEnum dictionary, bool expectedResult)
        {
            var checker = await ScrabbleWordChecker.CreateAsync();
            var result = checker.Check(wordToCheck, dictionary);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
