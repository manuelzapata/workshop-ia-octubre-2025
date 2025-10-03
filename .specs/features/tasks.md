# Lista de Tareas del Proyecto

Este documento desglosa el trabajo definido en `planning.md` en tareas accionables para el desarrollo del dashboard de análisis de empresas SaaS.

## Fase 0: Diseño y Arquitectura

### Documentación de Decisiones Arquitectónicas (ADRs)
- [ ] Crear ADR 1: "Patrón de arquitectura por capas para frontend y backend"
    - [ ] Documentar contexto del patrón de capas elegido
    - [ ] Justificar decisión vs otras alternativas (Clean Architecture, Hexagonal)
    - [ ] Definir consecuencias y estructura de capas específica
- [ ] Crear ADR 2: "Filtrado client-side vs server-side para el dashboard"
    - [ ] Analizar pros y contras de filtrado en cliente vs servidor
    - [ ] Documentar decisión de filtrado client-side con paginación
    - [ ] Evaluar impacto en performance y escalabilidad

### Diseño de Arquitectura (Modelo C4)
- [ ] Crear diagrama de contexto C4 utilizando Mermaid
    - [ ] Definir sistema principal (Dashboard SaaS)
    - [ ] Identificar usuarios (Inversionistas, Analistas)
    - [ ] Mostrar Azure SQL como sistema externo
- [ ] Crear diagrama de contenedores C4 utilizando Mermaid
    - [ ] Frontend Blazor WebAssembly como contenedor web
    - [ ] Backend ASP.NET Core Web API como contenedor de aplicación
    - [ ] Azure SQL Database como contenedor de base de datos
    - [ ] Definir protocolos de comunicación (HTTPS, SQL)

### Diseño de Base de Datos
- [ ] Crear diagrama de modelo de datos utilizando Mermaid
    - [ ] Diseñar entidades principales: company, industry, location, investor
    - [ ] Definir relaciones entre entidades (FK, muchos a muchos)
    - [ ] Especificar tipos de datos principales para cada campo
- [ ] Revisar modelo de datos existente en scripts SQL
    - [ ] Validar estructura de tablas vs requerimientos del dashboard
    - [ ] Verificar tipos de datos para campos monetarios y numéricos
    - [ ] Confirmar relaciones entre company, industry y location

### Documentación de Arquitectura
- [ ] Documentar diagramas de arquitectura en formato markdown
    - [ ] Explicar decisiones de cada diagrama C4
    - [ ] Describir flujo de datos entre contenedores
    - [ ] Documentar patrones de comunicación
- [ ] Documentar modelo de base de datos
    - [ ] Explicar normalización aplicada
    - [ ] Describir propósito de cada tabla
    - [ ] Documentar campos de auditoría (created_at, updated_at)

## Fase 1: Base de Datos y Backend Core

### Configuración de Base de Datos
- [ ] Configurar conexión a Azure SQL Database
    - [ ] Configurar connection strings para desarrollo y producción
    - [ ] Validar ejecución de scripts de creación de tablas
    - [ ] Verificar carga de datos desde dataset CSV
- [ ] Configurar Entity Framework Core
    - [ ] Crear DbContext principal del proyecto
    - [ ] Configurar modelos de entidades (Company, Industry, Location, Investor)
    - [ ] Configurar relaciones entre entidades usando Fluent API

### Configuración Backend
- [ ] Configurar proyecto ASP.NET Core Web API
    - [ ] Configurar estructura de carpetas (Controllers, Services, Repositories, Models)
    - [ ] Configurar inyección de dependencias para servicios y repositorios
    - [ ] Configurar CORS para desarrollo del frontend
- [ ] Implementar modelos DTO
    - [ ] Crear CompanyDto con todos los campos requeridos
    - [ ] Crear IndustryDto para el filtro de industrias
    - [ ] Crear LocationDto para el filtro de ubicaciones

### Implementación de Repositorios
- [ ] Implementar ICompanyRepository y CompanyRepository
    - [ ] Método GetAllCompaniesAsync() con Include de Industry y Location
    - [ ] Mapeo directo de entidades a DTOs
    - [ ] Manejo de errores y logging
