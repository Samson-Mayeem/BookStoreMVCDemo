using BookStoreMVCDemo.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVCDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly BaseDbContext bookDbContext;

        public UserController (BaseDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        } 
    }
}
