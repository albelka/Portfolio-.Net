using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace PortfolioCodeReview.Models
{
    public class Repo
    {
        public string HtmlUrl { get; set; }

    public static List<Repo> GetRepos()
    {
        var client = new RestClient("https://api.github.com");
        var request = new RestRequest("users/albelka/repos?client_id=" + EnvironmentVariables.ClientId + "&client_secret=" + EnvironmentVariables.ClientSecret, Method.GET);
            request.AddHeader("User-Agent", "albelka");
        var response = new RestResponse();
        Task.Run(async () =>
        {
            response = await GetResponseContentAsync(client, request) as RestResponse;
        }).Wait();
            Debug.WriteLine(response);
       // JObject[] jsonResponse = JsonConvert.DeserializeObject<JObject[]>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Repo>>(response.Content);
        return repoList;

    }

    public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
    {
        var tcs = new TaskCompletionSource<IRestResponse>();
        theClient.ExecuteAsync(theRequest, response =>
        {
            tcs.SetResult(response);
        });
        return tcs.Task;
    }
  }
}
