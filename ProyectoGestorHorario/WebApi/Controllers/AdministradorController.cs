using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        public AdministradorDAO administradorDAO = new AdministradorDAO();

        [HttpPost("admin")]
        public string login([FromBody] Administrador administrador)
        {
            return administradorDAO.login(administrador.Correo, administrador.Contrasenia);
        }
    }
}
