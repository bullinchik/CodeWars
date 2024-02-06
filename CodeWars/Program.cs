using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using NUnit.Framework.Legacy;
    
public class Kata
{
    public static bool Alphanumeric(string str)
    {
        return Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");
    }
}

[TestFixture]
public class Sample_Tests
{
    private static IEnumerable<TestCaseData> testCases
    {
        get
        {
            yield return new TestCaseData("Mazinkaiser").Returns(true);
            yield return new TestCaseData("hello world_").Returns(false);
            yield return new TestCaseData("PassW0rd").Returns(true);
            yield return new TestCaseData("     ").Returns(false);
        }
    }
    
    [Test, TestCaseSource("testCases")]
    public bool Test(string str) => Kata.Alphanumeric(str);
}
