using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherControllercs : ControllerBase
    {
        private WeatherDbContext _dbContext;
        public WeatherControllercs(WeatherDbContext weatherDbContext)
        {
            _dbContext = weatherDbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _dbContext.WeatherForecast.ToList();
        }

        [HttpGet("{city}")]
        public ActionResult<WeatherForecast> GetByCity(string city)
        {
            var forecast = _dbContext.WeatherForecast.FirstOrDefault(x => x.City == city);
            if (forecast == null) return NotFound();

            return Ok(forecast);
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast forecast)
        {
            _dbContext.WeatherForecast.Add(forecast);
            _dbContext.SaveChanges();

            return Ok(forecast);
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var forecast = _dbContext.WeatherForecast.FirstOrDefault(x => x.Id == id);
            if (forecast == null) return NotFound();


            _dbContext.WeatherForecast.Remove(forecast);
                _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{city}")]
        public IActionResult Delete(string city)
        {
            var forecast = _dbContext.WeatherForecast.FirstOrDefault(x => x.City == city);
            if (forecast == null) return NotFound();


            _dbContext.WeatherForecast.Remove(forecast);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
