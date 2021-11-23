-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema easyhouserent
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema easyhouserent
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `easyhouserent` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `easyhouserent` ;

-- -----------------------------------------------------
-- Table `easyhouserent`.`departamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`departamento` (
  `iddepartamento` INT NOT NULL AUTO_INCREMENT,
  `nombre` CHAR(100) NOT NULL,
  PRIMARY KEY (`iddepartamento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`usuarios` (
  `idusuario` INT NOT NULL AUTO_INCREMENT,
  `nombre` CHAR(80) NOT NULL,
  `apellidos` CHAR(80) NOT NULL,
  `fechaNacimiento` DATE NOT NULL,
  `telefono` INT NOT NULL,
  `email` VARCHAR(120) NOT NULL,
  `contraseña` VARCHAR(200) NOT NULL,
  `estado` CHAR(1) NOT NULL,
  `departamento` INT NOT NULL,
  PRIMARY KEY (`idusuario`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  INDEX `departamento_idx` (`departamento` ASC) VISIBLE,
  CONSTRAINT `departamento`
    FOREIGN KEY (`departamento`)
    REFERENCES `easyhouserent`.`departamento` (`iddepartamento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`estructura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`estructura` (
  `idtestructura` INT NOT NULL,
  `nombre` CHAR(100) NOT NULL,
  PRIMARY KEY (`idtestructura`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`anuncios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`anuncios` (
  `idanuncio` INT NOT NULL AUTO_INCREMENT,
  `idusuario` INT NOT NULL,
  `titulo` CHAR(80) NOT NULL,
  `descripcion` VARCHAR(3000) NOT NULL,
  `puntuacion` INT NOT NULL,
  `direccion` VARCHAR(150) NOT NULL,
  `estado` CHAR(1) NOT NULL,
  `tipoEstructura` INT NOT NULL,
  `valor` FLOAT NOT NULL,
  `fecha` DATE NOT NULL,
  `certificado` VARCHAR(500) NOT NULL,
  `fotos` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`idanuncio`),
  INDEX `usuarios_idx` (`idusuario` ASC) VISIBLE,
  INDEX `estructura_idx` (`tipoEstructura` ASC) VISIBLE,
  CONSTRAINT `anuncio - usuarios`
    FOREIGN KEY (`idusuario`)
    REFERENCES `easyhouserent`.`usuarios` (`idusuario`),
  CONSTRAINT `estructura`
    FOREIGN KEY (`tipoEstructura`)
    REFERENCES `easyhouserent`.`estructura` (`idtestructura`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`oferta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`oferta` (
  `idoferta` INT NOT NULL,
  `idanuncio` INT NULL DEFAULT NULL,
  `idusuario` INT NULL DEFAULT NULL,
  PRIMARY KEY (`idoferta`),
  INDEX `anuncios_idx` (`idanuncio` ASC) VISIBLE,
  INDEX `usuarios_idx` (`idusuario` ASC) VISIBLE,
  CONSTRAINT `anuncios`
    FOREIGN KEY (`idanuncio`)
    REFERENCES `easyhouserent`.`anuncios` (`idanuncio`),
  CONSTRAINT `usuarios`
    FOREIGN KEY (`idusuario`)
    REFERENCES `easyhouserent`.`usuarios` (`idusuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