- [ ] Implementar IIndustryRepository y IndustryRepository
    - [ ] Método GetAllIndustriesAsync() ordenado alfabéticamente
    - [ ] Retornar lista única de industrias
- [ ] Implementar ILocationRepository y LocationRepository
    - [ ] Método GetAllLocationsAsync() ordenado alfabéticamente
    - [ ] Concatenar ciudad y país para display name

### Implementación de Servicios
- [ ] Implementar ICompanyService y CompanyService
    - [ ] Lógica de negocio para obtener empresas
    - [ ] Validaciones de datos si son necesarias
    - [ ] Logging de operaciones principales
- [ ] Implementar IIndustryService y IndustryService
    - [ ] Lógica para obtener catálogo de industrias
    - [ ] Cache en memoria si es necesario
- [ ] Implementar ILocationService y LocationService
    - [ ] Lógica para obtener catálogo de ubicaciones
    - [ ] Formateo de nombres de ubicación

### Implementación de Controllers
- [ ] Implementar CompaniesController
    - [ ] Endpoint GET /api/companies para listado completo
    - [ ] Configurar ProducesResponseType para documentación
    - [ ] Manejo de errores con ProblemDetails
- [ ] Implementar IndustriesController
    - [ ] Endpoint GET /api/industries para catálogo
    - [ ] Respuesta ordenada alfabéticamente
- [ ] Implementar LocationsController
    - [ ] Endpoint GET /api/locations para catálogo
    - [ ] Respuesta con formato "Ciudad, País"
- [ ] Implementar HealthController
    - [ ] Endpoint GET /health para health check
    - [ ] Verificar conectividad con base de datos
    - [ ] Retornar estado del servicio

### Pruebas Unitarias Backend
- [ ] Configurar proyecto de pruebas unitarias (xUnit)
    - [ ] Configurar dependencias de testing (xUnit, Moq, FluentAssertions)
    - [ ] Configurar TestFixtures para DbContext in-memory
- [ ] Implementar pruebas para CompanyService
    - [ ] Prueba de GetAllCompaniesAsync() comportamiento esperado
    - [ ] Prueba de manejo de errores de base de datos
    - [ ] Prueba de mapeo correcto a DTOs
- [ ] Implementar pruebas para IndustryService
    - [ ] Prueba de GetAllIndustriesAsync() con ordenamiento
    - [ ] Prueba de cache si está implementado
- [ ] Implementar pruebas para LocationService
    - [ ] Prueba de GetAllLocationsAsync() con formato correcto
    - [ ] Prueba de ordenamiento alfabético
- [ ] Implementar pruebas para Repositories
    - [ ] Pruebas de CompanyRepository con datos de prueba
    - [ ] Pruebas de relaciones entre entidades (Include)
    - [ ] Pruebas de IndustryRepository y LocationRepository

## Fase 2: Frontend Base y Comunicación

### Configuración Frontend
- [ ] Configurar proyecto Blazor WebAssembly
    - [ ] Configurar estructura de carpetas (Components, Services, Models, Pages)
    - [ ] Configurar HttpClient para comunicación con API
    - [ ] Configurar base URL del API en configuración
- [ ] Implementar modelos DTO en frontend
    - [ ] Copiar CompanyDto, IndustryDto, LocationDto del backend
    - [ ] Asegurar serialización JSON correcta
    - [ ] Validar tipos de datos compatibles

### Servicios de Comunicación
- [ ] Implementar ICompanyService y CompanyService para frontend
    - [ ] Método GetAllCompaniesAsync() llamando al API
    - [ ] Manejo de errores HTTP y timeouts
    - [ ] Deserialización de respuestas JSON
- [ ] Implementar IIndustryService y IndustryService para frontend
    - [ ] Método GetAllIndustriesAsync() llamando al API
    - [ ] Cache local de industrias
- [ ] Implementar ILocationService y LocationService para frontend
    - [ ] Método GetAllLocationsAsync() llamando al API
    - [ ] Cache local de ubicaciones
- [ ] Configurar inyección de dependencias en Program.cs
    - [ ] Registrar HttpClient con base URL
    - [ ] Registrar servicios de datos (Company, Industry, Location)

