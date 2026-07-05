# Modelo Conceptual del Dominio

## Entidades principales

El sistema DevPortfolioMVC estará compuesto inicialmente por las siguientes entidades:

* Proyecto
* Tecnología
* Categoría
* Imagen
* Experiencia Laboral
* Certificación
* Configuración del Sitio

---

## Relaciones

### Proyecto → Tecnología

Tipo:

Muchos a Muchos (N:N)

Un Proyecto puede utilizar múltiples Tecnologías.

Una Tecnología puede utilizarse en múltiples Proyectos.

---

### Proyecto → Categoría

Tipo:

Muchos a Uno (N:1)

Cada Proyecto pertenece a una única Categoría.

Una Categoría puede agrupar muchos Proyectos.

---

### Proyecto → Imagen

Tipo:

Uno a Muchos (1:N)

Un Proyecto puede tener múltiples Imágenes.

Cada Imagen pertenece a un único Proyecto.

Una de ellas podrá marcarse como imagen principal.

---

### Configuración del Sitio

Representa toda la información global del portfolio.

Ejemplos:

* Nombre del autor.
* Cargo profesional.
* Foto.
* Email.
* LinkedIn.
* GitHub.
* Curriculum.
* Banner principal.

---

### Experiencia Laboral

Representa la trayectoria profesional del autor.

Una experiencia no depende de un Proyecto.

Puede mostrarse de manera independiente.

---

### Certificación

Representa cursos, certificaciones o capacitaciones obtenidas.

Una certificación no depende de un Proyecto.

Puede relacionarse con Tecnologías de manera informativa en futuras versiones.

---

## Relaciones futuras

No serán implementadas en la V1.

* Blog.
* Publicaciones.
* Estadísticas.
* Comentarios.
* Etiquetas.
* Visitantes.
