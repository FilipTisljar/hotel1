/*
SQLyog Community v8.61 
MySQL - 5.7.17-log : Database - hotel
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hotel` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `hotel`;

/*Table structure for table `korisnik` */

DROP TABLE IF EXISTS `korisnik`;

CREATE TABLE `korisnik` (
  `idkorisnik` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `ime` varchar(45) NOT NULL,
  `prezime` varchar(45) NOT NULL,
  `lozinka` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `pamtiLozinku` tinyint(1) NOT NULL,
  `uloga` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idkorisnik`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `korisnik` */

insert  into `korisnik`(`idkorisnik`,`ime`,`prezime`,`lozinka`,`email`,`pamtiLozinku`,`uloga`) values (1,'Filip','Tisljar','12345','igricefilip@gmail.com',1,'admin'),(2,'Ivo ','Ivic','54321','ivoivic@gmail.com',1,NULL),(3,'TestIme','TestPrezime','Test1','test1@gmail.com',1,NULL),(4,'Phil','Carpenter','12345','phil@gmail.com',0,NULL),(5,'Eddie','Rabbit','12345','eddie@gmail.com',0,NULL),(6,'John','Denver','12345','john@gmail.com',0,NULL),(7,'Willie','Nelson','12345','willie@gmail.com',0,NULL);

/*Table structure for table `rezervacija` */

DROP TABLE IF EXISTS `rezervacija`;

CREATE TABLE `rezervacija` (
  `idrezervacija` int(11) NOT NULL AUTO_INCREMENT,
  `datumRezervacije` date NOT NULL,
  `rezerviranoOd` date NOT NULL,
  `rezerviranoDo` date NOT NULL,
  `cijena` varchar(45) DEFAULT NULL,
  `id_korisnik` int(11) unsigned NOT NULL,
  `id_soba` int(11) unsigned NOT NULL,
  PRIMARY KEY (`idrezervacija`,`id_korisnik`,`id_soba`),
  KEY `id_korisnik_idx` (`id_korisnik`),
  KEY `id_soba_idx` (`id_soba`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;

/*Data for the table `rezervacija` */

insert  into `rezervacija`(`idrezervacija`,`datumRezervacije`,`rezerviranoOd`,`rezerviranoDo`,`cijena`,`id_korisnik`,`id_soba`) values (16,'2014-04-21','2018-02-10','2018-02-20','201',1,1),(18,'2014-04-21','2018-06-01','2018-06-05','202',1,1),(19,'2014-04-21','2018-02-06','2018-02-13','233',2,2),(21,'2014-04-21','2018-02-05','2018-02-12','233',2,1),(26,'2014-04-21','2017-02-10','2017-02-15','201',4,3),(27,'2014-04-21','2014-02-10','2014-02-14','233',6,1),(28,'2014-04-21','2017-02-10','2017-02-15','201',7,2),(29,'2014-04-21','2014-02-10','2014-02-15','1231',6,0),(30,'2018-02-02','2017-02-01','2018-02-02','233',6,4),(31,'2018-02-02','2000-01-01','2000-01-05','201',6,1),(32,'2018-02-02','2018-05-05','2018-05-08','201',6,4),(33,'2018-02-02','1999-01-01','1999-01-05','233',6,1),(34,'2018-02-02','2001-01-01','2001-01-05','233',6,1),(35,'2018-02-09','2019-02-26','2019-02-28','201',6,2),(36,'2018-02-09','2020-02-26','2020-02-28','201',6,2),(37,'2018-02-10','2018-03-15','2018-03-29','14.00:00:00',1,2),(38,'2018-02-11','2021-01-01','2021-01-03','2.00:00:00 kn',6,4),(39,'2018-02-11','2021-01-06','2021-01-07','1 kn',6,4),(40,'2018-02-11','2021-01-09','2021-01-11','500 kn',6,4),(41,'2018-02-11','2021-01-21','2021-01-22','200 kn',6,3),(42,'2018-02-11','2021-01-23','2021-01-24','250 kn',6,4),(44,'2018-02-11','2021-01-23','2021-01-24','200 kn',1,1),(45,'2018-02-11','2021-01-23','2021-01-25','500 kn',1,2),(46,'2018-02-11','2021-01-26','2021-01-27','250 kn',6,2);

/*Table structure for table `soba` */

DROP TABLE IF EXISTS `soba`;

CREATE TABLE `soba` (
  `idsoba` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `brojSobe` int(11) unsigned NOT NULL,
  `brojKreveta` int(11) unsigned NOT NULL,
  `cijenaSobe` int(11) unsigned NOT NULL,
  PRIMARY KEY (`idsoba`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `soba` */

insert  into `soba`(`idsoba`,`brojSobe`,`brojKreveta`,`cijenaSobe`) values (1,1,2,200),(2,2,2,250),(3,3,1,200),(4,4,2,250);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