### Componentes Base
- [ ] Crear layout principal de la aplicación
    - [ ] Actualizar MainLayout.razor con navegación del dashboard
    - [ ] Configurar estilos CSS básicos con Bootstrap
    - [ ] Agregar header con título del proyecto
- [ ] Crear página principal del dashboard (Dashboard.razor)
    - [ ] Estructura básica de la página
    - [ ] Estados de carga inicial
    - [ ] Manejo de errores de carga
- [ ] Implementar componente básico CompanyList.razor
    - [ ] Tabla HTML básica para mostrar empresas
    - [ ] Loading spinner durante carga de datos
    - [ ] Mensaje de error si falla la carga

### Validación de Comunicación
- [ ] Implementar manejo de estados de carga
    - [ ] Loading states para todas las llamadas async
    - [ ] Spinners o indicadores visuales
    - [ ] Estados de error con mensajes user-friendly
- [ ] Validar comunicación frontend-backend
    - [ ] Probar endpoints desde el frontend
    - [ ] Verificar serialización/deserialización JSON
    - [ ] Confirmar CORS configurado correctamente

## Fase 3: Funcionalidades del Dashboard

### Sistema de Filtros
- [ ] Crear componente FilterPanel.razor
    - [ ] Dropdown para filtro de industrias con opción "Todas las industrias"
    - [ ] Dropdown para filtro de ubicaciones con opción "Todas las ubicaciones"
    - [ ] Botón para resetear todos los filtros
    - [ ] Indicadores visuales de filtros activos
- [ ] Implementar lógica de filtrado client-side
    - [ ] Filtrado en tiempo real cuando cambian los dropdowns
    - [ ] Combinación de múltiples filtros (industria + ubicación)
    - [ ] Preservar filtros durante navegación entre páginas
- [ ] Integrar FilterPanel con CompanyList
    - [ ] Pasar eventos de filtro desde FilterPanel a CompanyList
    - [ ] Aplicar filtros a la lista de empresas
    - [ ] Actualizar contador de resultados filtrados

### Paginación y Navegación
- [ ] Implementar lógica de paginación client-side
    - [ ] Dividir resultados en páginas de 25 registros
    - [ ] Calcular número total de páginas
    - [ ] Mantener página actual en el estado del componente
- [ ] Crear componente PaginationControls.razor
    - [ ] Botones Anterior/Siguiente
    - [ ] Números de página clickeables
    - [ ] Información de "Mostrando X de Y resultados"
    - [ ] Deshabilitar controles cuando corresponda
- [ ] Integrar paginación con filtros
    - [ ] Resetear a página 1 cuando cambian los filtros
    - [ ] Recalcular paginación con resultados filtrados
    - [ ] Preservar filtros durante navegación de páginas

### Tabla de Empresas Completa
- [ ] Completar CompanyList.razor con todas las columnas
    - [ ] Columnas: Nombre, Industria, Ubicación, Productos, Año Fundación
    - [ ] Columnas monetarias: Total Inversión, ARR, Valoración
    - [ ] Columna de empleados y rating G2
    - [ ] Formato adecuado para valores monetarios (M/B)
- [ ] Implementar diseño responsivo
    - [ ] Tabla responsiva que se adapte a diferentes pantallas
    - [ ] Ocultar columnas menos importantes en móviles
    - [ ] Scroll horizontal para pantallas pequeñas
- [ ] Agregar estados de carga durante filtrado
    - [ ] Loading overlay mientras se aplican filtros
    - [ ] Mensaje cuando no hay resultados
    - [ ] Indicador de filtros activos

### Polish y UX
- [ ] Implementar estilos CSS consistentes
    - [ ] Estilos para tabla de empresas
    - [ ] Estilos para controles de filtros
    - [ ] Estilos para paginación
    - [ ] Responsive design con Bootstrap
- [ ] Agregar mensajes informativos
    - [ ] "No se encontraron resultados" cuando filtros no devuelven datos
    - [ ] Mensajes de error amigables para fallos de red
    - [ ] Contador de empresas mostradas vs total
- [ ] Optimizar performance del frontend
    - [ ] Debouncing para filtros si es necesario
    - [ ] Virtualización de tabla para datasets grandes (futuro)
    - [ ] Lazy loading de datos si aplica

