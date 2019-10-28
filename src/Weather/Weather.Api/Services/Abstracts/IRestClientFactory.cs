namespace Weather.Api.Services.Abstracts
{
    using RestSharp;

    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
