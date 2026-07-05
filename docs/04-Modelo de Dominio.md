# 04 - Modelo de Dominio

**Proyecto:** DevPortfolioMVC  
**Versión:** 1.0  
**Estado:** En progreso  
**Sprint:** Sprint 0  
**Última actualización:** 27/06/2026  

---

## Objetivo

Definir las entidades principales del sistema desde una perspectiva de negocio antes de diseñar la base de datos o escribir código.

---

# Entidad: Proyecto

## Definición

Un Proyecto representa un desarrollo de software realizado por el autor con el objetivo de resolver un problema, demostrar conocimientos técnicos y comunicar experiencia profesional.

En DevPortfolioMVC, Proyecto será la entidad principal del sistema.

---

## Atributos principales

| Atributo              | Descripción                                         | Obligatorio |
| --------------------- | --------------------------------------------------- | ----------- |
| Título                | Nombre visible del proyecto.                        | Sí          |
| Slug                  | Identificador para URL amigable.                    | Sí          |
| Resumen               | Descripción breve para tarjetas/listados.           | Sí          |
| Descripción           | Explicación completa del proyecto.                  | Sí          |
| Problema              | Contexto o necesidad que motivó el proyecto.        | Sí          |
| Solución              | Forma en que se resolvió el problema.               | Sí          |
| Arquitectura          | Descripción técnica de la solución.                 | No          |
| Desafíos              | Dificultades encontradas durante el desarrollo.     | No          |
| Aprendizajes          | Conocimientos adquiridos.                           | No          |
| Próximas mejoras      | Posibles evoluciones futuras.                       | No          |
| Repositorio GitHub    | URL del código fuente.                              | No          |
| Demo online           | URL de la demo publicada.                           | No          |
| Video demo            | URL de video demostrativo.                          | No          |
| Fecha de inicio       | Fecha aproximada de inicio.                         | No          |
| Fecha de finalización | Fecha aproximada de cierre.                         | No          |
| Estado                | Estado actual del proyecto.                         | Sí          |
| Contexto              | Origen del proyecto.                                | Sí          |
| Nivel de madurez      | Grado de seriedad o evolución del proyecto.         | Sí          |
| Destacado             | Indica si aparece destacado en la página principal. | Sí          |
| Visible               | Indica si se muestra públicamente.                  | Sí          |

---

## Estados posibles

| Estado        | Descripción                                    |
| ------------- | ---------------------------------------------- |
| Borrador      | Proyecto cargado pero no visible públicamente. |
| En desarrollo | Proyecto activo, todavía en construcción.      |
| Finalizado    | Proyecto terminado y apto para mostrar.        |
| Archivado     | Proyecto conservado como historial.            |

---

## Contextos posibles

| Contexto  | Descripción                                   |
| --------- | --------------------------------------------- |
| Personal  | Proyecto realizado por iniciativa propia.     |
| Académico | Proyecto realizado en contexto de estudio.    |
| Laboral   | Proyecto vinculado a experiencia profesional. |
| Freelance | Proyecto realizado para un cliente.           |
| Challenge | Proyecto realizado como desafío técnico.      |

---

## Niveles de madurez

| Nivel        | Descripción                                            |
| ------------ | ------------------------------------------------------ |
| Experimental | Proyecto usado para probar ideas o tecnologías.        |
| Académico    | Proyecto funcional, pero orientado al aprendizaje.     |
| Portfolio    | Proyecto preparado para ser mostrado profesionalmente. |
| Profesional  | Proyecto con estándares cercanos a un entorno real.    |

---

## Relaciones

Un Proyecto se relaciona con:

- Una Categoría.
- Muchas Tecnologías.
- Muchas Imágenes.

---

## Comportamientos

Un Proyecto podrá:

* Publicarse.
* Ocultarse.
* Cambiar de estado.
* Marcarse como destacado.
* Quitar la marca de destacado.
* Agregar tecnologías.
* Quitar tecnologías.
* Agregar imágenes.
* Eliminar imágenes.
* Actualizar su información.
* Archivarse.

---

## Reglas de negocio

* Todo Proyecto debe tener título, slug, resumen, descripción, problema y solución.
* Todo Proyecto debe tener un estado.
* Todo Proyecto debe tener un contexto.
* Todo Proyecto debe tener un nivel de madurez.
* Un Proyecto puede no tener demo online.
* Un Proyecto puede no tener video demo.
* Un Proyecto puede no tener fecha de finalización si está en desarrollo.
* Solo los proyectos visibles deberán mostrarse en el sitio público.
* Solo los proyectos destacados deberán mostrarse en la sección principal de destacados.
* Un Proyecto archivado no debería mostrarse como destacado.


## Definición

Un Proyecto representa un desarrollo de software realizado por el autor con el objetivo de resolver un problema, demostrar conocimientos técnicos y comunicar experiencia profesional.

En DevPortfolioMVC, la entidad Proyecto será el núcleo del sistema.

---

## Responsabilidades

Un Proyecto debe permitir mostrar:

- Qué problema resuelve.
- Qué solución fue implementada.
- Qué tecnologías se utilizaron.
- Qué decisiones técnicas se tomaron.
- Qué desafíos aparecieron.
- Qué aprendizaje dejó.
- Qué mejoras podrían agregarse en el futuro.

---

## Información principal

Un Proyecto tendrá la siguiente información conceptual:

- Título
- Slug
- Resumen corto
- Descripción completa
- Problema
- Solución
- Arquitectura
- Tecnologías
- Categoría
- Estado
- Imagen principal
- Galería de imágenes
- Repositorio GitHub
- Demo online
- Video demo
- Fecha de inicio
- Fecha de finalización
- Dificultad
- Tiempo invertido
- Lecciones aprendidas
- Próximas mejoras
- Visibilidad pública
- Destacado
- Contexto
- Nivel de madurez
---

