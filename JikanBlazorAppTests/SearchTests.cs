using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace JikanBlazorAppTests
{
    public class SearchTests : IDisposable
    {
        private readonly IWebDriver _driver;

        public SearchTests()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            _driver = new FirefoxDriver(options);
        }

        [Fact]
        public void TestSearchPageElements()
        {
            _driver.Navigate().GoToUrl("http://localhost:5273/search");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //checks the main header
            var header = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.Equal("Search Anime", header.Text);

            //checks the search input box
            var searchBox = wait.Until(d => d.FindElement(By.CssSelector("input[placeholder='Enter anime title']")));
            Assert.NotNull(searchBox);

            //check the search button is there
            var searchButton = wait.Until(d => d.FindElement(By.CssSelector("button.btn-primary")));
            Assert.NotNull(searchButton);

            //checks for possible message
            var messages = wait.Until(d => d.FindElements(By.CssSelector("p")));
            Assert.NotEmpty(messages);

            //verifys one of the expected messages is present
            var expectedMessages = new[] { "Loading...", "No results found. Try another search." };
            Assert.Contains(messages.Select(m => m.Text), text => expectedMessages.Contains(text));
        }


        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}