using System.Threading.Tasks;

namespace WhatsSay.Core.ApiClients.Abstract
{
    public interface IApiContext
    {
        Task<string> Login(string login, string password);

        Task<T> Get<T>(string url);

        Task<TResult> Post<TResult, TContent>(string url, TContent content);

        Task Put<T>(string url, T content);

        Task Delete(string url);
    }
}