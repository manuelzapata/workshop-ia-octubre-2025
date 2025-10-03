# 3. Estrategia de Filtrado y Paginación

Fecha: Septiembre 28 de 2025

## Status

Aceptada.

## Contexto

El sistema debe manejar listados de empresas SaaS con capacidades de filtrado por industria y ubicación, además de paginación para mejorar la experiencia de usuario. Se requiere definir dónde se realizará el procesamiento de datos y cómo se optimizará la performance.

## Decisión

**Paginación del Lado Cliente:**
- Backend retorna dataset completo sin paginación de servidor
- Frontend implementa paginación con 25 registros por página
- Navegación fluida sin requests adicionales al cambiar página

**Estrategia de Filtrado:**
- Backend ofrece endpoints con parámetros de query opcionales
- Filtros aplicados a nivel de base de datos para eficiencia
- Frontend mantiene estado de filtros activos
- Combinación de filtros: industria + ubicación simultáneamente

## Consecuencias

**Positivas:**
- UX fluida: navegación entre páginas sin latencia
- Filtrado eficiente: procesado en base de datos
- Estado consistente: filtros mantenidos durante navegación
- Implementación simple: lógica de paginación en cliente

**Negativas:**
- Transferencia inicial mayor: dataset completo en primera carga
- Limitación de escalabilidad: no viable para datasets >10K registros
- Mayor uso de memoria en cliente
- Dependencia de conexión estable para carga inicial