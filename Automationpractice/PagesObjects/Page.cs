using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automationpractice.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;

namespace Automationpractice.PagesObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriverFactory.Driver, page);

            return page;
        }

        public static MainPage Main
        {
            get { return GetPage<MainPage>(); }

        }

        public static AuthenticationPage Authentication
        {
            get { return GetPage<AuthenticationPage>(); }
        }

        public static OrderPage Order
        {
            get { return GetPage<OrderPage>(); }
        }

        public static CheckoutPage Checkout
        {
            get { return GetPage<CheckoutPage>(); }
        }

        public static ProductsPage Products
        {
            get { return GetPage<ProductsPage>(); }
        }


    }
}
