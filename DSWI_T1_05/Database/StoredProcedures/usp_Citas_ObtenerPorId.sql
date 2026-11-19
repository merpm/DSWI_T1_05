
-- usp_Citas_ObtenerPorId.sql
CREATE OR ALTER PROCEDURE dbo.usp_Citas_ObtenerPorId
    @CitaID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CitaID, Fecha, Hora,
        Especialidad, Estado, PacienteID
    FROM dbo.Citas
    WHERE CitaID = @CitaID;
END;
GO
