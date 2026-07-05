# ADR-001 - Selección de la arquitectura principal

**Proyecto:** DevPortfolioMVC

**Estado:** ✅ Aprobado

**Versión:** 1.0

**Fecha:** 27/06/2026

**Autores:**
- Ezequiel Benítez (Software Developer)
- ChatGPT (Tech Lead)

---

# Contexto

DevPortfolioMVC será un portfolio profesional desarrollado como una aplicación real.

El objetivo principal del proyecto no es únicamente publicar información personal, sino demostrar conocimientos técnicos relacionados con el desarrollo backend utilizando tecnologías del ecosistema .NET.

Antes de iniciar el desarrollo era necesario definir la arquitectura general de la solución.

---

# Problema

Existen distintas alternativas para desarrollar el proyecto.

Entre ellas:

- ASP.NET Core MVC
- ASP.NET Core Web API + React
- ASP.NET Core Web API + Angular
- Blazor Server
- Blazor WebAssembly

Cada alternativa presenta ventajas y desventajas en términos de complejidad, tiempo de desarrollo, mantenibilidad y objetivos del proyecto.

Era necesario seleccionar una arquitectura que permitiera alcanzar los objetivos definidos durante el Sprint 0.

---

# Alternativas consideradas

## Opción 1
### ASP.NET Core MVC

**Ventajas**

- Arquitectura conocida.
- Excelente integración con .NET.
- Ideal para aplicaciones CRUD.
- Permite demostrar MVC, Entity Framework e Identity.
- Menor complejidad inicial.
- Desarrollo más rápido.
- Muy utilizada en aplicaciones empresariales.

**Desventajas**

- Frontend menos desacoplado que SPA.
- Menor experiencia con JavaScript moderno.

---

## Opción 2
### ASP.NET Core Web API + React

**Ventajas**

- Arquitectura moderna.
- Frontend desacoplado.
- Excelente experiencia SPA.
- Muy demandada en el mercado.

**Desventajas**

- Mayor complejidad.
- Dos proyectos independientes.
- Mayor tiempo de desarrollo.
- El foco del proyecto pasaría parcialmente al frontend.

---

## Opción 3
### ASP.NET Core Web API + Angular

**Ventajas**

- Arquitectura escalable.
- Framework completo.

**Desventajas**

- Curva de aprendizaje mayor.
- Mayor cantidad de código.
- No representa el objetivo principal del proyecto.

---

## Opción 4
### Blazor

**Ventajas**

- Todo el desarrollo en C#.
- Integración completa con .NET.

**Desventajas**

- Menor adopción en comparación con MVC.
- El autor posee mayor experiencia utilizando MVC.

---

# Decisión

Se selecciona **ASP.NET Core MVC** como arquitectura principal del proyecto.

La solución estará compuesta inicialmente por un único proyecto MVC correctamente organizado mediante separación por responsabilidades.

No se utilizará una arquitectura distribuida ni múltiples proyectos durante la primera versión.

---

# Justificación

La decisión se basa en los siguientes criterios.

- Permite concentrar el esfuerzo en demostrar conocimientos backend.
- Reduce significativamente la complejidad inicial.
- Facilita terminar una primera versión funcional en menor tiempo.
- Permite implementar ASP.NET Core Identity.
- Permite utilizar Entity Framework Core.
- Facilita la incorporación de Docker posteriormente.
- Permite construir un panel administrativo completo.
- Se encuentra alineado con el objetivo profesional del autor.

---

# Consecuencias

## Positivas

- Desarrollo más rápido.
- Menor complejidad.
- Código más sencillo de mantener.
- Mayor foco en arquitectura y buenas prácticas.
- Ideal para un portfolio profesional.

## Negativas

- El frontend permanecerá acoplado al backend.
- Una futura migración a SPA requerirá una refactorización parcial.

Estas consecuencias son aceptadas debido a que no afectan los objetivos definidos para la versión inicial.

---

# Impacto

Esta decisión afecta directamente a:

- Organización de la solución.
- Estructura de carpetas.
- Tecnologías utilizadas.
- Estrategia de despliegue.
- Diseño de la base de datos.
- Desarrollo del panel administrativo.

---

# Revisión futura

Esta decisión podrá revisarse en una futura versión del proyecto si aparecen nuevos requerimientos que justifiquen una arquitectura desacoplada mediante una API REST y un frontend independiente.

---

# Referencias

- Microsoft Learn - ASP.NET Core MVC
- Microsoft Learn - ASP.NET Core Identity
- Microsoft Learn - Entity Framework Core

---

## Estado del ADR

| Campo | Valor |
|--------|-------|
| Estado | ✅ Aprobado |
| Sprint | Sprint 0 |
| Prioridad | Alta |
| Responsable | Ezequiel Benítez |
