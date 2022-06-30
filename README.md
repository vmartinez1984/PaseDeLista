# Conexión MS SQL con EF

https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core


# Comandos básicos de ef
 Finalmente generamos la migración

 dotnet ef migrations add InitialCreate

 Cargamos el script en la base de datos
 
 dotnet ef database update

 # Para borrar la base de datos
 dotnet ef database drop

 dotnet ef migrations remove