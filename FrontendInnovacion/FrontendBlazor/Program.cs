using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontendBlazor;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

// Crea un WebAssemblyHostBuilder, que configura la aplicación para Blazor WebAssembly.
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Registra el componente raíz de la aplicación, que es <App>. Esto es lo que inicia la aplicación en el cliente.
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura el servicio HttpClient como un servicio de ámbito (Scoped). 
// Esto permite hacer llamadas HTTP al backend de la aplicación.
// Aquí se define la dirección base de la API que utilizará la aplicación cliente
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5294/") });

// Construye y ejecuta la aplicación Blazor WebAssembly.
await builder.Build().RunAsync();
