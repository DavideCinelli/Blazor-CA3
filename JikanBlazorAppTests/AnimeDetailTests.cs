using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace JikanBlazorAppTests
{
    public class AnimeDetailTests : IDisposable
    {
        private readonly IWebDriver _driver;

        public AnimeDetailTests()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            _driver = new FirefoxDriver(options);
        }

        [Fact]
        public void TestAnimeDetailPageElements()
        {
            _driver.Navigate().GoToUrl("http://localhost:5273/anime/52991/Sousou_no_Frieren");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //check the main title
            var mainTitle = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.Equal("Sousou no Frieren", mainTitle.Text);

            //checks the image
            var animeImage = wait.Until(d => d.FindElement(By.CssSelector(".anime-image")));
            Assert.False(string.IsNullOrEmpty(animeImage.GetDomAttribute("src")), "Anime image is not loaded.");

            //check the info section
            var animeInfo = wait.Until(d => d.FindElement(By.CssSelector(".anime-info")));
            Assert.NotNull(animeInfo);

            //checks the additional info section
            var additionalInfo = wait.Until(d => d.FindElement(By.CssSelector(".anime-additional-info")));
            Assert.NotNull(additionalInfo);

            //checks the synopsis section
            var synopsis = wait.Until(d => d.FindElement(By.CssSelector(".anime-synopsis")));
            Assert.NotNull(synopsis);

            //title
            var title = animeInfo.FindElement(By.TagName("h2"));
            Assert.False(string.IsNullOrEmpty(title.Text), "Anime title is missing.");

            //score
            var score = animeInfo.FindElement(By.XPath("//p[strong[text()='Score:']]"));
            Assert.False(string.IsNullOrEmpty(score.Text), "Anime score is missing.");

            //rank
            var rank = animeInfo.FindElement(By.XPath("//p[strong[text()='Rank:']]"));
            Assert.False(string.IsNullOrEmpty(rank.Text), "Anime rank is missing.");

            //popularity
            var popularity = animeInfo.FindElement(By.XPath("//p[strong[text()='Popularity:']]"));
            Assert.False(string.IsNullOrEmpty(popularity.Text), "Anime popularity is missing.");

            //members
            var members = animeInfo.FindElement(By.XPath("//p[strong[text()='Members:']]"));
            Assert.False(string.IsNullOrEmpty(members.Text), "Anime members count is missing.");

            // episdoes
            var episodes = additionalInfo.FindElement(By.XPath("//p[strong[text()='Episodes:']]"));
            Assert.False(string.IsNullOrEmpty(episodes.Text), "Anime episodes count is missing.");

            //aired dates
            var aired = additionalInfo.FindElement(By.XPath("//p[strong[text()='Aired:']]"));
            Assert.False(string.IsNullOrEmpty(aired.Text), "Anime aired dates are missing.");

            //broadcast
            var broadcast = additionalInfo.FindElement(By.XPath("//p[strong[text()='Broadcast:']]"));
            Assert.False(string.IsNullOrEmpty(broadcast.Text), "Anime broadcast info is missing.");

            //genres
            var genres = additionalInfo.FindElement(By.XPath("//p[strong[text()='Genres:']]"));
            Assert.False(string.IsNullOrEmpty(genres.Text), "Anime genres are missing.");

            //themees
            var themes = additionalInfo.FindElement(By.XPath("//p[strong[text()='Themes:']]"));
            Assert.False(string.IsNullOrEmpty(themes.Text), "Anime themes are missing.");

            //producers
            var producers = additionalInfo.FindElement(By.XPath("//p[strong[text()='Producers:']]"));
            Assert.False(string.IsNullOrEmpty(producers.Text), "Anime producers are missing.");

            //lisensors
            var licensors = additionalInfo.FindElement(By.XPath("//p[strong[text()='Licensors:']]"));
            Assert.False(string.IsNullOrEmpty(licensors.Text), "Anime licensors are missing.");

            //studios
            var studios = additionalInfo.FindElement(By.XPath("//p[strong[text()='Studios:']]"));
            Assert.False(string.IsNullOrEmpty(studios.Text), "Anime studios are missing.");

            //trailer
            var trailer = additionalInfo.FindElement(By.XPath("//p[strong[text()='Trailer:']]//a"));
            Assert.False(string.IsNullOrEmpty(trailer.GetDomAttribute("href")), "Anime trailer link is missing.");

            //synopsis
            var synopsisText = synopsis.FindElement(By.TagName("p"));
            Assert.False(string.IsNullOrEmpty(synopsisText.Text), "Anime synopsis is missing.");
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}