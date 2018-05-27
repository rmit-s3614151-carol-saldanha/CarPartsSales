using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Models;
using OAuthExample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using OAuthExample.Models.Interfaces;
using OAuthExample.Models.ShoppingCartViewModels;

namespace OAuthExample.Controllers
{
    //[Authorize(Roles = Constants.Owner)]
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        //[Authorize]
        public ViewResult Cart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        //[Authorize]
        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.GetProductById(productId);

            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Cart");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.GetProductById(productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Cart");
        }
        //public async Task<IActionResult> Cart(string productName)
        //{
           
        //}

       
    }
}
