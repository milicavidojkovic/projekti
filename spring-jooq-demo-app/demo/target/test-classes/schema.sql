create schema if not exists library;
set search_path to library;

create table author (
  id bigserial primary key,
  first_name varchar(80) not null,
  last_name varchar(80) not null,
  created_at timestamptz not null default now()
);

create table book (
  id bigserial primary key,
  title varchar(200) not null,
  published_year int,
  author_id bigint not null references author(id) on delete restrict,
  created_at timestamptz not null default now()
);
