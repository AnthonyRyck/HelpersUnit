using HelpersUnit.Tests.FakeInterface;
using HelpersUnit.Tests.FakeModels;
using HelpersUnit.Helpers;
using Moq;
using Hw.Emploi.Test.Common.Extensions;

namespace HelpersUnit.Tests.Helpers
{
    internal class MoqHelperTests
    {

        [Test]
        public void CreateParametersMocks_Then_Ok()
        {
            #region Arrange

            MoqHelper moqHelper = new MoqHelper();

            #endregion

            #region Act

            var results = moqHelper.CreateMockParamsConstructor<ModelWithInterface>();

            #endregion

            #region Assert

            Assert.IsNotNull(results);
            Assert.That(results.Count(), Is.EqualTo(2));

            Mock<IConnection> mockConnection = results.GetMock<IConnection>();
            Assert.IsNotNull(mockConnection);

            Mock<ITestContract> mockTest = results.GetMock<ITestContract>();
            Assert.IsNotNull(mockTest);

            #endregion
        }
    }
}
