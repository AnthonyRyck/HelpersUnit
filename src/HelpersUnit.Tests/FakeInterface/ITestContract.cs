namespace HelpersUnit.Tests.FakeInterface
{
    internal interface ITestContract
    {
        /// <summary>
        /// Retourne quelquechose...
        /// </summary>
        /// <returns></returns>
        int GetQuelquechose();

        /// <summary>
        /// Retourne une autre chose.
        /// </summary>
        /// <param name="chose"></param>
        /// <returns></returns>
        string GetUneAutreChose(string chose);
    }
}
