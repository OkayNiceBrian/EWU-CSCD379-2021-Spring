using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;

namespace SecretSanta.E2E.Tests
{
    [TestClass]
    public class EndToEndTests
    {
        private static WebHostServerFixture<Web.Startup, Api.Startup> _Server;
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            _Server = new();
        }

        [TestMethod]
        public async Task LaunchHomepage()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            var headerContent = await page.GetTextContentAsync("body > header > div > a");
            Assert.AreEqual("Secret Santa", headerContent);
        }

        [TestMethod]
        public async Task VerifyAllNavigationLinksInHeaderWork()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");
            var button = await page.WaitForSelectorAsync("a:has-text('Create User')");
            Assert.IsNotNull(button);

            await page.ClickAsync("text=Groups");
            button = await page.WaitForSelectorAsync("a:has-text('Create Group')");
            Assert.IsNotNull(button);
        }

        [TestMethod]
        public async Task VerifyGroupCreationAndAssignment()
        {
            var localhost = _Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");
            await page.ClickAsync("text=Create User");
            await page.TypeAsync("input#FirstName", "Brian");
            await page.TypeAsync("input#LastName", "Jackson");
            await page.ClickAsync("text=Create");

            await page.ClickAsync("text=Create User");
            await page.TypeAsync("input#FirstName", "Vince");
            await page.TypeAsync("input#LastName", "Mejia");
            await page.ClickAsync("text=Create");

            await page.ClickAsync("text=Create User");
            await page.TypeAsync("input#FirstName", "Jared");
            await page.TypeAsync("input#LastName", "Bolender");
            await page.ClickAsync("text=Create");

            await page.ClickAsync("text=Groups");
            await page.ClickAsync("text=Create Group");
            
            await page.TypeAsync("input#Name", "Fellas");
            await page.ClickAsync("text=Create");

            await page.ClickAsync(":has-text('Fellas')");
            await page.SelectOptionAsync("select", "1");
            await page.ClickAsync("text=Add");
            await page.SelectOptionAsync("select", "2");
            await page.ClickAsync("text=Add");
            await page.SelectOptionAsync("select", "3");
            await page.ClickAsync("text=Add");

            await page.ClickAsync("text=Generate Assignments");

            var users = await page.QuerySelectorAllAsync("body > section > section");
            Assert.AreEqual(1, users.Count());
        }
    }
}
