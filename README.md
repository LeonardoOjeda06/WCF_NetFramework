# Sistema de Usuarios
### Arquitectura por Capas
### Implementacion de servicio WCF

## Requisitos

- Visual Studio 2022
- SQL Server
- .NET Framework 4.8

## Configuración

1. Crear base de datos DemoDB
2. Ejecutar el script SQL ubicado en /Database/script.sql
3. Verificar la cadena de conexión en Web.config

## Arquitectura

- Capa Presentación: ASP.NET Web Forms
- Capa Negocio: Servicio WCF
- Capa Datos: SQL Server + Stored Procedure
