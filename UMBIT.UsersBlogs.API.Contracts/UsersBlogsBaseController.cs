using Microsoft.AspNetCore.Mvc;
using UMBIT.Prototico.Core.API.Controller;

namespace UMBIT.UsersBlogs.API.Contracts
{
    [ApiController]
    [Route("[controller]")]
    public abstract class UsersBlogsBaseController : UMBITControllerBase
    {
    }
}
