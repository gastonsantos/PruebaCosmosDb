# PruebaCosmosDb

TP WEB 3


Si API de Azure CosmosDB y Azure Cosmos DB for MongoDB(vCore) son lo mismo?


Si son lo mismo cuando se crea un Cluster de Azure Cosmos DB for MongoDB se genera una API de Azure CosmosDB para MongoDB
Como funciona?


La API de Azure Cosmos DB para cuenta de MongoDB proporciona una capa de compatibilidad que te permite utilizar Azure Cosmos DB como una base de datos compatible con MongoDB. A continuación, se explica cómo funciona:
Creación de una cuenta de Azure Cosmos DB: En primer lugar, debes crear una cuenta de Azure Cosmos DB en el portal de Azure. Durante la creación, selecciona la opción "API para cuenta de MongoDB" como modelo de programación.
Configuración de la cuenta: Después de crear la cuenta, puedes configurar opciones como la ubicación geográfica, el nivel de escalabilidad y la consistencia.
Conexión a la cuenta: Para interactuar con la cuenta de Azure Cosmos DB, debes obtener la cadena de conexión que contiene la información necesaria para conectarte a la base de datos. Esta cadena de conexión incluye la dirección del servidor, el nombre de la base de datos y las credenciales de autenticación.
Interacción con la base de datos: Una vez que tienes la cadena de conexión, puedes utilizar cualquier cliente o driver de MongoDB para conectarte a la base de datos de Azure Cosmos DB. Puedes realizar operaciones de lectura, escritura, actualización y eliminación utilizando la sintaxis y las operaciones estándar de MongoDB.
Beneficios adicionales de Azure Cosmos DB: Aunque estás utilizando una API compatible con MongoDB, también puedes aprovechar las características adicionales que ofrece Azure Cosmos DB, como la escalabilidad global, la baja latencia, la replicación automática, la recuperación ante desastres y la integración con otros servicios de Azure.
Es importante tener en cuenta que, aunque la API de Azure Cosmos DB para cuenta de MongoDB proporciona una capa de compatibilidad con MongoDB, existen algunas diferencias en el comportamiento y las características en comparación con una implementación nativa de MongoDB. Por lo tanto, es recomendable revisar la documentación de Azure Cosmos DB y las guías de migración para asegurarte de comprender completamente cómo funciona esta API y cómo se adaptará a tus necesidades específicas.


Como funciona a Nivel Tecnico?


A nivel técnico, la API de Azure Cosmos DB para cuentas de MongoDB implementa un traductor y un mapeo entre las operaciones de MongoDB y las operaciones subyacentes en Azure Cosmos DB. Esto permite que las aplicaciones que utilizan la API de MongoDB se comuniquen con Azure Cosmos DB sin requerir modificaciones significativas en el código existente.
Cuando se realiza una operación utilizando la API de Azure Cosmos DB para cuentas de MongoDB, la API traduce esa operación en una forma compatible con Azure Cosmos DB. A continuación, se realiza la operación en el backend de Azure Cosmos DB utilizando sus capacidades de almacenamiento y administración de datos distribuidos. El resultado de la operación se devuelve a la aplicación como si se hubiera realizado directamente en una base de datos de MongoDB.
Cuando una aplicación realiza una operación utilizando la API de Azure Cosmos DB para cuentas de MongoDB, el siguiente proceso ocurre a nivel técnico:
Conexión a la cuenta de Azure Cosmos DB: La aplicación establece una conexión a la cuenta de Azure Cosmos DB utilizando las credenciales y la cadena de conexión proporcionadas.
Traducción de operaciones de MongoDB: La API de Azure Cosmos DB traduce las operaciones de MongoDB realizadas por la aplicación en un formato compatible con Azure Cosmos DB.
Comunicación con Azure Cosmos DB: Las operaciones traducidas se envían a Azure Cosmos DB a través de la red. Esto implica la comunicación con el backend de Azure Cosmos DB, que es una infraestructura distribuida que maneja el almacenamiento y la administración de datos.
Ejecución de operaciones en Azure Cosmos DB: Azure Cosmos DB ejecuta las operaciones en su backend distribuido. Utiliza su motor de almacenamiento y su modelo de datos para procesar las operaciones y acceder a los datos almacenados.
Retorno de resultados: Una vez que se completa la operación en Azure Cosmos DB, los resultados se devuelven a la aplicación que realizó la operación. Esto puede incluir documentos, respuestas a consultas, códigos de estado y cualquier otra información relevante.
Es importante destacar que, aunque la API de Azure Cosmos DB para cuentas de MongoDB proporciona compatibilidad con la sintaxis y el modelo de datos de MongoDB, existen algunas diferencias y consideraciones. Por ejemplo, Azure Cosmos DB puede ofrecer características adicionales, como la distribución global de datos, opciones de escalabilidad automática y diferentes niveles de consistencia.





Que es DbContext en Entity Frameework?


El DbContext es una clase fundamental en Entity Framework, un framework de mapeo objeto-relacional (ORM) desarrollado por Microsoft. Es una clase que actúa como una puerta de entrada al ORM y se utiliza para interactuar con la base de datos.
El DbContext en Entity Framework representa una sesión de trabajo con la base de datos y se utiliza para realizar operaciones de consulta (lectura) y modificación (escritura) en los datos. Proporciona una interfaz para realizar consultas LINQ y ejecutar comandos de base de datos, y también administra el seguimiento de los cambios en los objetos de entidad.
El DbContext se crea generalmente como una clase derivada de la clase base DbContext proporcionada por Entity Framework. Al derivar de DbContext, puedes definir conjuntos de entidades, que representan las tablas o vistas en la base de datos, y luego acceder a estas entidades para realizar operaciones de base de datos.
Además de representar una sesión de trabajo con la base de datos, el DbContext también se encarga de establecer la conexión con la base de datos, realizar el seguimiento de las entidades cargadas, administrar las transacciones y realizar operaciones de cambio en la base de datos a través del mecanismo de cambio de Entity Framework.
En resumen, el DbContext es una clase central en Entity Framework que proporciona una interfaz para interactuar con la base de datos, realizar consultas y modificaciones en los datos, y gestionar el seguimiento de los cambios en las entidades.




