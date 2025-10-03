# 1. Elección de Stack Tecnológico

Fecha: Septiembre 28 de 2025

## Status

Aceptada.

## Contexto

El proyecto SaaS Analytics Dashboard requiere una solución full-stack que permita mostrar información analítica de empresas SaaS con capacidades de filtrado y paginación. Se necesita una arquitectura que soporte:

- Frontend interactivo y responsivo para visualización de datos
- Backend robusto para servir APIs REST
- Base de datos confiable para almacenar información empresarial
- Integración fluida entre componentes

## Decisión

**Frontend: Blazor WebAssembly**
- Framework .NET para aplicaciones web del lado cliente
- Permite desarrollo en C# sin necesidad de JavaScript
- Componentización reutilizable y tipado fuerte

**Backend: ASP.NET Core Web API**
- Framework .NET para APIs REST robustas
- Integración nativa con Entity Framework Core
- Excelente performance y escalabilidad

**Base de Datos: Azure SQL Database**
- Base de datos relacional gestionada en la nube
- Alta disponibilidad y backup automático
- Integración óptima con Entity Framework Core

## Consecuencias

**Positivas:**
- Ecosistema .NET unificado reduce complejidad de desarrollo
- Tipado fuerte en toda la aplicación minimiza errores
- Tooling integrado de Visual Studio/VS Code
- Hosting simplificado en Azure App Service

**Negativas:**
- Tamaño inicial de descarga mayor en Blazor WASM (~2MB)
- Curva de aprendizaje para desarrolladores no familiarizados con .NET
- Dependencia del ecosistema Microsoft para despliegue óptimo