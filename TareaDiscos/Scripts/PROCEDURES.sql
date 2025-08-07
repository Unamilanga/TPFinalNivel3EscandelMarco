CREATE PROCEDURE storeAgregar
@Codigo VARCHAR(50),
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(150),
    @IdMarca INT,
    @IdCategoria INT,
    @ImagenUrl VARCHAR(1000),
    @Precio MONEY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)
    VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio);
END;
GO

CREATE PROCEDURE storeBuscarUser
@email varchar(100),
@contraseña varchar(20) 
AS
BEGIN
select U.email, U.pass, U.nombre, U.apellido, U.urlImagenPerfil, u.id, u.admin from USERS U
where u.email=@email and u.pass=@contraseña
END;
Go

CREATE PROCEDURE StoreCambiarContraseña
@Id int,
@NuevaContraseña varchar(20)
AS
BEGIN
update USERS set pass=@NuevaContraseña where Id=@Id
END;
Go

CREATE PROCEDURE StoreEditarUser
@Nombre varchar(50),
@Apellido varchar(50),
@urlimagen varchar(500),
@id int
AS
BEGIN
 UPDATE USERS SET nombre = @Nombre, apellido=@Apellido, urlImagenPerfil = @urlimagen
 WHERE Id = @Id
END;
Go

CREATE PROCEDURE storeExisteUser
@email varchar(100)
AS
BEGIN
select count(*) from USERS U
where u.email=@email 
END;
Go

CREATE PROCEDURE storeFiltroCodigo
@Codigo varchar(50)

AS
BEGIN

	SELECT 
    A.Id, 
    A.Codigo, 
    A.Nombre, 
    A.Descripcion, 
    M.Descripcion AS Marca, 
    A.IdMarca, 
    C.Descripcion AS Categoria, 
    A.IdCategoria, 
    A.ImagenUrl, 
    A.Precio
FROM ARTICULOS A
INNER JOIN MARCAS M ON A.IdMarca = M.Id
INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
WHERE A.Codigo = @Codigo
END;
Go

CREATE PROCEDURE storelistar
AS
BEGIN
    SELECT 
        A.Id, 
        A.Codigo, 
        A.Nombre, 
        A.Descripcion, 
        M.Descripcion AS Marca, 
        A.IdMarca, 
        C.Descripcion AS Categoria, 
        A.IdCategoria, 
        A.ImagenUrl, 
        A.Precio 
    FROM ARTICULOS A 
    INNER JOIN MARCAS M ON A.IdMarca = M.Id 
    INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id;
END;
GO

CREATE PROCEDURE storeModificar
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(150),
@IdMarca int,
@IdCategoria int,
@ImagenUrl varchar(1000),
@Precio decimal,
@Id int



AS
BEGIN
UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio
WHERE Id = @Id
END;
GO

CREATE PROCEDURE storeNuevoUser
@email VARCHAR(100),
    @contraseña VARCHAR(20)
AS
BEGIN
    INSERT INTO USERS (email, pass)
    VALUES (@email, @contraseña);

    SELECT SCOPE_IDENTITY() AS NuevoId;
END;
GO

CREATE PROCEDURE storeUserEncontrado
@email varchar(100),
@contraseña varchar(20)
AS
BEGIN
select count(*) from USERS U
where u.email=@email and u.pass= @contraseña

END;
GO