
-- usp_Citas_Listar.sql
CREATE OR ALTER PROCEDURE dbo.usp_Citas_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CitaID, Fecha, Hora,
        Especialidad, Estado, PacienteID
    FROM dbo.Citas
    ORDER BY CitaID;
END;
GO
