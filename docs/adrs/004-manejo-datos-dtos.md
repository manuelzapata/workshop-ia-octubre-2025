# 4. Manejo de Datos y DTOs

Fecha: Septiembre 28 de 2025

## Status

Aceptada.

## Contexto

El sistema requiere transferencia eficiente de datos entre frontend y backend, manteniendo separación entre modelos de dominio y representaciones de datos. Se debe definir estrategia de mapeo, serialización y contratos de comunicación.

## Decisión

**Uso de DTOs (Data Transfer Objects):**
- Separación completa entre entidades de base de datos y DTOs
- DTOs específicos para comunicación frontend-backend
- Mapeo explícito entre entidades y DTOs en servicios

**Estrategia de Mapeo:**
- Mapeo manual en servicios para control total
- Extension methods para conversiones repetitivas
- Validación en DTOs usando Data Annotations

**Serialización JSON:**
- System.Text.Json como serializador por defecto
- Convención camelCase para propiedades JSON
- Configuración de opciones de serialización centralizadas

## Consecuencias

**Positivas:**
- Contratos de API estables independientes de cambios internos
- Exposición controlada de datos sensibles
- Versionado de API facilitado por DTOs
- Validación centralizada en boundaries

**Negativas:**
- Código adicional para mapeo entre entidades y DTOs
- Mantenimiento de sincronización entre modelos
- Duplicación aparente de estructura de datos
- Overhead mínimo en conversiones