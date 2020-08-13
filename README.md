# APIStore

_Proyecto desarrollado en ASP.Net Framework 4.7.1 con Visual Studio Community 2019_

APIStore es un pequeño proyecto web durante el curso de Programación avanzada en mi casa de estudios, se trataba de realizar proyectos y comunicarlos entre ellos para desarrollar un ecomerce, con carrusel de fotos de sus productos, paginación y un carro de compra asíncrono con Ajax. Si bien no es muy completo en UX/UI, cumple con la funcionalidades básicas de un ecomerce.

## Instalación de dependencias

Con el asistente de paquetes NuGet se puede hacer una reinstalación de los paquetes y dependencias que ocupa el proyeto.
Tambien con el comando `nuget update packages`

## Instalación de base de datos

El archivo `script.sql` en la carpeta raíz es el script que estructura la base de datos en SQL Server para poder ser implementada en el proyecto, posterior a esto, modificar el archivo `web.config` en la sección `<connectionStrings>` para que se pueda conectar su base de datos local o remota con el proyecto. Este archivo es independiente de la compilación del proyecto, por lo que puede ser modificado en ambiente de producción.


## Autor ✒️
* **Alejandro Gutiérrez** - *Trabajo Inicial* - [AlejandroGI](https://github.com/AlejandroGI)