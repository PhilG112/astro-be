USE [Astro]
GO
-- Object: Table dbo.CelestialObjects
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.CelestialObjects
(
	Id INT IDENTITY(1,1),
	ObjectType VARCHAR(25) NOT NULL,
	Magnitude DECIMAL(4,2) NOT NULL,
	AbsoluteMagnitude DECIMAL(4,2) NULL,
	Name VARCHAR(20) NULL,
	Designation1 VARCHAR(10) NOT NULL,
	Designation2 VARCHAR(10) NULL,
	Designation3 VARCHAR(10) NULL,
	Designation4 VARCHAR(10) NULL,
	CONSTRAINT PK_CelestialObjects_Id PRIMARY KEY CLUSTERED (Id)
)
GO
CREATE UNIQUE NONCLUSTERED INDEX IDX_Designation1 ON dbo.CelestialObjects (Designation1)