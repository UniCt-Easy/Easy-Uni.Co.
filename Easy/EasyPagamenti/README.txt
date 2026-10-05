Se in fase di debug risultano mancare

"System.Web.Http"
"Xamarin.JOSE.JWT"

è possibile ripristinarli cliccando col destro sulla soluzione e scegliendo "Restore NuGet Packages".

Nel caso il problema non si risolva è possibile reinstallarli dalla console di NuGet package manager con i comandi seguenti:

Install-Package Microsoft.AspNet.WebApi.Core
Install-Package Xamarin.JOSE.JWT