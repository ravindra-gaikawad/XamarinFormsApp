using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Core.Models;

namespace XamarinFormsApp.Services.Definitions
{
    public interface IHttpService
    {
        Task<ResponseModel> Post<T>(string relativeUrl, T model);

        Task<string> Get(string relativeUrl);

        Task<ResponseModel> Put<T>(string relativeUrl, T model);

        Task<ResponseModel> Delete(string relativeUrl);
    }
}
