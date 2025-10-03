# Descripción General

SaaS Analytics Dashboard es una aplicación web que permite a inversionistas analizar y explorar las métricas de las 100 empresas SaaS más importantes del mundo. La aplicación resuelve la necesidad de tener un acceso centralizado y estructurado a información crítica de empresas SaaS para la toma de decisiones de inversión.

El sistema está dirigido a inversionistas, analistas financieros y profesionales del sector tecnológico que requieren acceso rápido y filtrado a métricas empresariales como valoración, ingresos anuales, financiamiento total, industria y ubicación geográfica de las principales empresas SaaS del mercado.

La aplicación es valiosa porque centraliza datos dispersos del ecosistema SaaS en una interfaz unificada, permitiendo análisis comparativo eficiente y filtrado por criterios relevantes para decisiones de inversión.

# Funcionalidades Principales

## Backend API
- **Endpoint de Health Check**: Verificación del estado del servicio para monitoreo y disponibilidad del sistema. Importante para garantizar la confiabilidad del servicio. Retorna estado HTTP 200 con información básica del servicio.

- **Endpoint de Listado de Empresas**: Obtención del catálogo completo de empresas con capacidad de filtrado por industria y ubicación. Funcionalidad core que permite a los usuarios acceder a la información empresarial. Retorna datos completos sin paginación del lado del servidor.

- **Endpoint de Industrias**: Obtención del listado de todas las industrias disponibles para alimentar los filtros del frontend. Permite la construcción de filtros dinámicos y consistentes. Retorna lista única de industrias presentes en la base de datos.

- **Endpoint de Ubicaciones**: Obtención del listado de todas las ubicaciones disponibles para filtros geográficos. Esencial para la funcionalidad de filtrado por ubicación. Retorna lista única de ubicaciones (ciudad/país) disponibles.

## Frontend Dashboard
- **Listado Principal de Empresas**: Visualización tabular paginada con información clave de cada empresa incluyendo nombre, industria, ubicación, productos, fecha de fundación, inversión total, ingresos anuales y valoración. Core de la experiencia de usuario para exploración de datos.

- **Sistema de Filtros**: Controles de filtrado por industria y ubicación que permiten refinar la vista de empresas según criterios específicos. Mejora la usabilidad permitiendo análisis segmentado.

- **Paginación Frontend**: Control de visualización de 25 registros por página para mejorar la experiencia de usuario y rendimiento de renderizado.

# Experiencia de Usuario

## Perfiles de Usuario
- **Inversionista Principal**: Profesional que busca identificar oportunidades de inversión en el sector SaaS, requiere acceso rápido a métricas financieras y de valoración.
- **Analista de Mercado**: Especialista que necesita análisis comparativo entre empresas de diferentes industrias y ubicaciones geográficas.

## Flujos Clave de Usuario
1. **Exploración General**: Usuario accede al dashboard → visualiza listado completo de empresas → navega entre páginas para explorar todo el catálogo.
2. **Análisis Segmentado**: Usuario aplica filtros por industria/ubicación → revisa empresas filtradas → compara métricas dentro del segmento seleccionado.
3. **Búsqueda Específica**: Usuario combina múltiples filtros → identifica empresas que cumplen criterios específicos → analiza métricas de empresas resultantes.

## Consideraciones de UI/UX
- **Interfaz Minimalista**: Diseño enfocado en la información, sin elementos decorativos que distraigan del análisis de datos.
- **Tabla Responsiva**: Adaptación a diferentes tamaños de pantalla manteniendo legibilidad de datos críticos.
- **Filtros Intuitivos**: Controles de filtrado claramente visibles y fáciles de usar, con indicadores de filtros activos.
- **Navegación Clara**: Controles de paginación evidentes con información de página actual y total de registros.

# Arquitectura

## Componentes del Sistema

### Frontend (Blazor WebAssembly)
- **Componentes de UI**:
  - `CompanyList.razor`: Tabla principal con listado de empresas
  - `FilterPanel.razor`: Panel de controles de filtrado
  - `Pagination.razor`: Controles de navegación entre páginas
- **Servicios**:
  - `CompanyService`: Comunicación con API backend para datos de empresas
  - `FilterService`: Manejo de estado de filtros y parámetros de búsqueda

### Backend (ASP.NET Core Web API)
- **Controllers**:
  - `HealthController`: Endpoint de verificación de estado
  - `CompaniesController`: CRUD y filtrado de empresas
  - `IndustriesController`: Listado de industrias
  - `LocationsController`: Listado de ubicaciones
- **Services**:
  - `CompanyService`: Lógica de negocio para gestión de empresas
  - `FilterService`: Lógica para aplicación de filtros
- **Repositories**:
  - `CompanyRepository`: Acceso a datos de empresas con Entity Framework Core
  - `IndustryRepository`: Acceso a datos de industrias
  - `LocationRepository`: Acceso a datos de ubicaciones

## Modelos de Datos

### DTOs (Data Transfer Objects)
```csharp
public class CompanyDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Industry { get; set; }
    public string Location { get; set; }
    public string Products { get; set; }
    public int? FoundingYear { get; set; }
    public long? TotalFunding { get; set; }
    public long? AnnualRevenue { get; set; }
    public long? Valuation { get; set; }
}

public class IndustryDto
{
    public long Id { get; set; }
    public string Name { get; set; }
}

public class LocationDto
{
    public long Id { get; set; }
    public string DisplayName { get; set; } // Ciudad, País
}
```

