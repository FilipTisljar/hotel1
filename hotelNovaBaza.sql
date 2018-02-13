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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

/*Data for the table `korisnik` */

insert  into `korisnik`(`idkorisnik`,`ime`,`prezime`,`lozinka`,`email`,`pamtiLozinku`,`uloga`) values (1,'Filip','Tisljar','12345','igricefilip@gmail.com',1,'admin'),(2,'Ivo ','Ivic','54321','ivoivic@gmail.com',1,NULL),(3,'TestIme','TestPrezime','Test1','test1@gmail.com',1,NULL),(4,'Phil','Carpenter','12345','phil@gmail.com',0,NULL),(5,'Eddie','Rabbit','12345','eddie@gmail.com',0,NULL),(6,'John','Denver','12345','john@gmail.com',0,NULL),(7,'Willie','Nelson','12345','willie@gmail.com',0,NULL),(8,'Saul','Hudson','1234567','saul@gmail.com',0,'admin'),(9,'Ronnie','James','1234567','ronnie@gmail.com',0,'admin'),(10,'TestDva','TestDvaPrezime','1234567','test2@gmail.com',0,NULL);

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
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8;

/*Data for the table `rezervacija` */

insert  into `rezervacija`(`idrezervacija`,`datumRezervacije`,`rezerviranoOd`,`rezerviranoDo`,`cijena`,`id_korisnik`,`id_soba`) values (42,'2018-02-11','2021-01-23','2021-01-24','250 kn',6,4),(50,'2018-02-13','2021-01-23','2021-01-24','200 kn',1,1),(51,'2018-02-13','2021-01-23','2021-01-24','450 kn',6,9),(53,'2018-02-13','2021-01-23','2021-01-24','500 kn',10,8);

/*Table structure for table `soba` */

DROP TABLE IF EXISTS `soba`;

CREATE TABLE `soba` (
  `idsoba` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `brojSobe` int(11) unsigned NOT NULL,
  `brojKreveta` int(11) unsigned NOT NULL,
  `cijenaSobe` int(11) unsigned NOT NULL,
  PRIMARY KEY (`idsoba`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

/*Data for the table `soba` */

insert  into `soba`(`idsoba`,`brojSobe`,`brojKreveta`,`cijenaSobe`) values (1,1,2,200),(2,2,2,249),(3,3,1,200),(4,4,2,250),(5,5,1,100),(6,6,3,300),(7,7,3,500),(8,8,3,500),(9,9,4,450);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
