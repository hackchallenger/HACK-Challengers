using Hackathon_Search.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Google.Api.Gax;
using Google.Cloud.DiscoveryEngine.V1Beta;
using Google.Protobuf.WellKnownTypes;

namespace Hackathon_Search.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>Snippet for Search</summary>
        /// <remarks>
        /// This snippet has been automatically generated and should be regarded as a code template only.
        /// It will require modifications to work:
        /// - It may require correct/in-range values for request initialization.
        /// - It may require specifying regional endpoints when creating the service client as shown in
        ///   https://cloud.google.com/dotnet/docs/reference/help/client-configuration#endpoint.
        /// </remarks>
        public void SearchRequestObject()
        {
            // Create client
            SearchServiceClient searchServiceClient = SearchServiceClient.Create();
            // Initialize request argument(s)
            SearchRequest request = new SearchRequest
            {
                ServingConfigAsServingConfigName = ServingConfigName.FromProjectLocationDataStoreServingConfig("[PROJECT]", "[LOCATION]", "[DATA_STORE]", "[SERVING_CONFIG]"),
                BranchAsBranchName = BranchName.FromProjectLocationDataStoreBranch("[PROJECT]", "[LOCATION]", "[DATA_STORE]", "[BRANCH]"),
                Query = "",
                Offset = 0,
                Filter = "",
                OrderBy = "",
                FacetSpecs =
            {
                new SearchRequest.Types.FacetSpec(),
            },
                BoostSpec = new SearchRequest.Types.BoostSpec(),
                Params = { { "", new Value() }, },
                QueryExpansionSpec = new SearchRequest.Types.QueryExpansionSpec(),
                SpellCorrectionSpec = new SearchRequest.Types.SpellCorrectionSpec(),
                UserPseudoId = "",
                ImageQuery = new SearchRequest.Types.ImageQuery(),
                SafeSearch = false,
                UserInfo = new UserInfo(),
                UserLabels = { { "", "" }, },
                EmbeddingSpec = new SearchRequest.Types.EmbeddingSpec(),
                ContentSearchSpec = new SearchRequest.Types.ContentSearchSpec(),
                RankingExpression = "",
                CanonicalFilter = "",
                DataStoreSpecs =
            {
                new SearchRequest.Types.DataStoreSpec(),
            },
            };
            // Make the request
            PagedEnumerable<SearchResponse, SearchResponse.Types.SearchResult> response = searchServiceClient.Search(request);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (SearchResponse.Types.SearchResult item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (SearchResponse page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (SearchResponse.Types.SearchResult item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<SearchResponse.Types.SearchResult> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (SearchResponse.Types.SearchResult item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
        }
    }
}
