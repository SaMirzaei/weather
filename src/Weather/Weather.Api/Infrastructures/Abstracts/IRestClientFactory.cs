namespace Weather.Api.Infrastructures.Abstracts
{
    using RestSharp;

    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
