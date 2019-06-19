using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EstresAPI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiEscalador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstresController : ControllerBase
    {
        private readonly EstresController _context;

        #region Propiedades
        public Stopwatch Ejec = new Stopwatch(); /* Tiempo ejecucion*/
        #endregion

        [HttpGet("Saludar")]
        public async Task<IActionResult> Saludar()
        {
            await Task.Delay(5000);
            string mensaje = "Hola soy: " + System.Reflection.Assembly.GetExecutingAssembly().FullName + " delay: Task.Delay(5000);";
            return Ok(mensaje);
        }

        private async Task<string> UnMensajeParalaRAM(string x)
        {
            return "UnMensajeParalaRAM " + x;
        }

        [HttpGet("IncrementarCPU")]
        public async Task<IActionResult> IncrementarCPU([FromQuery] int numero)
        {
            List<string> mersenne = Mersenne.CalcularMersenne(numero);

            Ejec.Start();
            Fibonacci fibonacci = new Fibonacci();
            double resultado = fibonacci.CalcularFiboncciConRecursividad(numero);
            Ejec.Stop();


            return Ok("Resultado cálculo fibonacci: " + resultado + " tiempo ejecución: " + Ejec.Elapsed.ToString() +
                " Resultado cálculo mersenne: " + JsonConvert.SerializeObject(mersenne));
        }
    }
}
