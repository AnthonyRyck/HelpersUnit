using HelpersUnit.Tests.FakeModels;
using HelpersUnit.Helpers;
using HelpersUnit.Tests.FakeClass;

namespace HelpersUnit.Tests.Helpers
{
    public class ObjectHelpersTests
    {
        [Test]
        public void ChangeIntField_Ok()
        {
            #region Arrange

            TestModel testModel = new TestModel()
            {
                Id = 1,
                Name = "test",
                Description = "description_test"
            };

            int nouvelAge = 52;

            #endregion

            #region Act

            Assert.IsTrue(testModel.GetAge() == 21);

            ObjectHelpers.ReplaceFieldValue<TestModel>(testModel, "_age", nouvelAge);

            #endregion

            #region Assert

            Assert.IsTrue(testModel.GetAge() == nouvelAge);

            #endregion
        }

        [Test]
        public void ChangeStringField_Ok()
        {
            #region Arrange

            TestModel testModel = new TestModel()
            {
                Id = 1,
                Name = "test",
                Description = "description_test"
            };

            string newSurname = "Hello!";

            #endregion

            #region Act

            Assert.IsTrue(testModel.GetSurname() == "Plouf");

            ObjectHelpers.ReplaceFieldValue<TestModel>(testModel, "_surname", newSurname);

            #endregion

            #region Assert

            Assert.IsTrue(testModel.GetSurname() == newSurname);

            #endregion
        }


        [Test]
        public void GetPrivateStaticMethodInStaticClass_WhenResultIsDouble()
        {
            #region Arrange

            double nbreUn = 10;
            double nbreDeux = 5;
            double expected = 50;

            #endregion

            #region Act

            double result = ObjectHelpers.InvokePrivateStaticMethodInStaticClass<double>(typeof(MyStaticClass), "Multiplication", nbreUn, nbreDeux);

            #endregion

            #region Assert

            Assert.That(result, Is.EqualTo(expected));

            #endregion
        }

        [Test]
        public void GetPrivateStaticMethodInStaticClass_WhenResultIsInt()
        {
            #region Arrange

            int nbreUn = 10;
            int nbreDeux = 5;
            int expected = 15;

            #endregion

            #region Act

            int result = ObjectHelpers.InvokePrivateStaticMethodInStaticClass<int>(typeof(MyStaticClass), "Somme", nbreUn, nbreDeux);

            #endregion

            #region Assert

            Assert.That(result, Is.EqualTo(expected));

            #endregion
        }

        [Test]
        public void GetPrivateStaticMethodInClass_WhenResultIsDouble()
        {
            #region Arrange

            double nbreUn = 10;
            double nbreDeux = 5;
            double expected = 50;

            #endregion

            #region Act

            double result = ObjectHelpers.InvokePrivateStaticMethodInStaticClass<double>(typeof(UneClassPasStatic), "Multiplication", nbreUn, nbreDeux);

            #endregion

            #region Assert

            Assert.That(result, Is.EqualTo(expected));

            #endregion
        }

        [Test]
        public void GetPrivateStaticMethodInClass_WhenResultIsInt()
        {
            #region Arrange

            int nbreUn = 10;
            int nbreDeux = 5;
            int expected = 15;

            #endregion

            #region Act

            int result = ObjectHelpers.InvokePrivateStaticMethodInStaticClass<int>(typeof(UneClassPasStatic), "Somme", nbreUn, nbreDeux);

            #endregion

            #region Assert

            Assert.That(result, Is.EqualTo(expected));

            #endregion
        }


        [Test]
        public void GetPrivateStaticMethodInClass_WhenResultIsObject()
        {
            #region Arrange

            int id = 10;

            #endregion

            #region Act

            TestModel result = ObjectHelpers.InvokePrivateStaticMethodInStaticClass<TestModel>(typeof(UneClassPasStatic), "GetTestModel", id);

            #endregion

            #region Assert

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));

            #endregion
        }

        [Test]
        public void GetPrivateStaticMethodInClass_WhenResultIsObjectqsd()
        {
            #region Arrange

            int id = 10;
            UneClassPasStatic uneInstance = new UneClassPasStatic();

            #endregion

            #region Act

            TestModel result = ObjectHelpers.InvokePrivateStaticMethod<TestModel>(uneInstance, "GetTestModel", id);

            #endregion

            #region Assert

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));

            #endregion
        }

        [Test]
        public void GetPrivateMethodInInstance_WhenResultIsObject()
        {
            #region Arrange

            int id = 10;
            UneClassPasStatic uneInstance = new UneClassPasStatic();

            #endregion

            #region Act

            TestModel result = ObjectHelpers.InvokePrivateMethod<TestModel>(uneInstance, "GetTest", id);

            #endregion

            #region Assert

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));

            #endregion
        }
        
        [Test]
        public void GetPrivateVoidInInstance_WhenResultIsObject()
        {
            #region Arrange

            UneClassPasStatic uneInstance = new UneClassPasStatic();

            #endregion

            #region Act

            ObjectHelpers.InvokePrivateMethod(uneInstance, "MoiJeRetourneRien");

            #endregion

            #region Assert

            Assert.That(uneInstance.UneValeur, Is.EqualTo(3));

            #endregion
        }
    }
}
