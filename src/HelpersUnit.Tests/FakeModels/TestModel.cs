namespace HelpersUnit.Tests.FakeModels
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private string _surname;

        private int _age;

        public TestModel()
        {
            _age = 21;
            _surname = "Plouf";
        }


        public int GetAge() { return _age; }
        public string GetSurname() { return _surname;}
    }
}
