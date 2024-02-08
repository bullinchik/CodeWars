//https://www.codewars.com/kata/5279f6fe5ab7f447890006a7/train/csharp
using NUnit.Framework;
using NUnit.Framework.Legacy;

public class PickPeaks
{
    public static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        Dictionary<string, List<int>> picksDictionary = new Dictionary<string, List<int>>();
        int peak = 0, pos = 0;
        picksDictionary.Add("pos", new List<int>());
        picksDictionary.Add("peaks", new List<int>());
        
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                pos = i;
                peak = arr[i];
            }
            if (arr[i] > arr[i + 1] && pos != 0)
            {
                picksDictionary["pos"].Add(pos);
                picksDictionary["peaks"].Add(peak);
                pos = 0;
                peak = 0;
            }
        }

        return picksDictionary;
    }

    [TestFixture]
    public class SolutionTest
    {

        private static string[] msg =
        {
            "1 should support finding peaks",
            "2 should support finding peaks, but should ignore peaks on the edge of the array",
            "3 should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
            "4 should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
            "5 should support finding peaks, but should ignore peaks on the edge of the array",
            "6 should support finding peaks; if the peak is in an end of a plateau"
        };

        private static int[][] array =
        {
            new int[] { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 },
            new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3 },
            new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 2, 2, 1 },
            new int[] { 2, 1, 3, 1, 2, 2, 2, 2, 1 },
            new int[] { 2, 1, 3, 1, 2, 2, 2, 2 },
            new int[] { 6, 10, 15, 13, -2, 8, 13, 13, 14, 0, -2 }
        };

        private static int[][] posS =
        {
            new int[] { 3, 7 },
            new int[] { 3, 7 },
            new int[] { 3, 7, 10 },
            new int[] { 2, 4 },
            new int[] { 2 },
            new int[] { 2, 8 }
        };

        private static int[][] peaksS =
        {
            new int[] { 6, 3 },
            new int[] { 6, 3 },
            new int[] { 6, 3, 2 },
            new int[] { 3, 2 },
            new int[] { 3 },
            new int[] { 15, 14}
        };

        [Test]
        public void SampleTests()
        {
            for (int n = 0; n < msg.Length; n++)
            {
                int[] p1 = posS[n], p2 = peaksS[n];
                var expected = new Dictionary<string, List<int>>()
                {
                    ["pos"] = p1.ToList(),
                    ["peaks"] = p2.ToList()
                };
                var actual = PickPeaks.GetPeaks(array[n]);
                ClassicAssert.AreEqual(expected, actual, msg[n]);
            }
        }
    }
}
