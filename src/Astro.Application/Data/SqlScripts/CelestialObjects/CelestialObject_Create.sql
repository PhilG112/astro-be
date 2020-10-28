﻿INSERT INTO dbo.CelestialObjects
(
	ObjectType,
	Magnitude,
	AbsoluteMagnitude,
	Name,
	Designation1,
	Designation2,
	Designation3,
	Designation4, 
	Description,
	Distance,
	DistanceTolerance
)
VALUES
(
	@ObjectType,
	@Magnitude,
	@AbsoluteMagnitude,
	@Name,
	@Designation1,
	@Designation2,
	@Designation3,
	@Designation4,
	@Description,
	@Distance,
	@DistanceTolerance
);
SELECT CAST (SCOPE_IDENTITY() as INT)