### Entidades de Base de Datos
- **Company**: Información principal de empresas
- **Industry**: Catálogo de industrias
- **Location**: Información geográfica
- **Investor**: Catálogo de inversores
- **CompanyInvestor**: Relación muchos a muchos entre empresas e inversores

## APIs e Integraciones

### Endpoints REST
- `GET /api/health` - Health check del servicio
- `GET /api/companies?industry={id}&location={id}` - Listado de empresas con filtros opcionales
- `GET /api/industries` - Listado de industrias
- `GET /api/locations` - Listado de ubicaciones

### Integración con Base de Datos
- **Azure SQL Database** como almacén de datos principal
- **Entity Framework Core** como ORM
- **Connection String** configurada en appsettings con soporte para diferentes entornos

## Requisitos de Infraestructura
- **Azure SQL Database**: Base de datos ya provisioned con esquema creado
- **Hosting**: Preparado para despliegue en Azure App Service o contenedores
- **Frontend**: Distribución como archivos estáticos (Blazor WASM)
- **Backend**: API REST desplegable como aplicación web

# Plan de Desarrollo

## Desarrollo Backend
- Configuración inicial del proyecto ASP.NET Core Web API
- Implementación de Entity Framework Core con modelos de datos
- Configuración de conexión a Azure SQL Database existente
- Desarrollo de repositorios básicos (Company, Industry, Location)
- Implementación de servicios de lógica de negocio
- Desarrollo de controladores REST con endpoints definidos:
  - `GET /api/health` - Health check del servicio
  - `GET /api/companies?industry={id}&location={id}` - Listado con filtros
  - `GET /api/industries` - Listado de industrias
  - `GET /api/locations` - Listado de ubicaciones
- Configuración de CORS para integración con frontend
- Implementación de logging básico con ILogger

## Desarrollo Frontend
- Configuración inicial del proyecto Blazor WebAssembly
- Implementación de servicios HTTP para comunicación con API
- Desarrollo de componentes de UI:
  - `CompanyList.razor`: Tabla principal con listado de empresas
  - `FilterPanel.razor`: Panel de controles de filtrado
  - `Pagination.razor`: Controles de navegación entre páginas
- Integración de Bootstrap para estilos básicos
- Implementación de paginación del lado del cliente (25 registros por página)
- Sistema de filtrado funcional por industria y ubicación
- Manejo básico de estados de carga y errores

## Integración y Pruebas
- Testing unitario básico para servicios y controladores
- Pruebas de integración API-Base de datos
- Validación de comunicación Frontend-Backend

# Riesgos y Mitigaciones

## Desafíos Técnicos Identificados

### Riesgo: Problemas de conectividad con Azure SQL Database
**Mitigación**: Implementar retry policies en Entity Framework Core, connection pooling apropiado, y health checks específicos para base de datos.

### Riesgo: Inconsistencias de datos entre frontend y backend durante filtrado
**Mitigación**: Validación de parámetros en ambos extremos y manejo robusto de estados de error.

## Criterios de Aceptación para Entrega

### Funcionalidades Indispensables
1. **Backend API funcional** con todos los endpoints definidos
2. **Conectividad con base de datos** Azure SQL operativa  
3. **Frontend básico** con tabla de empresas y filtros
4. **Paginación del lado del cliente** funcionando correctamente
5. **Filtrado por industria y ubicación** completamente operativo

### Validación de Entrega
- Usuario puede ver listado completo de empresas paginado
- Filtros de industria y ubicación funcionan independiente y conjuntamente
- Todos los campos definidos se muestran correctamente en la tabla
- Health check responde correctamente
- Aplicación es accesible via navegador web sin errores de consola

# Apéndice

## Estructura de Archivos Requerida

### Backend (`src/backend/`)
```
Controllers/
├── HealthController.cs
├── CompaniesController.cs  
├── IndustriesController.cs
└── LocationsController.cs

Models/
├── Entities/
│   ├── Company.cs
│   ├── Industry.cs
│   ├── Location.cs
│   └── Investor.cs
└── DTOs/
    ├── CompanyDto.cs
    ├── IndustryDto.cs
    └── LocationDto.cs

Services/
├── Interfaces/
│   ├── ICompanyService.cs
│   ├── IIndustryService.cs
│   └── ILocationService.cs
└── Implementations/
    ├── CompanyService.cs
    ├── IndustryService.cs
    └── LocationService.cs

Data/
├── ApplicationDbContext.cs
└── Repositories/
    ├── Interfaces/
    └── Implementations/
```

### Frontend (`src/frontend/`)
```
Components/
├── CompanyList.razor
├── FilterPanel.razor
└── Pagination.razor

Services/
├── ICompanyService.cs
├── CompanyService.cs
├── IApiService.cs
└── ApiService.cs

Models/
├── CompanyDto.cs
├── FilterParameters.cs
└── PagedResult.cs

Pages/
└── Dashboard.razor
```

## Configuración Técnica Requerida

### Entity Framework Core
- Connection String: Azure SQL Database con SSL
- Migrations: Basadas en scripts SQL existentes
- Lazy Loading: Deshabilitado

### CORS Backend
- Origins: Dominio específico del frontend  
- Methods: GET, OPTIONS
- Headers: Content-Type

### Estándares de Código
- Naming Conventions: Pascal case públicos, camel case privados
- Async/Await: Obligatorio para operaciones I/O
- Logging: ILogger con niveles apropiados
- Exception Handling: Global middleware para errores