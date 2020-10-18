namespace GrpcGreeterFSharpClient

open System
open System.Net.Http
open System.Threading.Tasks
open Grpc.Net.Client
open GrpcGreeterLib

module Program =

    [<EntryPoint>]
    let main args =

        let httpClientHandler = new HttpClientHandler();
        let disableVerification = Func<HttpRequestMessage,_,_,_,bool>(fun _ _ _ _ -> true)
        httpClientHandler.ServerCertificateCustomValidationCallback <- disableVerification
        let httpClient = new HttpClient(httpClientHandler);
        httpClient.DefaultRequestVersion <- Version(2, 0);
        let options = GrpcChannelOptions();
        options.HttpClient <- httpClient;

        use channel = GrpcChannel.ForAddress("https://localhost:5001", options)
        let client = Greeter.GreeterClient(channel);
        let helloRequest = HelloRequest()
        helloRequest.Name <- "GreeterClientFSharp"
        async {
            let! reply = client.SayHelloAsync(helloRequest).ResponseAsync |> Async.AwaitTask
            Console.WriteLine("Greeting: " + reply.Message)
        } |> Async.RunSynchronously
        0