namespace smartcoffe.Domain.Interfaces
{
    public interface IPaymentGatewayService
    {
        // El objetivo es obtener el formToken para el frontend
        Task<string> GeneratePaymentTokenAsync(decimal amount, string currency, string orderId, string customerEmail, string customerId);
    }
}