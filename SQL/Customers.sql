
use const_hours;
/*
Note: must use UTF8mb4
*/
drop table if exists tblContacts;
create table tblContacts (
	contact_id	integer not null primary key,
	first_name	varchar(30),
	middle_name	varchar(30),
	last_name	varchar(30),
	phone1		varchar(15),
	phone2		varchar(15),
	email		varchar(50)
);
insert into tblContacts (contact_id,first_name,last_name,phone1,email) values (1,'רחלי', 'ביטון', '08-656-4766','racheli@rotemi.co.il'),
																	(2,'דימיטרי','גינזבורג','050-620-0521','dimgiz@rotemi.co.il');
select * from tblContacts;

create table tblClients (
	client_id integer not null primary key,
	client_name	varchar(50),
	code	varchar(30),
	address	varchar(100),
	fax	varchar(15),
	phone varchar(15)
);
insert into tblClients (client_id,client_name) values (1,'רותם תעשיות');
select * from tblClients;

create table tblClientsContacts (
	client_id	integer,
	contact_id integer,
	foreign key (client_id) references tblClients (client_id) on update cascade on delete set null,
	foreign key (contact_id) references tblContacts (contact_id) on update cascade on delete set null
	);
	
insert into tblClientsContacts (client_id,contact_id) values (1,1);

/*
	address varchar(100),
	zip	varchar(10),
	business_code varchar(10)
create tal
*/
