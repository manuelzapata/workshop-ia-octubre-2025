# Lista de Tareas del Proyecto

Este documento desglosa el trabajo definido en `planning.md` en tareas accionables para el desarrollo del SaaS Analytics Dashboard.

## Fase 1: Diseño y Arquitectura

### Architectural Decision Records (ADRs)
- [x] **ADR 1: Elección de Stack Tecnológico**
    - [x] Documentar decisión de usar Blazor WebAssembly para frontend
    - [x] Documentar decisión de usar ASP.NET Core Web API para backend
    - [x] Documentar decisión de usar Azure SQL Database para almacenamiento
    - [x] Justificar beneficios y consecuencias de cada tecnología
- [x] **ADR 2: Arquitectura por Capas**
    - [x] Documentar patrón de arquitectura por capas para backend
    - [x] Documentar separación de responsabilidades (Controllers → Services → Repositories)
    - [x] Documentar estructura de componentes para frontend Blazor
    - [x] Definir consecuencias en mantenibilidad y testabilidad
- [x] **ADR 3: Estrategia de Filtrado y Paginación**
    - [x] Documentar decisión de paginación del lado del cliente (25 registros por página)
    - [x] Documentar que backend devuelve listado completo sin paginación del servidor
    - [x] Justificar estrategia de filtrado por industria y ubicación
    - [x] Definir consecuencias en performance y experiencia de usuario
- [x] **ADR 4: Manejo de Datos y DTOs**
    - [x] Documentar uso de DTOs para comunicación frontend-backend
    - [x] Documentar mapeo entre entidades de base de datos y DTOs
    - [x] Definir estrategia de serialización JSON
    - [x] Justificar separación entre modelos de dominio y transferencia

### Diagramas de Arquitectura C4
- [x] **Diagrama de Contexto C4**
    - [x] Crear diagrama usando Mermaid mostrando Usuario (Inversionista)
    - [x] Mostrar relación con SaaS Analytics Dashboard como sistema principal
    - [x] Incluir Azure SQL Database como sistema externo
    - [x] Documentar propósito y audiencia del sistema
- [x] **Diagrama de Contenedores C4**
    - [x] Crear diagrama usando Mermaid con Frontend (Blazor WASM)
    - [x] Incluir Backend (ASP.NET Core Web API) como contenedor
    - [x] Mostrar Base de Datos (Azure SQL) como almacén de datos
    - [x] Documentar tecnologías y responsabilidades de cada contenedor
    - [x] Incluir protocolos de comunicación (HTTPS/REST, SQL)

### Diseño de Base de Datos
- [x] **Documentación del Modelo de Datos**
    - [x] Revisar script `01-top-saas-db-creation.sql` existente
    - [x] Crear diagrama ER usando Mermaid basado en el script
    - [x] Documentar tablas principales: company, industry, location, investor
    - [x] Documentar relaciones: company_investor (muchos a muchos)
    - [x] Documentar tipos de datos y restricciones de cada campo
- [x] **Análisis de Integridad Referencial**
    - [x] Verificar foreign keys entre company → industry
    - [x] Verificar foreign keys entre company → location  
    - [x] Documentar cascadas en tabla company_investor
    - [x] Validar campos obligatorios y opcionales en cada tabla

## Fase 2: Desarrollo Backend

### Configuración Inicial y Estructura
- [x] **Configurar proyecto ASP.NET Core Web API**
    - [x] Configurar Entity Framework Core con Azure SQL Database
    - [x] Configurar connection string en appsettings.json y appsettings.Development.json
    - [x] Configurar logging con ILogger
    - [x] Configurar CORS para comunicación con frontend Blazor
- [x] **Crear estructura de carpetas del proyecto**
    - [x] Crear carpeta Controllers/ con controladores base
    - [x] Crear carpeta Models/ con subcarpetas Entities/ y DTOs/
    - [x] Crear carpeta Services/ con subcarpetas Interfaces/ e Implementations/
    - [x] Crear carpeta Data/ con ApplicationDbContext y Repositories/

