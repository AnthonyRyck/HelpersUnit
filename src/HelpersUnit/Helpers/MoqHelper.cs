using Moq;
using System.Reflection;

namespace HelpersUnit.Helpers
{
    public class MoqHelper
    {
        /// <summary>
        /// Créer des Mock des paramètres du constructeur du type passé.
        /// Possible de sélectionner le constructeur (si plusieurs) avec une liste de Type qui doit
        /// contenir.
        /// </summary>
        /// <typeparam name="T">Class pour avoir les Mock</typeparam>
        /// <param name="constructorTypes">
        /// Liste de Type qui doit être présent dans le constructeur.
        /// Si vide, prend le premier constructeur qu'il trouve.
        /// </param>
        /// <returns>Liste des paramètres en Mock<T></returns>
        public IEnumerable<Mock> CreateMockParamsConstructor<T>(params Type[] constructorTypes)
            where T : class
        {
            Type targetType = typeof(T);

            ConstructorInfo constructor = constructorTypes.Length == 0
                    ? targetType.GetConstructors().FirstOrDefault()
                    : targetType.GetConstructor(constructorTypes);

            return constructor == null
                ? throw new InvalidOperationException($"No constructor found for type {targetType.Name}.")
                : GetMocks(constructor);
        }

        #region private methods

        private IEnumerable<Mock> GetMocks(ConstructorInfo constructor)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            List<Mock> mocks = new List<Mock>();

            foreach (ParameterInfo parameter in parameters)
            {
                if (!IsPrimitiveType(parameter.ParameterType))
                {
                    var mock = CreateMockRecursive(parameter.ParameterType);
                    mocks.Add(mock);
                }
            }

            return mocks;
        }

        private static bool IsPrimitiveType(Type type)
        {
            return type.IsPrimitive
                || type == typeof(string)
                || type == typeof(decimal)
                || type == typeof(DateTime);
        }

        private Mock CreateMockRecursive(Type targetType)
        {
            Type mockType = typeof(Mock<>).MakeGenericType(targetType);
            return (Mock)Activator.CreateInstance(mockType);
        }

        #endregion

    }
}
