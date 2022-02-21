# CrusadexGenerator

Tool for checking words against the SOWPODS (European) and TWL (US) Scrabble dictionaries.

# Installing via NuGet

    Install-Package ScrabbleWordChecker
    
# How To Use

```csharp
var checker = await ScrabbleWordChecker.CreateAsync();

// check "pyjamaed" in the SOWPODS dictionary: true
var sowpodResult = checker.Check("pyjamaed", ScrabbleDictionaryEnum.SOWPODS);

// check "pyjamaed" in the TWL dictionary: false
var twlResult = checker.Check("pyjamaed", ScrabbleDictionaryEnum.TWL);
```