### Modelos y Entidades
- [x] **Crear entidades de base de datos**
    - [x] Crear entidad Company con todas las propiedades del script SQL
    - [x] Crear entidad Industry con campos id y name
    - [x] Crear entidad Location con campos city, state, country
    - [x] Crear entidad Investor con campo name
    - [x] Configurar relaciones en ApplicationDbContext
- [x] **Crear DTOs para transferencia de datos**
    - [x] Crear CompanyDto con campos para mostrar en frontend
    - [x] Crear IndustryDto con id y name
    - [x] Crear LocationDto con DisplayName (Ciudad, País)
    - [x] Crear FilterParametersDto para parámetros de filtrado

### Acceso a Datos y Repositorios
- [x] **Implementar repositorios**
    - [x] Crear ICompanyRepository e implementación con Entity Framework
    - [x] Crear IIndustryRepository e implementación
    - [x] Crear ILocationRepository e implementación
    - [x] Implementar métodos de filtrado en CompanyRepository

### Servicios de Lógica de Negocio
- [x] **Crear interfaces de servicios**
    - [x] Crear ICompanyService con métodos GetAllAsync y GetFilteredAsync
    - [x] Crear IIndustryService con método GetAllAsync
    - [x] Crear ILocationService con método GetAllAsync
- [x] **Implementar servicios de negocio**
    - [x] Implementar CompanyService con lógica de filtrado y mapeo a DTOs
    - [x] Implementar IndustryService con mapeo a DTOs
    - [x] Implementar LocationService con formato DisplayName
    - [x] Configurar inyección de dependencias en Program.cs

### Controladores y Endpoints
- [x] **Crear HealthController**
    - [x] Implementar endpoint GET /api/health
    - [x] Retornar información básica del estado del servicio
    - [x] Incluir verificación de conectividad con base de datos
- [x] **Crear CompaniesController**
    - [x] Implementar endpoint GET /api/companies con filtros opcionales
    - [x] Configurar parámetros de query industry y location
    - [x] Implementar manejo de errores y validaciones
    - [x] Configurar respuestas HTTP apropiadas
- [x] **Crear IndustriesController**
    - [x] Implementar endpoint GET /api/industries
    - [x] Retornar listado completo de industrias únicas
- [x] **Crear LocationsController**
    - [x] Implementar endpoint GET /api/locations
    - [x] Retornar listado de ubicaciones con formato DisplayName

## Fase 3: Desarrollo Frontend

### Configuración Inicial Blazor WebAssembly
- [ ] **Configurar proyecto Blazor WASM**
    - [ ] Configurar HttpClient para comunicación con backend API
    - [ ] Configurar base URL del backend en appsettings
    - [ ] Integrar Bootstrap para estilos básicos
    - [ ] Configurar routing básico en App.razor
- [ ] **Crear modelos para frontend**
    - [ ] Crear CompanyDto idéntico al backend
    - [ ] Crear FilterParameters para manejo de filtros
    - [ ] Crear PagedResult<T> para paginación del cliente

### Servicios de Comunicación con API
- [ ] **Crear servicios HTTP**
    - [ ] Crear IApiService con métodos HTTP base
    - [ ] Implementar ApiService con manejo de errores HTTP
    - [ ] Crear ICompanyService para operaciones específicas de empresas
    - [ ] Implementar CompanyService con llamadas a endpoints del backend

### Componentes de UI
- [ ] **Crear componente FilterPanel.razor**
    - [ ] Implementar dropdown para selección de industria
    - [ ] Implementar dropdown para selección de ubicación  
    - [ ] Configurar eventos OnChange para aplicar filtros
    - [ ] Mostrar indicadores de filtros activos
- [ ] **Crear componente CompanyList.razor**
    - [ ] Crear tabla HTML con todas las columnas requeridas
    - [ ] Implementar binding de datos desde CompanyDto
    - [ ] Aplicar estilos Bootstrap para tabla responsiva
    - [ ] Mostrar estados de carga y mensajes de error
