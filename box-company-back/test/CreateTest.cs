using System.Net;
using System.Net.Http.Json;

namespace DefaultNamespace;

public class CreateTest
{
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
    }
    
    [Test]
    public async Task SuccessfullyCreatBox()
    {
        Utillity.TriggerRebuild();
        var box = new Box()
        {
            Height = 10,
            Width = 50,
            Lenght = 30,
            Type = "Blue-bird",
            Amount = 20
        };

        var url = 'http://localhost:5035/api/boxes';

        HttpResponseMessage response;

        try
        {
            response = await _httpClient.PostAsJsonAsync(url, box);
            TestContext.WriteLine("FULL BODY RESPONSE: " + await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            throw new Exception(Utillity.NoResponseMessage,e)
        }

        Box responseBox;
        try
        {
            responseBox = JsonConvert.DeserializeObject<Box>(await response.Content.ReadAsStringAsync())?? throw new InvalidOperationException()
        }
        catch (Exception e)
        {
            throw new Exception(Utillity.BadResponse(await response.Content.ReadAsStringAsync()), e);
        }
    }
}