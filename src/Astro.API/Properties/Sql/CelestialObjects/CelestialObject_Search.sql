SELECT c.Id, c.Designation1
FROM dbo.CelestialObjects c
WHERE CONTAINS((c.Name, c.Designation1, c.Designation2, c.Designation3, c.Designation4), @searchText)