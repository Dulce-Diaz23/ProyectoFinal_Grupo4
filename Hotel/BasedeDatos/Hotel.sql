SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

ALTER SCHEMA `hotelbd`  DEFAULT CHARACTER SET utf8  DEFAULT COLLATE utf8_general_ci ;

ALTER TABLE `hotelbd`.`Factura` 
DROP FOREIGN KEY `FK_Factura_Cliente`,
DROP FOREIGN KEY `FK_Factura_Usuario`;

ALTER TABLE `hotelbd`.`DetalleFactura` 
DROP FOREIGN KEY `FK_DetalleFactura_Factura`,
DROP FOREIGN KEY `FK_DetalleFactura_Habitacion`;

ALTER TABLE `hotelbd`.`Usuario` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `hotelbd`.`Habitacion` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `hotelbd`.`Cliente` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `Identidad` `Identidad` NVARCHAR(30) NOT NULL ,
CHANGE COLUMN `Nombre` `Nombre` NVARCHAR(60) NOT NULL ,
CHANGE COLUMN `Direccion` `Direccion` NVARCHAR(100) NOT NULL ,
CHANGE COLUMN `Email` `Email` NVARCHAR(60) NULL ,
CHANGE COLUMN `Telefono` `Telefono` NVARCHAR(20) NOT NULL ;

ALTER TABLE `hotelbd`.`Factura` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `IdentidadCliente` `IdentidadCliente` NVARCHAR(30) NOT NULL ;

ALTER TABLE `hotelbd`.`DetalleFactura` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `hotelbd`.`Factura` 
ADD CONSTRAINT `FK_Factura_Cliente`
  FOREIGN KEY (`IdentidadCliente`)
  REFERENCES `hotelbd`.`Cliente` (`Identidad`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `FK_Factura_Usuario`
  FOREIGN KEY (`CodigoUsuario`)
  REFERENCES `hotelbd`.`Usuario` (`Codigo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `hotelbd`.`DetalleFactura` 
ADD CONSTRAINT `FK_DetalleFactura_Factura`
  FOREIGN KEY (`IdFactura`)
  REFERENCES `hotelbd`.`Factura` (`Id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `FK_DetalleFactura_Habitacion`
  FOREIGN KEY (`CodigoHabitacion`)
  REFERENCES `hotelbd`.`Habitacion` (`Codigo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
