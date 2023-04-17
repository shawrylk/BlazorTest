using BlazorApp.Pages;
using Bunit;

namespace UnitTest.Pages
{
    public class TestCounter
    {
        [Fact]
        public void Test1()
        {
            var context = new TestContext();
            var page = context.RenderComponent<Counter>();
            var btn = page.Find($".btn");

            Assert.Equal("Click me", btn.TextContent);

            btn.Click();
            page.Find("p").MarkupMatches($"<p role=\"status\">Current count: 1</p>");
        }
    }
}