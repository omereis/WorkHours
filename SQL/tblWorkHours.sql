use work_hours;
drop table if exists tblWorkHours;
create table tblWorkHours (
	wh_id		integer not null primary key,
	dtStart		datetime,
	dtEnd		datetime,
	txtDesc		text,
	txtLoc		text,
	subject_id	integer,
	foreign key (subject_id) references tblSubjects (subject_id) on update cascade on delete set null
);

select * from tblWorkHours;
select * from tblWorkHours,tblSubjects where  tblWorkHours.subject_id=tblSubjects.subject_id;
select wh_id,dtStart,dtEnd,txtDesc,txtLoc,tblSubjects.subject_id,subject_name from tblWorkHours,tblSubjects where  tblWorkHours.subject_id=tblSubjects.subject_id;
select wh_id,dtStart,dtEnd,txtDesc,txtLoc,null as 'subject_id',null as 'subject_name' from tblWorkHours where  subject_id is null;


create view vWorkSubjects
as
	select
		wh_id,
		dtStart,
		dtEnd,
		txtDesc,
		txtLoc,
		tblSubjects.subject_id,
		subject_name
	from
		tblWorkHours,
		tblSubjects
	where
		tblWorkHours.subject_id = tblSubjects.subject_id
	union
	select
		wh_id,
		dtStart,
		dtEnd,
		txtDesc,
		txtLoc,
		null as 'subject_id',
		null as 'subject_name'
	from
		tblWorkHours
	where
		subject_id is null;

drop table if exists tbl_work_outputs;
create table tbl_work_outputs (
	wh_id		integer,
	output_id	integer,
	foreign key (wh_id) references tblWorkHours (wh_id) on update cascade on delete set null,
	foreign key (output_id) references tblOutputs (output_id) on update cascade on delete set null
);

select * from tblSubjects;
select * from tblOutputs;
select * from vWorkSubjects;

insert into tblWorkHours (wh_id,subject_id) values (4,1);
insert into tbl_work_outputs (wh_id,output_id) values (1,1);
insert into tbl_work_outputs (wh_id,output_id) values (3,3);
select * from tbl_work_outputs ;


select * from tblWorkHours,tbl_work_outputs where tblWorkHours.wh_id=tbl_work_outputs.wh_id;

drop view if exists vWorkHours;
create view vWorkHours 
as
	select
		vWorkSubjects.wh_id,
		dtStart,dtEnd,
		txtDesc,
		txtLoc,
		subject_id,
		subject_name,
		tblOutputs.output_id,
		output_name
	from
		vWorkSubjects,tblOutputs,tbl_work_outputs
	where (vWorkSubjects.wh_id=tbl_work_outputs.wh_id) and (tblOutputs.output_id=tbl_work_outputs.output_id)
	union
	select 
		wh_id,
		dtStart,dtEnd,
		txtDesc,
		txtLoc,
		subject_id,
		subject_name,
		null as 'output_id',
		null as 'output_name'
	from
		vWorkSubjects
	where
		wh_id not in (select wh_id from tbl_work_outputs);


select * from vWorkHours order by wh_id;
