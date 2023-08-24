using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hw.Emploi.Test.Common.Extensions
{
    public static class MockExtension
    {
        /// <summary>
        /// Retourne le Mock du type recherche, sinon c'est null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mocks"></param>
        /// <returns></returns>
        public static Mock<T> GetMock<T>(this IEnumerable<Mock> mocks)
            where T : class
        {
            var mock = mocks.OfType<Mock<T>>().FirstOrDefault();
            if (mock == null)
            {
                throw new InvalidOperationException($"Aucun élément de type {typeof(T).Name} trouvé dans la liste.");
            }
            return mock;
        }
    }
}
