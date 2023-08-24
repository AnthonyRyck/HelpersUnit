using HelpersUnit.Datas;
using System.Text;

namespace HelpersUnit.Helpers
{
    public static class Generate
    {
        /// <summary>
        /// Permet de créer un string aléatoirement avec une longueur spécifiée.
        /// </summary>
        /// <param name="longueur"></param>
        /// <returns></returns>
        public static string GenerateString(int longueur)
        {
            if (longueur <= 0)
            {
                throw new ArgumentException("La longueur doit être supérieure à zéro.");
            }

            StringBuilder sb = new StringBuilder();

            // Caractères pouvant être utilisés pour générer la chaîne
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            Random random = new Random();

            // Générer les caractères un par un jusqu'à atteindre la longueur spécifiée
            while (sb.Length < longueur)
            {
                int index = random.Next(caracteres.Length);
                char caractere = caracteres[index];
                sb.Append(caractere);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Permet de créer un string aléatoirement avec une longueur spécifiée et les caractères voulus.
        /// </summary>
        /// <param name="longueur">Longueur du string à retourner</param>
        /// <param name="caractresUtilisatble">Liste des caractères à utiliser</param>
        /// <returns></returns>
        public static string GenerateString(int longueur, string caractresUtilisatble)
        {
            if (longueur <= 0)
            {
                throw new ArgumentException("La longueur doit être supérieure à zéro.");
            }

            StringBuilder sb = new StringBuilder();

            Random random = new Random();

            // Générer les caractères un par un jusqu'à atteindre la longueur spécifiée
            while (sb.Length < longueur)
            {
                int index = random.Next(caractresUtilisatble.Length);
                char caractere = caractresUtilisatble[index];
                sb.Append(caractere);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Permet de générer un mail par rapport aux constantes de la lib.
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomEmail()
        {
            Random random = new Random();
            string name = Constantes.Names[random.Next(Constantes.Names.Length)];
            string domain = Constantes.Domains[random.Next(Constantes.Domains.Length)];

            string email = $"{name}{random.Next(1000)}@{domain}";

            return email;
        }
    }
}
