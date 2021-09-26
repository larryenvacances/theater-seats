using Boilerplate.Api.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Boilerplate.Api.IntegrationTests
{
    public class IntegrationTest
    {
        protected static readonly WebApplicationFactory<Startup> Factory =
            new WebApplicationFactory<Startup>().BuildApplicationFactory();

        protected IntegrationTest()
        {
        }
    }
}