# HelpersUnit

[![NuGet](https://img.shields.io/nuget/vpre/HelpersUnit.svg)](https://www.nuget.org/packages/HelpersUnit)
[![Downloads](https://img.shields.io/nuget/dt/HelpersUnit.svg)](https://www.nuget.org/packages/HelpersUnit)

Il a pour but d'aider dans la création des tests unitaires. C'est un ensemble d'outils _(helpers, extensions,...)_.  

## Docs - Helpers

### MoqHelper

La `class MoqHelper` est une aide pour la création de Mock.  
- `public IEnumerable<Mock> CreateMockParamsConstructor<T>(params Type[] constructorTypes)`  
Crée les Mock des paramètres du constructeur du type passé. Si la liste `params` est vide, il prendra le premier constructeur qu'il trouve.  
Pour selectionner le constructeur (si plusieurs), il faut passer la liste de type qui sont présent dans ce constructeur.   
Ensuite, il suffit de récupérer le Mock voulu pour lui ajouter des comportements.  

Exemple complet :  
```csharp
#region Arrange
    
MoqHelper moqHelper = new MoqHelper();
// Permet de créer une liste de mock de chaque paramètre du constructeur.
// la class UnSuperController a 24 paramètres.
IEnumerable<Mock> allMockParams = moqHelper.CreateMockParamsConstructor<UnSuperController>();

// Méthode d'extension pour récupérer un Mock particulier de la liste.
Mock<IWebDetailsService> mockOffre = allMockParams.GetMock<IWebDetailsService>();
mockOffre.Setup(x => x.GetDetailViewModel(123, 666, false, false))
         .Returns(new DetailViewModel());

// même code, mais avec une écriture "fluide"
allMockParams.GetMock<IWebDetailsService>()
             .Setup(x => x.GetDetailViewModel(123, 666, false, false))
             .Returns(new OffreViewModel());

#endregion
```

### ObjectHelpers

La `class ObjectHelpers` permet de faire des actions sur un objet/instance.  

- `public static void ReplaceFieldValue<T>(T obj, string namePrivateField, object newValue)`  
Permet de modifier la valeur d'un champ privé (field) par une nouvelle valeur.  
```csharp
// ...methode de test...

#region Arrange

// [..du code..]

Mock<IAuthService> mockAuth = new Mock<IAuthService>();
mockAuth.Setup(x => x.GetEmailFailedHistory(It.IsAny<string>()))
       .Returns(new Common.Result.InfoResult<int>() { Result = 2 });
mockAuth.Setup(x => x.GetByEmail(It.IsAny<string>()))
       .Returns(new InfoResult<AuthUser>()
          {
             Success = false
          });

#endregion

#region Act

ResourceOwnerPasswordValidator resourceOwner = new ResourceOwnerPasswordValidator(config, mockLogger.Object);

// Remplace le field "_authManager" par notre Mock.
ObjectHelpers.ReplaceFieldValue<ResourceOwnerPasswordValidator>(resourceOwner, "_authManager", mockAuth.Object);

var result = resourceOwner.ValidateAsync(context);

#endregion
```

- `public static T InvokePrivateMethod<T>(object instance, string namePrivateMethod, params object[] parameters)`  
Récupére le résultat d'une méthode privée dans une instance.  
```csharp
int id = 10;
UneClassPasStatic uneInstance = new UneClassPasStatic();
TestModel result = ObjectHelpers.InvokePrivateMethod<TestModel>(uneInstance, "GetTest", id);
```
- `public static void InvokePrivateMethod(object instance, string namePrivateMethod, params object[] parameters)`  
Exécute une méthode privée dans une instance, SANS résultat.

```csharp
UneClassPasStatic uneInstance = new UneClassPasStatic();
ObjectHelpers.InvokePrivateMethod(uneInstance, "MoiJeRetourneRien");
```
Note : dans cette exemple, il n'y a pas non plus de paramètre pour la méthode.  

- `public static T InvokePrivateStaticMethod<T>(object instance, string namePrivateMethod, params object[] parameters)`  
Récupére le résultat d'une méthode privée **STATIC** dans une instance.
```csharp
int id = 10;
UneClassPasStatic uneInstance = new UneClassPasStatic();

TestModel result = ObjectHelpers.InvokePrivateStaticMethod<TestModel>(uneInstance, "GetTestModel", id);
```

- `public static void InvokePrivateStaticMethod(object instance, string namePrivateMethod, params object[] parameters)`  
Exécute une méthode privée STATIC dans une instance sans retour de résultat.
```csharp
int id = 10;
UneClassPasStatic uneInstance = new UneClassPasStatic();

ObjectHelpers.InvokePrivateStaticMethod(uneInstance, "UneMethodSansRetour", id);
```

- `public static T InvokePrivateStaticMethodInStaticClass<T>(Type staticClassType, string namePrivateMethod, params object[] parameters)`  
Retourne le résultat d'une méthode "private static" dans une class static.
```csharp
double nbreUn = 10;
double nbreDeux = 5;

double result = ObjectHelpers.InvokePrivateStaticMethodInStaticClass<double>(typeof(MyStaticClass), "Multiplication", nbreUn, nbreDeux);
```

- `public static void InvokePrivateStaticMethodInStaticClass(Type staticClassType, string namePrivateMethod, params object[] parameters)`  
Exécute une méthode "private static" sans retour de résultat dans une class static.
```csharp
ObjectHelpers.InvokePrivateStaticMethodInStaticClass(typeof(MyStaticClass), "UneMethodSansRetour");
```
Note : dans cette exemple, il n'y a pas non plus de paramètre pour la méthode.

### ObjectFillerHelper

La `class ObjectFillerHelper` permet de faire de "nourrir" un objet, via des paramètres.  

- `public static T FillConstructorOf<T>(IEnumerable<Mock> mockList)`  
En passant une liste de Mock, cette méthode va construire un objet.  
```csharp
[Test]
public async Task UserBlocked_Then_NoLogin()
{
    #region Arrange

    MoqHelper moqHelper = new MoqHelper();
    var paramsMock = moqHelper.CreateMockParamsConstructor<CompteController>();
    // [... code pour mock les comportements...]
    
    #endregion
    
    #region Act
    
    CompteController controller = ObjectFillerHelper.FillConstructorOf<CompteController>(paramsMock);
        
    #endregion
```

### Generate

La `class Generate` permet de générer du contenu (string, email) :  

- `public static string GenerateString(int longueur)`  
Permet de créer un string aléatoirement avec une longueur spécifiée.
```csharp
string random = Generate.GenerateString(12);
// output : "AsIU1g4Vcp4";
```
- `public static string GenerateString(int longueur, string caractresUtilisatble)`  
Permet de créer un string aléatoirement avec une longueur spécifiée et les caractères voulus.
```csharp
string random = Generate.GenerateString(5, "ABCDefgh");
// output : "AeCfg";
```
- `public static string GenerateRandomEmail()`  
Permet de générer un mail par rapport aux constantes de la lib.  
```csharp
string email = Generate.GenerateRandomEmail();
// output : "Kai-Haley866@yahoo.com
```
