UPDATE dbo.CelestialObjects
SET 
	ObjectType = @ObjectType,
	Magnitude = @Magnitude,
	AbsoluteMagnitude = @AbsoluteMagnitude,
	Name = @Name,
	Designation1 = @Designation1,
	Designation2 = @Designation2,
	Designation3 = @Designation3,
	Designation4 = @Designation4,
	Description = @Description
WHERE Id = @Id