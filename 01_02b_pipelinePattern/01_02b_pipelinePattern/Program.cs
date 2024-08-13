// See https://aka.ms/new-console-template for more information
using _01_02b_pipelinePattern.pipelinepattern;
using _01_02b_pipelinePattern.pipelinepattern.pipelineImpl;

Console.WriteLine("Ejemplo de PipeLine");

IContexto contexto = new InfoTexto();
PipelineOrquestador pipeLine = new PipelineOrquestador(contexto);
pipeLine.AgregarPaso(new PasoCargarArchivo());
pipeLine.AgregarPaso(new PasoConvertirMayuscula());
pipeLine.AgregarPaso(new PasoGenerarArchivoSalida());
pipeLine.Ejecutar();


