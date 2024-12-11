using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace JikanBlazorAppTests
{
    public class HomeTests : IDisposable
    {
        private readonly IWebDriver _driver;

        public HomeTests()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            _driver = new FirefoxDriver(options);
        }

        [Fact]
        public void TestHomePageElements()
        {
            _driver.Navigate().GoToUrl("http://localhost:5273/");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //check the header
            var header = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.Equal("Welcome to SearchJikanAPI", header.Text);

            //checks the subheader for Top 10 Most Popular Anime
            var topAnimeHeader = wait.Until(d => d.FindElement(By.XPath("//h2[text()='Top 10 Most Popular Anime']")));
            Assert.Equal("Top 10 Most Popular Anime", topAnimeHeader.Text);

            //check the subheader for Upcoming Releases part
            var upcomingReleasesHeader = wait.Until(d => d.FindElement(By.XPath("//h2[text()='Upcoming Releases']")));
            Assert.Equal("Upcoming Releases", upcomingReleasesHeader.Text);

            //checks the subheader for the Seasonal Anime part
            var seasonalAnimeHeader = wait.Until(d => d.FindElement(By.XPath("//h2[text()='Seasonal Anime']")));
            Assert.Equal("Seasonal Anime", seasonalAnimeHeader.Text);
        }

        [Fact]
        public void TestNavigationToDetailPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:5273/");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //wait for the cards to load
            var animeCard = wait.Until(d => d.FindElement(By.CssSelector(".anime-card")));
            var animeTitleWithRank = animeCard.FindElement(By.CssSelector(".anime-title")).Text;
            var animeTitle = animeTitleWithRank.Substring(animeTitleWithRank.IndexOf(' ') + 1); //gets title without the rank
            animeCard.Click();

            //wait for the detail page to load
            var detailHeader = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.Contains(animeTitle, detailHeader.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}