## Reglas de negocio

- Todo Proyecto debe tener un título.
- Todo Proyecto debe tener un resumen corto.
- Todo Proyecto debe tener una descripción completa.
- Todo Proyecto debe tener al menos una categoría.
- Un Proyecto puede tener muchas tecnologías.
- Una tecnología puede estar asociada a muchos proyectos.
- Un Proyecto puede tener muchas imágenes.
- Solo los proyectos marcados como públicos deberán mostrarse en el sitio público.
- Un Proyecto puede estar en estado Borrador, En desarrollo, Finalizado o Archivado.
- Un Proyecto puede no tener demo online.
- Un Proyecto puede no tener video demo.
- Un Proyecto puede no tener fecha de finalización si todavía está en desarrollo.

---

## Estados posibles

| Estado | Descripción |
|---|---|
| Borrador | Proyecto cargado en el sistema pero todavía no visible públicamente. |
| En desarrollo | Proyecto activo, todavía en construcción. |
| Finalizado | Proyecto terminado y listo para mostrar. |
| Archivado | Proyecto antiguo que se conserva como historial. |

---

## Relaciones

Un Proyecto se relaciona con:

- Una Categoría.
- Muchas Tecnologías.
- Muchas Imágenes.

---

## Decisiones de dominio

- La entidad Proyecto será prioritaria en la V1.
- Blog, publicaciones y estadísticas quedarán fuera de la primera versión.
- Las skills no serán una entidad independiente en V1; se representarán mediante tecnologías y proyectos.
- El foco principal será mostrar proyectos con profundidad técnica, no solo como tarjetas visuales.

---
## Comportamientos del Proyecto

Un Proyecto deberá poder realizar las siguientes acciones:

- Publicarse.
- Ocultarse.
- Cambiar de estado.
- Agregar tecnologías.
- Quitar tecnologías.
- Agregar imágenes.
- Eliminar imágenes.
- Actualizar su información.
- Marcarse como destacado.
- Archivar.
---
## Proyecto destacado

Un Proyecto podrá marcarse como destacado.

Los proyectos destacados aparecerán en la página principal del portfolio para resaltar los trabajos más representativos del autor.
---
# Entidad: Tecnología

## Definición

Una Tecnología representa un lenguaje, framework, herramienta, plataforma o servicio utilizado durante el desarrollo de uno o más proyectos.

Su objetivo es describir el stack tecnológico empleado y permitir la búsqueda y clasificación de proyectos.

---

## Atributos principales

| Atributo      | Descripción                      | Obligatorio |
| ------------- | -------------------------------- | ----------- |
| Nombre        | Nombre de la tecnología.         | Sí          |
| Descripción   | Breve explicación.               | No          |
| Logo          | Imagen representativa.           | No          |
| Sitio oficial | URL oficial.                     | No          |
| Categoría     | Clasificación de la tecnología.  | Sí          |
| Activa        | Indica si continúa utilizándose. | Sí          |

---

## Categorías posibles

* Lenguaje
* Framework
* Base de Datos
* ORM
* Frontend
* Backend
* Cloud
* DevOps
* Testing
* Herramienta
* IDE
* Control de Versiones
* Contenedores

---

## Relaciones

Una Tecnología puede estar asociada a muchos Proyectos.

Un Proyecto puede utilizar muchas Tecnologías.

---

## Reglas de negocio

* No puede existir una tecnología con el mismo nombre.
* El nombre será único.
* Una tecnología podrá dejar de utilizarse sin eliminarla del sistema.

---

## Comportamientos

Una Tecnología podrá:

* Activarse.
* Desactivarse.
* Modificar su información.
* Asociarse a proyectos.
* Desasociarse de proyectos.
---
# Entidad: Categoría

## Definición

Una Categoría representa la clasificación funcional de un Proyecto.

Permite organizar el portfolio y facilitar la navegación del usuario.

---

## Ejemplos

* Backend
* API REST
* Desktop
* Mobile
* Web
* Full Stack
* Universidad
* Personal

---

## Atributos principales

| Atributo    | Descripción                    |
| ----------- | ------------------------------ |
| Nombre      | Nombre de la categoría.        |
| Descripción | Información adicional.         |
| Activa      | Indica si continúa disponible. |

---

## Relaciones

Una Categoría podrá agrupar muchos Proyectos.

Cada Proyecto pertenecerá a una Categoría.

---

## Comportamientos

* Crear.
* Modificar.
* Desactivar.
* Reactivar.

# Entidad: Imagen

## Definición

Una Imagen representa un recurso gráfico asociado a un Proyecto.

Su finalidad es documentar visualmente el desarrollo y funcionamiento del sistema.

---

## Atributos principales

| Atributo          | Descripción                           |
| ----------------- | ------------------------------------- |
| Nombre            | Nombre interno.                       |
| Archivo           | Ruta o nombre del archivo.            |
| Texto alternativo | Accesibilidad (alt).                  |
| Orden             | Posición dentro de la galería.        |
| Imagen principal  | Indica si es la portada del proyecto. |

---

## Relaciones

Cada Imagen pertenece a un único Proyecto.

Un Proyecto puede tener múltiples Imágenes.

---

## Reglas de negocio

* Solo una imagen podrá ser la principal.
* El orden de visualización deberá ser configurable.

---

## Comportamientos

* Subir imagen.
* Eliminar imagen.
* Reordenar.
* Marcar como principal.

## Pendientes


- Definir entidad Imagen.
- Definir entidad Experiencia Laboral.
- Definir entidad Certificación.
- Definir Configuración del Sitio.