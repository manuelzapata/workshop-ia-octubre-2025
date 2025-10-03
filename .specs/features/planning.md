# Descripción General  

El proyecto consiste en el desarrollo de un **dashboard de análisis de empresas SaaS** orientado a inversionistas que buscan evaluar y comparar las métricas de las 100 empresas SaaS más importantes del mundo. La aplicación permitirá visualizar información clave como valoración, ingresos anuales, total de inversión, ubicación geográfica e industria de cada empresa.

El dashboard resuelve la necesidad de los inversionistas de tener acceso centralizado y estructurado a datos de empresas SaaS para tomar decisiones informadas de inversión. Los datos provienen de un dataset curado de Kaggle que contiene información verificada de las principales empresas del ecosistema SaaS global.

La aplicación está dirigida a:
- **Inversionistas** que buscan oportunidades en el sector SaaS
- **Analistas financieros** que necesitan comparar métricas empresariales
- **Consultores** que requieren datos del mercado SaaS para reportes

El valor principal radica en proporcionar una vista unificada y filtrable de datos empresariales que tradicionalmente están dispersos en múltiples fuentes.

# Funcionalidades Principales  

## Backend (ASP.NET Core Web API)

### 1. Endpoint de Health Check
- **Qué hace**: Verifica el estado del servicio y la conectividad con la base de datos
- **Por qué es importante**: Permite monitoreo automatizado y verificación de disponibilidad
- **Cómo funciona**: Endpoint GET `/health` que retorna estado HTTP 200 si el servicio está operativo

### 2. Endpoint de Listado de Empresas
- **Qué hace**: Retorna la lista completa de empresas SaaS con todas sus métricas
- **Por qué es importante**: Es la funcionalidad core que alimenta el dashboard principal
- **Cómo funciona**: Endpoint GET `/api/companies` que retorna todas las empresas sin filtrado backend, incluyendo datos relacionados de industria y ubicación

### 3. Endpoint de Industrias
- **Qué hace**: Retorna la lista de todas las industrias disponibles
- **Por qué es importante**: Alimenta el dropdown de filtrado por industria en el frontend
- **Cómo funciona**: Endpoint GET `/api/industries` que retorna lista única de industrias ordenada alfabéticamente

### 4. Endpoint de Ubicaciones
- **Qué hace**: Retorna la lista de todas las ubicaciones disponibles
- **Por qué es importante**: Alimenta el dropdown de filtrado por ubicación en el frontend
- **Cómo funciona**: Endpoint GET `/api/locations` que retorna lista única de ubicaciones (ciudad, país) ordenada alfabéticamente

## Frontend (Blazor WebAssembly)

### 1. Dashboard Principal con Listado de Empresas
- **Qué hace**: Muestra una tabla paginada con las empresas y sus métricas clave
- **Por qué es importante**: Es la interfaz principal donde los usuarios consumen la información
- **Cómo funciona**: 
  - Tabla responsiva con columnas: Nombre, Industria, Ubicación, Productos, Año Fundación, Total Inversión, ARR, Valoración
  - Paginación cliente-side de 25 registros por página
  - Sin funcionalidades de ordenamiento

### 2. Sistema de Filtros
- **Qué hace**: Permite filtrar las empresas por industria y ubicación usando dropdowns
- **Por qué es importante**: Facilita la búsqueda específica según criterios de interés del inversionista
- **Cómo funciona**: 
  - Dropdown de industrias con opción "Todas las industrias"
  - Dropdown de ubicaciones con opción "Todas las ubicaciones"
  - Filtrado en tiempo real aplicado en el cliente
  - Reseteo de filtros disponible

# Experiencia de Usuario  

## Perfiles de Usuario

### Inversionista Principal
- **Características**: Busca oportunidades de inversión en empresas SaaS establecidas
- **Necesidades**: Comparar valoraciones, analizar industrias prometedoras, identificar geografías estratégicas
- **Comportamiento**: Revisa múltiples empresas por sesión, filtra por criterios específicos

### Analista Financiero
- **Características**: Realiza análisis comparativo para reportes e investigación
- **Necesidades**: Acceso rápido a métricas financieras, capacidad de filtrado eficiente
- **Comportamiento**: Sesiones de trabajo extendidas, uso intensivo de filtros

## Flujos Clave de Usuario

