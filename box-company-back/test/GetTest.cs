namespace DefaultNamespace;

public class GetTest
{
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
    }

    [Test]
    public async Task GetBoxTest()
    {
        Utillity.TriggerRebuild();
        var expected = new List<Box>();
        for (int i = 1; i < 10; i++)
        {
            var box = new Box()
            {
                Id = i,
                Weight = 1,
                Width = 1,
                Length = 1,
                Type = "Blue-Bird",
                Amount = 1,
            };
            expected.Add(box);
            var sql =
                $@"insert into Boxes(weight, width, length, type, amount) VALUES (@weight, @width, @length, @type, @amount)";
            using (var conn = Utillity.DataSource.OpenConnection())
            {
                conn.Execute(sql, box);
            }
        }

        var url = 'http://localhost:5035/api/boxes';
        HttpResponseMessage response;
        try
        {
            response = await _httpClient.GetAsync(url);
            TestContext.WriteLine("FULL BODY RESPONSE: " + await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            throw new Exception(Utillity.NoResponseMessage, e);
        }

        IEnumerable<Box> boxes;
        try
        {
            boxes = JsonConvert.DeserializeObject<IEnumerable<Box>>(await response.Content.ReadAsStringAsync()) ??
                    throw new InvalidOperationException();
        }
        catch (Exception e)
        {
            throw new Exception(Utillity.BadResponseBody(await response.Content.ReadAsStringAsync()), e);
        }
 		using (new AssertionScope())
        {
            foreach (var box in boxes)
            {
                box.Id.Should().BeGreaterThan(0);
            }
   	 }
}