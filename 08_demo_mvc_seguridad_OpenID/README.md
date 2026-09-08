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


## 🚀 Cómo ejecutar el proyecto

```bash
dotnet run
```

Navega en tu navegador a:
👉 `https://localhost:7281`
