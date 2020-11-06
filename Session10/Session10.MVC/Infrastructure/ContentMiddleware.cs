using Microsoft.AspNetCore.Http;

using System.Text;
using System.Threading.Tasks;

namespace Session10.MVC.Infrastructure
{
    public class ContentMiddleware
    {
        private readonly RequestDelegate nextDelegate;

        public ContentMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
