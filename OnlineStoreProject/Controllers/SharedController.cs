using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Protocol;
using OnlineStoreProject.DTO;
using OnlineStoreProject.Models;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly OnlineStoreContext _storeContext;
        public SharedController(OnlineStoreContext storeContext)
        {
            this._storeContext = storeContext;
        }
        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetAllCategory()
        {
            var getcategory = _storeContext.Categories.ToList();
            return Ok(getcategory);
        }
        [HttpGet]
        [Route("GetItems")]

        public IActionResult GetItemes(int PageSize,int PageNumber)
        {
            var itemes = _storeContext.Items;
            int SkipAmount = PageSize * PageNumber - (PageSize);
            int SelectedAmount = itemes.Count() - SkipAmount;

           
            return Ok(itemes.Skip(SkipAmount).Take(PageSize));
        }
        [HttpGet]
        [Route("Item/{id}")]
        public IActionResult GetItemById(int id )
        {

            var items = _storeContext.Items.Where(x => x.ItemId == id&& x.IsAvailabile==true).SingleOrDefault();




            if (items != null) {




                return Ok(items);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("Item")]
        public IActionResult FillterItem([FromQuery] ItemDTO item)
        {
            //Returen All Item
            var items = _storeContext.Items.Where(x => x.IsAvailabile == true).ToList(); ;


            if (item.CategoryId != null)
            {
                items = items.Where(x => x.CategoryId == item.CategoryId && x.IsAvailabile == true).ToList();
            }
            if (item.Price != null)
            {
                items = items.Where(x => x.Price >= item.Price && x.IsAvailabile == true).ToList();
            }
            if (item.Name != null)
            {
                items = items.Where(x => x.Name.Contains(item.Name) && x.IsAvailabile == true).ToList();
            }
            if (item.Description != null)
            {
                items = items.Where(x => x.Description.Contains(item.Description) && x.IsAvailabile == true).ToList();
            }
            int SkipAmount = item.PageNumber * item.PageSize - (item.PageSize);
            return Ok(items.Skip(SkipAmount).Take(item.PageSize));
        }
       
    }
}