### Flujo Principal - Exploración de Empresas
1. **Acceso**: Usuario ingresa a la aplicación (sin autenticación requerida)
2. **Vista inicial**: Carga automática del listado completo (primeras 25 empresas)
3. **Exploración**: Navegación por páginas para revisar todas las empresas
4. **Filtrado** (opcional): Selección de industria y/o ubicación específica
5. **Análisis**: Revisión detallada de métricas de empresas de interés

### Flujo Secundario - Búsqueda Dirigida
1. **Filtrado inmediato**: Usuario aplica filtros específicos desde el inicio
2. **Revisión**: Análisis de resultados filtrados
3. **Refinamiento**: Ajuste de filtros según necesidades
4. **Navegación**: Exploración de páginas dentro del conjunto filtrado

## Consideraciones de UI/UX

- **Diseño responsivo**: Compatible con desktop, tablet y móvil
- **Carga progresiva**: Indicadores de carga durante operaciones asíncronas
- **Feedback visual**: Estados claros de filtros activos y resultados encontrados
- **Usabilidad**: Interfaz intuitiva que no requiere entrenamiento
- **Performance**: Tiempos de respuesta menores a 2 segundos
- **Accesibilidad**: Cumplimiento de estándares WCAG básicos

# Arquitectura  

## Componentes del Sistema

### Frontend (Blazor WebAssembly)
- **Componentes Razor**: 
  - `CompanyList.razor`: Componente principal con tabla y paginación
  - `FilterPanel.razor`: Panel de filtros con dropdowns
  - `CompanyCard.razor`: Tarjeta individual de empresa (opcional para vista detalle)
- **Servicios**:
  - `ICompanyService`: Interfaz para comunicación con API
  - `CompanyService`: Implementación con HttpClient
- **Modelos**:
  - `CompanyDto`: Modelo de datos de empresa
  - `IndustryDto`: Modelo de industria
  - `LocationDto`: Modelo de ubicación

### Backend (ASP.NET Core Web API)
- **Controladores**:
  - `CompaniesController`: CRUD y endpoints de empresas
  - `IndustriesController`: Gestión de industrias
  - `LocationsController`: Gestión de ubicaciones
  - `HealthController`: Health checks
- **Servicios**:
  - `ICompanyService`: Lógica de negocio de empresas
  - `IIndustryService`: Lógica de negocio de industrias
  - `ILocationService`: Lógica de negocio de ubicaciones
- **Repositorios**:
  - `ICompanyRepository`: Acceso a datos de empresas
  - `IIndustryRepository`: Acceso a datos de industrias
  - `ILocationRepository`: Acceso a datos de ubicaciones

## Modelos de Datos

### Entidades de Base de Datos
```sql
-- company: Tabla principal con métricas empresariales
-- industry: Catálogo normalizado de industrias
-- location: Catálogo normalizado de ubicaciones
-- investor: Catálogo de inversores
-- company_investor: Relación muchos a muchos
```

### DTOs (Data Transfer Objects)
```csharp
public class CompanyDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Products { get; set; }
    public int? FoundingYear { get; set; }
    public long? TotalFunding { get; set; }
    public long? Arr { get; set; }
    public long? Valuation { get; set; }
    public int? Employees { get; set; }
    public decimal? G2Rating { get; set; }
    public string Industry { get; set; }
    public string Location { get; set; }
}

public class IndustryDto
{
    public long Id { get; set; }
    public string Name { get; set; }
}

public class LocationDto
{
    public long Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string DisplayName => $"{City}, {Country}";
}
```

## APIs e Integraciones

### Endpoints REST
- `GET /health` - Health check
- `GET /api/companies` - Lista completa de empresas
- `GET /api/industries` - Lista de industrias
- `GET /api/locations` - Lista de ubicaciones

### Comunicación Frontend-Backend
- **HttpClient** configurado con base URL del API
- **Serialización JSON** para transferencia de datos
- **Manejo de errores** con try-catch y mensajes user-friendly
- **Loading states** durante llamadas asíncronas

## Requisitos de Infraestructura

### Desarrollo
- **.NET 8 SDK** para backend y frontend
- **Azure SQL Database** para almacenamiento
- **Visual Studio Code** o **Visual Studio 2022**
- **Git** para control de versiones

### Producción (Futuro)
- **Azure App Service** para hosting del backend
- **Azure Static Web Apps** para hosting del frontend
- **Azure SQL Database** para datos
- **Azure Application Insights** para monitoreo

# Hoja de Ruta de Desarrollo  

## Fase 1: Base de Datos y Backend Core (Fundación)

