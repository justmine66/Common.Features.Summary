using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Features.Summary.Extensions
{
    public static class HttpRequestExtensions
    {
        private static bool IsAjaxRequest(this HttpRequest request)
        {
            return string.Equals(request.Query["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal) ||
                string.Equals(request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal);
        }
    }
}
