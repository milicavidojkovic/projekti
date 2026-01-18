set search_path to library;

insert into author(first_name, last_name) values
('Ivo', 'Andric'),
('Mesa', 'Selimovic');

insert into book(title, published_year, author_id) values
('Na Drini cuprija', 1945, (select id from author where last_name='Andric' limit 1)),
('Dervis i smrt', 1966, (select id from author where last_name='Selimovic' limit 1));
