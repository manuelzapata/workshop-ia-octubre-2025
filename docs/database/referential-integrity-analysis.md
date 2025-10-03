# Análisis de Integridad Referencial - SaaS Analytics Dashboard

## Resumen de Relaciones

El modelo de datos implementa un esquema relacional con integridad referencial estricta mediante foreign keys y restricciones de cascada apropiadas.

## Foreign Keys Implementadas

### 1. company → industry (company.industry_id → industry.id)

**Definición SQL:**
```sql
industry_id BIGINT REFERENCES industry(id)
```

**Características:**
- **Tipo de Relación:** Muchos a Uno (N:1)
- **Comportamiento ON DELETE:** RESTRICT (por defecto)
- **Comportamiento ON UPDATE:** RESTRICT (por defecto)
- **Cardinalidad:** Una empresa pertenece a exactamente una industria
- **Opcionalidad:** Permite NULL (empresa puede no tener industria asignada)

**Validación:**
- ✅ FK correctamente definida
- ✅ Permite clasificación de empresas por sector
- ✅ Integridad garantizada: no se puede eliminar una industria con empresas asociadas
- ⚠️ Consideración: Al eliminar una industria, todas las empresas asociadas mantendrán la referencia (puede causar error)

### 2. company → location (company.location_id → location.id)

**Definición SQL:**
```sql
location_id BIGINT REFERENCES location(id)
```

**Características:**
- **Tipo de Relación:** Muchos a Uno (N:1)
- **Comportamiento ON DELETE:** RESTRICT (por defecto)
- **Comportamiento ON UPDATE:** RESTRICT (por defecto)
- **Cardinalidad:** Una empresa está ubicada en exactamente una location
- **Opcionalidad:** Permite NULL (empresa puede no tener ubicación asignada)

**Validación:**
- ✅ FK correctamente definida
- ✅ Permite filtrado geográfico de empresas
- ✅ Integridad garantizada: no se puede eliminar una ubicación con empresas asociadas
- ⚠️ Consideración: Mismo comportamiento que industry - restricción por defecto

## Relaciones de Cascada

### 3. company_investor → company (company_investor.company_id → company.id)

**Definición SQL:**
```sql
company_id BIGINT REFERENCES company(id) ON DELETE CASCADE
```

**Características:**
- **Tipo de Relación:** Uno a Muchos (1:N) desde company
- **Comportamiento ON DELETE:** CASCADE
- **Comportamiento ON UPDATE:** RESTRICT (por defecto)
- **Efecto:** Al eliminar una empresa, se eliminan automáticamente todas sus relaciones con inversores

**Validación:**
- ✅ CASCADE correctamente implementado
- ✅ Mantiene integridad: no quedan registros huérfanos en company_investor
- ✅ Comportamiento esperado para tabla de unión

### 4. company_investor → investor (company_investor.investor_id → investor.id)

**Definición SQL:**
```sql
investor_id BIGINT REFERENCES investor(id) ON DELETE CASCADE
```

**Características:**
- **Tipo de Relación:** Uno a Muchos (1:N) desde investor
- **Comportamiento ON DELETE:** CASCADE
- **Comportamiento ON UPDATE:** RESTRICT (por defecto)
- **Efecto:** Al eliminar un inversor, se eliminan automáticamente todas sus relaciones con empresas

**Validación:**
- ✅ CASCADE correctamente implementado
- ✅ Mantiene integridad: no quedan registros huérfanos en company_investor
- ✅ Comportamiento esperado para tabla de unión

## Campos Obligatorios vs Opcionales

### Campos Obligatorios (NOT NULL)

| Tabla | Campo | Justificación |
|-------|-------|---------------|
| location | city | Esencial para identificación geográfica |
| location | country | Esencial para identificación geográfica |
| industry | name | Identificador único de la industria |
| investor | name | Identificador único del inversor |
| company | name | Identificador esencial de la empresa |
| Todas las tablas | created_at | Auditoria obligatoria |
| Todas las tablas | updated_at | Auditoria obligatoria |

### Campos Opcionales (NULLABLE)

| Tabla | Campo | Justificación |
|-------|-------|---------------|
| location | state | No todos los países tienen estados/provincias |
| company | products | Información descriptiva opcional |
| company | founding_year | Puede no estar disponible |
| company | total_funding | No todas las empresas han recibido funding |
| company | arr | Métrica opcional, puede no ser pública |
| company | valuation | Información privada, no siempre disponible |
| company | employees | Dato que puede no ser público |
| company | g2_rating | No todas las empresas están en G2 |
| company | industry_id | Empresa puede no tener industria clasificada |
| company | location_id | Empresa puede no tener ubicación específica |
| Todas las tablas | created_by | Usuario opcional en logs |
| Todas las tablas | updated_by | Usuario opcional en logs |

## Recomendaciones de Mejora

### 1. Comportamiento de Eliminación para Referencias Principales

**Problema Actual:**
```sql
-- Comportamiento actual (RESTRICT por defecto)
industry_id BIGINT REFERENCES industry(id)
location_id BIGINT REFERENCES location(id)
```

**Solución Recomendada:**
```sql
-- Comportamiento mejorado con SET NULL
industry_id BIGINT REFERENCES industry(id) ON DELETE SET NULL
location_id BIGINT REFERENCES location(id) ON DELETE SET NULL
```

**Justificación:** Permitir eliminación de industrias/ubicaciones sin perder empresas.

### 2. Índices para Performance

**Recomendación:**
```sql
-- Índices en foreign keys para mejorar performance de joins
CREATE INDEX IX_company_industry_id ON company(industry_id);
CREATE INDEX IX_company_location_id ON company(location_id);
CREATE INDEX IX_company_investor_company_id ON company_investor(company_id);
CREATE INDEX IX_company_investor_investor_id ON company_investor(investor_id);
```

### 3. Restricciones de Validación

**Campos Numéricos:**
```sql
-- Validaciones adicionales recomendadas
ALTER TABLE company ADD CONSTRAINT CK_company_founding_year 
    CHECK (founding_year >= 1800 AND founding_year <= YEAR(GETDATE()));

ALTER TABLE company ADD CONSTRAINT CK_company_employees 
    CHECK (employees >= 0);

ALTER TABLE company ADD CONSTRAINT CK_company_g2_rating 
    CHECK (g2_rating >= 0 AND g2_rating <= 5);
```

## Conclusiones

### Fortalezas del Diseño
- ✅ Integridad referencial bien implementada
- ✅ Uso apropiado de CASCADE en tabla de unión
- ✅ Separación lógica de entidades (normalización)
- ✅ Campos de auditoría consistentes

### Áreas de Mejora
- ⚠️ Considerar SET NULL para industry_id y location_id
- ⚠️ Añadir índices en foreign keys para performance
- ⚠️ Implementar restricciones de validación para datos numéricos
- ⚠️ Considerar restricciones de longitud más específicas para algunos campos NVARCHAR(MAX)