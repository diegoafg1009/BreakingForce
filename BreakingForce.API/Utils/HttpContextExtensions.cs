using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace BreakingForce.API.Utils;

public static class HttpContextExtensions
{
    public static void InsertPaginationParametersInHeader(this HttpContext httpContext, double totalRecords, int recordsPerPage)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        var total = Math.Ceiling(totalRecords / recordsPerPage);
        httpContext.Response.Headers.Append("totalRecords", totalRecords.ToString(CultureInfo.InvariantCulture));
        httpContext.Response.Headers.Append("totalPages", total.ToString(CultureInfo.InvariantCulture));
    }
}