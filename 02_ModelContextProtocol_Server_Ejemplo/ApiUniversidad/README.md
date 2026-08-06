# API Universidad

Esta es una API REST construida con controladores MVC en .NET 10. Proporciona información sobre materias, profesores y horarios de clases de apoyo, simulando el sistema de una universidad. Sirve como la fuente de datos principal que consume nuestro Servidor MCP.

## Cómo levantar el ambiente

Abre una consola en esta carpeta y ejecuta:

```bash
dotnet run
```

*Nota: Por defecto, el proyecto se levantará en el puerto asignado en `Properties/launchSettings.json` (usualmente `http://localhost:5220`). Asegúrate de que el Servidor MCP apunte a este puerto.*

## Pruebas de funcionamiento (cURL)

Para verificar que los endpoints responden correctamente, puedes ejecutar las siguientes consultas desde otra terminal:

**1. Obtener la lista completa de profesores y las materias que dictan:**
```bash
curl -X GET http://localhost:5220/api/profesores
```

**2. Consultar la fecha de examen y temas de una materia (Ej: PROG101):**
```bash
curl -X GET http://localhost:5220/api/materias/PROG101/examen
```

**3. Obtener los horarios de clases de apoyo para un profesor específico (Ej: Profesor ID 2):**
```bash
curl -X GET http://localhost:5220/api/profesores/2/horarios
```
