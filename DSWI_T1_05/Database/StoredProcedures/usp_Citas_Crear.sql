
-- usp_Citas_Crear.sql
CREATE OR ALTER PROCEDURE dbo.usp_Citas_Crear
    @Fecha DATE,
    @Hora TIME,
    @Especialidad NVARCHAR(50),
    @Estado NVARCHAR(20),
    @PacienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Citas
        (Fecha, Hora, Especialidad, Estado, PacienteID)
    VALUES
        (@Fecha, @Hora, @Especialidad, @Estado, @PacienteID);

    SELECT
        CitaID, Fecha, Hora,
        Especialidad, Estado, PacienteID
    FROM dbo.Citas
    WHERE CitaID = CONVERT(INT, SCOPE_IDENTITY());
END;
GO
