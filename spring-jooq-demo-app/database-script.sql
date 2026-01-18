create schema if not exists library;

set search_path to library;

create table author (
    id           bigserial primary key,
    first_name   varchar(80) not null,
    last_name    varchar(80) not null,
    created_at   timestamptz not null default now()
);

create table book (
    id             bigserial primary key,
    title          varchar(200) not null,
    published_year int,
    author_id      bigint not null,
    created_at     timestamptz not null default now(),
    constraint fk_book_author
        foreign key (author_id) references author(id)
        on delete restrict
);

create table loan (
    id           bigserial primary key,
    book_id      bigint not null,
    borrower     varchar(120) not null,
    loan_date    date not null default current_date,
    return_date  date null,
    created_at   timestamptz not null default now(),
    constraint fk_loan_book
        foreign key (book_id) references book(id)
        on delete cascade
);

create index idx_author_last_name on author(last_name);
create index idx_book_author_id   on book(author_id);
create index idx_loan_book_id     on loan(book_id);

create unique index uq_active_loan_per_book
on loan(book_id)
where return_date is null;

insert into author(first_name, last_name) values
('Ivo', 'Andric'),
('Mesa', 'Selimovic'),
('Danilo', 'Kis');

insert into book(title, published_year, author_id) values
('Na Drini cuprija', 1945, (select id from author where last_name='Andric' limit 1)),
('Prokleta avlija', 1954, (select id from author where last_name='Andric' limit 1)),
('Dervis i smrt', 1966, (select id from author where last_name='Selimovic' limit 1)),
('Basta, pepeo', 1965, (select id from author where last_name='Kis' limit 1));

insert into loan(book_id, borrower, loan_date)
values ((select id from book where title='Dervis i smrt' limit 1), 'Milica', current_date);


select * from library.author;
select * from library.book;
select * from library.loan;