Que son las Consultas LINQ.


Las consultas LINQ (Language Integrated Query, consulta integrada en el lenguaje) son una característica de C# (y otros lenguajes de programación compatibles) que permite realizar consultas y manipulaciones de datos de manera intuitiva y uniforme sobre diferentes fuentes de datos, como colecciones de objetos, bases de datos relacionales, servicios web y más.
LINQ combina la sintaxis del lenguaje con la capacidad de escribir consultas de forma declarativa, lo que significa que puedes expresar lo que deseas obtener en lugar de especificar cómo obtenerlo. Esto facilita la escritura de consultas complejas y reduce la cantidad de código necesario para realizar operaciones de filtrado, ordenación, agrupación y proyección de datos.
Las consultas LINQ se basan en expresiones y operadores que se combinan para formar una consulta. Algunos de los operadores comunes que se pueden utilizar en las consultas LINQ incluyen:
From: especifica la fuente de datos sobre la cual se realizará la consulta.
Where: se utiliza para filtrar los datos según una condición específica.
OrderBy / OrderByDescending: se utiliza para ordenar los datos en orden ascendente o descendente.
Select: se utiliza para proyectar los datos y seleccionar solo las propiedades o valores necesarios.
Join: se utiliza para combinar datos de múltiples fuentes basándose en una clave común.
GroupBy: se utiliza para agrupar los datos según una determinada propiedad.
Aggregate: se utiliza para realizar operaciones de agregación, como sumas, promedios, máximos, mínimos, etc.


Existen LINQ para base de datos NoSQL.


existen consultas LINQ para bases de datos NoSQL como MongoDB. Entity Framework Core, una versión ligera y multiplataforma de Entity Framework, admite bases de datos NoSQL, incluida MongoDB.
Para utilizar LINQ con MongoDB, primero debes agregar los paquetes necesarios a tu proyecto de C# mediante NuGet. Los paquetes requeridos son MongoDB.Driver y MongoDB.Driver.Linq.
Una vez que hayas instalado los paquetes, puedes usar la sintaxis de consultas LINQ para realizar consultas y manipulaciones de datos en MongoDB. Algunos ejemplos de operadores LINQ que se pueden utilizar con MongoDB incluyen:
Where: se utiliza para filtrar documentos según una condición específica.
Select: se utiliza para seleccionar propiedades específicas de los documentos.
OrderBy / OrderByDescending: se utiliza para ordenar los documentos según una propiedad específica.
Skip / Take: se utiliza para paginar los resultados de la consulta.
GroupBy: se utiliza para agrupar los documentos según una propiedad específica.
Aggregate: se utiliza para realizar operaciones de agregación, como sumas, promedios, máximos, mínimos, etc.

Collection.AsQueryable()
El método AsQueryable() se utiliza para convertir una colección de MongoDB en un objeto IQueryable<T>, lo cual permite utilizar la sintaxis de consultas LINQ sobre esa colección.

IFramework.EntityFrameworkCore.Blueshift.MongoDB.
Es como una librería no oficial, que permitiría entablar MongoDB con EF.
Me aparecen errores de Versiones, las cuales Blueshift llega hasta la 2.2.2 y EF hasta la 7.0.5, no son compatibles. 


MongoFramework.
  
  
Git Oficial.
  
  
https://github.com/TurnerSoftware/MongoFramework
  
  
MongoFramework es una biblioteca de mapeo de objetos (Object-Document Mapper o ODM) para MongoDB en el entorno de desarrollo de .NET. Proporciona una capa de abstracción sobre la biblioteca oficial de MongoDB para facilitar la interacción y el mapeo de objetos entre una aplicación .NET y una base de datos MongoDB.
MongoFramework permite a los desarrolladores utilizar modelos de objetos y realizar operaciones CRUD (crear, leer, actualizar y eliminar) en MongoDB sin tener que preocuparse por los detalles de bajo nivel de la biblioteca de MongoDB. Proporciona una sintaxis simple y orientada a objetos para trabajar con documentos y colecciones en MongoDB.
Algunas características y funcionalidades clave de MongoFramework incluyen:
Mapeo de objetos a documentos de MongoDB: Permite definir clases de modelos en C# que representan documentos en MongoDB y realizar el mapeo automático entre los objetos y los documentos de la base de datos.
Operaciones CRUD: Permite realizar operaciones de creación, lectura, actualización y eliminación de documentos en MongoDB utilizando métodos simples y expresivos.
Consultas LINQ: Permite utilizar consultas LINQ (Language Integrated Query) para realizar consultas avanzadas en MongoDB, lo que facilita la escritura de consultas complejas y la manipulación de datos.
Relaciones y referencias: Permite establecer relaciones y referencias entre objetos y documentos en MongoDB, lo que facilita el trabajo con datos relacionales y la navegación entre entidades relacionadas.
Integración con ASP.NET Core: Proporciona integración con el marco de trabajo ASP.NET Core, lo que facilita la implementación de aplicaciones web y API RESTful utilizando MongoDB como base de datos.
En resumen, MongoFramework es una biblioteca de mapeo de objetos para MongoDB en .NET que simplifica el trabajo con MongoDB al proporcionar una capa de abstracción y una sintaxis orientada a objetos para interactuar con la base de datos.

