namespace HelpersUnit.Tests.FakeInterface
{
    internal interface IConnection
    {
        /// <summary>
        /// Pour simuler une connexion.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task GetConnection(string url);
    }
}
