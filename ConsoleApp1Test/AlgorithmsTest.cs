using ConsoleApp1;

namespace ConsoleApp1Test
{
    [TestFixture]
    public class AlgorithmsTest
    {
        [TestCase("{}", true)]
        [TestCase("{", false)]
        [TestCase("}", false)]
        [TestCase("[]", true)]
        [TestCase("[", false)]
        [TestCase("]", false)]
        [TestCase("()", true)]
        [TestCase("(", false)]
        [TestCase(")", false)]
        [TestCase("<>", true)]
        [TestCase("<", false)]
        [TestCase(">", false)]
        [TestCase("(){}<>", true)]
        [TestCase("({[<>]})", true)]
        [TestCase("ab", false)]
        [TestCase("{>", false)]
        [TestCase("{}[", false)]
        public void IsCorrectStringTest(string text, bool result)
        {
            Assert.That(Algorithms.IsCorrectString(text), Is.EqualTo(result));
        }
        [TestCase("45+", 9)]
        [TestCase("45+5*", 45)]
        [TestCase("45-", 1)]
        [TestCase("55/", 1)]
        public void ReversePolishNotationTest(string text, int result)
        {
            Assert.That(Algorithms.ReversePolishNotation(text), Is.EqualTo(result));
        }
    }
}