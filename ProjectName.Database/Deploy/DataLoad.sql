/*
SQL Data Deployment Script
----------------------
El contenido de este script se ejecutará una vez commiteado al correr
el Release Pipeline sobre la base de datos del ambiente configurado,
luego de haber corrido UpdateDatabase.sql

Este script debe insertar, actualizar o borrar datos en el ambiente
de destino según sea necesario

Revisar el script para que esté haciendo lo deseado
y sea seguro de correr en el ambiente de destino
*/

BEGIN TRANSACTION;  
  
BEGIN TRY  

    --Reemplazar por los datos
    SELECT 1

END TRY  
BEGIN CATCH  

    -- Se hace rollback si hay un error
    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  
  
    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
  
IF @@TRANCOUNT > 0  
    COMMIT TRANSACTION;  
GO  