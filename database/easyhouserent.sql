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
CREATE SCHEMA IF NOT EXISTS `easyhouserent` DEFAULT CHARACTER SET utf8mb4 ;
USE `easyhouserent` ;

-- -----------------------------------------------------
-- Table `easyrenthoouse`.`departamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`departamento` (
  `iddepartamento` INT(11) NOT NULL,
  `nombre` CHAR(100) NOT NULL,
  PRIMARY KEY (`iddepartamento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `easyrenthoouse`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`usuarios` (
  `idUsuarios` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` CHAR(80) NOT NULL,
  `apellidos` CHAR(80) NOT NULL,
  `fechaNacimiento` DATE NOT NULL,
  `telefono` INT(11) NOT NULL,
  `email` VARCHAR(120) NOT NULL,
  `contraseña` VARBINARY(200) NOT NULL,
  `estado` CHAR(1) NOT NULL,
  `iddepartamento` INT(11) NOT NULL,
  PRIMARY KEY (`idUsuarios`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  INDEX `iddepartamento_idx` (`iddepartamento` ASC) VISIBLE,
  CONSTRAINT `iddepartamento`
    FOREIGN KEY (`iddepartamento`)
    REFERENCES `easyhouserent`.`departamento` (`iddepartamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `easyrenthoouse`.`tipoestructura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`tipoestructura` (
  `idtipoEstructura` INT(11) NOT NULL,
  `nombre` CHAR(100) NOT NULL,
  PRIMARY KEY (`idtipoEstructura`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `easyrenthoouse`.`anuncios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`anuncios` (
  `idanuncios` INT(11) NOT NULL AUTO_INCREMENT,
  `idusuario` INT(11) NOT NULL,
  `titulo` CHAR(80) NOT NULL,
  `descripcion` VARCHAR(3000) NOT NULL,
  `puntuacion` INT(11) NOT NULL,
  `direccion` VARCHAR(150) NOT NULL,
  `estado` CHAR(1) NOT NULL,
  `tipoEstructura` INT(11) NOT NULL,
  `valor` FLOAT NOT NULL,
  `fecha` DATE NOT NULL,
  `certificado` VARCHAR(500) NOT NULL,
  `fotos` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`idanuncios`),
  INDEX `idusuario_idx` (`idusuario` ASC) VISIBLE,
  INDEX `tipoEstructura_idx` (`tipoEstructura` ASC) VISIBLE,
  CONSTRAINT `idusuario`
    FOREIGN KEY (`idusuario`)
    REFERENCES `easyhouserent`.`usuarios` (`idUsuarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `tipoEstructura`
    FOREIGN KEY (`tipoEstructura`)
    REFERENCES `easyhouserent`.`tipoestructura` (`idtipoEstructura`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `easyhouserent`.`oferta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`oferta` (
  `idoferta` INT(11) NOT NULL,
  `idanuncio` INT(11) NULL DEFAULT NULL,
  `idusuario` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idoferta`),
  INDEX `idanuncio_idx` (`idanuncio` ASC) VISIBLE,
  INDEX `idusuario_idx` (`idusuario` ASC) VISIBLE,
  CONSTRAINT `anuncio`
    FOREIGN KEY (`idanuncio`)
    REFERENCES `easyhouserent`.`anuncios` (`idanuncios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `oferta`
    FOREIGN KEY (`idusuario`)
    REFERENCES `easyhouserent`.`usuarios` (`idUsuarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
