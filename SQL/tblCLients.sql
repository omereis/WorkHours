/*
SQLyog Community v13.2.1 (64 bit)
MySQL - 5.7.44-log 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

use const_hours;
create table `tblclients` (
	`client_id` int (11),
	`client_name` varchar (150),
	`code` varchar (90),
	`address` varchar (300),
	`fax` varchar (45),
	`phone` varchar (45)
); 
insert into `tblclients` (`client_id`, `client_name`, `code`, `address`, `fax`, `phone`) values('1','Rotem Industries',NULL,NULL,NULL,NULL);
insert into `tblclients` (`client_id`, `client_name`, `code`, `address`, `fax`, `phone`) values('2','ערד',NULL,NULL,NULL,NULL);
insert into `tblclients` (`client_id`, `client_name`, `code`, `address`, `fax`, `phone`) values('3','קרית ענבים',NULL,NULL,NULL,NULL);
