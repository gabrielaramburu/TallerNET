var builder = DistributedApplication.CreateBuilder(args);

//agrego al proyecto un sevidor RabbitMQ

var usrRabbitMQ = builder.AddParameter("usrRabbitMQ");
var passRabbitMQ = builder.AddParameter("passRabbitMQ");
var messaging = builder.AddRabbitMQ("messaging", usrRabbitMQ, passRabbitMQ).WithManagementPlugin(port: 15672);

builder.AddProject<Projects.ServerHub>("serverhub")
     .WithReference(messaging);

builder.AddProject<Projects.SimuladorSensor>("simuladorSensor");


builder.Build().Run();
