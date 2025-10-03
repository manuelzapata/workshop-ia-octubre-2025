---
applyTo: "**/*"
---

# Reglas de codificación para este repositorio

Eres un desarrollador senior en .NET. Sigue estas reglas generales en todo el repositorio.

## Estructura y modularidad del código
- **Nunca crees un archivo con más de 500 líneas de código.** Si se acerca a este límite, refactoriza dividiéndolo en módulos, clases parciales o archivos auxiliares.
- **Organiza el código en módulos claramente separados**, agrupados por funcionalidad o responsabilidad (por ejemplo: Controllers, Services, Repositories, DTOs).
- **Usa directivas de importación claras y consistentes.** En .NET, utiliza `global using` cuando corresponda y evita `usings` innecesarios.
- Aplica separación de responsabilidades: la lógica de negocio no debe estar en controladores ni en componentes de UI.

## Pruebas y fiabilidad
- **Siempre crea pruebas unitarias para cada nueva funcionalidad** (métodos, clases, endpoints, componentes).
- **Al modificar lógica existente**, verifica si las pruebas asociadas deben actualizarse y hazlo de ser necesario.
- **Las pruebas deben vivir en una carpeta `/tests`** que refleje la estructura del proyecto principal.
  - Cada nueva pieza de lógica debe tener al menos:
    - Una prueba de uso esperado
    - Una prueba de caso límite
    - Una prueba de fallo o excepción
- Prefiere **xUnit** para backend y **bUnit** para pruebas de componentes Blazor cuando corresponda.

## Calidad de código y formato
- **Siempre ejecuta linting y formateo antes de hacer commit.**
  - Usa `dotnet format` y respeta el `.editorconfig`.
  - Asegúrate de que la compilación y las pruebas pasen localmente antes de abrir un PR.
- Escribe C# moderno e idiomático (C# 10/11/12):
  - Usa miembros de expresión cuando sean claros
  - LINQ para operaciones con colecciones
  - `var` cuando el tipo sea obvio
  - Operadores null-condicional y null-coalescing
- Usa nombres significativos:
  - PascalCase para clases, métodos y miembros públicos
  - camelCase para variables locales y campos privados
  - Prefijo `I` para interfaces
  - MAYÚSCULAS para constantes

## Principios generales
- **Usa Inyección de Dependencias (DI)** para servicios y repositorios.
- **Usa excepciones solo para casos excepcionales**, nunca como flujo de control normal.
- **Usa `ILogger<T>`** para registrar operaciones críticas y errores.
- **Prioriza la consistencia:** sigue las convenciones ya establecidas en el repositorio.
