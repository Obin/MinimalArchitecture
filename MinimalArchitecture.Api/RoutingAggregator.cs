using Microsoft.AspNetCore.Builder;
using MinimalArchitecture.Api.Routings;

namespace MinimalArchitecture.Api
{
    public static class RoutingAggregator
    {
        public static void RegisterRoutings(WebApplication webApplication)
        {
            AccountRouting.Register(webApplication);
        }
    }
}