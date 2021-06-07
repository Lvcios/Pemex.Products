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
2. Ejecutar en IIS Express
3. Esperar a que compile e instale los nugets
4. El proyecto iniciará en la url `https://localhost:44338/api/v1/weatherforecast` solo como prueba

## Lista de Endpoints
1. `GET api/v1/weatherforecast` Prueba
2. `POST api/v1/advertisement` Guarda un producto/anuncio
3. `GET api/v1/advertisement/{UUID}` Obtener un producto/anuncio
4. `GET api/v1/advertisement/page` Obtiene una página de productos
5. `POST notification/sendToAdmin` Guarda una notificación de correo


## Extras
1. Colección de Postman en archivo `PemexProducts.postman_collection.json`
