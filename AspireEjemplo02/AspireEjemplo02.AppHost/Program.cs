var builder = DistributedApplication.CreateBuilder(args);


var apiService2 = builder.AddProject<Projects.ApiService2>("apiservice2");
    //.WithReplicas(3);


var apiService = builder.AddProject<Projects.AspireEjemplo02_ApiService>("apiservice")
    .WithReference(apiService2);


builder.AddProject<Projects.AspireEjemplo02_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);



builder.Build().Run();
