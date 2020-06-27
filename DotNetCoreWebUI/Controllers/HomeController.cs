using DotNetCoreWebUI.Helpers;
using DotNetCoreWebUI.Models;
using Integration;
using Integration.ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotNetCoreWebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var loginResponse = Authentication.Login(loginRequest);
                SessionHelper.Set(HttpContext, SessionKeys.AccessToken, loginResponse?.Result?.Token);

                return RedirectToAction("Index","Book");
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            if (ModelState.IsValid)
            {
                var registerResponse = Authentication.Register(registerRequest);
                if(registerResponse?.Result?.UserId != null)
                {
                    ViewBag["UserId"] = registerResponse.Result.UserId;

                }
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Logout()
        {
            CacheHelper.ClearCache();
            SessionHelper.ClearSession(HttpContext);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult SubscriptionList()
        {
            var viewModel = new UserSubscriptionViewModel();
            var userSubscriptionRes = Integration.ApiIntegration.User.
                                                GetSubscriptionList(SessionHelper.Get(HttpContext,SessionKeys.AccessToken));

            viewModel.UserSubscriptionListResponse = userSubscriptionRes?.Result;

            #region dummyDataForAssesment
            if (viewModel.UserSubscriptionListResponse == null &&
                        !string.IsNullOrEmpty(""))
            {
                viewModel.UserSubscriptionListResponse = new Integration.UserSubscriptionListResponse
                {
                    Books = new List<Integration.BookModel>
                    {
                        new Integration.BookModel { Id = new Guid().ToString(), Name = "The Country Of White Lilies", Text = "Author By Grigory Spiridonovich Petrov" , PurchasePrice = 12 },
                        new Integration.BookModel { Id = new Guid().ToString(), Name = "The Sun Also Rises", Text = "Author by Ernest Hemingway" , PurchasePrice = 10 },
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

        [HttpGet]
        public IActionResult Subscribe(SubscribeRequest subscribeRequest)
        {
            if (ModelState.IsValid)
            {
                var subscribeResponse = Integration.ApiIntegration.User.Subscribe(subscribeRequest, SessionHelper.Get(HttpContext, SessionKeys.AccessToken));
                if (subscribeResponse?.Result?.UserSubscriptionId != null)
                {
                    ViewBag["UserSubscriptionId"] = subscribeResponse?.Result?.UserSubscriptionId;

                }
            }

            return RedirectToAction("SubscriptionList");

        }


        [HttpGet]
        public IActionResult Unsubscribe(SubscribeRequest subscribeRequest)
        {
            if (ModelState.IsValid)
            {
                var subscribeResponse = Integration.ApiIntegration.User.Unsubscribe(subscribeRequest, SessionHelper.Get(HttpContext, SessionKeys.AccessToken));
            }

            return RedirectToAction("SubscriptionList");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
