using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.DTO;
using OnlineStoreProject.Models;
using System.Runtime.CompilerServices;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OnlineStoreContext _storeContext;
        public UserController(OnlineStoreContext storeContext)
        {
            this._storeContext = storeContext;
        }

        [HttpGet]
        [Route("AddToCart")]
        public IActionResult AddItemToCart([FromRoute] AddToCartDto addToCart)
        {
            if(addToCart.ItemId>0 && addToCart.UserId>0 && addToCart.Qtn > 0)
            {
                var cartNew = _storeContext.Carts.Where(x => x.UserId == addToCart.UserId ).SingleOrDefault();
                if (cartNew != null)
                {
                    var items = _storeContext.Items.Where(x => x.ItemId == addToCart.ItemId && x.IsAvailabile == true).SingleOrDefault();
                    if (items != null)
                    {
                        var IsExistitcartItem = _storeContext.CartItemIds
                            .Where(y => y.ItemId == addToCart.ItemId && y.CartId == cartNew.CartId).SingleOrDefault();
                        if (IsExistitcartItem == null)
                        {
                            CartItemId cartItem = new CartItemId();
                            cartItem.ItemId = addToCart.ItemId;
                            cartItem.Note = addToCart.Note;
                            cartItem.CartId = cartNew.CartId;
                            cartItem.Qtn = addToCart.Qtn;
                            cartItem.NetPrice = items.Price * addToCart.Qtn;
                            _storeContext.Add(cartItem);
                            _storeContext.SaveChanges();

                        }
                        else
                        {
                            IsExistitcartItem.Qtn += addToCart.Qtn;
                            _storeContext.Update(IsExistitcartItem);
                            _storeContext.SaveChanges();
                        }

                    }

                }
            
            var cart = _storeContext.Carts.Where(x => x.UserId == addToCart.UserId && x.IsActive == true).SingleOrDefault();
            var item = _storeContext.Items.Where(x => x.ItemId == addToCart.ItemId).SingleOrDefault();
            if (item != null)
            {

                var IsExistitcartItem = _storeContext.CartItemIds
                    .Where(y => y.ItemId == addToCart.ItemId && y.CartId == cart.CartId).SingleOrDefault();
                if (IsExistitcartItem == null)
                {
                    CartItemId cartItem = new CartItemId();
                    cartItem.ItemId = addToCart.ItemId;
                    cartItem.Note = addToCart.Note;
                    cartItem.CartId = cart.CartId;
                    cartItem.Qtn = addToCart.Qtn;
                    cartItem.NetPrice = item.Price * addToCart.Qtn;
                    _storeContext.Add(cartItem);
                    _storeContext.SaveChanges();

                }
                else
                {
                    IsExistitcartItem.Qtn += addToCart.Qtn;
                    _storeContext.Update(IsExistitcartItem);
                    _storeContext.SaveChanges();
                }
            }




            else
            {
                var user = _storeContext.Users.Where(x => x.UserId == addToCart.UserId).SingleOrDefault();
                if (user != null)
                {
                    Cart cart1 = new Cart();
                    cart1.UserId = addToCart.UserId;
                    cart1.IsActive = true;
                    _storeContext.Add(cart1);
                    _storeContext.SaveChanges();
                    var cartn= _storeContext.Carts.Where(x => x.UserId == addToCart.UserId && x.IsActive == true).SingleOrDefault();
                    if (cartn!= null)
                    {
                        var items = _storeContext.Items.Where(x => x.ItemId == addToCart.ItemId).SingleOrDefault();
                        if (items != null)
                        {
                            var IsExistitcartItem = _storeContext.CartItemIds
                                .Where(y => y.ItemId == addToCart.ItemId && y.CartId == cartn.CartId).SingleOrDefault();
                            if (IsExistitcartItem == null)
                            {
                                CartItemId cartItem = new CartItemId();
                                cartItem.ItemId = addToCart.ItemId;
                                cartItem.Note = addToCart.Note;
                                cartItem.CartId = cart.CartId;
                                cartItem.Qtn = addToCart.Qtn;
                                cartItem.NetPrice = item.Price * addToCart.Qtn;
                                _storeContext.Add(cartItem);
                                _storeContext.SaveChanges();

                            }
                            else
                            {
                                IsExistitcartItem.Qtn += addToCart.Qtn;
                                _storeContext.Update(IsExistitcartItem);
                                _storeContext.SaveChanges();
                            }

                        }

                    }
                }
            }
            return Ok("Added");
            }
            return BadRequest("");
        }

        [HttpPut]
        [Route("RemoveFromCart/{CartItemId}")]
        public IActionResult RemoveFromCart(int CartItemId)
        {
            var cartitem = _storeContext.CartItemIds.Where(x => x.CartItemId1 == CartItemId).SingleOrDefault();
        if(cartitem != null)
            {
                if(cartitem.Qtn==1)
                {
                    _storeContext.Remove(cartitem);
                    _storeContext.SaveChanges();
                }
                else
                {
                    cartitem.Qtn -= 1;
                    cartitem.NetPrice = _storeContext.Items.Where(x => x.ItemId == cartitem.ItemId).First().Price * cartitem.Qtn;
                    _storeContext.Update(cartitem);
                    _storeContext.SaveChanges();

                }
                return Ok("RemovedItem");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("RemoveFromCartItem/{CartItemId}")]
        public IActionResult RemoveFromCartItem(int CartItemId)
        {
            var cartitem = _storeContext.CartItemIds.Where(x => x.CartItemId1 == CartItemId).SingleOrDefault();
            if (cartitem != null)
            {
                
                    _storeContext.Remove(cartitem);
                    _storeContext.SaveChanges();
               
                return Ok("RemovedItem");
            }
            else
            {
                return NotFound();
            }
        }
    }
}


   