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

        /// <summary>
        /// Récupére le résultat d'une méthode privée dans une instance.
        /// </summary>
        /// <typeparam name="T">Type du retour de la méthode</typeparam>
        /// <param name="instance">fournir l'instance</param>
        /// <param name="namePrivateMethod">Nom de la méthode privée</param>
        /// <param name="parameters">Liste des paramètres pour la méthode</param>
        /// <returns></returns>
        public static T InvokePrivateMethod<T>(object instance, string namePrivateMethod, params object[] parameters)
        {
            if (string.IsNullOrEmpty(namePrivateMethod))
                throw new ArgumentNullException(nameof(namePrivateMethod));

            var method = instance.GetType().GetMethod(namePrivateMethod, BindingFlags.NonPublic | BindingFlags.Instance);
            var result = method.Invoke(instance, parameters);
            return (T)result;
        }

        /// <summary>
        /// Exécute une méthode privée dans une instance, SANS résultat
        /// </summary>
        /// <typeparam name="T">Type du retour de la méthode</typeparam>
        /// <param name="instance">fournir l'instance</param>
        /// <param name="namePrivateMethod">Nom de la méthode privée</param>
        /// <param name="parameters">Liste des paramètres pour la méthode</param>
        public static void InvokePrivateMethod(object instance, string namePrivateMethod, params object[] parameters)
        {
            if (string.IsNullOrEmpty(namePrivateMethod))
                throw new ArgumentNullException(nameof(namePrivateMethod));

            var method = instance.GetType().GetMethod(namePrivateMethod, BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(instance, parameters);
        }

        /// <summary>
        /// Récupére le résultat d'une méthode privée STATIC dans une instance.
        /// </summary>
        /// <typeparam name="T">Type du retour de la méthode</typeparam>
        /// <param name="instance">fournir l'instance</param>
        /// <param name="namePrivateMethod">Nom de la méthode privée</param>
        /// <param name="parameters">Liste des paramètres pour la méthode</param>
        /// <returns></returns>
        public static T InvokePrivateStaticMethod<T>(object instance, string namePrivateMethod, params object[] parameters)
        {
            if (string.IsNullOrEmpty(namePrivateMethod))
                throw new ArgumentNullException(nameof(namePrivateMethod));

            var method = instance.GetType().GetMethod(namePrivateMethod, BindingFlags.NonPublic | BindingFlags.Static);
            var result = method.Invoke(instance, parameters);
            return (T)result;
        }

        /// <summary>
        /// Exécute une méthode privée STATIC dans une instance sans retour de résultat
        /// </summary>
        /// <typeparam name="T">Type du retour de la méthode</typeparam>
        /// <param name="instance">fournir l'instance</param>
        /// <param name="namePrivateMethod">Nom de la méthode privée</param>
        /// <param name="parameters">Liste des paramètres pour la méthode</param>
        public static void InvokePrivateStaticMethod(object instance, string namePrivateMethod, params object[] parameters)
        {
            if (string.IsNullOrEmpty(namePrivateMethod))
                throw new ArgumentNullException(nameof(namePrivateMethod));

            var method = instance.GetType().GetMethod(namePrivateMethod, BindingFlags.NonPublic | BindingFlags.Static);
            method.Invoke(instance, parameters);
        }

        /// <summary>
        /// Retourne le résultat d'une méthode "private static" dans une class static
        /// </summary>
        /// <typeparam name="T">Type du retour</typeparam>
        /// <param name="staticClassType">Type de la class</param>
        /// <param name="namePrivateMethod"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T InvokePrivateStaticMethodInStaticClass<T>(Type staticClassType, string namePrivateMethod, params object[] parameters)
        {
            if (string.IsNullOrEmpty(namePrivateMethod))
                throw new ArgumentNullException(nameof(namePrivateMethod));

            var methodInfo = staticClassType.GetMethod(namePrivateMethod, BindingFlags.NonPublic | BindingFlags.Static);
            var result = methodInfo.Invoke(null, parameters);
            return (T)result;
        }

        /// <summary>
        /// Exécute une méthode "private static" sans retour de résultat dans une class static
        /// </summary>
        /// <typeparam name="T">Type du retour</typeparam>
        /// <param name="staticClassType">Type de la class</param>
        /// <param name="namePrivateMethod"></param>
        /// <param name="parameters"></param>
        public static void InvokePrivateStaticMethodInStaticClass(Type staticClassType, string namePrivateMethod, params object[] parameters)
        {
            if (string.IsNullOrEmpty(namePrivateMethod))
                throw new ArgumentNullException(nameof(namePrivateMethod));

            var methodInfo = staticClassType.GetMethod(namePrivateMethod, BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo.Invoke(null, parameters);
        }
    }
}