## Fase 4: Testing y Documentación

### Testing Comprehensivo Backend
- [ ] Ampliar cobertura de pruebas unitarias
    - [ ] Alcanzar >80% de cobertura de código
    - [ ] Pruebas para todos los métodos públicos de servicios
    - [ ] Pruebas de casos límite y manejo de errores
- [ ] Implementar pruebas de integración para controllers
    - [ ] Pruebas end-to-end de endpoints con WebApplicationFactory
    - [ ] Validar respuestas HTTP correctas
    - [ ] Probar serialización de DTOs
- [ ] Configurar reporte de cobertura de pruebas
    - [ ] Configurar herramientas de coverage (coverlet)
    - [ ] Generar reportes HTML de cobertura
    - [ ] Establecer thresholds mínimos de cobertura

### Documentación Técnica
- [ ] Actualizar README.md con instrucciones de setup
    - [ ] Prerrequisitos (.NET 8, Azure SQL)
    - [ ] Instrucciones paso a paso para desarrollo local
    - [ ] Comandos para ejecutar backend y frontend
    - [ ] Configuración de connection strings
- [ ] Documentar API con Swagger/OpenAPI
    - [ ] Asegurar que Swagger UI esté configurado
    - [ ] Documentar todos los endpoints con ejemplos
    - [ ] Agregar descripciones detalladas de DTOs
- [ ] Crear documentación de arquitectura
    - [ ] Incluir diagramas C4 generados en Fase 0
    - [ ] Documentar decisiones arquitectónicas (ADRs)
    - [ ] Explicar estructura de capas y responsabilidades

### Optimización y Performance
- [ ] Optimizar queries de base de datos
    - [ ] Revisar queries generados por Entity Framework
    - [ ] Asegurar uso eficiente de Include() para relaciones
    - [ ] Validar que no haya problemas N+1
- [ ] Optimizar bundle size del frontend
    - [ ] Configurar build de producción de Blazor WASM
    - [ ] Verificar tamaño de archivos generados
    - [ ] Aplicar tree shaking si es necesario
- [ ] Implementar caché básico donde aplicable
    - [ ] Cache de industrias y ubicaciones en frontend
    - [ ] Considerar IMemoryCache en backend para catálogos
- [ ] Validar métricas de performance
    - [ ] Tiempo de carga inicial < 3 segundos
    - [ ] Tiempo de filtrado < 1 segundo
    - [ ] Verificar performance en navegadores principales

### Preparación para Producción
- [ ] Configurar environments (Development, Production)
    - [ ] Separar configuraciones por environment
    - [ ] Variables de entorno para connection strings
    - [ ] Configurar logging diferente por environment
- [ ] Implementar logging estructurado
    - [ ] Configurar Serilog o logger nativo de .NET
    - [ ] Logs de errores con contexto adecuado
    - [ ] Logs de performance para operaciones críticas
- [ ] Configurar health checks completos
    - [ ] Health check de base de datos con timeout
    - [ ] Health check de dependencias externas
    - [ ] Endpoint /health listo para monitoreo
- [ ] Crear scripts de deployment básicos
    - [ ] Scripts para build de producción
    - [ ] Comandos para deployment a Azure
    - [ ] Documentar proceso de deployment

---

## Notas de Implementación

### Prioridades de Desarrollo
1. **Crítico**: Fases 1-2 deben completarse para tener MVP funcional
2. **Importante**: Fase 3 para funcionalidades completas del dashboard
3. **Deseable**: Fase 4 para calidad de producción

### Dependencias entre Tareas
- Todas las tareas de Fase 0 deben completarse antes de comenzar desarrollo
- Backend (Fase 1) debe estar funcional antes de comenzar frontend (Fase 2)
- Filtros y paginación (Fase 3) requieren servicios de comunicación completos
- Testing (Fase 4) debe ejecutarse en paralelo con desarrollo cuando sea posible

### Criterios de Aceptación
- **Cada tarea debe incluir**: Código funcional, pruebas (si aplica), documentación básica
- **Definition of Done**: Código revisado, pruebas passing, sin errores de build
- **MVP Ready**: Fases 1-2 completas + filtro básico de Fase 3