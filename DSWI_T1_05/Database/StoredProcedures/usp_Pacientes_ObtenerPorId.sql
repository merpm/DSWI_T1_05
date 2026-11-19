
-- usp_Pacientes_ObtenerPorId.sql
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_ObtenerPorId
    @PacienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PacienteID, Nombre, DNI
    FROM dbo.Pacientes
    WHERE PacienteID = @PacienteID;
END;
GO
