using Microsoft.AspNetCore.Mvc;

namespace DesarrolloAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> ListItem = new List<User>()
        {
            new User()
            {
                Name= "Juan",
                LastName = "Perez",
                Id = 1,
                Address = "Calle 1",
                Phone = "123456789",
                BirthDate = DateTime.Now
            },
            new User()
            {
                Name= "Pedro",
                LastName = "Jaramillo",
                Id = 2,
                Address = "Calle 2",
                Phone = "123456789",
                BirthDate = DateTime.Now
            },
            new User()
            {
                Name= "Maria",
                LastName = "Gomez",
                Id = 3,
                Address = "Calle 3",
                Phone = "123456789",
                BirthDate = DateTime.Now
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return ListItem;
        }

        [HttpGet("{id}")]
        public dynamic Detail(int id)
        {
            //var hdr_key = Request.Headers["key_app"];
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API ERROR",
                    message = "No esta autorizado",
                    Detail = "N/A"
                });
            }
            else
            {
                if (hdr_key.Value != "x1234")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        code = "API ERROR",
                        message = "Key invalido",
                        Detail = "N/A"
                    });
                }
            }

            var item = ListItem.Where(x => x.Id == id).ToList();
            if (item.Count > 0)
            {
                if (id == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        Data = item,
                        code = "OK",
                        message = "Respuesta Exitosa",
                        Detail = "N/A"
                    });
                }
                else
                {
                    return item;
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, new
                {
                    code = "API COUNT",
                    message = "No existen registros",
                    Detail = "N/A"
                });
            }
        }

        [HttpPost]
        public dynamic Create([FromBody] User user)
        {
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API ERROR",
                    message = "No esta autorizado",
                    Detail = "N/A"
                });
            }
            else
            {
                if (hdr_key.Value != "x1234")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        code = "API ERROR",
                        message = "Key invalido",
                        Detail = "N/A"
                    });
                }
            }

            ListItem.Add(user);
            return StatusCode(StatusCodes.Status201Created, new
            {
                code = "API CREATE",
                message = "Registro creado",
                Detail = "N/A"
            });
        }

        [HttpPut("{id}")]
        public dynamic Update(int id, [FromBody] User user)
        {
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API ERROR",
                    message = "No esta autorizado",
                    Detail = "N/A"
                });
            }
            else
            {
                if (hdr_key.Value != "x1234")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        code = "API ERROR",
                        message = "Key invalido",
                        Detail = "N/A"
                    });
                }
            }

            var item = ListItem.Where(x => x.Id == id).ToList();
            if (item.Count > 0)
            {
                ListItem.Remove(item[0]);
                ListItem.Add(user);
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "API UPDATE",
                    message = "Registro actualizado",
                    Detail = "N/A"
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, new
                {
                    code = "API COUNT",
                    message = "No existen registros",
                    Detail = "N/A"
                });
            }
        }

        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
            var hdr_key = Request.Headers.Where(x => x.Key.Equals("key_app")).FirstOrDefault();

            if (hdr_key.Value.Count == 0)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    code = "API ERROR",
                    message = "No esta autorizado",
                    Detail = "N/A"
                });
            }
            else
            {
                if (hdr_key.Value != "x1234")
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new
                    {
                        code = "API ERROR",
                        message = "Key invalido",
                        Detail = "N/A"
                    });
                }
            }

            var item = ListItem.Where(x => x.Id == id).ToList();
            if (item.Count > 0)
            {
                ListItem.Remove(item[0]);
                return StatusCode(StatusCodes.Status200OK, new
                {
                    code = "API DELETE",
                    message = "Registro eliminado",
                    Detail = "N/A"
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, new
                {
                    code = "API COUNT",
                    message = "No existen registros",
                    Detail = "N/A"
                });
            }
        }
    }
}

