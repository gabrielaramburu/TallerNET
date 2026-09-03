# Portal Educativo - Demo de Seguridad con OpenID Connect

Proyecto educativo en **ASP.NET Core MVC** diseñado para enseñar cómo delegar la autenticación y la gestión de identidades a un Proveedor de Identidad externo (IdP) utilizando el estándar **OpenID Connect (OIDC)**.

---

## 🎯 Esquema de Funcionalidades y Roles del Sistema

| Rol / Perfil | Estado de Autenticación | Funcionalidades Permitidas | Color de Botón |
| :--- | :--- | :--- | :---: |
| **Visitante** | Anónimo (Sin Login) | Navegar por el catálogo de cursos, ver detalle y ficha técnica de cursos. | **Gris** (`btn-secondary`) |
| **Estudiante** | Autenticado con OpenID | Inscribirse a cursos, ver *Mis Cursos*, consultar *Perfil y Claims*. | **Azul** (`btn-primary`) |
| **Docente / Admin** | Autenticado + Rol asignado | Crear y publicar nuevos cursos, gestionar cursos asignados. | **Amarillo** (`btn-warning`) |

---

## 🧩 Principios de Diseño y Arquitectura

1. **Programación Orientada a Objetos (POO)**:
   * Entidades de dominio puras: [`Curso`](Models/Curso.cs), [`Docente`](Models/Docente.cs), [`Estudiante`](Models/Estudiante.cs), [`Inscripcion`](Models/Inscripcion.cs).
   * Tipado fuerte mediante el enum [`NivelCurso`](Models/NivelCurso.cs).
   * Separación explícita entre `Models/` (dominio) y `ViewModels/` (modelos de vista).

2. **Patrón Repository en Memoria**:
   * Interfaz [`ICursoRepositorio`](Repositorios/ICursoRepositorio.cs) y su implementación [`CursoRepositorioEnMemoria`](Repositorios/CursoRepositorioEnMemoria.cs) con concurrencia segura mediante `ConcurrentDictionary`.

3. **Vistas Parciales (Partial Views)**:
   * `_TarjetaCursoPartial.cshtml`: Renderizado modular de tarjetas de cursos.
   * `_LoginStatusPartial.cshtml`: Barra de navegación con estado de sesión.
   * `_TablaClaimsPartial.cshtml`: Explorador interactivo de Claims de OpenID.

---

## 🚀 Cómo ejecutar el proyecto

```bash
dotnet run
```

Navega en tu navegador a:
👉 `https://localhost:7281`
