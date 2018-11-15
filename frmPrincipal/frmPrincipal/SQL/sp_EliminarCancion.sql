USE BulletProofRecords
GO

CREATE PROCEDURE sp_EliminarCancion
(
	@nombre NVARCHAR(200)
)
AS
BEGIN
	DECLARE @cancionId INT
	SELECT @cancionId = id
	FROM Music.Cancion
	WHERE Nombre = @nombre

	DELETE FROM Music.Cancion WHERE id = @cancionId

END