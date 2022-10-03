using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AnubusAutharizationStub.Controllers
{
    [ApiController]
    [Route("UsersStub")]
    public class UsersStubController : Controller
    {
        private readonly ILogger<UsersStubController> _logger;
        private readonly IDbContextFactory<AuthStubDbContext> _dbContextFactory;

        public UsersStubController(ILogger<UsersStubController> logger, IDbContextFactory<AuthStubDbContext> dbContextFactory)
        {
            _logger = logger;
            this._dbContextFactory = dbContextFactory;
        }

        [HttpGet(Name = "User")]
        public async Task<IActionResult> Get(string login)
        {
            using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
            var user = dbContext.UsersStub.FirstOrDefaultAsync(x => x.Login == login);

            if (user == null)
                return NotFound("Пользователь ненайден");

            return Json(user);
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(string login, string name, string[] roles)
        {
            using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
            var user = new UserStub 
            { 
                Login = login,
                Name = name,
                Roles = roles
            };

            dbContext.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}