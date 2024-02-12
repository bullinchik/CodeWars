//https://www.codewars.com/kata/54d512e62a5e54c96200019e/train/csharp

using NUnit.Framework;
using NUnit.Framework.Legacy;

public class TimeFormat
{
    public static string GetReadableTime(int seconds)
    {
        return string.Format("{0:d2}:{1:d2}:{2:d2}", seconds/3600, (seconds%3600)/60 , seconds%60);
    }

    
    private void DoTest(int seconds, String expected)
    {
        String actual = TimeFormat.GetReadableTime(seconds);
        ClassicAssert.AreEqual(expected, actual, "for " + seconds + " seconds");
    }

    [Test]
    public void SampleTests()
    {
        DoTest(     0, "00:00:00");
        DoTest(    59, "00:00:59");
        DoTest(    60, "00:01:00");
        DoTest(    90, "00:01:30");
        DoTest(  3599, "00:59:59");
        DoTest(  3600, "01:00:00");
        DoTest( 45296, "12:34:56");
        DoTest( 86399, "23:59:59");
        DoTest( 86400, "24:00:00");
        DoTest(359999, "99:59:59");
    }
}