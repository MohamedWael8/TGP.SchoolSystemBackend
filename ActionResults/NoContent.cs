using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ITWORX.TGP.EGYPT.SchoolSystem_WebAPI_.ActionResults
{
    public class NoContent : IHttpActionResult
    {
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage noContent = new HttpResponseMessage();
            noContent.StatusCode = System.Net.HttpStatusCode.NoContent;
            noContent.ReasonPhrase = "No Content";

            return Task.FromResult(noContent);
        }
    }
}