using Core.Interfaces;
using Core.models;
using Core.models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepoUser _RepoUser;
        protected DtoResponse _reponse;
        public UserController(IRepoUser RepoUser)
        {
            _RepoUser = RepoUser;
            _reponse = new DtoResponse();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(userDto user)
        {
            var respuesta = await _RepoUser.Register(new user
            {
                userName = user.userName
            }, user.password);


            if (respuesta == -1)
            {
                _reponse.message = "Usuario ya existe";
                return BadRequest(_reponse);
            }

            if (respuesta == -500)
            {
                _reponse.message = "Error al crear el usuario";
            }

            _reponse.message = "Usuario creado con exito";
            _reponse.results = respuesta;

            return Ok(_reponse);

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Post([FromBody] userDto user)
        {
            var respuesta = await _RepoUser.login(user.userName, user.password);

            if (respuesta == "nouser")
            {
                _reponse.message = "No existe el usuario";
                _reponse.statusCode = 404;
                return Ok(_reponse);
            }

            _reponse.message = "se ha logeado con exito";
            _reponse.results = respuesta;
            _reponse.statusCode = 200;

            return Ok(_reponse);
        }
    }
}
