# 09 - Despliegue del portfolio

## Objetivo

Publicar la aplicación ASP.NET Core MVC sin almacenar credenciales en Git y
mantener PostgreSQL fuera del sistema de archivos del servidor.

## Arquitectura recomendada

```text
Visitante
   │
   ▼
Render Web Service
   │  contenedor Docker
   │
   ▼
Neon PostgreSQL
```

Esta combinación permite empezar sin costo:

- Render construye la imagen definida por el `Dockerfile`.
- Neon aloja PostgreSQL sin límite temporal en su plan gratuito.
- Render ejecuta `/health` para comprobar que la aplicación y la base están
  disponibles.

## Archivos de despliegue

### `Dockerfile`

Realiza una compilación en dos etapas:

1. Restaura y publica la aplicación con el SDK de .NET.
2. Copia el resultado a una imagen más pequeña que contiene únicamente el
   runtime de ASP.NET Core.

El proceso final se ejecuta con un usuario sin privilegios de administrador.

### `.dockerignore`

Evita enviar al proceso de construcción carpetas locales, binarios, archivos
temporales y posibles archivos `.env`.

### `render.yaml`

Define el servicio web, el health check, la construcción con Docker y los
nombres de las variables requeridas. La cadena de conexión tiene
`sync: false`, por lo que Render la solicita en su panel y no la guarda en Git.

## Variables de entorno

### `ASPNETCORE_ENVIRONMENT`

```text
Production
```

Activa la configuración y el manejo de errores de producción.

### `ConnectionStrings__DefaultConnection`

Cadena de conexión de PostgreSQL en formato Npgsql:

```text
Host=database-host;Port=5432;Database=database-name;Username=database-user;Password=replace-me;SSL Mode=Require;Trust Server Certificate=true
```

Los dos guiones bajos representan la separación que en JSON se escribe con
`:`. El valor real debe guardarse como secreto en la plataforma.

### Puerto HTTP

El contenedor escucha en el puerto `8080` de forma predeterminada. Si una
plataforma proporciona la variable `PORT`, la aplicación utiliza ese valor
automáticamente.

## Tutorial: crear la base en Neon

1. Crear una cuenta en [Neon](https://neon.com/).
2. Seleccionar **New Project**.
3. Elegir una región cercana a los visitantes esperados.
4. Crear el proyecto y abrir **Connection Details**.
5. Copiar por separado host, base, usuario y contraseña.
6. Construir la cadena en formato Npgsql:

```text
Host=<host>;Port=5432;Database=<database>;Username=<user>;Password=<password>;SSL Mode=Require;Trust Server Certificate=true
```

No pegar esta cadena en `appsettings.json`, `.env.example`, capturas de pantalla
ni documentación.

## Tutorial: publicar en Render

1. Confirmar los cambios y subir el repositorio a GitHub.
2. Crear una cuenta en [Render](https://render.com/).
3. Conectar la cuenta de GitHub.
4. Seleccionar **New > Blueprint**.
5. Elegir el repositorio del portfolio.
6. Confirmar el archivo `render.yaml`.
7. Cuando Render solicite `ConnectionStrings__DefaultConnection`, pegar la
   cadena de Neon.
8. Crear el Blueprint y seguir los logs del primer despliegue.
9. Esperar a que `/health` responda correctamente.
10. Abrir la URL `onrender.com` asignada y recorrer el portfolio.

Cada nuevo commit en la rama conectada inicia un despliegue automático.

## Qué ocurre en el primer arranque

`DatabaseInitializer`:

1. Aplica las migraciones pendientes mediante `MigrateAsync()`.
2. Inserta o actualiza los proyectos iniciales.
3. Evita duplicar los datos en ejecuciones posteriores.

Este mecanismo es adecuado mientras el portfolio utilice una sola instancia.
Si en el futuro escala horizontalmente, las migraciones deben ejecutarse en una
tarea exclusiva del proceso de despliegue.

## Comprobación local sin Docker

PowerShell:

```powershell
$env:ASPNETCORE_ENVIRONMENT = "Production"
$env:ConnectionStrings__DefaultConnection = "Host=localhost;Port=5432;Database=devportfolio_db;Username=postgres;Password=postgres"
$env:ASPNETCORE_URLS = "http://localhost:8080"

dotnet run --project src/DevPortfolioMVC.Web
```

En otra terminal:

```powershell
Invoke-WebRequest http://localhost:8080/health
Invoke-WebRequest http://localhost:8080/
```

Al finalizar:

```powershell
Remove-Item Env:ConnectionStrings__DefaultConnection
Remove-Item Env:ASPNETCORE_ENVIRONMENT
Remove-Item Env:ASPNETCORE_URLS
```

## Comprobación local con Docker

Requiere Docker Desktop:

```bash
docker build -t devportfolio .
docker run --rm \
  -p 8080:8080 \
  -e ConnectionStrings__DefaultConnection="<cadena-de-conexion>" \
  devportfolio
```

Después, abrir `http://localhost:8080`.

## Limitaciones del nivel gratuito

- Render suspende un servicio web gratuito después de un período sin tráfico.
  La primera visita posterior puede tardar alrededor de un minuto.
- Neon suspende el proceso de cómputo cuando la base queda inactiva y lo reactiva
  automáticamente ante una nueva consulta.
- El sistema de archivos de Render es efímero. En este proyecto no es un
  problema porque las imágenes y el CV forman parte de la imagen Docker y los
  datos persistentes viven en PostgreSQL.

Para evitar la espera inicial frente a reclutadores, se puede pasar el servicio
web a un plan pago o utilizar Railway Hobby como alternativa.

## Mantenimiento de .NET

El proyecto utiliza .NET 9, actualmente en fase de mantenimiento y con soporte
hasta el 10 de noviembre de 2026. Después del primer despliegue conviene migrar
a .NET 10 LTS, soportado hasta noviembre de 2028.

## Lista de verificación

- [ ] Repositorio actualizado en GitHub.
- [ ] Base PostgreSQL creada.
- [ ] Cadena de conexión guardada como secreto.
- [ ] Primer despliegue completado.
- [ ] `/health` responde con estado 200.
- [ ] Inicio y detalles de proyectos cargan correctamente.
- [ ] Imágenes y CV son accesibles.
- [ ] Enlaces de correo, GitHub y LinkedIn funcionan.
- [ ] URL pública agregada al CV y LinkedIn.
