using DotNetCoreWebUI.Helpers;
using DotNetCoreWebUI.Models;
using Integration.ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DotNetCoreWebUI.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new BookViewModel();
            var bookResponse = Book.GetBooks(SessionHelper.Get(HttpContext, SessionKeys.AccessToken));
            if(bookResponse.Code == Integration.ResponseCode.OK)
            {
                viewModel.BookResponse = bookResponse.Result;
            }

            #region dummyDataForAssesment
            if (viewModel.BookResponse == null && !string.IsNullOrEmpty(SessionHelper.Get(HttpContext, SessionKeys.AccessToken)))
            {
                viewModel.BookResponse = new Integration.BookResponse
                {
                    Books = new List<Integration.BookModel>
                    {
                        new Integration.BookModel { Id = new Guid().ToString(), Name = "The Country Of White Lilies", Text = "Author By Grigory Spiridonovich Petrov" , PurchasePrice = 12 },
                        new Integration.BookModel { Id = new Guid().ToString(), Name = "The Sun Also Rises", Text = "Author by Ernest Hemingway" , PurchasePrice = 10 },
                        new Integration.BookModel { Id = new Guid().ToString(), Name = "The Lord of the Rings", Text = "Author by J.R.R. Tolkien" , PurchasePrice = 5 },
                    }
                };

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            return View(viewModel);
        }
    }
}