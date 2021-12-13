using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Threading.Tasks;
using PrometheusAppWebApi.Repository.Abstract;

namespace PrometheusAppWebApi.Controllers
{
    // Url yazılırken api/controllers şeklinde yazılacak şekilde ayarlandı
    [Route("api/{controller}s")]
    [ApiController]
    public class UserController : Controller
    {
        // CRUD işlemlerini gerçekleştirecek metodların tanımlandığı interface çağırılıyor.
        // Namespace'i PrometheusAppWebApi.Repository.Abstract
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        // Tüm kullanıcıların getirileceği action metodu
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await userRepository.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Kullanıcıları getirme işlemi gerçekleştirilirken hata oluştu.");
            }
        }

        // Tek bir kullanıcının getirileceği action metodu
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await userRepository.GetUser(id);

                if (result == null)
                {
                    return NotFound($"{id} numaralı id'ye ait kullanıcı bulunamadı.");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Kullanıcıyı getirme işlemi gerçekleştirilirken hata oluştu.");
            }
        }

        // Kullanıcı eklemenin gerçekleştirileceği action metodu
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Eklenilecek kullanıcı bulunamadı");
                }

                var alreadyUser = await userRepository.GetUserByEmail(user.Email);

                // Kullanıcının emaili zaten başkası tarafından kullanılıyorsa mesaj yollanıyor.
                if (alreadyUser != null)
                {
                    ModelState.AddModelError("Email", "Bu e-mail zaten kullanılıyor.");
                }

                var createdUser = await userRepository.AddUser(user);
                return Ok(createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ekleme işlemi gerçekleştirilirken hata oluştu.");
            }
        }

        // Kullanıcı güncellemenin gerçekleştirileceği action metodu
        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                if (id != user.UserId)
                {
                    return BadRequest("Id'ler birbirleriyle eşleşmiyor.");
                }

                var userForUpdate = await userRepository.GetUser(id);

                if (userForUpdate == null)
                {
                    return NotFound($"{id} numaralı id'ye ait kullanıcı bulunamadı.");
                }

                return await userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Güncelleme işlemi gerçekleştirilirken hata oluştu.");
            }
        }

        // Kullanıcı silmenin gerçekleştirileceği action metodu
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await userRepository.GetUser(id);

                if (user == null)
                {
                    return NotFound($"{id} numaralı id'ye ait kullanıcı bulunamadı");
                }

                await userRepository.DeleteUser(id);

                return Ok($"{id} numaralı id'ye ait kullanıcı silindi.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Silme işlemi gerçekleştirilirken hata oluştu.");
            }
        }
    }
}
