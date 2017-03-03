using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace PortfolioCodeReview.Models
{
    public class Repo
    {
        public string HtmlUrl { get; set; }

    public static List<JObject> GetRepos()
    {
        var client = new RestClient("https://api.github.com");
        var request = new RestRequest("search/repositories?q=user:albelka&stars:1..2&order=desc&?client_id=" + EnvironmentVariables.ClientId + "&client_secret=" + EnvironmentVariables.ClientSecret, Method.GET);
            request.AddHeader("User-Agent", "albelka");
        var response = new RestResponse();
        Task.Run(async () =>
        {
            response = await GetResponseContentAsync(client, request) as RestResponse;
        }).Wait();
            Debug.WriteLine(response);
        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        List<JObject> repoList = JsonConvert.DeserializeObject<List<JObject>>(jsonResponse["items"].ToString());

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
