UPDATE dbo.Distances
SET
	DistanceType = @DistanceType,
	Value = @Value,
	Tolerance = @Tolerance
WHERE CelestialObjectId = @CelestialObjectId