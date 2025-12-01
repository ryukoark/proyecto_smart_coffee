using smartcoffe.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http.Headers;

namespace smartcoffe.Infrastructure.Services
{
    public class IzipayPaymentService : IPaymentGatewayService
    {
        private readonly HttpClient _httpClient;
        private readonly string _username;
        private readonly string _password;
        private readonly string _endpoint;

        public IzipayPaymentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _username = configuration["Izipay:Username"]!;
            _password = configuration["Izipay:Password"]!;
            _endpoint = configuration["Izipay:Endpoint"]!;
        }

        public async Task<string> GeneratePaymentTokenAsync(decimal amount, string currency, string orderId, string email, string userId)
        {
            // 1. Izipay requiere el monto en CENTAVOS (entero). Ej: 10.50 -> 1050
            int amountInCents = (int)(amount * 100);

            // 2. Construir el cuerpo de la petición (Payload)
            var requestBody = new
            {
                amount = amountInCents,
                currency = currency, // "PEN" o "USD"
                orderId = orderId,
                customer = new
                {
                    email = email,
                    reference = userId
                }
            };

            // 3. Configurar Autenticación Basic (Usuario:Password en Base64)
            var authBytes = Encoding.ASCII.GetBytes($"{_username}:{_password}");
            var authString = Convert.ToBase64String(authBytes);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);

            // 4. Enviar la petición POST
            var response = await _httpClient.PostAsJsonAsync(_endpoint, requestBody);

            // 5. Leer respuesta
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Tip: Es bueno loguear 'jsonResponse' aquí para ver por qué falló Izipay
                throw new Exception($"Error Izipay ({response.StatusCode}): {jsonResponse}");
            }

            // 6. Extraer el formToken del JSON
            // La estructura de respuesta es: { "answer": { "formToken": "..." }, "status": "SUCCESS" }
            using var doc = JsonDocument.Parse(jsonResponse);
            if (doc.RootElement.TryGetProperty("answer", out var answer) && 
                answer.TryGetProperty("formToken", out var token))
            {
                return token.GetString()!;
            }

            throw new Exception("No se encontró el formToken en la respuesta de Izipay.");
        }
    }
}