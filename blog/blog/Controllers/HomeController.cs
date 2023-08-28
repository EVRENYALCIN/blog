using blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        #region Category
        public IActionResult Category()
        {
            List<Category> list = _context.Category.ToList();
            return View(list);
        }

        public async Task<IActionResult> CategoryDetails(int Id)
        {
            var category = await _context.Category.FindAsync(Id);
            return Json(category);
        }
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (category.Id == 0)
            {
                await _context.AddAsync(category);
            }
            else
            {
                _context.Update(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }

        public async Task<IActionResult> DeleteCategory(int? Id)
        {
            var category = await _context.Category.FindAsync(Id);
            _context.Remove(category);          
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        #endregion

        #region Author
        public IActionResult Author()
        {
            List<Author> list = _context.Author.ToList();
            return View(list);
        }

        public async Task<IActionResult> AuthorDetails(int Id)
        {
            var author = await _context.Author.FindAsync(Id);
            return Json(author);
        }
        public async Task<IActionResult> AddAuthor(Author author)
        {
            if (author.Id == 0)
            {
                await _context.AddAsync(author);
            }
            else
            {
                _context.Update(author);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }

        public async Task<IActionResult> DeleteAuthor(int? Id)
        {
            var author = await _context.Author.FindAsync(Id);
            _context.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }
        #endregion


        //public IActionResult Index()
        //{
        //    var list = _context.Blog.Take(4).Where(b => b.IsPublish).OrderByDescending(x => x.CreateTime).ToList();
        //    foreach (var blog in list)
        //    {
        //        blog.Author = _context.Author.Find(blog.AuthorId);
        //    }
        //    return View(list);
        //}

        //public IActionResult Post(int Id)
        //{
        //    var blog = _context.Blog.Find(Id);
        //    blog.Author = _context.Author.Find(blog.AuthorId);
        //    blog.ImagePath = "/img/" + blog.ImagePath;
        //    return View(blog);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}