using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        public const string SessionKeyMovieID = "_MovieID";

        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            var genres = _context.Movie.Select(x => x.Genre).Distinct().OrderBy(x => x);

            var movies = _context.Movie.Select(x => x);
            if(!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            if(!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View(new MovieGenreViewModel
            {
                Genres = new SelectList(await genres.ToListAsync()),
                Movies = await movies.ToListAsync()
            });
        }

        // GET: Movies/DetailsAddToSession
        public async Task<IActionResult> DetailsAddToSession(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            if(!await _context.Movie.AnyAsync(x => x.ID == id))
            {
                return NotFound();
            }

            // Set id into session.
            HttpContext.Session.SetInt32(SessionKeyMovieID, id.Value);

            return RedirectToAction(nameof(Details));
        }

        // GET: Movies/Details
        public async Task<IActionResult> Details()
        {
            // Get id from session.
            var id = HttpContext.Session.GetInt32(SessionKeyMovieID);
            if(id == null)
            {
                return BadRequest();
            }

            return View(await _context.Movie.SingleAsync(x => x.ID == id));
        }
    }
}
