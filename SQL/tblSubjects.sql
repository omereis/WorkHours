use const_hours;
drop table if exists tblSubject;
drop table if exists tblSubjects;
create table tblSubjects (
	subject_id	integer not null primary key,
	subject_name	text,
	alternate_name	text
);
insert into tblSubjects (subject_id,subject_name,alternate_name) values (1,'IC3',null),(2,'DRM-3000','DPU3');
select * from tblSubjects;