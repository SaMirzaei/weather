namespace Weather.Api.Services.Abstracts
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using RestSharp;

    public interface IRestClientProxy
    {
        IRestClientProxy Setup(Action<IRestRequest> action);

        IActionResult Execute();

        Task<IActionResult> ExecuteAsync();

        ActionResult<T> Execute<T>();

        Task<ActionResult<T>> ExecuteAsync<T>();
    }
}
