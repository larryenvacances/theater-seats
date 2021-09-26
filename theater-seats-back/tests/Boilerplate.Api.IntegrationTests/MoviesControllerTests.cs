using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Boilerplate.Api.IntegrationTests.Helpers;
using Boilerplate.Application.DTOs.Theater;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Boilerplate.Api.IntegrationTests
{
    public class MoviesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task It_ShouldReturnOk_WhenGettingAllMovies()
        {
            // Arrange
            var client = Factory.RebuildDb().CreateClient();
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["dateTime"] = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            var queryString = query.ToString();

            // Act
            var response = await client.GetAsync($"/api/Movies?{queryString}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var json = JsonConvert.DeserializeObject<List<MovieGetDto>>(await response.Content.ReadAsStringAsync());
            json.Should().NotBeNull();
            json.Should().OnlyHaveUniqueItems();
            json.Should().HaveCount(3);
        }
    }
}