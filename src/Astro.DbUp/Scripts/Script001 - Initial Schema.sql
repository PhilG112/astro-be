IF OBJECT_ID('dbo.CelestialObjects', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.CelestialObjects
	(
		Id INT IDENTITY(1,1),
		ObjectType VARCHAR(25) NOT NULL,
		Magnitude DECIMAL(4,2) NOT NULL,
		AbsoluteMagnitude DECIMAL(4,2) NULL,
		Name VARCHAR(40) NULL,
		Designation1 VARCHAR(60) NOT NULL,
		Designation2 VARCHAR(60) NULL,
		Designation3 VARCHAR(60) NULL,
		Designation4 VARCHAR(60) NULL,
		Description TEXT NULL,
		Distance DECIMAL(20,3) NOT NULL,
		DistanceTolerance DECIMAL(15,3) NULL,
		CONSTRAINT PK_CelestialObjects_Id PRIMARY KEY CLUSTERED (Id),
		INDEX IDX_ObjectType (OBjectType)
	)
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.fulltext_catalogs WHERE [name] = 'CelestialObjects_Catalog')
BEGIN
	CREATE FULLTEXT CATALOG CelestialObjects_Catalog
	CREATE FULLTEXT INDEX ON dbo.CelestialObjects
	(
		Name Language 1033,
		Designation1 Language 1033,
		Designation2 Language 1033,
		Designation3 Language 1033,
		Designation4 Language 1033
	)
	KEY INDEX PK_CelestialObjects_Id ON CelestialObjects_Catalog
    WITH CHANGE_TRACKING = AUTO, STOPLIST = OFF
END
GO

IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.Users
	(
		Id INT IDENTITY(1,1),
		UserName VARCHAR(40) NOT NULL,
		PasswordHash VARCHAR(MAX) NOT NULL,
		Salt VARCHAR(MAX) NOT NULL
	)
	CREATE UNIQUE INDEX IDX_UserName on dbo.Users (UserName)
END