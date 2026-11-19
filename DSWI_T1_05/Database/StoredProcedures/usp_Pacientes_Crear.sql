
-- usp_Pacientes_Crear.sql
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Crear
    @Nombre NVARCHAR(100),
    @DNI NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Pacientes (Nombre, DNI)
    VALUES (@Nombre, @DNI);

    SELECT
        PacienteID, Nombre, DNI
    FROM dbo.Pacientes
    WHERE PacienteID = CONVERT(INT, SCOPE_IDENTITY());
END;
GO
