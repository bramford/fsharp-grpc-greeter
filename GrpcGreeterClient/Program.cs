using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterLib;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Custom HttpClientHandler that ignores TLS server cert
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestVersion = new Version(2, 0);
            var options = new GrpcChannelOptions();
            options.HttpClient = httpClient;

            using var channel = GrpcChannel.ForAddress("https://localhost:5001", options);
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
        }
    }
}
