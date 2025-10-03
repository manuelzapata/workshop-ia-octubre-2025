-- src/database/schema.sql
-- Este script crea el esquema inicial de la base de datos.

-- Tabla para almacenar ubicaciones normalizadas
CREATE TABLE location (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    city NVARCHAR(MAX) NOT NULL,
    state NVARCHAR(MAX),
    country NVARCHAR(MAX) NOT NULL,
    created_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    created_by NVARCHAR(MAX),
    updated_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    updated_by NVARCHAR(MAX)
);

-- Tabla para almacenar industrias únicas
CREATE TABLE industry (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL UNIQUE,
    created_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    created_by NVARCHAR(MAX),
    updated_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    updated_by NVARCHAR(MAX)
);

-- Tabla para almacenar inversores únicos
CREATE TABLE investor (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL UNIQUE,
    created_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    created_by NVARCHAR(MAX),
    updated_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    updated_by NVARCHAR(MAX)
);

-- Tabla principal para almacenar información de las empresas
CREATE TABLE company (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX) NOT NULL,
    products NVARCHAR(MAX),
    founding_year INT,
    total_funding BIGINT,
    arr BIGINT,
    valuation BIGINT,
    employees INT,
    g2_rating REAL,
    industry_id BIGINT REFERENCES industry(id),
    location_id BIGINT REFERENCES location(id),
    created_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    created_by NVARCHAR(MAX),
    updated_at DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    updated_by NVARCHAR(MAX)
);

-- Tabla de unión para la relación muchos a muchos entre empresas e inversores
CREATE TABLE company_investor (
    company_id BIGINT REFERENCES company(id) ON DELETE CASCADE,
    investor_id BIGINT REFERENCES investor(id) ON DELETE CASCADE,
    PRIMARY KEY (company_id, investor_id)
);