- [ ] **Crear componente Pagination.razor**
    - [ ] Implementar controles Previous/Next
    - [ ] Mostrar número de página actual y total
    - [ ] Configurar navegación con 25 registros por página
    - [ ] Manejar eventos de cambio de página

### Página Principal Dashboard
- [ ] **Crear Dashboard.razor**
    - [ ] Integrar FilterPanel en la parte superior
    - [ ] Integrar CompanyList para mostrar datos
    - [ ] Integrar Pagination en la parte inferior
    - [ ] Implementar comunicación entre componentes
    - [ ] Manejar estado global de filtros y paginación

## Fase 4: Integración y Pruebas

### Pruebas Unitarias Backend
- [ ] **Configurar framework de pruebas**
    - [x] Configurar proyecto de pruebas xUnit
    - [ ] Configurar mocks para repositorios y HttpClient
    - [ ] Configurar base de datos en memoria para pruebas
- [ ] **Pruebas de servicios de lógica de negocio**
    - [ ] Crear CompanyServiceTests con escenarios de filtrado
    - [ ] Crear IndustryServiceTests para obtener listado
    - [ ] Crear LocationServiceTests para obtener listado
    - [ ] Implementar pruebas de casos límite y manejo de errores

### Validación de Integración
- [ ] **Pruebas de comunicación Frontend-Backend**
    - [ ] Validar que todos los endpoints respondan correctamente
    - [ ] Verificar formato de respuestas JSON
    - [ ] Probar filtros combinados (industria + ubicación)
    - [ ] Verificar funcionamiento de CORS
- [ ] **Pruebas de conectividad con base de datos**
    - [ ] Verificar conexión a Azure SQL Database
    - [ ] Probar consultas con filtros en base real
    - [ ] Validar mapeo entre entidades y DTOs

### Documentación de Implementación
- [ ] **Documentar diagramas de arquitectura**
    - [ ] Crear archivo README.md con diagramas C4 generados
    - [ ] Documentar decisiones tomadas durante implementación
    - [ ] Incluir instrucciones de configuración y despliegue
- [ ] **Documentar modelo de base de datos**
    - [ ] Crear documentación del diagrama ER generado
    - [ ] Documentar queries principales y optimizaciones
    - [ ] Incluir ejemplos de uso de filtros y consultas

## Fase 5: Validación Final

### Criterios de Aceptación
- [ ] **Validar funcionalidad completa del sistema**
    - [ ] Usuario puede acceder al dashboard sin errores
    - [ ] Listado de empresas se muestra correctamente paginado
    - [ ] Filtros de industria y ubicación funcionan independiente y conjuntamente  
    - [ ] Health check responde correctamente
    - [ ] Todos los campos definidos se muestran en la tabla
- [ ] **Validar experiencia de usuario**
    - [ ] Navegación entre páginas es fluida
    - [ ] Estados de carga se muestran apropiadamente
    - [ ] Mensajes de error son informativos
    - [ ] Interfaz es responsiva en diferentes dispositivos

### Preparación para Entrega
- [ ] **Documentación final del proyecto**
    - [ ] Actualizar README.md con instrucciones completas
    - [ ] Documentar configuración de variables de entorno
    - [ ] Incluir guía de instalación y ejecución local
- [ ] **Validación de código y estándares**
    - [ ] Ejecutar dotnet format en backend
    - [ ] Verificar que todas las pruebas pasen (dotnet test)
    - [ ] Revisar que no existen errores de compilación
    - [ ] Validar que aplicación funciona end-to-end

---

## Notas de Implementación

### Dependencias del Proyecto
- **Backend**: ASP.NET Core 8.0, Entity Framework Core, Azure SQL Database
- **Frontend**: Blazor WebAssembly, Bootstrap, HttpClient
- **Pruebas**: xUnit, Moq, Entity Framework In-Memory

### Estándares de Código
- Usar async/await para todas las operaciones I/O
- Implementar manejo global de excepciones en backend
- Usar PascalCase para públicos, camelCase para privados
- Incluir logging apropiado con ILogger en todos los servicios