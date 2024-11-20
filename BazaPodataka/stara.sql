-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema fudbal_semafor
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema fudbal_semafor
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `fudbal_semafor` DEFAULT CHARACTER SET utf8 ;
USE `fudbal_semafor` ;

-- -----------------------------------------------------
-- Table `fudbal_semafor`.`role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`role` (
  `idRole` INT NOT NULL AUTO_INCREMENT,
  `nazivRole` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idRole`),
  UNIQUE INDEX `naziv_role_UNIQUE` (`nazivRole` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`korisnik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`korisnik` (
  `idKorisnik` INT NOT NULL AUTO_INCREMENT,
  `ime` VARCHAR(50) NOT NULL,
  `prezime` VARCHAR(50) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `lozinka` VARCHAR(255) NOT NULL,
  `role` INT NOT NULL,
  PRIMARY KEY (`idKorisnik`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  INDEX `FK_korisnik_role_idx` (`role` ASC) VISIBLE,
  CONSTRAINT `FK_korisnik_role`
    FOREIGN KEY (`role`)
    REFERENCES `fudbal_semafor`.`role` (`idRole`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`pozicija`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`pozicija` (
  `oznakaPozicije` VARCHAR(5) NOT NULL,
  `nazivPozicije` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`oznakaPozicije`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`boja`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`boja` (
  `idBoja` INT NOT NULL AUTO_INCREMENT,
  `primarnaBoja` CHAR(7) NOT NULL,
  `sekundarnaBoja` CHAR(7) NULL,
  PRIMARY KEY (`idBoja`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`klub`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`klub` (
  `idKlub` INT NOT NULL AUTO_INCREMENT,
  `nazivKluba` VARCHAR(100) NOT NULL,
  `grad` VARCHAR(100) NOT NULL,
  `boja` INT NOT NULL,
  PRIMARY KEY (`idKlub`),
  INDEX `FK_klub_boja_idx` (`boja` ASC) VISIBLE,
  CONSTRAINT `FK_klub_boja`
    FOREIGN KEY (`boja`)
    REFERENCES `fudbal_semafor`.`boja` (`idBoja`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`igrac`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`igrac` (
  `idIgrac` INT NOT NULL AUTO_INCREMENT,
  `ime` VARCHAR(50) NOT NULL,
  `prezime` VARCHAR(50) NOT NULL,
  `brojDresa` INT NOT NULL,
  `klub` INT NOT NULL,
  `pozicija` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`idIgrac`),
  INDEX `FK_igrac_klub_idx` (`klub` ASC) VISIBLE,
  INDEX `FK_igrac_pozicija_idx` (`pozicija` ASC) VISIBLE,
  CONSTRAINT `FK_igrac_klub`
    FOREIGN KEY (`klub`)
    REFERENCES `fudbal_semafor`.`klub` (`idKlub`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_igrac_pozicija`
    FOREIGN KEY (`pozicija`)
    REFERENCES `fudbal_semafor`.`pozicija` (`oznakaPozicije`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`stadion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`stadion` (
  `idStadion` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(100) NOT NULL,
  `grad` VARCHAR(100) NULL,
  `kapacitet` INT NOT NULL,
  `podloga` VARCHAR(100) NULL,
  PRIMARY KEY (`idStadion`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`utakmica`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`utakmica` (
  `idUtakmica` INT NOT NULL AUTO_INCREMENT,
  `domaci` INT NOT NULL,
  `gosti` INT NOT NULL,
  `stadion` INT NULL,
  `goloviDomaci` INT NOT NULL,
  `goloviGosti` INT NOT NULL,
  PRIMARY KEY (`idUtakmica`),
  INDEX `FK_utakmica_domaci_idx` (`domaci` ASC) VISIBLE,
  INDEX `FK_utakmica_gosti_idx` (`gosti` ASC) VISIBLE,
  INDEX `FK_utakmica_stadion_idx` (`stadion` ASC) VISIBLE,
  CONSTRAINT `FK_utakmica_domaci`
    FOREIGN KEY (`domaci`)
    REFERENCES `fudbal_semafor`.`klub` (`idKlub`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_utakmica_gosti`
    FOREIGN KEY (`gosti`)
    REFERENCES `fudbal_semafor`.`klub` (`idKlub`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_utakmica_stadion`
    FOREIGN KEY (`stadion`)
    REFERENCES `fudbal_semafor`.`stadion` (`idStadion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`gol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`gol` (
  `idGol` INT NOT NULL AUTO_INCREMENT,
  `utakmica` INT NOT NULL,
  `klub` INT NOT NULL,
  `igrac` INT NOT NULL,
  `minut` INT NOT NULL,
  PRIMARY KEY (`idGol`),
  INDEX `FK_gol_utakmica_idx` (`utakmica` ASC) VISIBLE,
  INDEX `FK_gol_klub_idx` (`klub` ASC) VISIBLE,
  INDEX `FK_gol_igrac_idx` (`igrac` ASC) VISIBLE,
  CONSTRAINT `FK_gol_utakmica`
    FOREIGN KEY (`utakmica`)
    REFERENCES `fudbal_semafor`.`utakmica` (`idUtakmica`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_gol_klub`
    FOREIGN KEY (`klub`)
    REFERENCES `fudbal_semafor`.`klub` (`idKlub`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_gol_igrac`
    FOREIGN KEY (`igrac`)
    REFERENCES `fudbal_semafor`.`igrac` (`idIgrac`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`izmjena`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`izmjena` (
  `idIzmjena` INT NOT NULL AUTO_INCREMENT,
  `igracUlazi` INT NOT NULL,
  `igracIzlazi` INT NOT NULL,
  `utakmica` INT NOT NULL,
  `minut` INT NOT NULL,
  PRIMARY KEY (`idIzmjena`),
  INDEX `FK_izmjena_igracUlazi_idx` (`igracUlazi` ASC) VISIBLE,
  INDEX `FK_izmjena_igracIzlazi_idx` (`igracIzlazi` ASC) VISIBLE,
  INDEX `FK_izmjena_utakmica_idx` (`utakmica` ASC) VISIBLE,
  CONSTRAINT `FK_izmjena_igracUlazi`
    FOREIGN KEY (`igracUlazi`)
    REFERENCES `fudbal_semafor`.`igrac` (`idIgrac`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_izmjena_igracIzlazi`
    FOREIGN KEY (`igracIzlazi`)
    REFERENCES `fudbal_semafor`.`igrac` (`idIgrac`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_izmjena_utakmica`
    FOREIGN KEY (`utakmica`)
    REFERENCES `fudbal_semafor`.`utakmica` (`idUtakmica`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`karton_tip`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`karton_tip` (
  `idKartonTip` INT NOT NULL AUTO_INCREMENT,
  `tip` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idKartonTip`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `fudbal_semafor`.`karton`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fudbal_semafor`.`karton` (
  `idKarton` INT NOT NULL AUTO_INCREMENT,
  `kartonTip` INT NOT NULL,
  `igrac` INT NOT NULL,
  `utakmica` INT NOT NULL,
  `minut` INT NOT NULL,
  PRIMARY KEY (`idKarton`),
  INDEX `FK_karton_kartonTip_idx` (`kartonTip` ASC) VISIBLE,
  INDEX `FK_karton_igrac_idx` (`igrac` ASC) VISIBLE,
  INDEX `FK_karton_utakmica_idx` (`utakmica` ASC) VISIBLE,
  CONSTRAINT `FK_karton_kartonTip`
    FOREIGN KEY (`kartonTip`)
    REFERENCES `fudbal_semafor`.`karton_tip` (`idKartonTip`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_karton_igrac`
    FOREIGN KEY (`igrac`)
    REFERENCES `fudbal_semafor`.`igrac` (`idIgrac`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_karton_utakmica`
    FOREIGN KEY (`utakmica`)
    REFERENCES `fudbal_semafor`.`utakmica` (`idUtakmica`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
