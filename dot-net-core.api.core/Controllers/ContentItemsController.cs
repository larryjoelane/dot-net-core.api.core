using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentService.Models;
using ContentService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContentService.Controllers
{
    [Produces("application/json")]
    [Route("api/ContentItems")]
    public class ContentItemsController : Controller
    {
        private readonly ContentContext _context;
        private readonly IContentItemRepository _repository;


        public ContentItemsController(ContentContext context, IContentItemRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/ContentItems
        [HttpGet]
        public IEnumerable<ContentItem> GetContentItems()
        {
            //return _context.ContentItems.ToList();
            return _repository.GetAllConentItemsAsync();
        }

        // GET: api/ContentItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contentItem = await _context.ContentItems.SingleOrDefaultAsync(m => m.ContentKey == id);

            if (contentItem == null)
            {
                return NotFound();
            }

            return Ok(contentItem);
        }

        // PUT: api/ContentItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentItem([FromRoute] long id, [FromBody] ContentItemUpdateRequest contentItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContentItems
        [HttpPost]
        public async Task<IActionResult> PostContentItem([FromBody] ContentItem contentItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContentItems.Add(contentItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentItem", new { id = contentItem.ContentKey }, contentItem);
        }

        // DELETE: api/ContentItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contentItem = await _context.ContentItems.SingleOrDefaultAsync(m => m.ContentKey == id);
            if (contentItem == null)
            {
                return NotFound();
            }

            _context.ContentItems.Remove(contentItem);
            await _context.SaveChangesAsync();

            return Ok(contentItem);
        }

        private bool ContentItemExists(long id)
        {
            return _context.ContentItems.Any(e => e.ContentKey == id);
        }
    }
}