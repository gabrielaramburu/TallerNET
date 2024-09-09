var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ServerHub>("serverhub");
builder.AddProject<Projects.SimuladorSensor>("simuladorSensor");

builder.Build().Run();
