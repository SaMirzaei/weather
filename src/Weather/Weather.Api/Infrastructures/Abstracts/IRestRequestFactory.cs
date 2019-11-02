namespace Weather.Api.Infrastructures.Abstracts
{
    using RestSharp;

    public interface IRestRequestFactory
    {
        string ContentType { get; set; }

        IRestRequest Create();
    }
}
