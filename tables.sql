
-- Las tablas ya existen en la base de datos.
-- había considerado la siguiente función para el default de los id's pero mi usuario no tenía permisos
-- CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
-- SELECT uuid_generate_v4();

CREATE TABLE advertisement
(
	id uuid primary key,
	title varchar(50),
	type_ad varchar(50),
	price numeric, 
	image bytea,
	creation_date timestamp default current_timestamp
);

CREATE TABLE email_notification(
	id uuid primary key not null,
	name_from varchar(50) not null,
	email_from varchar(50) not null,
	name_to varchar(50) not null,
	email_to varchar(50) not null,
	subject character varying not null,
	message text not null,
	sent boolean default false,
	creation_date timestamp default current_timestamp,
	sent_date timestamp default null
);
