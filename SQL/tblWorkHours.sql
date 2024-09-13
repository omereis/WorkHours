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

drop table if exists tbl_work_outputs;
create table tbl_work_outputs (
	wh_id		integer,
	output_id	integer,
	foreign key (wh_id) references tblWorkHours (wh_id) on update cascade on delete set null,
	foreign key (output_id) references tblOutputs (output_id) on update cascade on delete set null
);

select * from tblSubjects;
select * from tblOutputs;

insert into tblWorkHours (wh_id,subject_id) values (1,1),(2,1),(3,2);
insert into tbl_work_outputs (wh_id,output_id) values (1,1);

select * from tblWorkHours,tbl_work_outputs where tblWorkHours.wh_id=tbl_work_outputs.wh_id;
select
	tblWorkHours.wh_id,
	dtStart,
	dtEnd,
	txtDesc,
	txtLoc,
	subject_id,
	output_id
from
	tblWorkHours,tbl_work_outputs
where
	tblWorkHours.wh_id=tbl_work_outputs.wh_id;
	
select 
	wh_id,
	dtStart,
	dtEnd,
	txtDesc,
	txtLoc
	subject_id,
	null as output_id
from
	tblWorkHours
where
	wh_id not in (select wh_id from tbl_work_outputs);

select
	tblWorkHours.wh_id,
	dtStart,
	dtEnd,
	txtDesc,
	subject_id,
	output_id
from
	tblWorkHours,tbl_work_outputs
where
	tblWorkHours.wh_id=tbl_work_outputs.wh_id
union	
select 
	wh_id,
	dtStart,
	dtEnd,
	txtDesc,
	subject_id,
	null as output_id
from
	tblWorkHours
where
	wh_id not in (select wh_id from tbl_work_outputs);



drop view vWorkHoursSubj;
create view vWorkHoursSubj
as
select
	tblWorkHours.wh_id as 'wh_id',
	tblWorkHours.subject_id,
	dtStart,
	dtEnd,
	txtDesc,
	txtLoc,
	subject_name
from
	tblWorkHours,tblSubjects
where
	tblWorkHours.subject_id=tblSubjects.subject_id;

update tblWorkHours set dtStart='2024-08-29 08:00:00',dtEnd='2024-08-29 16:00:00',txtDesc='השלמת פרוטוקול',txtLoc='בית' where wh_id=2;
select * from vWorkHoursSubj;

insert into tbl_work_outputs (wh_id,output_id) values (1,2),(2,3),(3,1);
select * from tbl_work_outputs;
select * from tblWorkHours;
select * from tblOutputs;
select * from vWorkHoursSubj,tblOutputs,tbl_work_outputs where (vWorkHoursSubj.wh_id=tbl_work_outputs.wh_id) and (tblOutputs.output_id=tbl_work_outputs.output_id);

drop view vWorkHours;
create view vWorkHours
	as
	select
		vWorkHoursSubj.wh_id,
		dtStart,
		dtEnd,
		txtDesc,
		txtLoc,
		subject_id,
		subject_name,
		tblOutputs.output_id,
		output_name
	from
		vWorkHoursSubj,tblOutputs,tbl_work_outputs
	where
		(vWorkHoursSubj.wh_id=tbl_work_outputs.wh_id)
		and
		(tblOutputs.output_id=tbl_work_outputs.output_id);
;

drop view vWorkHours;
create view vWorkHours
as
select
	vWorkHoursSubj.wh_id,
	dtStart,
	dtEnd,
	txtDesc,
	txtLoc,
	subject_id,
	subject_name,
	output_id
from
	vWorkHoursSubj,tbl_work_outputs
where
	vWorkHoursSubj.wh_id=tbl_work_outputs.wh_id
union	
select 
	wh_id,
	dtStart,
	dtEnd,
	txtDesc,
	txtLoc,
	subject_id,
	subject_name,
	null as output_id
from
	vWorkHoursSubj
where
	wh_id not in (select wh_id from tbl_work_outputs)
;

select * from tblWorkHours;
update tblWorkHours set dtStart='2023-09-11 10:59:42' where wh_id=1;
select * from vWorkHours;

select * from tblSubjects;

select * from vWorkHours order by wh_id;
