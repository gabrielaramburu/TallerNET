Cuando se inicia el servidor y se abre el browser de forma automática, se ejcuta dentro del controlado Pajaros, la action Index.
Esto es así porque en Program.cs se ha definido que la ruta por defecto (cuando no se especifica ninguna)
es la del controlador Pajaros y la acción Index.

*** El problema
Observar el código del controlador Pajaros (PajarosController) y el action Index para ver cómo se genera la página web que se muestra en el browser.

*** Primera mejora: separar la vista del controlador (Razor)
http://localhost:5223/Pajarosversion2/Index

*** Segunda mejora: separar la vista del controlador (Razor) 
y el modelo 
http://localhost:5223/Pajarosversion3/Index

Notas:

Observar dentro de Dependencias, Paquetes, las dos dependencias que se tuvieron que agregar (
para que se pueda trabajar con SQLite)

Observar como para las versiones 2 y 3 aparecen los layout.

