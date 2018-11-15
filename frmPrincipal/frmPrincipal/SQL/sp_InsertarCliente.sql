USE BulletProofRecords 
GO

CREATE PROCEDURE sp_InsertarCancion
(
	@NombreCancion NVARCHAR(200),
	@NombreArtista NVARCHAR(200),
	@NombreAlbum NVARCHAR(200),
	@Genero NVARCHAR(100),
	@AñoCreacion NVARCHAR(4)
)
AS
BEGIN
	DECLARE @idArtista INT,
			@idAlbum INT

	SELECT @idArtista = id
	FROM	Music.Artista
	WHERE	Nombre = @NombreArtista

	SELECT @idAlbum = id
	FROM	Music.Album
	WHERE	Nombre = @NombreAlbum

	INSERT INTO Music.Cancion(Nombre,Artista,Album,Genero,AñoCreacion)
			VALUES(@NombreCancion,@idArtista,@idAlbum,@Genero,@AñoCreacion)

END


