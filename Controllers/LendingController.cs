using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.DTO.BookCategories;
using WebApplication1.DTO.Lending;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendingController : ControllerBase
    {
        private readonly ILendingRepo _lendingRepo;

        public LendingController(ILendingRepo lendingRepo)
        {
            _lendingRepo = lendingRepo;
        }

        [HttpGet]

        public IActionResult Getall()
        {
            var lending = _lendingRepo.GetAll();
            return Ok(lending);
        }

        [HttpGet("{LendingId}")]
        public IActionResult GetById(int LendingId)
        {
            var books = _lendingRepo.GetById(LendingId);
            if (books == null)
                return NotFound();
            return Ok(books);
        }

        //[HttpPost]
        //public IActionResult Create(BookCategoryResponse bookCategoryResponse)
        //{
        //    var books = new BookCategories
        //    {
        //        CategoryName = bookCategoryResponse.CategoryName,

        //    };
        //    _bookCategoryRepo.Add(books);
        //    return CreatedAtAction(nameof(GetById), new { CategoryId = books.CategoryId }, books);
        //}

        //[HttpPut("{CategoryId}")]
        //public IActionResult Update(int CategoryId, LendingResponse LendingResponse)
        //{
        //    var bookCategories = _lendingRepo.GetById(CategoryId);
        //    if (bookCategories == null)
        //        return NotFound();

        //    bookCategories.CategoryName = LendingResponse.CategoryName;

        //    _lendingRepo.Update(bookCategories);

        //    return NoContent();
        //}

        //[HttpDelete("{LendingId}")]
        //public IActionResult Delete(int LendingId)
        //{
        //    var lending = _lendingRepo.GetById(LendingId);
        //    if (lending == null)
        //        return NotFound();

        //    _lending.Delete(LendingId);
        //    return NoContent();
        //}
    }
}
