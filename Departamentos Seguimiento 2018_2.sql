USE [master]
GO
/****** Object:  Database [SucursalCuenta]    ******/
CREATE DATABASE [DepartamentosSeguimiento2018_2] 

GO
USE [DepartamentosSeguimiento2018_2]
GO
/****** Object:  Table [dbo].[Cuenta]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Concepto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Concepto] [varchar] (100) NULL,
 CONSTRAINT [PK_Concepto] PRIMARY KEY (	[Id] )) 
GO

CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Area] [varchar](100) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY ([Id])) 
GO
CREATE TABLE [dbo].[Elemento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdConcepto][int] NOT NULL,	
	[Elemento] [varchar]  (100) NOT NULL unique,
 CONSTRAINT [PK_Elemento] PRIMARY KEY (	[Id]),
 CONSTRAINT [FK_Elemento_Concepto] FOREIGN KEY ([IdConcepto]) REFERENCES [dbo].[Concepto]([Id]))  

GO
CREATE TABLE [dbo].[Elemento_Area](
	
	[IdElemento] [int] NOT NULL,
	[IdArea][int] NOT NULL,		
 CONSTRAINT [PK_Elemento_Area_IdElemento_IdArea] PRIMARY KEY ([IdElemento],[IdArea]),
 CONSTRAINT [FK_Elemento_Area_Elemento] FOREIGN KEY ([IdElemento]) REFERENCES [dbo].[Elemento]([Id]),
 CONSTRAINT [FK_Elemento_Area_Area] FOREIGN KEY ([IdArea]) REFERENCES [dbo].[Area]([Id]))
   
GO
CREATE TABLE [dbo].[Asiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdElemento] [int] NOT NULL,
	[IdArea][int] NOT NULL,	
	[fecha] [date] NOT NULL,
	[Estimado] [money]  NULL,
	[Descuento] [money]  NULL,
	[Real] [money]  NULL,

 CONSTRAINT [PK_Asiento] PRIMARY KEY ([Id]) ,
 CONSTRAINT [FK_Asiento_Elemento_Area] FOREIGN KEY ([IdElemento],[IdArea]) REFERENCES [dbo].[Elemento_Area]([IdElemento],[IdArea])

 )

GO

INSERT INTO [dbo].[Concepto] VALUES ('INGRESOS'),('GASTOS'),('BENEFICIO'),('COBROS'),('PAGOS'),('DIFERENCIA')
GO 


/*Algunas consultas*/

/* qElementosConceptoMesAñoArea */
SELECT e.id, e.elemento, ce.estimado,ce.descuento,ce.real, ce.id FROM asiento as ce 
INNER JOIN Elemento AS e ON e.Id=ce.IdElemento 
WHERE e.IdConcepto like '1' AND Month(ce.fecha) LIKE '5'  AND Year(ce.fecha) LIKE '2018' AND ce.idarea like '1'

/*Acumulado ingresos año*/
SELECT sum(a.real) FROM asiento AS a 
INNER JOIN Elemento AS e ON E.Id=a.IdElemento
WHERE e.IdConcepto = 1  AND Year(a.fecha) LIKE '2018'


/*Totales por concepto mes y año*/
SELECT sum(a.estimado),sum(a.descuento),sum(a.real) FROM asiento AS a 
INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO
WHERE E.IdConcepto = 1/* @idconcepto*/ AND MONTH(a.fecha) like 1/*@mes*/ AND Year(a.fecha) LIKE /*@año*/'2018'



