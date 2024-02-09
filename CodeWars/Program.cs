//https://www.codewars.com/kata/54d512e62a5e54c96200019e/train/csharp

using NUnit.Framework;
using NUnit.Framework.Legacy;

public class PrimeDecomp
{
    public static String factors(int lst)
    {
        String result = "";
        int i = 2, count = 0;
        do
        {
            if (lst % i == 0)
            {
                lst /= i;
                count++;
            }
            
            if (lst % i == 0 && lst != 1) continue;
            
            if (count > 0)
            {
                result += count > 1 ? $"({i}**{count})" : $"({i})";
            }

            count = 0;
            i += i % 2 == 0 ? 1 : 2;
            
        } while (lst != 1);

        return result;
    }


    [TestFixture]
    public class PrimeDecompTests {

        [Test]
        public void Test1() {
  
            int lst = 7775460;
            ClassicAssert.AreEqual("(2**2)(3**3)(5)(7)(11**2)(17)", PrimeDecomp.factors(lst));
        }
    }
}