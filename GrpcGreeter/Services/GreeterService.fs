namespace GrpcGreeter

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Grpc.Core
open Microsoft.Extensions.Logging
open GrpcGreeterLib

type GreeterService (logger : ILogger<GreeterService>) =

        inherit Greeter.GreeterBase()

        let _logger = logger

        override __.SayHello(request : HelloRequest, _ : ServerCallContext) : Task<HelloReply> =
            let reply = HelloReply()
            reply.Message <- "Hello " + request.Name 
            Task.FromResult(reply)