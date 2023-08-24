using Moq;
using System.Reflection;

namespace HelpersUnit.Helpers
{
    public static class ObjectHelpers
    {
        /// <summary>
        /// Permet de remplacer une valeur d'un champ privé pour une autre.
        /// </summary>
        /// <typeparam name="T">Type de l'instance</typeparam>
        /// <param name="obj">Objet ou il faut remplacer une valeur</param>
        /// <param name="namePrivateField">Nom du champ privé</param>
        /// <param name="newValue">La nouvelle valeur.</param>
        public static void ReplaceFieldValue<T>(T obj, string namePrivateField, object newValue)
            where T : class
        {
            var allFields = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in allFields)
            {
                if (field.Name == namePrivateField)
                {
                    field.SetValue(obj, newValue);
                }
            }
        }

        /// <summary>
        /// Permet de remplacer une valeur d'un champ privé pour une autre.
        /// </summary>
        /// <typeparam name="T">Type de l'instance</typeparam>
        /// <param name="obj">Objet ou il faut remplacer une valeur</param>
        /// <param name="namePrivateField">Nom du champ privé</param>
        /// <param name="newValue">La nouvelle valeur.</param>
        public static void ReplaceFieldValue<T>(Mock<T> obj, string namePrivateField, object newValue)
            where T : class
        {
            ReplaceFieldValue<T>(obj.Object, namePrivateField, newValue);
        }
    }
}
