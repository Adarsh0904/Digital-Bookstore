using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBookstoreManagement.Services;
using DigitalBookstoreManagement.Models;

namespace DigitalBookstoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // Get all authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthorsAsync());
        }

        // Get author by ID
        [HttpGet("{authorId}")]
        public async Task<ActionResult<Author>> GetAuthorById(int authorId)
        {
            var author = await _authorService.GetAuthorByIdAsync(authorId);
            if (author == null)
                return NotFound($"Author with ID {authorId} not found.");

            return Ok(author);
        }

        // Add a new author
        [HttpPost]
        public async Task<ActionResult> AddAuthor([FromBody] Author author)
        {

            //if (author == null)
            //{
            //    return BadRequest("Author data is null.");
            //}

            await _authorService.AddAuthorAsync(author);
            return CreatedAtAction("GetAuthorById", new { id = author.AuthorID }, author);
            //return Ok($"Author added successfully.");
        }

        // Update an author
        [HttpPut("{authorId}")]
        public async Task<ActionResult> UpdateAuthor(int authorId, [FromBody] Author author)
        {
            if (authorId != author.AuthorID)
                return BadRequest("Author ID mismatch.");

            var existingAuthor = await _authorService.GetAuthorByIdAsync(authorId);
            if (existingAuthor == null)
            {
                return NotFound($"Author with ID {authorId} not found.");
            }

            await _authorService.UpdateAuthorAsync(author);
            return Ok("Author updated.");
        }

        // Delete an author
        [HttpDelete("{authorId}")]
        public async Task<ActionResult> DeleteAuthor(int authorId)
        {
            var author = await _authorService.GetAuthorByIdAsync(authorId);
            if (author == null)
            {
                return NotFound($"Author with ID {authorId} not found.");
            }
            await _authorService.DeleteAuthorAsync(authorId);
            return NoContent();
        }
    }
}