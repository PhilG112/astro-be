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
	Name VARCHAR(40) NULL,
	Designation1 VARCHAR(30) NOT NULL,
	Designation2 VARCHAR(30) NULL,
	Designation3 VARCHAR(30) NULL,
	Designation4 VARCHAR(30) NULL,
	Description TEXT NULL,
	CONSTRAINT PK_CelestialObjects_Id PRIMARY KEY CLUSTERED (Id)
)
GO
CREATE NONCLUSTERED INDEX IDX_Designation1 ON dbo.CelestialObjects (Designation1)
GO
CREATE NONCLUSTERED INDEX IDX_Name ON dbo.CelestialObjects (Name)
GO
-- Object: Table dbo.Distance
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Distances
(
	CelestialObjectId INT NOT NULL,
	DistanceType VARCHAR(20) NOT NULL,
	Value DECIMAL(10,2) NOT NULL,
	Tolerance DECIMAL(5,2) NULL,
	CONSTRAINT FK_CelesstialObjects_Id FOREIGN KEY (CelestialObjectId) REFERENCES dbo.CelestialObjects (Id) ON DELETE CASCADE
)
GO
CREATE CLUSTERED INDEX IDX_CelestialObjectId on dbo.Distances (CelestialObjectId)