
-- usp_Pacientes_Listar.sql
CREATE OR ALTER PROCEDURE dbo.usp_Pacientes_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PacienteID, Nombre, DNI
    FROM dbo.Pacientes
    ORDER BY PacienteID;
END;
GO
