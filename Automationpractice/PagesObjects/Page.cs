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

        public static MainPage Main => GetPage<MainPage>();

        public static AuthenticationPage Authentication => GetPage<AuthenticationPage>();

        public static OrderPage Order => GetPage<OrderPage>();

        public static CheckoutPage Checkout => GetPage<CheckoutPage>();

        public static ProductsPage Products => GetPage<ProductsPage>();
    }
}
