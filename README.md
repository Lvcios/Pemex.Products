# REST API  Productos Pemex

El proyecto se realizó con netCore 3.1 y el framework webAPI.

## Nuget Packages usados

1. Automapper: Para mapear objetos de los request hacia la base de datos y viceversa
2. Mediatr: Para implementar el patron Mediator y CQRS
3. Petapoco.Compiled: ORM para realizar las consultas a base de datos
4. Npgsql: Driver para PostgreSql
5. Fluentvalidation: Validaciones de modelos en los Comandos y Queries de CQRS

## Pre requisitos

1. Tener Visual Studio
2. Fin

## Como ejecutar

1. Abrir el proyecto
2. Seleccionar como proyecto de inicio/"startup project" el proyecto `Pemex.Products.API`
3. Ejecutar en IIS Express
4. Esperar a que compile e instale los nugets
5. El proyecto iniciará en la url `https://localhost:44338/api/v1/weatherforecast` solo como prueba

## Lista de Endpoints
1. `GET  api/v1/weatherforecast` Prueba
2. `POST api/v1/advertisement` Guarda un producto/anuncio
3. `GET  api/v1/advertisement/{UUID}` Obtener un producto/anuncio
4. `GET  api/v1/advertisement/page` Obtiene una página de productos
5. `POST api/v1/notification/sendToAdmin` Guarda una notificación de correo


## Estructura de la solución

La solución se divide en los siguientes proyectos:
1. Pemex.Products.API: Endpoints, controladores y validaciones de objetos en solicitudes
2. Pemex.Products.DAL: Data Access Layer. Incluye la abstracción para comunicarse con la base de datos y todos los modelos de tablas de base de datos
3. Pemex.Products.Repository: Incluye todos los comandos de inserción en base de datos y recuperación de registros. Es donde se aplica el patrón CQRS.
4. Pemex.Products.Service: Abstracción e implementación de la capa de servicios del proyecto.

## Extras
1. Colección de Postman en archivo `PemexProducts.postman_collection.json`
2. Script para creat tablas en base de datos

