using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DefaultNamespace;
{
    [TestFixture]
    public class BoxesApiIntegrationTests
    {
        private HttpClient _httpClient;
        private string _baseUri;

        [SetUp]
        public void SetUp()
        {
            _baseUri = "http://localhost:4200/";
            _httpClient = new HttpClient();
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
        }

        [Test]
        public async Task Get_BoxesEndpoint_ShouldReturnSuccess()
        {
            // Act
            var response = await _httpClient.GetAsync($"{_baseUri}/api/boxes");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Post_CreateBoxEndpoint_ShouldCreateBox()
        {
            // Arrange
            var boxData = new { Height = 10, Width = 5, Length = 15, Type = "Test", Amount = 5 };
            var content = new StringContent(JsonConvert.SerializeObject(boxData), Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync($"{_baseUri}/api/boxes/create", content);

            // Assert
            response.EnsureSuccessStatusCode(); 
        }

        [Test]
        public async Task Put_UpdateBoxEndpoint_ShouldUpdateBox()
        {
            // Arrange
            var boxData = new { BoxId = 1, Height = 12, Width = 6, Length = 18, Type = "Updated", Amount = 8 };
            var content = new StringContent(JsonConvert.SerializeObject(boxData), Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PutAsync($"{_baseUri}/api/boxes/update/{{boxId}}", content);

            // Assert
            response.EnsureSuccessStatusCode(); 
        }

        [Test]
        public async Task Delete_DeleteBoxEndpoint_ShouldDeleteBox()
        {
            // Act
            var response = await _httpClient.DeleteAsync($"{_baseUri}/api/boxes/delete/{{boxId}}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
