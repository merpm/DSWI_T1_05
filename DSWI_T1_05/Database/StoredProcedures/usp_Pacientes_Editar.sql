
-- usp_Pacientes_Editar.sql
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Editar
    @PacienteID INT,
    @Nombre NVARCHAR(100),
    @DNI NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Pacientes
    SET Nombre = @Nombre,
        DNI = @DNI
    WHERE PacienteID = @PacienteID;

    IF @@ROWCOUNT = 0
        THROW 50001, 'Paciente no encontrado.', 1;

    SELECT PacienteID, Nombre, DNI
    FROM dbo.Pacientes
    WHERE PacienteID = @PacienteID;
END;
GO
