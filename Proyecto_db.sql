CREATE DATABASE Proyecto_db;
USE Proyecto_db;
GO

/* TABLAS */
CREATE TABLE Titulares(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(15) NOT NULL,
	Apellido varchar(15) NOT NULL

);

CREATE TABLE Transacciones(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Id_movimiento int,
	Id_tarjeta int NOT NULL,
	Fecha date NOT NULL
);

CREATE TABLE Movimientos(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Id_tarjeta int REFERENCES tarjetas(Id),
	Monto decimal(7,2) NOT NULL,
	Descripcion varchar(100) NOT NULL,
	Tipo_mov numeric(2) NOT NULL,
	Numero_autorizacion int UNIQUE NOT NULL,
	Fecha date NOT NULL
);

CREATE TABLE Tarjetas(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Id_titular int NOT NULL,
	Numero_tarjeta varchar(16) UNIQUE NOT NULL,
	Saldo_total decimal(10,2),
	Saldo_min decimal(7,2),
	Interes decimal(7,2),
	Pago_min decimal(10,2),
	Total_a_pagar decimal(10,2),
	Interes_bono decimal(10,2)

);



GO

/*LLAVES FORANEAS  */
ALTER TABLE Transacciones
ADD CONSTRAINT FK_Transacciones_Movimientos
FOREIGN KEY (Id_movimiento) REFERENCES Movimientos(Id)ON DELETE CASCADE
    ON UPDATE CASCADE

ALTER TABLE Transacciones
ADD CONSTRAINT FK_Transacciones_Tarjetas
FOREIGN KEY (Id_tarjeta) REFERENCES Tarjetas(Id) ON DELETE CASCADE
    ON UPDATE CASCADE

ALTER TABLE Tarjetas
ADD CONSTRAINT FK_Tarjetas_Titulares
FOREIGN KEY (Id_titular) REFERENCES Titulares(Id)ON DELETE CASCADE
    ON UPDATE CASCADE

GO


/* TRIGERRS */
CREATE TRIGGER trg_CuotaMinima
ON Tarjetas
AFTER INSERT
AS
BEGIN
	UPDATE Tarjetas
	SET Pago_min = i.Saldo_total * i.Saldo_min
	FROM inserted i
	WHERE Tarjetas.Id = i.Id
END;
GO

CREATE TRIGGER trg_InteresBonificable
ON Tarjetas
AFTER INSERT
AS
BEGIN
	UPDATE Tarjetas
	SET Interes_bono = i.Saldo_total * Tarjetas.Interes
	FROM inserted i
	WHERE Tarjetas.Id = i.Id
END;
GO

CREATE TRIGGER trg_TotalAPagar
ON Tarjetas
AFTER INSERT
AS
BEGIN
	UPDATE t
	SET Total_a_pagar = t.Saldo_total + ISNULL(
	(
		SELECT SUM(m.Monto)
		FROM Transacciones tr
		INNER JOIN Movimientos m ON tr.Id_movimiento = m.Id
		WHERE tr.Id_tarjeta = t.Id
	), 0
	)
	FROM Tarjetas t
	INNER JOIN inserted i ON t.Id = i.Id

END;
GO





/* TITULARES */
INSERT INTO Titulares(Nombre, Apellido) VALUES ('GUSTAVO','SOSA'),
('JOSE','HERNANDEZ'),
('DANIEL','CARRANZA'),
('EDWIN','MENDOZA'),
('MICHELLE','CALDERON'),
('SANDRA','ROSALES'),
('MAYRA','SOSA'),
('VICTOR','ZELADA'),
('ALEXANDRA','PADILLA'),
('ALISSON','MORALES')
GO

/* TARJETAS */
insert into Tarjetas(Id_titular,Numero_tarjeta,Saldo_total ,Saldo_min,Interes)
VALUES (1,4345658421459865,12000 / 12, 0.05,0.25),
(2,4354658215724589,23000/12,0.05,0.25),
(3,4312659845321546,45000/12,0.15,0.35),
(4,4346548759216548,30000/12,0.25,0.15),
(5,4312987548659216,52000/12,0.15,0.40),
(6,4365981837496515,12000/12,0.05,0.25),
(7,4300156409876408,70000/12,0.25,0.35),
(8,4365059837089105,60000/12,0.15,0.40),
(9,4325068072195064,35000/12,0.05,0.25),
(10,4352460897310645,70000/12,0.50,0.25)
GO

/* PAGOS */
INSERT INTO Movimientos(Id_tarjeta,Monto,Descripcion,Tipo_mov,Numero_autorizacion,Fecha)
VALUES (400,1,'Pago TC',1,64542384,'2024-07-02'),
(250,1,'Pago TC',1,3211864,'2024-07-04'),
(325,2,'Pago TC',1,6542384,'2024-07-04'),
(500,2,'Pago TC',1,65423189,'2024-07-15'),
(25.00,1,'Pago TC',1,6542175,'2024-07-15'),
(455.50,3,'Pago TC',1,6543219,'2024-07-17'),
(640,4,'Pago TC',1,987651328,'2024-08-05'),
(65.00,1,'Pago TC',1,65431897,'2024-08-08'),
(400,4,'Pago TC',1,987349612,'2024-08-12'),
(465,5,'Pago TC',1,45638967,'2024-08-14'),
(784,5,'Pago TC',1,56423789,'2024-08-15'),
(540,2,'Pago TC',1,65432179,'2024-08-16')
GO


/* COMPRAS */

INSERT INTO Movimientos(Id_tarjeta,Monto,Descripcion,Tipo_mov,Numero_autorizacion,Fecha)
VALUES (50.00,1,'Ropa',2,24542384,'2024-07-03'),
(350,2,'Compras de cumpleaneos',2,3211874,'2024-07-05'),
(300,3,'Viaje a mexico',2,3544374,'2024-07-05'),
(25,1,'Comida',2,65443119,'2024-07-16'),
(25,1,'Cena',2,4564175,'2024-07-16'),
(225.25,4,'Mejoras para pc',2,22143219,'2024-07-18'),
(120.25,2,'Figuras',2,941851128,'2024-08-06'),
(55,3,'Juego',2,12431897,'2024-08-09'),
(200,5,'Salida familiar',2,945349412,'2024-08-13'),
(320,4,'Mecanico',2,45238967,'2024-08-15'),
(500,2,'Viaje a peru',2,16423789,'2024-08-16'),
(25,1,'Suscripcion',2,63431779,'2024-08-17')






/* Transascciones */

INSERT INTO Transacciones 
VALUES (13,1,'2024-07-03'),
(14,1,'2024-07-05'),
(15,2,'2024-07-05'),
(17,2,'2024-07-16'),
(16,1,'2024-07-16'),
(19,3,'2024-08-06'),
(18,3,'2024-07-18'),
(22,4,'2024-08-15'),
(20,5,'2024-08-09'),
(21,4,'2024-08-13'),
(5,1,'2024-07-15'),
(7,2,'2024-08-05'),
(6,2,'2024-07-17'),
(9,4,'2024-08-12'),
(10,5,'2024-08-14'),
(5,4,'2024-07-15'),
(4,2,'2024-07-15'),
(21,6,'2024-08-13')
GO


Select * from Transacciones

Select * from Tarjetas

DELETE FROM Tarjetas WHERE Id = 3
	


