namespace ShortCircuitingRoutes
{
    public static class DummyMiddlewareExtensions
    {
        public static IApplicationBuilder UseDummyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DummyMiddleware>();
        }
    }

}
