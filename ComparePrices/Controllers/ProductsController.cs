using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Models;

namespace ComparePrices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itemstabletest>>> GetItemstabletests()
        {
            if (_context.Itemstabletests == null)
            {
                return NotFound();
            }
            return await _context.Itemstabletests.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("models-of-{producer}")]
        //[Route("producer")]
        public async Task<ActionResult<IEnumerable<String>>> GetProducerModels(string producer)
        {
            if (_context.Itemstabletests == null)
            {
                return NotFound();
            }
            var models = from item in _context.Itemstabletests
                         where item.Producer == producer
                         select item.Model;

            models = models.Distinct();
           
            return await models.ToListAsync();


        }
        [HttpGet("all-producers")]
        public async Task<ActionResult<IEnumerable<String>>>GetAllProducers()
        {
            if (_context.Itemstabletests == null)
            {
                return NotFound();
            }

            var producers = from item in _context.Itemstabletests
                            select item.Producer;

            producers =producers.Distinct();
            return await producers.ToListAsync();


        }
        [HttpGet("all-phones-of-model-{model}")]
        public async Task<ActionResult<IEnumerable<Itemstabletest>>>getProductsByModel(string model)
        {
            if (_context.Itemstabletests == null)
            {
                return NotFound();
            }

            List<Itemstabletest> phones = (from item in _context.Itemstabletests
                         where item.Model.Contains(model)
                         select item).ToList();

            List<Itemstabletest> orderedProducts = phones.OrderBy(p => double.Parse(p.Price.Replace(".","").Replace(",","."))).ToList();
           

            return orderedProducts;
        }


        [HttpGet("search-{title}")]
        public async Task<ActionResult<IEnumerable<Itemstabletest>>>getProductsByTitle(string title)
        {
            if (_context.Itemstabletests == null)
            {
                return NotFound();
            }
            List<Itemstabletest> products = new List<Itemstabletest>();

            string[]words = title.Trim().Split(' ');
            foreach (Itemstabletest item in _context.Itemstabletests)
            {
                bool doesNotContain=false;
                foreach (string word in words)
                {
                    if (!item.Title.Contains(word,StringComparison.OrdinalIgnoreCase))
                    {
                        doesNotContain = true;
                        break;
                    }
                }
                if(doesNotContain==false)
                {
                    products.Add(item);
                }
            }

            List<Itemstabletest>orderedProducts= products.OrderBy(p => double.Parse(p.Price.Replace(".", "").Replace(",", "."))).ToList();
            


            return  orderedProducts;


        }



     



        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itemstabletest>> GetItemstabletest(int id)
        {
          if (_context.Itemstabletests == null)
          {
              return NotFound();
          }
            var itemstabletest = await _context.Itemstabletests.FindAsync(id);

            if (itemstabletest == null)
            {
                return NotFound();
            }

            return itemstabletest;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemstabletest(int id, Itemstabletest itemstabletest)
        {
            if (id != itemstabletest.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemstabletest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemstabletestExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itemstabletest>> PostItemstabletest(Itemstabletest itemstabletest)
        {
          if (_context.Itemstabletests == null)
          {
              return Problem("Entity set 'ProductsContext.Itemstabletests'  is null.");
          }
            _context.Itemstabletests.Add(itemstabletest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemstabletest", new { id = itemstabletest.Id }, itemstabletest);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemstabletest(int id)
        {
            if (_context.Itemstabletests == null)
            {
                return NotFound();
            }
            var itemstabletest = await _context.Itemstabletests.FindAsync(id);
            if (itemstabletest == null)
            {
                return NotFound();
            }

            _context.Itemstabletests.Remove(itemstabletest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemstabletestExists(int id)
        {
            return (_context.Itemstabletests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
