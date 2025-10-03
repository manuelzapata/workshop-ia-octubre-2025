# 2. Arquitectura por Capas

Fecha: Septiembre 28 de 2025

## Status

Aceptada.

## Contexto

El proyecto requiere una arquitectura que permita mantenibilidad, testabilidad y separación clara de responsabilidades. Se necesita definir cómo organizar el código tanto en backend como frontend para facilitar el desarrollo colaborativo y futuras extensiones.

## Decisión

**Backend - Patrón por Capas:**
```
Controllers → Services → Repositories → Data/Entities
```

- **Controllers**: Manejo de HTTP, validación de entrada, respuestas
- **Services**: Lógica de negocio, orquestación, DTOs mapping  
- **Repositories**: Acceso a datos, consultas específicas
- **Data/Entities**: Modelos de dominio, DbContext

**Frontend - Arquitectura Componente-Servicio:**
```
Pages → Components → Services → Models
```

- **Pages**: Rutas principales, coordinación de componentes
- **Components**: UI reutilizable, lógica de presentación
- **Services**: Comunicación HTTP, estado compartido
- **Models**: DTOs, ViewModels, tipos de datos

## Consecuencias

**Positivas:**
- Separación clara de responsabilidades mejora mantenibilidad
- Inyección de dependencias facilita testing unitario
- Reutilización de componentes y servicios
- Escalabilidad horizontal por capa

**Negativas:**
- Mayor complejidad inicial para funcionalidades simples
- Posible over-engineering para casos triviales
- Curva de aprendizaje para patrones de arquitectura