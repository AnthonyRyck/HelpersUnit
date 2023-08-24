using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HelpersUnit.Helpers
{
    public static class ObjectFillerHelper
    {
        public static T FillObject<T>()
        {
            T obj = Activator.CreateInstance<T>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite && property.PropertyType == typeof(string))
                {
                    property.SetValue(obj, GenerateRandomString());
                }
                else if (property.CanWrite && property.PropertyType == typeof(int))
                {
                    property.SetValue(obj, GenerateRandomNumber());
                }
                // Ajout d'autres conditions pour d'autres types de propriétés
                // ...
            }

            return obj;
        }

        private static string GenerateRandomString()
        {
            return Generate.GenerateString(12);
        }

        private static int GenerateRandomNumber()
        {
            // Logique pour générer un nombre aléatoire
            return 123;
        }

        /// <summary>
        /// Permet de créer une instance d'un objet en passant une liste de mock
        /// pour les paramètres du constructeur.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mockList"></param>
        /// <returns></returns>
        public static T FillConstructorOf<T>(IEnumerable<Mock> mockList) 
            where T : class
        {
            T result = null;
            Type type = typeof(T);
            var constructors = type.GetConstructors();

            if (constructors.Length > 0)
            {
                var allObjects = mockList.Select(x => x.Object).ToArray();
                // Pour l'instant, prend le premier constructeur.
                result = (T)constructors[0].Invoke(allObjects);
            }

            return result; 
        }

        /// <summary>
        /// Permet de créer un Mock d'un objet en passant une liste de mock
        /// pour les paramètres du constructeur.
        /// A utiliser pour faire des "Verify" sur l'objet à tester.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mockList"></param>
        /// <returns></returns>
        public static Mock<T> CreateMockForFilledConstructor<T>(IEnumerable<Mock> mockList)
            where T : class
        {
            ConstructorInfo[] constructors = typeof(T).GetConstructors();

            if (constructors.Length != 0
                && constructors[0].GetParameters().Length == mockList.Count())
            {
                object[] parameters = mockList.Select((Mock x) => x.Object).ToArray();
                var result = new Mock<T>(MockBehavior.Default, parameters);

                return result;
            }

            return null; 
        }

    }
}