--PPI


-Para los fines prácticos de la prueba decidí usar un mockDB. En el cual están los Activos, Cuentas, Estados.
Y en donde también se realizan las acciones solicitadas de crear, ver, actualizar y eliminar Ordenes.

-Se utilizó AutoMapper para el mapeo de objetos. (Entidades, DTOs y Requests)

-También dejo un Schema SQL, para configurar una base de datos fácilmente en caso de ser necesario.



Consideraciones: 
-Debido a falta de tiempo, no pude implementar los puntos optativos que se mencionan en el challenge. 
Iba a implementar la seguridad con apiKey y secretKey.
-Las propiedades apiKey y secretKey las iba a dejar en la configuración del proyecto para poder acceder.
-Por medio de un endpoint Login. Donde se compararía la apiKey y secretKey generando un TOKEN.