### Alcance
Establecer la infraestructura básica de datos y API funcional.

### Entregables Específicos
1. **Configuración de Azure SQL Database**
   - Ejecución de scripts de creación de tablas
   - Carga inicial de datos desde dataset CSV
   - Configuración de connection strings

2. **Backend API Básico**
   - Configuración del proyecto ASP.NET Core Web API
   - Entity Framework Core con modelos de datos
   - Implementación de repositorios con patrón Repository
   - Health check endpoint funcional

3. **Endpoints de Datos**
   - `GET /api/companies` retornando lista completa
   - `GET /api/industries` retornando catálogo de industrias
   - `GET /api/locations` retornando catálogo de ubicaciones
   - Configuración de CORS para desarrollo

4. **Testing Básico**
   - Pruebas unitarias para servicios
   - Pruebas de integración para endpoints
   - Validación de conexión a base de datos

## Fase 2: Frontend Base y Comunicación (Interfaz)

### Alcance
Desarrollo del frontend básico con comunicación al backend.

### Entregables Específicos
1. **Configuración Frontend**
   - Proyecto Blazor WebAssembly configurado
   - HttpClient configurado para comunicación con API
   - Modelos DTO en frontend

2. **Servicios de Comunicación**
   - `CompanyService` para llamadas al API de empresas
   - `IndustryService` para llamadas al API de industrias
   - `LocationService` para llamadas al API de ubicaciones
   - Manejo de errores y loading states

3. **Componentes Base**
   - Layout principal de la aplicación
   - Página principal del dashboard
   - Componente básico de lista de empresas
   - Estados de carga y error

4. **Testing Frontend**
   - Pruebas unitarias para servicios
   - Pruebas de componentes con bUnit
   - Validación de comunicación con API

## Fase 3: Funcionalidades del Dashboard (Experiencia Completa)

### Alcance
Implementación completa de funcionalidades de filtrado y paginación.

### Entregables Específicos
1. **Sistema de Filtros**
   - Componente `FilterPanel` con dropdowns de industria y ubicación
   - Lógica de filtrado en tiempo real
   - Opción de resetear filtros
   - Indicadores visuales de filtros activos

2. **Paginación y Navegación**
   - Paginación de 25 registros por página
   - Controles de navegación (anterior, siguiente, números de página)
   - Información de total de registros y página actual
   - Preservación de filtros durante navegación

3. **Tabla de Empresas Completa**
   - Todas las columnas de datos empresariales
   - Formato adecuado para valores monetarios
   - Responsive design para diferentes tamaños de pantalla
   - Loading states durante filtrado

4. **Polish y UX**
   - Estilos CSS consistentes
   - Mensajes informativos (sin resultados, errores)
   - Optimización de performance
   - Validación completa de funcionalidades

## Fase 4: Testing y Documentación (Calidad)

### Alcance
Asegurar calidad del código y documentar la solución.

### Entregables Específicos
1. **Testing Comprehensivo**
   - Cobertura de pruebas > 80%
   - Pruebas de integración end-to-end
   - Pruebas de performance básicas
   - Validación en diferentes navegadores

2. **Documentación**
   - README.md con instrucciones de setup
   - Documentación de API (Swagger)
   - Guía de deployment
   - Documentación de arquitectura

3. **Optimización**
   - Optimización de queries de base de datos
   - Minimización de bundle size del frontend
   - Configuración de caché donde aplicable
   - Validación de métricas de performance

4. **Preparación para Producción**
   - Configuración de environments (dev, prod)
   - Scripts de deployment
   - Configuración de logging
   - Health checks completos

# Riesgos y Mitigaciones  

## Desafíos Técnicos

### 1. Performance con Dataset Completo
**Riesgo**: El frontend podría volverse lento al cargar y filtrar 100+ empresas simultáneamente.
**Mitigación**: 
- Implementar paginación eficiente en el cliente
- Considerar debouncing para filtros en tiempo real
- Monitorear métricas de performance y optimizar según necesidad

### 2. Complejidad de la Base de Datos Normalizada
**Riesgo**: Queries complejos con múltiples JOINs podrían impactar performance.
**Mitigación**:
- Usar Entity Framework Core con Include() optimizado
- Implementar proyecciones directas a DTOs
- Considerar índices en columnas de filtrado frecuente

