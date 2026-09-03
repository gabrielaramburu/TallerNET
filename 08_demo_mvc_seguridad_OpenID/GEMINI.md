# Reglas y Convenciones del Proyecto

## 1. Idioma y Nomenclatura
- Todo el código (clases, métodos, variables, comentarios), vistas y textos de interfaz deben estar en **español**.

## 2. Arquitectura y Principios de Diseño
- Seguir los principios de **Programación Orientada a Objetos (POO)**: usar asociaciones de objetos en el dominio (evitar tipos primitivos como sustitutos de objetos).
- **Separación estricta:**
  - `Models/`: Contiene únicamente entidades de dominio puro (`Curso`, `Docente`, `Estudiante`, `Inscripcion`, enums).
  - `ViewModels/`: Contiene exclusivamente los modelos de presentación asociados a las vistas (`ViewModels/Cursos/`, `ViewModels/Perfil/`).
- **Patrón Repository en Memoria:** Mantener las colecciones de datos en memoria (`ConcurrentDictionary`, listas sincronizadas) sin agregar persistencia en bases de datos.
- **Vistas Parciales:** Modularizar componentes reutilizables con Vistas Parciales Razor (`_TarjetaCursoPartial`, `_LoginStatusPartial`, `_TablaClaimsPartial`).

## 3. Experiencia de Usuario y Convención Visual
- **Colores de Botones según Rol:**
  - **Gris** (`btn-secondary` / `btn-outline-secondary`): Acciones públicas del Visitante / Anónimo (catálogo, ver detalle).
  - **Azul** (`btn-primary` / `btn-outline-primary`): Acciones del Estudiante autenticado con OpenID (login, inscribirse, mis cursos, perfil).
  - **Amarillo** (`btn-warning` / `btn-outline-warning`): Acciones del Docente / Admin (crear cursos, gestión docente).
- No hacer menciones explícitas a números de versión específicos del framework en los textos visibles de la aplicación.

## 4. Filosofía de Interfaz ("Menos es Más")
- **Minimalismo y Enfoque Didáctico:** Mantener las vistas con el mínimo de texto y elementos estrictamente necesarios para no saturar al estudiante y evitar que se disperse.
- **Evitar contenido de relleno o decorativo:** No incluir tarjetas promocionales, textos extensos ni bloques informativos accesorios (por ejemplo en la página de inicio); el foco debe estar al 100% en la funcionalidad básica y en la seguridad con OpenID Connect.
