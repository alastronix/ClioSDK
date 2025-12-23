using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace ClioSDK.Tests
{
    public class TestBase
    {
        protected HttpClient HttpClient { get; private set; }
        protected Mock<HttpMessageHandler> MockHandler { get; private set; }

        public TestBase()
        {
            MockHandler = new Mock<HttpMessageHandler>();
            HttpClient = new HttpClient(MockHandler.Object)
            {
                BaseAddress = new Uri("https://app.clio.com/api/v4/")
            };
        }
    }
}