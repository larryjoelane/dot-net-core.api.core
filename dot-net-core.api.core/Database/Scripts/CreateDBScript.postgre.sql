-- postgres version
-- CREATE DATABASE Content;

CREATE TABLE ContentItems (
   ContentKey SERIAL PRIMARY KEY,
   Name varchar,
   Value varchar
);

INSERT INTO ContentItems (Name, Value) VALUES
('sample google link','https://www.google.com'),
('sample mlb link','https://www.mlb.com')

select * from contentitems;