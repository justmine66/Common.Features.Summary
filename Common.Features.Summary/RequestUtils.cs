using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Features.Summary
{
    public class RequestUtils
    {
        private static bool IsAjaxRequest(HttpRequest request)
        {
            return string.Equals(request.Query["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal) ||
                string.Equals(request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal);
        }
    }
}
