using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.DTO.BookCategories;
using WebApplication1.DTO.Members;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepo _membersRepo;

        public MembersController(IMembersRepo membersRepo)
        {
            _membersRepo = membersRepo;
        }

        [HttpGet]

        public IActionResult Getall()
        {
            var members = _membersRepo.GetAll();
            return Ok(members);
        }

        //        [HttpGet("{MemberId}")]
        //        public IActionResult GetById(int CategoryId)
        //        {
        //            var books = _bookCategoryRepo.GetById(CategoryId);
        //            if (books == null)
        //                return NotFound();
        //            return Ok(books);
        //        }

        //        [HttpPost]
        //        public IActionResult Create(MemberResponse MemberResponse)
        //        {
        //            var books = new BookCategories
        //            {
        //                MembersName = MemberResponse.CategoryName,

        //            };
        //            _bookCategoryRepo.Add(books);
        //            return CreatedAtAction(nameof(GetById), new { CategoryId = books.CategoryId }, books);
        //        }

        //        [HttpPut("{CategoryId}")]
        //        public IActionResult Update(int MemberId, MembersResponse MembersResponse)
        //        {
        //            var bookCategories = _bookCategoryRepo.GetById(MemberId);
        //            if (bookCategories == null)
        //                return NotFound();

        //            bookCategories.MemberName = MembersResponse.MemberName;

        //            _bookCategoryRepo.Update(bookCategories);

        //            return NoContent();
        //        }

        //        [HttpDelete("{MemberId}")]
        //        public IActionResult Delete(int MemberId)
        //        {
        //            var bookCategories = _bookCategoryRepo.GetById(MemberId);
        //            if (bookCategories == null)
        //                return NotFound();

        //            _bookCategoryRepo.Delete(MemberId);
        //            return NoContent();
        //        }
        //    }
        //}
        //    }
    }
}
