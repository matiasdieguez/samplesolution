/*
SQL Deployment Script
----------------------
El contenido de este script se ejecutará una vez commiteado al correr
el Release Pipeline sobre la base de datos del ambiente configurado

Este script debe ser generado apuntando el connection string en
/ProjectName.Api/appsettings.js al ambiente deseado,
posicionandose sobre la carpeta /ProjectName.Api y
ejecutando el siguiente comando:

dotnet ef migrations script

Luego revisar el script y verificar las modificaciones, y en caso
de ser necesario editar el script para que esté haciendo lo deseado
y sea seguro de correr en el ambiente de destino
*/