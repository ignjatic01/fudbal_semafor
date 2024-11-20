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
-- Table structure for table `boja`
--

DROP TABLE IF EXISTS `boja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `boja` (
  `idBoja` int NOT NULL AUTO_INCREMENT,
  `primarnaBoja` char(7) NOT NULL,
  `sekundarnaBoja` char(7) DEFAULT NULL,
  PRIMARY KEY (`idBoja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `boja`
--

LOCK TABLES `boja` WRITE;
/*!40000 ALTER TABLE `boja` DISABLE KEYS */;
/*!40000 ALTER TABLE `boja` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gol`
--

LOCK TABLES `gol` WRITE;
/*!40000 ALTER TABLE `gol` DISABLE KEYS */;
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
  PRIMARY KEY (`idIgrac`),
  KEY `FK_igrac_klub_idx` (`klub`),
  KEY `FK_igrac_pozicija_idx` (`pozicija`),
  CONSTRAINT `FK_igrac_klub` FOREIGN KEY (`klub`) REFERENCES `klub` (`idKlub`),
  CONSTRAINT `FK_igrac_pozicija` FOREIGN KEY (`pozicija`) REFERENCES `pozicija` (`oznakaPozicije`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `igrac`
--

LOCK TABLES `igrac` WRITE;
/*!40000 ALTER TABLE `igrac` DISABLE KEYS */;
/*!40000 ALTER TABLE `igrac` ENABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `izmjena`
--

LOCK TABLES `izmjena` WRITE;
/*!40000 ALTER TABLE `izmjena` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karton`
--

LOCK TABLES `karton` WRITE;
/*!40000 ALTER TABLE `karton` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karton_tip`
--

LOCK TABLES `karton_tip` WRITE;
/*!40000 ALTER TABLE `karton_tip` DISABLE KEYS */;
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
  `boja` int NOT NULL,
  PRIMARY KEY (`idKlub`),
  KEY `FK_klub_boja_idx` (`boja`),
  CONSTRAINT `FK_klub_boja` FOREIGN KEY (`boja`) REFERENCES `boja` (`idBoja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klub`
--

LOCK TABLES `klub` WRITE;
/*!40000 ALTER TABLE `klub` DISABLE KEYS */;
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
  `email` varchar(255) NOT NULL,
  `lozinka` varchar(255) NOT NULL,
  `role` int NOT NULL,
  PRIMARY KEY (`idKorisnik`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `FK_korisnik_role_idx` (`role`),
  CONSTRAINT `FK_korisnik_role` FOREIGN KEY (`role`) REFERENCES `role` (`idRole`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `korisnik`
--

LOCK TABLES `korisnik` WRITE;
/*!40000 ALTER TABLE `korisnik` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stadion`
--

LOCK TABLES `stadion` WRITE;
/*!40000 ALTER TABLE `stadion` DISABLE KEYS */;
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
  PRIMARY KEY (`idUtakmica`),
  KEY `FK_utakmica_domaci_idx` (`domaci`),
  KEY `FK_utakmica_gosti_idx` (`gosti`),
  KEY `FK_utakmica_stadion_idx` (`stadion`),
  CONSTRAINT `FK_utakmica_domaci` FOREIGN KEY (`domaci`) REFERENCES `klub` (`idKlub`),
  CONSTRAINT `FK_utakmica_gosti` FOREIGN KEY (`gosti`) REFERENCES `klub` (`idKlub`),
  CONSTRAINT `FK_utakmica_stadion` FOREIGN KEY (`stadion`) REFERENCES `stadion` (`idStadion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utakmica`
--

LOCK TABLES `utakmica` WRITE;
/*!40000 ALTER TABLE `utakmica` DISABLE KEYS */;
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

-- Dump completed on 2024-11-20 23:15:36
