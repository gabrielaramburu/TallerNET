// See https://aka.ms/new-console-template for more information
using _01_02c_pipelineEstiloFuncional;
using _01_02c_pipelineEstiloFuncional.pipeline;

//new EjemploEstiloFuncional().probar();


PipeLineEstiloFuncional pipeLine= new PipeLineEstiloFuncional();

pipeLine.AgregarEndPoint(new Endpoint("/casoA", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoA");
    Console.WriteLine($"Parámetro recibido: {s}");
}));


pipeLine.AgregarEndPoint(new Endpoint("/casoB", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoB");
}));

pipeLine.AgregarEndPoint(new Endpoint("/casoC", (string s) => {
    Console.WriteLine("Haciendo algo interesante al recibir request casoC");
}));


// cada vez que recibo un request ejecuto el pipeLine pasando como parámetro
// la urlDestino
pipeLine.ProcesarRequestEntrante("/casoB");





