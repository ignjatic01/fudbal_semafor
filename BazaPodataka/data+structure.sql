CREATE DATABASE  IF NOT EXISTS `fudbal_semafor` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `fudbal_semafor`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: fudbal_semafor
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `gol`
--

DROP TABLE IF EXISTS `gol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gol` (
  `idGol` int NOT NULL AUTO_INCREMENT,
  `utakmica` int NOT NULL,
  `klub` int NOT NULL,
  `igrac` int NOT NULL,
  `minut` int NOT NULL,
  PRIMARY KEY (`idGol`),
  KEY `FK_gol_utakmica_idx` (`utakmica`),
  KEY `FK_gol_klub_idx` (`klub`),
  KEY `FK_gol_igrac_idx` (`igrac`),
  CONSTRAINT `FK_gol_igrac` FOREIGN KEY (`igrac`) REFERENCES `igrac` (`idIgrac`),
  CONSTRAINT `FK_gol_klub` FOREIGN KEY (`klub`) REFERENCES `klub` (`idKlub`),
  CONSTRAINT `FK_gol_utakmica` FOREIGN KEY (`utakmica`) REFERENCES `utakmica` (`idUtakmica`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gol`
--

LOCK TABLES `gol` WRITE;
/*!40000 ALTER TABLE `gol` DISABLE KEYS */;
INSERT INTO `gol` VALUES (11,6,15,6,3),(12,6,16,10,5),(13,6,15,6,5),(14,6,15,7,5),(15,7,17,15,6),(16,7,15,8,8),(23,9,17,15,2),(24,8,23,18,1),(25,8,24,35,3),(26,8,23,19,13);
/*!40000 ALTER TABLE `gol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `igrac`
--

DROP TABLE IF EXISTS `igrac`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `igrac` (
  `idIgrac` int NOT NULL AUTO_INCREMENT,
  `ime` varchar(50) NOT NULL,
  `prezime` varchar(50) NOT NULL,
  `brojDresa` int NOT NULL,
  `klub` int NOT NULL,
  `pozicija` varchar(5) NOT NULL,
  `uIgri` bit(1) NOT NULL,
  PRIMARY KEY (`idIgrac`),
  KEY `FK_igrac_klub_idx` (`klub`),
  KEY `FK_igrac_pozicija_idx` (`pozicija`),
  CONSTRAINT `FK_igrac_klub` FOREIGN KEY (`klub`) REFERENCES `klub` (`idKlub`),
  CONSTRAINT `FK_igrac_pozicija` FOREIGN KEY (`pozicija`) REFERENCES `pozicija` (`oznakaPozicije`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `igrac`
--

LOCK TABLES `igrac` WRITE;
/*!40000 ALTER TABLE `igrac` DISABLE KEYS */;
INSERT INTO `igrac` VALUES (5,'Filip','Manojlović',13,15,'GK',_binary ''),(6,'Srđan','Grahovac',15,15,'CF',_binary '\0'),(7,'Bart','Meiers',2,15,'CB',_binary '\0'),(8,'Đorđe','Despotović',99,15,'CF',_binary '\0'),(9,'Vedad','Muftić',13,16,'GK',_binary '\0'),(10,'Marin','Karamarko',6,16,'CB',_binary '\0'),(11,'Sulejman','Krpić',7,16,'CF',_binary '\0'),(12,'Lukas','Hardecky',1,17,'GK',_binary '\0'),(13,'Edmond','Tapsoba',12,17,'CB',_binary '\0'),(14,'Granit','Xhaka',34,17,'DM',_binary '\0'),(15,'Florian','Wirtz',10,17,'AM',_binary '\0'),(16,'Victor','Boniface',22,17,'CF',_binary '\0'),(17,'Zoran','Kvrzic',20,15,'RB',_binary '\0'),(18,'Student','Student',1,23,'GK',_binary '\0'),(19,'Student','Student',2,23,'CB',_binary '\0'),(20,'Student','Student',3,23,'CB',_binary '\0'),(21,'Student','Student',4,23,'RB',_binary '\0'),(22,'Student','Student',5,23,'RB',_binary '\0'),(23,'Student','Student',6,23,'DM',_binary '\0'),(24,'Student','Student',7,23,'DM',_binary '\0'),(25,'Student','Student',8,23,'AM',_binary '\0'),(26,'Student','Student',9,23,'AM',_binary '\0'),(27,'Student','Student',10,23,'CF',_binary '\0'),(28,'Student','Student',11,23,'CF',_binary '\0'),(29,'Student','Student',12,23,'GK',_binary '\0'),(30,'Student','Student',13,23,'CB',_binary '\0'),(31,'Student','Student',14,23,'CF',_binary '\0'),(32,'Student','Student',1,24,'GK',_binary '\0'),(33,'Student','Student',2,24,'CB',_binary '\0'),(34,'Student','Student',3,24,'CB',_binary '\0'),(35,'Student','Student',4,24,'CB',_binary '\0'),(36,'Student','Student',5,24,'RB',_binary '\0'),(37,'Student','Student',6,24,'DM',_binary '\0'),(38,'Student','Student',7,24,'DM',_binary '\0'),(39,'Student','Student',8,24,'AM',_binary '\0'),(40,'Student','Student',9,24,'CF',_binary '\0'),(41,'Student','Student',10,24,'CF',_binary '\0');
/*!40000 ALTER TABLE `igrac` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `igrac_na_utakmici`
--

DROP TABLE IF EXISTS `igrac_na_utakmici`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `igrac_na_utakmici` (
  `idIgrac` int NOT NULL,
  `idUtakmica` int NOT NULL,
  PRIMARY KEY (`idIgrac`,`idUtakmica`),
  KEY `FK_igrac_na_utakmici_utakmica_idx` (`idUtakmica`),
  CONSTRAINT `FK_igrac_na_utakmici_igrac` FOREIGN KEY (`idIgrac`) REFERENCES `igrac` (`idIgrac`),
  CONSTRAINT `FK_igrac_na_utakmici_utakmica` FOREIGN KEY (`idUtakmica`) REFERENCES `utakmica` (`idUtakmica`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `igrac_na_utakmici`
--

LOCK TABLES `igrac_na_utakmici` WRITE;
/*!40000 ALTER TABLE `igrac_na_utakmici` DISABLE KEYS */;
INSERT INTO `igrac_na_utakmici` VALUES (5,6),(6,6),(7,6),(9,6),(10,6),(5,7),(6,7),(7,7),(12,7),(13,7),(14,7),(15,7),(18,8),(19,8),(20,8),(21,8),(22,8),(23,8),(24,8),(25,8),(26,8),(27,8),(28,8),(32,8),(34,8),(35,8),(37,8),(38,8),(41,8),(9,9),(10,9),(12,9),(13,9),(14,9),(15,9);
/*!40000 ALTER TABLE `igrac_na_utakmici` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `izmjena`
--

DROP TABLE IF EXISTS `izmjena`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `izmjena` (
  `idIzmjena` int NOT NULL AUTO_INCREMENT,
  `igracUlazi` int NOT NULL,
  `igracIzlazi` int NOT NULL,
  `utakmica` int NOT NULL,
  `minut` int NOT NULL,
  PRIMARY KEY (`idIzmjena`),
  KEY `FK_izmjena_igracUlazi_idx` (`igracUlazi`),
  KEY `FK_izmjena_igracIzlazi_idx` (`igracIzlazi`),
  KEY `FK_izmjena_utakmica_idx` (`utakmica`),
  CONSTRAINT `FK_izmjena_igracIzlazi` FOREIGN KEY (`igracIzlazi`) REFERENCES `igrac` (`idIgrac`),
  CONSTRAINT `FK_izmjena_igracUlazi` FOREIGN KEY (`igracUlazi`) REFERENCES `igrac` (`idIgrac`),
  CONSTRAINT `FK_izmjena_utakmica` FOREIGN KEY (`utakmica`) REFERENCES `utakmica` (`idUtakmica`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `izmjena`
--

LOCK TABLES `izmjena` WRITE;
/*!40000 ALTER TABLE `izmjena` DISABLE KEYS */;
INSERT INTO `izmjena` VALUES (1,8,6,6,4),(2,8,7,7,7);
/*!40000 ALTER TABLE `izmjena` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karton`
--

DROP TABLE IF EXISTS `karton`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karton` (
  `idKarton` int NOT NULL AUTO_INCREMENT,
  `kartonTip` int NOT NULL,
  `igrac` int NOT NULL,
  `utakmica` int NOT NULL,
  `minut` int NOT NULL,
  PRIMARY KEY (`idKarton`),
  KEY `FK_karton_kartonTip_idx` (`kartonTip`),
  KEY `FK_karton_igrac_idx` (`igrac`),
  KEY `FK_karton_utakmica_idx` (`utakmica`),
  CONSTRAINT `FK_karton_igrac` FOREIGN KEY (`igrac`) REFERENCES `igrac` (`idIgrac`),
  CONSTRAINT `FK_karton_kartonTip` FOREIGN KEY (`kartonTip`) REFERENCES `karton_tip` (`idKartonTip`),
  CONSTRAINT `FK_karton_utakmica` FOREIGN KEY (`utakmica`) REFERENCES `utakmica` (`idUtakmica`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karton`
--

LOCK TABLES `karton` WRITE;
/*!40000 ALTER TABLE `karton` DISABLE KEYS */;
INSERT INTO `karton` VALUES (6,5,9,6,1),(7,5,9,6,1),(8,4,9,6,2),(9,5,14,7,3),(10,5,14,7,8),(11,4,14,7,8),(30,5,34,8,2),(31,5,19,8,13);
/*!40000 ALTER TABLE `karton` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karton_tip`
--

DROP TABLE IF EXISTS `karton_tip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karton_tip` (
  `idKartonTip` int NOT NULL AUTO_INCREMENT,
  `tip` varchar(45) NOT NULL,
  PRIMARY KEY (`idKartonTip`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karton_tip`
--

LOCK TABLES `karton_tip` WRITE;
/*!40000 ALTER TABLE `karton_tip` DISABLE KEYS */;
INSERT INTO `karton_tip` VALUES (4,'Crveni'),(5,'Žuti');
/*!40000 ALTER TABLE `karton_tip` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klub`
--

DROP TABLE IF EXISTS `klub`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `klub` (
  `idKlub` int NOT NULL AUTO_INCREMENT,
  `nazivKluba` varchar(100) NOT NULL,
  `grad` varchar(100) NOT NULL,
  `slika` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idKlub`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klub`
--

LOCK TABLES `klub` WRITE;
/*!40000 ALTER TABLE `klub` DISABLE KEYS */;
INSERT INTO `klub` VALUES (15,'Borac','Banja Luka','Images\\screen.png'),(16,'Željezničar','Sarajevo','Images\\screen.png'),(17,'Bayer','Leverkusen','Images\\screen.png'),(18,'Sporting','Lisabon','Images\\screen.png'),(19,'Olimpija','Ljubljana','Images\\screen.png'),(20,'Chelsea','London','Images\\screen.png'),(21,'Slovan','Bratislava','Images\\screen.png'),(23,'Klub ETF','Banja Luka','Images\\screen.png'),(24,'Klub ETF2','Banja Luka','Images\\screen.png');
/*!40000 ALTER TABLE `klub` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `korisnik`
--

DROP TABLE IF EXISTS `korisnik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `korisnik` (
  `idKorisnik` int NOT NULL AUTO_INCREMENT,
  `ime` varchar(50) NOT NULL,
  `prezime` varchar(50) NOT NULL,
  `korisnickoIme` varchar(255) NOT NULL,
  `lozinka` varchar(300) NOT NULL,
  `role` int NOT NULL,
  PRIMARY KEY (`idKorisnik`),
  UNIQUE KEY `email_UNIQUE` (`korisnickoIme`),
  KEY `FK_korisnik_role_idx` (`role`),
  CONSTRAINT `FK_korisnik_role` FOREIGN KEY (`role`) REFERENCES `role` (`idRole`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `korisnik`
--

LOCK TABLES `korisnik` WRITE;
/*!40000 ALTER TABLE `korisnik` DISABLE KEYS */;
INSERT INTO `korisnik` VALUES (1,'Admin1','Admin','admin1','JfQ7FIatlaE5jj7rPYO8QBABX8yb7bNbQy4AKY1QIfc=',1),(2,'Korisnik1','Korisnik','korisnik1','nuAS6oMiwVFXZAgYGUEYj9FALX7TQ3F1eOlsRGqBIWI=',2),(3,'Korisnik2','Korisnik2','korisnik2','OeciDXArTfYwmig1Lax119EiMfnDWQbhBZdqUb2rsCA=',2);
/*!40000 ALTER TABLE `korisnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pozicija`
--

DROP TABLE IF EXISTS `pozicija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pozicija` (
  `oznakaPozicije` varchar(5) NOT NULL,
  `nazivPozicije` varchar(45) NOT NULL,
  PRIMARY KEY (`oznakaPozicije`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pozicija`
--

LOCK TABLES `pozicija` WRITE;
/*!40000 ALTER TABLE `pozicija` DISABLE KEYS */;
INSERT INTO `pozicija` VALUES ('AM','Prednji vezni'),('CB','Štoper'),('CF','Centarfor'),('DM','Zadnji vezni'),('GK','Golman'),('RB','Desni bek');
/*!40000 ALTER TABLE `pozicija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `idRole` int NOT NULL AUTO_INCREMENT,
  `nazivRole` varchar(50) NOT NULL,
  PRIMARY KEY (`idRole`),
  UNIQUE KEY `naziv_role_UNIQUE` (`nazivRole`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'ADMIN'),(2,'OPERATER');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stadion`
--

DROP TABLE IF EXISTS `stadion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stadion` (
  `idStadion` int NOT NULL AUTO_INCREMENT,
  `naziv` varchar(100) NOT NULL,
  `grad` varchar(100) DEFAULT NULL,
  `kapacitet` int NOT NULL,
  `podloga` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idStadion`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stadion`
--

LOCK TABLES `stadion` WRITE;
/*!40000 ALTER TABLE `stadion` DISABLE KEYS */;
INSERT INTO `stadion` VALUES (3,'Gradski stadion','Banja luka',10000,'Hibridna trava'),(4,'Enfild','Liverpul',53394,'Hibridna trava'),(5,'Olimpijski stadion','Berlin',74228,'Trava'),(6,'San Siro','Milan',80018,'Trava'),(7,'Grupami arena','Budimpesta',22000,'Trava');
/*!40000 ALTER TABLE `stadion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utakmica`
--

DROP TABLE IF EXISTS `utakmica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utakmica` (
  `idUtakmica` int NOT NULL AUTO_INCREMENT,
  `domaci` int NOT NULL,
  `gosti` int NOT NULL,
  `stadion` int DEFAULT NULL,
  `goloviDomaci` int NOT NULL,
  `goloviGosti` int NOT NULL,
  `zapoceta` bit(1) DEFAULT NULL,
  PRIMARY KEY (`idUtakmica`),
  KEY `FK_utakmica_domaci_idx` (`domaci`),
  KEY `FK_utakmica_gosti_idx` (`gosti`),
  KEY `FK_utakmica_stadion_idx` (`stadion`),
  CONSTRAINT `FK_utakmica_domaci` FOREIGN KEY (`domaci`) REFERENCES `klub` (`idKlub`),
  CONSTRAINT `FK_utakmica_gosti` FOREIGN KEY (`gosti`) REFERENCES `klub` (`idKlub`),
  CONSTRAINT `FK_utakmica_stadion` FOREIGN KEY (`stadion`) REFERENCES `stadion` (`idStadion`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utakmica`
--

LOCK TABLES `utakmica` WRITE;
/*!40000 ALTER TABLE `utakmica` DISABLE KEYS */;
INSERT INTO `utakmica` VALUES (6,15,16,3,3,1,_binary ''),(7,15,17,3,1,1,_binary ''),(8,23,24,7,2,1,_binary ''),(9,17,16,4,1,0,_binary ''),(10,15,19,3,0,0,_binary '\0');
/*!40000 ALTER TABLE `utakmica` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-01-13 11:27:08
