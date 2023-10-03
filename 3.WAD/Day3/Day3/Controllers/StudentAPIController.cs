using Day3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentAPIController : ControllerBase
    {
        /*[HttpGet]
        public List<Student> Get()
        {
            return new List<Student> {
                new Student { Id= 1, Name="Tuong",Email="cattuongw2001@gmail.com"},
                new Student { Id= 2, Name="DI",Email="cattuongw2002@gmail.com"},
                new Student { Id= 3, Name="Coffee",Email="cattuongw2003@gmail.com"},
            };
        }*/
    }
}
