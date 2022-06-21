CREATE database mahdb;

ALTER database mahdb owner TO postgres;

CREATE TABLE IF NOT EXISTS parents(
	id SERIAL not null,
	"name" text not null,
	email text not null,
	created timestamp not null,
	deleted timestamp null,
	updated timestamp null,
	primary key(id)
);

CREATE TABLE IF NOT EXISTS teachers(
	id SERIAL not null,
	"name" text not null,
	email text not null,
	created timestamp not null,
	deleted timestamp null,
	updated timestamp null,
	primary key(id)
);

CREATE TABLE IF NOT EXISTS students(
	id SERIAL not null,
	"name" text not null,
	email text null,
	created timestamp not null,
	deleted timestamp null,
	updated timestamp null,
	primary key(id)
);