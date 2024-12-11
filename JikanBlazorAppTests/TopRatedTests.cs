using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace JikanBlazorAppTests
{
    public class TopRatedTests : IDisposable
    {
        private readonly IWebDriver _driver;

        public TopRatedTests()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            _driver = new FirefoxDriver(options);
        }

        [Fact]
        public void TestTopRatedPageElements()
        {
            _driver.Navigate().GoToUrl("http://localhost:5273/top-rated");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            //check the main header
            var header = wait.Until(d => d.FindElement(By.TagName("h2")));
            Assert.Equal("Top Rated Anime", header.Text);

            //checking the loading message
            var loadingMessage = wait.Until(d => d.FindElement(By.CssSelector("p")));
            Assert.Equal("Loading...", loadingMessage.Text);

            //waits for the table to load
            var table = wait.Until(d => d.FindElement(By.CssSelector("table.table-striped")));
            Assert.NotNull(table);

            //checking the table headers
            var rankHeader = table.FindElement(By.XPath("//th[text()='Rank']"));
            var titleHeader = table.FindElement(By.XPath("//th[text()='Title']"));
            var scoreHeader = table.FindElement(By.XPath("//th[text()='Score']"));
            Assert.NotNull(rankHeader);
            Assert.NotNull(titleHeader);
            Assert.NotNull(scoreHeader);

            //waits for all the rows to load
            var animeRows = wait.Until(d => d.FindElements(By.CssSelector("tbody tr")));
            Assert.NotEmpty(animeRows);

            //checks the first row
            var firstRow = animeRows.First();
            var rankCell = firstRow.FindElement(By.CssSelector("td.text-center.align-middle"));
            var titleCell = firstRow.FindElement(By.CssSelector("td a"));
            var scoreCell = firstRow.FindElement(By.CssSelector("td.text-center.align-middle i.fas.fa-star"));
            Assert.NotNull(rankCell);
            Assert.NotNull(titleCell);
            Assert.NotNull(scoreCell);

            //checks the image in the first row
            var image = firstRow.FindElement(By.CssSelector("td img"));
            Assert.NotNull(image);
            var imageSrc = image.GetDomAttribute("src");
            Assert.False(string.IsNullOrEmpty(imageSrc));

            //checks the episode and year information in the first row
            var episodeInfo = firstRow.FindElement(By.CssSelector("td div small"));
            Assert.NotNull(episodeInfo);
            Assert.False(string.IsNullOrEmpty(episodeInfo.Text));
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}