### 3. Configuración de Azure SQL
**Riesgo**: Problemas de conectividad o configuración de base de datos en Azure.
**Mitigación**:
- Documentar paso a paso la configuración de Azure SQL
- Implementar connection strings configurables por environment
- Tener scripts de rollback para cambios de esquema

## Definir la Versión Inicial sobre la que se Puede Construir

### MVP (Producto Mínimo Viable)
La versión inicial debe incluir **obligatoriamente**:
1. **Listado básico funcional**: Tabla que muestre las empresas con datos básicos (nombre, industria, ubicación, valoración)
2. **Un filtro funcional**: Mínimo el filtro por industria completamente operativo
3. **Navegación básica**: Paginación simple (anterior/siguiente)
4. **API estable**: Endpoints de companies e industries funcionando correctamente

### Criterios de "Listo para Usar"
- Usuario puede ver empresas SaaS en formato tabular
- Usuario puede filtrar por al menos una dimensión (industria)
- Usuario puede navegar entre páginas de resultados
- Aplicación carga en menos de 5 segundos
- No hay errores críticos en consola del navegador

### Base para Iteraciones Futuras
Una vez establecido el MVP, se puede iterar agregando:
- Filtro por ubicación
- Más columnas de datos
- Mejoras visuales
- Optimizaciones de performance
- Funcionalidades adicionales (exportar, métricas agregadas)

## Limitaciones de Recursos

### 1. Datos Estáticos
**Limitación**: Los datos provienen de un CSV estático, no se actualizan automáticamente.
**Impacto**: La información puede volverse obsoleta con el tiempo.
**Plan a Futuro**: Considerar integración con APIs de fuentes de datos financieras.

### 2. Sin Autenticación
**Limitación**: La aplicación es completamente pública sin control de acceso.
**Impacto**: No hay personalización ni segmentación de usuarios.
**Plan a Futuro**: Implementar Azure AD B2C para diferentes tipos de usuarios.

### 3. Capacidad de Escalamiento
**Limitación**: La arquitectura actual está optimizada para el dataset específico (100 empresas).
**Impacto**: Podría requerir refactoring significativo para datasets mucho más grandes.
**Plan a Futuro**: Implementar paginación server-side y indexación avanzada.

# Apéndice  

## Hallazgos de Investigación

### Análisis del Dataset
- **100 empresas SaaS** con datos completos de métricas financieras
- **Industrias identificadas**: ~15 categorías principales (Enterprise Software, CRM, Creative Software, etc.)
- **Geografías**: Concentración en Estados Unidos, con presencia en Europa y Asia
- **Rangos de valoración**: Desde millones hasta billones de dólares
- **Datos faltantes**: Algunos campos como funding total tienen valores N/A que requieren manejo especial

### Consideraciones de Datos
- **Formato monetario**: Valores en diferentes escalas (M para millones, B para billones)
- **Normalización requerida**: Industrias y ubicaciones necesitan normalización para filtros eficientes
- **Calidad de datos**: Dataset de alta calidad con pocas inconsistencias

## Especificaciones Técnicas

### Stack Tecnológico Detallado
- **.NET 8**: Framework base para backend y frontend
- **ASP.NET Core 8**: Web API con minimal APIs donde aplicable
- **Blazor WebAssembly**: Frontend SPA con C#
- **Entity Framework Core 8**: ORM para acceso a datos
- **Azure SQL Database**: Base de datos relacional en la nube
- **Bootstrap 5**: Framework CSS para UI responsiva

### Configuración de Desarrollo
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:{server}.database.windows.net,1433;Initial Catalog={database};Persist Security Info=False;User ID={username};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
  "ApiSettings": {
    "BaseUrl": "https://localhost:7001/api",
    "Timeout": 30000
  }
}
```

### Estructura de Carpetas Recomendada
```
src/
├── backend/
│   ├── Controllers/
│   ├── Services/
│   ├── Repositories/
│   ├── Models/
│   │   ├── Entities/
│   │   └── DTOs/
│   ├── Data/
│   └── Configuration/
└── frontend/
    ├── Components/
    ├── Services/
    ├── Models/
    ├── Pages/
    └── Shared/
```

### Métricas de Éxito
- **Performance**: Tiempo de carga inicial < 3 segundos
- **Usabilidad**: Filtrado de resultados < 1 segundo
- **Confiabilidad**: Uptime > 99% (para versión de producción)
- **Cobertura de pruebas**: > 80% de code coverage
- **Compatibilidad**: Funcionamiento en Chrome, Firefox, Safari, Edge