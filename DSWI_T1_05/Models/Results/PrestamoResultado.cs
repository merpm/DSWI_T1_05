
namespace DSWI_T1_05.Models.Results
{
    public class PrestamoResultado
    {
        // Monto solicitado por el cliente
        public decimal MontoPrestamo { get; set; }

        // Porcentaje de interes aplicado
        public decimal PorcentajeInteres { get; set; }

        // Importe del interes en dinero
        public decimal MontoInteres { get; set; }

        // Deuda total incluyendo intereses
        public decimal DeudaTotal { get; set; }

        // Cantidad de cuotas a pagar
        public int CantidadCuotas { get; set; }

        // Valor de cada cuota
        public decimal ValorCuota { get; set; }
    }
}
