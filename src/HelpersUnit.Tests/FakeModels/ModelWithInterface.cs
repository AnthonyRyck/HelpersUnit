using HelpersUnit.Tests.FakeInterface;

namespace HelpersUnit.Tests.FakeModels
{
    internal class ModelWithInterface
    {
        private readonly IConnection _connection;

        private readonly ITestContract _contract;



        public ModelWithInterface(IConnection connection, ITestContract contract)
        {
            _connection = connection;
            _contract = contract;
        }
    }
}
