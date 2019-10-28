namespace Weather.Api.Services.Abstracts
{
    using RestSharp;

    public interface IRestRequestFactory
    {
        string ContentType { get; set; }

        IRestRequest Create();
    }
}
