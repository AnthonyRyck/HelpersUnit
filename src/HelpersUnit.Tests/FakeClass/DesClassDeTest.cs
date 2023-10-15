using HelpersUnit.Tests.FakeModels;

namespace HelpersUnit.Tests.FakeClass
{
    public static class MyStaticClass
    {

        private static double Multiplication(double a, double b)
        {
            return a * b;
        }

        private static int Somme(int a, int b)
        {
            return a + b;
        }
    }

    public class UneClassPasStatic
    {
        public int UneValeur { get; private set; }

        public UneClassPasStatic()
        {
            UneValeur = 1;
        }

        private TestModel GetTest(int id)
        {
            return new TestModel
            {
                Id = id,
                Name = "test",
                Description = "test",
            };
        }

        private void MoiJeRetourneRien()
        {
            UneValeur = 3;
        }

        private static double Multiplication(double a, double b)
        {
            return a * b;
        }

        private static int Somme(int a, int b)
        {
            return a + b;
        }

        private static TestModel GetTestModel(int id)
        {
            return new TestModel
            {
                Id = id,
                Name = "test",
                Description = "test",
            };
        }
    }
}
