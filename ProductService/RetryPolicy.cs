using Polly;

namespace ProductService
{
    public class RetryPolicy
    {

        public static IAsyncPolicy GetRetryPolicy()
        {
            return Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }


    }
}
