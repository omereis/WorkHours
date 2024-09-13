use const_hours;
drop table if exists tblOutputs;
create table tblOutputs (
	output_id	integer not null primary key,
	output_name	text
);
insert into tblOutputs (output_id,output_name) values (1,'דוח'),(2,'קוד');
select * from tblOutputs;