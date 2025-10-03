---
mode: agent
---

Utilizando esta plantilla [planning_template_es.md(../../.specs/templates/planning_template_es.md)] ayúdame a generar el [planning.md(../../.specs/features/planning.md)] para este proyecto usando la siguiente información:

# Descripción general

Quiero crear una aplicación con frontend, backend y base de datos. En el frontend, desplegaremos un dashboard con métricas provenientes del backend. Este se comunicará con una base de datos normalizada, alimentada por un dataset de Kaggle @https://www.kaggle.com/datasets/shreyasdasari7/top-100-saas-companiesstartups.

El dashboard está enfocado a inversionistas que quiere analizar las métricas de las empresas SaaS más importantes del mundo.

## Funcionalidades principales

Para la primera versión, las funcionalidades principales son:

Backend:
- Endpoint de healthcheck para verificar el estado del servicio.
- Endpoint para obtener el listado de empresas con filtros de búsqueda por industria y ubicación.
- Endpoint para obtener las industrias que será usado por el filtro.
- Endpoint para obtener las ubicaciones que será usado por el filtro.

Frontend:
- Listado de empresas y sus métricas. Los campos a mostrar son:
  - Nombre empresa.
  - Industria.
  - Ubicación.
  - Productos.
  - Fecha de fundación.
  - Total inversión.
  - Ingresos anuales.
  - Valoración de la empresa.
- El listado incluirá filtros de búsqueda por industria y ubicación.

## Atributos de calidad

- Factibilidad. Necesitamos una arquitectura que sea factible de implementar en un tiempo razonable.
- Mantenibilidad. La arquitectura debe ser fácil de modificar y ampliar.

## Patrón de arquitectura

Patrón de arquitectura por capas tanto en backend como en frontend.

## Stack tecnológico

- Blazor Web Assembly en el frontend.
- ASP.NET Core Web API en el backend.
- SQLServer a través de Azure para el almacenamiento de datos.

La estructura base de los proyectos ya se encuentra creada:
- Frontend: `src/frontend`
- Backend: `src/backend`

La base de datos ya se encuentra en Azure SQL y el script de creación de tablas está en `scripts/database/01-top-saas-db-creation.sql`.

# Objetivo

Necesito tu ayuda para definir el plan de desarrollo completo.

Ayúdame a entender el problema y hazme las 3 preguntas más relevantes que se requieran para completar la información en la plantilla. Para cada pregunta, dame una sugerencia de respuesta.
