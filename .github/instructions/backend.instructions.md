---
applyTo: "src/backend/**"
---

# ASP.NET Core Web API

Propósito: crear endpoints REST seguros, testeables y claros. Seguir patrón Controller → Service → Repository → EF Core (u otro provider).

- Estilo y convenciones:
  - Usar `[ApiController]` y routing `api/[controller]`.
  - Validación con DataAnnotations y/o FluentValidation.
  - No exponer entidades de BD directamente: usar DTOs (Request/Response).
  - Añadir `[ProducesResponseType]` en endpoints.

- Seguridad:
  - Swagger (Swashbuckle) para documentación.
  - JWT Bearer o esquema OIDC para auth. Usar `[Authorize]` con roles/claims.
  - Centralizar manejo de errores con middleware y devolver `ProblemDetails`.

- DI y pruebas:
  - Promover DI para servicios/repositorios.
  - xUnit para unit tests, `WebApplicationFactory<TEntryPoint>` para integración.

- Logging y observabilidad:
  - Inyectar `ILogger<T>`.
  - Recomendar correlación de logs (RequestId).

- CI/CD y checks:
  - Antes de merge: `dotnet format`, `dotnet build`, `dotnet test`, escaneo de dependencias.
  - Revisión humana obligatoria para cambios en `src/` e `infrastructure/`.

- Ejemplos de prompts:
  - `// copilot: Crear ProductsController CRUD con DTOs ProductCreateDto, ProductReadDto, ProductUpdateDto. Inyectar IProductService y devolver códigos correctos (200/201/400/404).`
  - `// copilot: Generar repositorio EF Core con IProductRepository y ProductRepository (métodos async Add/GetAll/GetById/Update/Delete).`
