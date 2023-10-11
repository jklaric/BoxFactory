namespace test;

public class UpdateTest
{
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
    }

    [Test]
    public async Task SuccessFullyUpdateBox()
    {
        Utillity.TriggerRebuild();

        var box = new Box()
        {
            Id = 1,
            Height = 1,
            Width = 1,
            Length = 1,
            Type = "Blue-Bird",
            Amount = 1,
        };
        
        var sql = $@"insert into Boxes(weight, width, length, type, amount) VALUES (@weight, @width, @length, @type, @amount)";
        using (var conn = Utillity.DataSource.OpenConnection())
        {
            conn.Execute(sql, box);
        }

        var url = 'http://localhost:5035/api/boxes/' + 1;

        HttpResponsMessage response;
        try
        {
            response = await _httpClient.PutAsJsonAsync(url, box);
            TestContext.WriteLine("FULL BODY RESPONSE: " + await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            throw new Exception(Utillity.NoResponseMessage, e);
        }
        using (new AssertionScope())
        {
            response.IsSuccessStatusCode.Should().BeTrue();
            responseObject.Should().BeEquivalentTo(box, Utillity.MyBecause(responseObject, box));
        }
    }
}