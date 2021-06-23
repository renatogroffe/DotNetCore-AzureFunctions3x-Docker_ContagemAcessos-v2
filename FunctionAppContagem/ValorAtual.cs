using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FunctionAppContagem.Models;

namespace FunctionAppContagem
{
    public class ValorAtual
    {
        private Contador _contador;

        public ValorAtual(Contador contador)
        {
            _contador = contador;
        }

        [FunctionName("ValorAtual")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Requisição HTTP recebida...");

            int valorAtualContador;
            lock (_contador)
            {
                _contador.Incrementar();
                valorAtualContador = _contador.ValorAtual;
            }

            log.LogInformation($"Contador - Valor atual: {valorAtualContador}");

            return new OkObjectResult(new ResultadoContador(valorAtualContador));
        }
    }
}