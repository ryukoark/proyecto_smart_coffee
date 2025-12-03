# ====================================================================
# ETAPA 1: BUILD (Compilación y Publicación de la Aplicación)
# ====================================================================

# Utiliza la imagen del SDK para compilar la aplicación.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiar y restaurar dependencias (para aprovechar el cache de Docker)

# Copiar el archivo de solución (.sln) y todos los archivos de proyecto (.csproj).
# Asegúrate de que el patrón de copia cubra todos los archivos .csproj de tus capas.
COPY smartcoffe.sln .
COPY smartcoffe/*.csproj smartcoffe/
COPY smartcoffe.Application/*.csproj smartcoffe.Application/
COPY smartcoffe.Domain/*.csproj smartcoffe.Domain/
COPY smartcoffe.Infrastructure/*.csproj smartcoffe.Infrastructure/

# Restaurar dependencias (paquetes NuGet).
RUN dotnet restore

# 2. Copiar el resto del código fuente y publicar

# Copiar el resto del código fuente del proyecto.
COPY . .

# Moverse al directorio del proyecto de la API (el punto de entrada).
WORKDIR /src/smartcoffe

# Compilar y publicar la aplicación. La salida va a /app/publish
# Reemplaza 'smartcoffe.csproj' si tu proyecto principal tiene otro nombre.
RUN dotnet publish "smartcoffe.csproj" -c Release -o /app/publish


# ====================================================================
# ETAPA 2: FINAL (Ejecución de la Aplicación)
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
# Reemplaza 'smartcoffe.dll' con el nombre de la DLL principal (el mismo que el .csproj).
ENTRYPOINT ["dotnet", "smartcoffe.dll"]