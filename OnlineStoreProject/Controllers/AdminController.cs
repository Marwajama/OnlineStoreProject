using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.DTO;
using OnlineStoreProject.Models;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly OnlineStoreContext _storeContext;
        public AdminController(OnlineStoreContext storeContext)
        {
            this._storeContext = storeContext;
        }

        [HttpPost]
        [Route("[Action]")]

        public IActionResult CreateItem([FromRoute] CreateItemDTO create)
        {
            var createitem = _storeContext.Categories.Where(x => x.CategoryId == create.CategoryId).SingleOrDefault();
            if (createitem != null)
            {
                var checkitem = _storeContext.Items.Where(x => x.ItemId == create.ItemId);
                Item item = new();
                item.CategoryId = create.CategoryId;
                item.Price = create.Price;
                item.Name = create.Name;
                item.Description = create.Description;
                item.IsAvailabile = create.IsAvailabile;
                _storeContext.Add(item);
                _storeContext.SaveChanges();
                return Ok("Item Adedd");

            }
            else
            {
                return BadRequest("Category Doesn't Exisiste");
            }
            return Ok();
        }
        [HttpPut]
        [Route("[Action]")]
        public IActionResult UpateItems([FromQuery] UpdateItem update)
        {

            var checkiem = _storeContext.Items.Where(x => x.ItemId == update.ItemId && x.IsAvailabile==true).SingleOrDefault();

            if (checkiem != null)
            {
                if(checkiem.Price > 0 && checkiem.Qtn > 0 && checkiem.Name != null && checkiem.Description != null && checkiem.IsAvailabile==true)
                { 
                checkiem.Price = update.Price ;
                checkiem.Qtn = update.Qtn ;
                checkiem.Name = update.Name ;
                checkiem.Description = update.Description ;
                checkiem.IsAvailabile = update.IsAvailabile ;
                _storeContext.Update(checkiem);
                _storeContext.SaveChanges();
                return Ok("Item Has Been Updated");
                }
            }

            return Ok("Item Not Available");
       
        }
        [HttpDelete]
        [Route("DeleteItem/{itemid}")]
        public IActionResult DeleteItem(int itemid)
        {
            var item = _storeContext.Items.Where(x => x.ItemId == itemid && x.IsAvailabile == true).FirstOrDefault();
            if (item != null)
            {
                var checkcart = _storeContext.Carts.Where(x => x.IsActive == true).ToList();
                foreach (var c in checkcart)
                {
                    var checkcartitem = _storeContext.CartItemIds.Where(x => x.CartId == c.CartId && x.ItemId == itemid).SingleOrDefault();
                    if (checkcartitem != null)
                    {
                        _storeContext.Remove(item);
                        _storeContext.SaveChanges();
                    }
                    else
                    {
                        continue;
                    }
                    item.IsAvailabile = false;
                    _storeContext.Update(item);
                    _storeContext.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    } 

}
    

    

