namespace ShortCircuitingRoutes
{
    public class DummyMiddleware
    {
        private readonly RequestDelegate _next;

        public DummyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
