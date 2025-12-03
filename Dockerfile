# ====================================================================
# ETAPA 1: BUILD (Compilación y Publicación de la Aplicación)
# ====================================================================

# Utiliza la imagen del SDK para compilar la aplicación.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiar archivos de la solución y proyectos (para aprovechar el cache)

# Copia el archivo de la solución a la raíz del WORKDIR (/src)
COPY smartcoffe.sln .

# Copia todos los archivos de proyecto (csproj) a /src en sus respectivas carpetas.
# Esto asegura que dotnet restore pueda resolver las referencias entre proyectos.
COPY smartcoffe/smartcoffe.csproj smartcoffe/
COPY smartcoffe.Application/smartcoffe.Application.csproj smartcoffe.Application/
COPY smartcoffe.Domain/smartcoffe.Domain.csproj smartcoffe.Domain/
COPY smartcoffe.Infrastructure/smartcoffe.Infrastructure.csproj smartcoffe.Infrastructure/

# Restaurar dependencias (paquetes NuGet).
# Usamos el archivo de la solución para la restauración
RUN dotnet restore smartcoffe.sln

# 2. Copiar el resto del código fuente y publicar

# Copiar el resto del código fuente del proyecto.
COPY . .

# Moverse al directorio del proyecto de la API (el punto de entrada).
WORKDIR /src/smartcoffe

# Compilar y publicar la aplicación. La salida va a /app/publish
RUN dotnet publish "smartcoffe.csproj" -c Release -o /app/publish


# ====================================================================
# ETAPA 2: FINAL (Ejecución de la Aplicación)
# El resto de la etapa final se mantiene igual
# ====================================================================

# Utiliza la imagen del Runtime de ASP.NET (es más ligera y solo contiene lo necesario para ejecutar).
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copia los artefactos (los binarios de la aplicación publicados) desde la etapa 'build'.
COPY --from=build /app/publish .

# Define el puerto que el contenedor expone (Render lo gestionará).
EXPOSE 8080

# Comando para iniciar la aplicación.
# Render requiere que configures la variable de entorno ASPNETCORE_URLS=http://+:$PORT
# para que la aplicación escuche en el puerto que Render le asigne.
ENTRYPOINT ["dotnet", "smartcoffe.dll"]