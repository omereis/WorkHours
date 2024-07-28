
use const_hours;
/*
Note: must use UTF8mb4
*/
drop table if exists tblContacts;
create table tblContacts (
	id integer not null primary key,
	first_name varchar(30),
	middle_name varchar(30),
	last_name varchar(30),
	phone1	varchar(15),
	phone2	varchar(15),
	email varchar(50)
);
insert into tblContacts (id,first_name) values (10,'אבג');
insert into tblContacts (id,first_name,last_name,phone1,email) values (1,'racheli', 'biton', '08-656-4766','racheli@rotemi.co.il');
insert into tblContacts (id,first_name,last_name,phone1,email) values (1,'רחלי', 'ביטון', '08-656-4766','racheli@rotemi.co.il'),
																	(2,'דימיטרי','גינזבורג','050-620-0521','dimgiz@rotemi.co.il');
select * from tblContacts;
/*
	address varchar(100),
	zip	varchar(10),
	business_code varchar(10)
create tal
*/
