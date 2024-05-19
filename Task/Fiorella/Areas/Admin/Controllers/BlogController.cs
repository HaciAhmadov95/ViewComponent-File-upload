using Fiorella.Data;
using Fiorella.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.OrderByDescending(m => m.Id).ToListAsync();
            return View(blogs);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool existBlog = await _context.Blogs.AnyAsync(m => m.Title == blog.Title);

            if (existBlog)
            {
                ModelState.AddModelError("Title", "This title already exist");
                return View();
            }


            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Blog blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Blog blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }


            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Blog blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(new Blog { Id = blog.Id, Title = blog.Title, Description = blog.Description, Date = blog.Date, Image = blog.Image });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Blog blog)
        {

            if (id == null)
            {
                return BadRequest();
            }

            Blog dbBlog = await _context.Blogs.FindAsync(id);

            if (dbBlog == null)
            {
                return NotFound();
            }

            dbBlog.Title = blog.Title;
            dbBlog.Description = blog.Description;
            dbBlog.Date = blog.Date;
            dbBlog.Image = blog.Image;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}
