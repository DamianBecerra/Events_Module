# Events_Module
Proyecto para prueba técnica de ingreso a OverThere

Esta es una API construida con .NET 10 para la gestión de eventos. El proyecto cuenta con un conatainer en docker para facilitar su despliegue y pruebas.

Para ejecutar el proyecto: 
Ya que el proyecto utiliza Docker Compose para orquestar la API y la base de datos SQL Server automáticamente se necesita lo siguiente:

  - Docker Desktop instalado y en ejecución.

Pasos para levantar el proyecto:
 - Clonar el repositorio:

    git clone https://github.com/DamianBecerra/Events_Module.git
    cd Events_Module

Levantar servicios con Docker:
 - Desde la carpeta raíz del proyecto, ejecuta lo siguiente:

    docker-compose -f Events_Model_Back/docker-compose.yml up -d --build
   
Verificar la API:
Una vez que los contenedores estén corriendo, puedes acceder a la interfaz de Swagger en la siguiente ruta:
  http://localhost:1444/swagger (Puerto configurado en Docker)
