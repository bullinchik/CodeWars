//https://www.codewars.com/kata/54d512e62a5e54c96200019e/train/csharp

using NUnit.Framework;
using NUnit.Framework.Legacy;

public class Permutations
{
    public static List<String> SinglePermutations(string s)
    {
        List<char> arr = s.ToCharArray().ToList();
        List<string>  result = new List<string>();

        _Permute(arr, ref result, "");
        
        return result.Distinct().ToList();
    }

    private static void _Permute(List<char> arr, ref List<string> result, string memo)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            var current = arr[i];
            arr.RemoveAt(i);

            if (arr.Count == 0)
            {
                result.Add(memo + current);
            }

            _Permute(arr, ref result, memo + current);
            
            arr.Insert(i, current);
        }
    }


    [TestFixture]
    public class PrimeDecompTests {

        [Test]
        public void Example1()
        {
            ClassicAssert.AreEqual(new List<string> { "a" }, Permutations.SinglePermutations("a").OrderBy(x => x).ToList());
        }

        [Test]
        public void Example2()
        {
            ClassicAssert.AreEqual(new List<string> { "ab", "ba" }, Permutations.SinglePermutations("ab").OrderBy(x => x).ToList());
        }

        [Test]
        public void Example3()
        {
            ClassicAssert.AreEqual(new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }, Permutations.SinglePermutations("aabb").OrderBy(x => x).ToList());
        }
        [Test]
        public void Example4()
        {
            ClassicAssert.AreEqual(new List<string> { "abc","acb","bac","bca","cab","cba" }, Permutations.SinglePermutations("abc").OrderBy(x => x).ToList());
        }
    }
}