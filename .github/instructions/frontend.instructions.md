---
applyTo: "src/frontend/**"
---

# Blazor WebAssembly (WASM)

Propósito: generar componentes Razor, servicios HTTP y UI accesible, con separación de responsabilidades y seguridad.

- Estructura y convenciones:
  - Carpetas típicas: `wwwroot`, `Pages`, `Shared`, `Services`.
  - Componentes pequeños y composables.
  - Usar `[Parameter]` y `EventCallback<T>` para comunicación entre componentes.
  - Si un componente excede ~150 líneas, sugerir mover lógica a servicios o clases parciales.

- Http / Servicios:
  - Usar `HttpClient` inyectado. En hosted, preferir `IHttpClientFactory`.
  - Mapear JSON con `System.Text.Json` (usar `PropertyNameCaseInsensitive = true` si aplica).
  - Manejar errores con `try/catch` en servicios y devolver un wrapper tipo `Result<T>`.

- Autenticación y autorización:
  - Si hay login: sugerir OIDC/MSAL/IdentityServer.
  - Nunca incluir secretos en código; usar configuración segura.

- Accesibilidad y performance:
  - Incluir `aria-*` en componentes.
  - Sugerir lazy loading de páginas grandes.
  - Usar `IAsyncDisposable` cuando se gestionen recursos nativos.
  - Proponer `dotnet publish -c Release` con trimming/AOT para producción.

- Tests:
  - xUnit para lógica. bUnit para renderizado de componentes si aplica.

- Ejemplos de prompts:
  - `// copilot: Crear componente UserCard con parámetros UserDto (Id, Name, Email) y EventCallback<Guid> OnEdit.`
  - `// copilot: Generar UserService con interfaz IUserService. Métodos async GetByIdAsync(Guid), GetAllAsync(). Usar HttpClient inyectado y devolver Result<T>.`
