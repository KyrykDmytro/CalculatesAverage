using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathD;

namespace MathDTest
{
    [TestClass]
    public class DeltaTest
    {
        /*!Покритя тестами!
         Коли тобі потрібно перевірити чи весь код покритий тестами(або дізнатись 
        де він непокритий) ти можеш для кожного вєтвленея цього блоку коду поставити по 
        brakpoint'y і запустити тести(звязаний з цим кодом) в режимі Debug(і саме в цім режимі
        в інших brakpoint'и не працуют). Під час тестуваня коли ти зупинаєтеся на яакомусь brakpont'і
        ти його забераєш і нажимаєш F5 після тестуваня в тебе буде блок коду де вєтленя яке має біля 
        себе brakpoint не покрите тестем( для одного вєтленія потрібно тілку один тест в білщості випадках )
        */
        
        
        // МОДУЛЬНЕ ТЕСТУВАНЯ
        
        //params дозволяє після вписування трох парамерів сі наступні будуть записяний в масив
        //
        void SolverTest(double a, double b, double c, params double[] expectedResult)
        {
            var result = Delta.Solver(a, b, c);

            Assert.AreEqual(expectedResult.Length, result.Length);
            
            for(int i = 0; i < result.Length; i++) 
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }   
        }
        
        [TestMethod]
        public void SolverPositive()
        {
            SolverTest(1, -3, 2, 1, 2);
        }
        [TestMethod]
        public void SolverNegative()
        {
            SolverTest(1, 1, 1);
        }
        [TestMethod]
        public void SolverZero()
        {
            SolverTest(1, 2, 1, -1);
        }

        //Функціональне тестовання

        //Виколистовуєтся коли:
        //-На покритя кода модульними тестами  треба затратити багато 
        //  часу фінансівб тоді функціональне тест. є компромісом
        //-Не є можливим точне тестованяб тоді фунб тестовання 
        // висупає як тестуваня яке загально перевірає роботу алгоритма

        [TestMethod]
        public void FunctionalTest()
        {
            Random random = new Random();
            double a = random.NextDouble();
            double b = random.NextDouble();
            double c = random.NextDouble();

            double[] result = Delta.Solver(a, b, c);

            for(int i = 0;i < 100;i++)
            {
                foreach(double x in result)
                {
                    Assert.AreEqual(0, a * x * x + b * x + c, 10E-6);//10E-6 не докладне срвненя(≈)
                }
            }
        }
    }
}
//Завартість бібліотеки MathD
/*
namespace MathD
{
    public class Delta
    {
        public static double[] Solver(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;

            if (d > 0)
            {
                return new double[] { (-b - Math.Sqrt(d)) / (2 * a), (-b + Math.Sqrt(d)) / (2 * a) };
            }
            else if (d == 0)
            {
                return new[] { (-b) / (2 * a) };
            }
            else
            {
                return new double[0];
            }

        }
    }
}
*/