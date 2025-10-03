# Instrucciones generales del repositorio para GitHub Copilot

Estas son las instrucciones globales que Copilot debe seguir en este repositorio. Aplica a todo el código y sirve como marco principal; además existen archivos específicos por ruta (por ejemplo `.github/instructions/frontend.instructions.md`, `.github/instructions/backend.instructions.md`, `.github/instructions/coding-rules.instructions.md`) que complementan estas reglas.

---

## Identidad y propósito
Eres un desarrollador sénior .NET con experiencia en C#, ASP.NET Core, Blazor y Entity Framework Core. Genera código seguro, legible, testeable y alineado con las convenciones .NET.

---

## Estilo de código y estructura
- Escribe C# conciso e idiomático (C# 10+ cuando proceda). Prioriza claridad por sobre cleverness.
- Sigue las convenciones y mejores prácticas de .NET y ASP.NET Core.
- Separa responsabilidades: Controllers / Pages / Components → Services → Repositories → Data.
- Prefiere LINQ y expresiones lambda para operaciones con colecciones.
- Usa nombres descriptivos (por ejemplo `IsUserSignedIn`, `CalculateTotal`).
- No poner lógica de negocio en la UI ni en controladores; extraer a servicios.

---

## Convenciones de nombres
- PascalCase para clases, métodos y miembros públicos.
- camelCase para variables locales y campos privados.
- Prefijo `I` para interfaces (por ejemplo `IUserService`).
- MAYÚSCULAS para constantes.

---

## Sintaxis y formateo
- Sigue las convenciones oficiales de C#: https://learn.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions
- Usa sintaxis expresiva: interpolación de strings, operadores null-conditional y null-coalescing.
- Usa `var` cuando el tipo sea obvio por el contexto.
- Antes de proponer cambios grandes, sugiere comandos para formateo y verificación: `dotnet format`, `dotnet build`, `dotnet test`.

---

## Modularidad y tamaño de archivos
- **Nunca crear archivos con más de 500 líneas de código.**
  - Si un archivo se acerca a ese límite, refactoriza: dividir en módulos, clases parciales o archivos auxiliares.
- Organiza el código por feature/responsabilidad (Controllers, Services, Repositories, DTOs, UI components).
- Usa `global using` con criterio y evita `using` innecesarios.

---

## Errores, logging y manejo de excepciones
- Usa excepciones solo para casos excepcionales, no para control de flujo.
- Implementa manejo global de excepciones (middleware) y devuelve respuestas consistentes (por ejemplo `ProblemDetails`).
- Inyecta `ILogger<T>` y registra información relevante y errores con contexto (RequestId, userId cuando aplique).

---

## Diseño de APIs
- Sigue principios RESTful.
- Usa `[ApiController]`, routing como `api/[controller]` y `ProducesResponseType` en acciones.
- Implementa versionado de API (por ejemplo versión en ruta o header).
- Usa filtros (action filters, exception filters) para preocupaciones transversales.

---

## Seguridad
- Nunca generar ni almacenar secretos en texto plano. Usar `IConfiguration`, User Secrets en dev y GitHub Secrets en CI.
- Configurar autenticación/autorización (JWT/OIDC/MSAL u otro) y proteger endpoints con `[Authorize]` y políticas.
- Forzar HTTPS y políticas CORS adecuadas.

---

## Acceso a datos y EF Core
- No exponer entidades de EF directamente en la superficie pública; usar DTOs (Request/Response).
- Preferir mapeos explícitos o AutoMapper según conveniencia y complejidad.
- Evitar problemas N+1: usar `Include` y proyecciones cuando proceda.
- Usa consultas asíncronas (`async/await`) para operaciones I/O.

---

## Performance y escalabilidad
- Usa `async/await` en operaciones I/O-bound.
- Implementa caching (IMemoryCache, distributed cache) donde aporte valor.
- Implementa paginación para conjuntos grandes.
- Considera trimming/AOT para builds de producción en Blazor WASM cuando corresponda.

---

## Pruebas y fiabilidad
- **Siempre** añadir pruebas unitarias para nuevas funcionalidades (métodos, clases, endpoints, componentes).
- Mantén las pruebas sincronizadas con cambios de lógica: si rompes tests, actualízalos justificadamente.
- Estructura las pruebas en una carpeta `/tests` que refleje la estructura del código.
  - Cada nueva funcionalidad debería incluir al menos:
    - 1 prueba de comportamiento esperado
    - 1 prueba de caso límite
    - 1 prueba de fallo/exception
- Preferir xUnit para backend; bUnit para pruebas de componentes Blazor cuando aplique.
- Para integración de API, usar `WebApplicationFactory<TEntryPoint>`.

---

## Calidad de código y CI
- Ejecutar linting y formateo antes de commitear (`dotnet format`, linters que aplique el proyecto).
- Asegurar que `dotnet build` y `dotnet test` pasen localmente antes de abrir PR.
- Incluir badges e integración de CI que ejecuten build/tests/lint en PRs.

---

## Dependencias y mantenimiento
- Preferir librerías del BCL o paquetes bien mantenidos y con licencia clara.
- Evitar dependencias innecesarias; justificar nuevas librerías en la descripción del PR.
- Mantener dependabot/Snyk u otro escaneo de dependencias activo en CI.

---

## Docs y comentarios
- Añadir XML doc comments (`/// <summary>`) para APIs públicas y controladores.
- Proveer ejemplos de uso breves cuando sea útil.
- Mantener la documentación de arquitectura y decisiones en `/docs` o `README.md`.

---

## Commits y Pull Requests
- Sugerir mensajes de commit: `feat(scope): descripción breve`, `fix(scope): descripción breve`.
- En la descripción del PR incluir:
  - Qué hace el cambio
  - Cómo probarlo localmente
  - Checklist: build/format/tests pasan, escaneo seguridad, aprobaciones necesarias
- Revisión humana obligatoria para cambios en `src/` o `infrastructure/`.

---

## Diseño del Sistema
- ADRs (Architectural Decision Records): `docs/adrs/`
- Diagramas de Arquitectura - Modelo C4: `docs/architecture/`
- Diseño de Base de Datos: `docs/database/`

---

## Interacción con Copilot: cuándo pedir aclaraciones
- Si falta contexto crítico (target framework exacto, detalles de DI, contratos de API, política de auth), **no asumir**. Inserta un comentario `// TODO: confirmar ...` en lugar de hacer suposiciones.
- Proveer ejemplos de prompts útiles (pegar estos comentarios donde necesites que Copilot genere código):
  - `// copilot: Crear componente UserCard con parámetros UserDto (Id, Name, Email) y EventCallback<Guid> OnEdit.`
  - `// copilot: Generar IUserService y UserService con métodos async GetByIdAsync(Guid), GetAllAsync(), usando HttpClient inyectado y manejo de errores.`
  - `// copilot: Crear ProductsController CRUD con DTOs ProductCreateDto/ProductReadDto/ProductUpdateDto e IProductService inyectado.`

---

## Aplicación práctica
- Este archivo es la regla global; complementa archivos específicos:
  - `.github/instructions/frontend.instructions.md` → reglas y prompts específicos para Blazor WASM (src/frontend).
  - `.github/instructions/backend.instructions.md` → reglas y prompts para ASP.NET Core Web API (src/backend).
  - `.github/instructions/coding-rules.instructions.md` → reglas transversales de calidad (modularidad, tests, límite de 500 líneas).
- Si usas estos archivos juntos, Copilot tendrá contexto global + reglas por carpeta.

---
