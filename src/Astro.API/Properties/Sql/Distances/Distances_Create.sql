INSERT INTO dbo.Distances
(
	CelestialObjectId,
	DistanceType,
	Value,
	Tolerance
)
VALUES
(
	@CelestialObjectId,
	@DistanceType,
	@Value,
	@Tolerance
)