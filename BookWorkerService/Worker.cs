using Newtonsoft.Json.Linq;

namespace BookWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public Worker(ILogger<Worker> logger,IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory; ;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            /*while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }*/
            await GetBooksAsync(stoppingToken);

        }
        public async Task GetBooksAsync( CancellationToken stoppingToken)
        {
            var bookRequest = _httpClientFactory.CreateClient("BookAPI");
            //  /volumes?q=science&maxResults=10
            string fields= "items(volumeInfo/title,volumeInfo/authors,volumeInfo/imageLinks,volumeInfo/description,volumeInfo/industryIdentifiers,volumeInfo/categories,volumeInfo/publishedDate)";
            var response= await bookRequest.GetAsync($"volumes?q=history&maxResults=10&fields={fields}", stoppingToken);
            var data = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(data);

            var JsonData = JObject.Parse(data);
            var bookdata = JsonData["items"];

            Console.WriteLine(bookdata);

            foreach (var bookInfo in bookdata) {
                var title = bookInfo["volumeInfo"]
                
            }
        }



    }
}
