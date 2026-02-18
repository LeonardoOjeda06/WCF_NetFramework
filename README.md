# Sistema de Usuarios
- Arquitectura por Capas
- Implementacion de servicio WCF

## Requisitos

- Visual Studio 2022
- SQL Server
- .NET Framework 4.8

## Configuración

1. Crear base de datos WCFDemo
2. Ejecutar el script SQL ubicado en /Database/CreateTable.sql para crear la tabla de la entidad User
3. Ejecutar el script SQL ubicado en /Database/StoredProcedure.sql para crear SP_User_CRUD
4. Verificar la cadena de conexión en Web.config

## Arquitectura

- Capa Presentación: ASP.NET Web Forms
- Capa Negocio: Servicio WCF
- Capa Datos: SQL Server + Stored Procedure
