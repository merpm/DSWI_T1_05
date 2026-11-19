
-- usp_Citas_Editar.sql
CREATE OR ALTER PROCEDURE dbo.usp_Citas_Editar
    @CitaID INT,
    @Fecha DATE,
    @Hora TIME,
    @Especialidad NVARCHAR(50),
    @Estado NVARCHAR(20),
    @PacienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Citas
    SET Fecha = @Fecha,
        Hora = @Hora,
        Especialidad = @Especialidad,
        Estado = @Estado,
        PacienteID = @PacienteID
    WHERE CitaID = @CitaID;

    IF @@ROWCOUNT = 0
        THROW 50002, 'Cita no encontrada.', 1;

    SELECT
        CitaID, Fecha, Hora,
        Especialidad, Estado, PacienteID
    FROM dbo.Citas
    WHERE CitaID = @CitaID;
END;
GO
