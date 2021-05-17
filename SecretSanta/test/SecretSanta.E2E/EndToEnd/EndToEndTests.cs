using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;
using System.Linq;

namespace SecretSanta.Web.Tests
{
    [TestClass]
    public class EndToEndTests 
    {
        private static WebHostServerFixture<Web.Startup, SecretSanta.Api.Startup> Server;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Server = new();
        }

        [TestMethod]
        public async Task LaunchHomepage()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            var headerContent = await page.GetTextContentAsync("body > header > div > a");
            Assert.AreEqual("Secret Santa", headerContent);
        }

        [TestMethod]
        public async Task CreateGift()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");

            // 4 gifts to start
            var gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(4, gifts.Count());

            await page.ClickAsync("text=Create");

            await page.TypeAsync("input#Title", "Guitar");
            await page.TypeAsync("input#Description", "A cool guitar.");
            await page.TypeAsync("input#Url", "fender.com");
            await page.TypeAsync("input#Priority", "1");
            await page.SelectOptionAsync("select#UserId", "1");

            await page.ClickAsync("text=Create");

            // make sure we have 5 gifts now
            gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(5, gifts.Count());
        }

        [TestMethod]
        public async Task DeleteGift()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");

            // 5 gifts to start
            var gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(5, gifts.Count());

            page.Dialog += (_, args) => args.Dialog.AcceptAsync();

            await page.ClickAsync("body > section > section > section:last-child > a > section > form > button");

            // make sure we have 4 gifts now
            gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(4, gifts.Count());
        }

        [TestMethod]
        public async Task UpdateLastGiftText()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");

            var sectionText = await page.GetTextContentAsync("body > section > section > section:last-child > a > section > div");

            await page.ClickAsync("body > section > section > section:last-child > a > section > div");

            await page.TypeAsync("input#Title", "Test");

            await page.ClickAsync("text=Update");

            var newSectionText = await page.GetTextContentAsync("body > section > section > section:last-child > a > section > div");

            Assert.AreEqual("TestDrone", newSectionText);
        }

        [TestMethod]
        public async Task NavigateToUsers()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");

            await page.ScreenshotAsync("users.png");
        }

        [TestMethod]
        public async Task NavigateToGifts()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");

            await page.ScreenshotAsync("gifts.png");
        }

        [TestMethod]
        public async Task NavigateToGroups()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Groups");

            await page.ScreenshotAsync("groups.png");
        }
    }
}