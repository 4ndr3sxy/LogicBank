-Ejecutar aplicativo:
  Gestor DB SQL Server: ejecutar script de ruta /scriptDB/script_Db_BlueBank.sql
  Clonar repositorio en Visual Studio .Net
-Arquitectura planteada:
  Uso de modelo relacional, entre usuario y cuentas, siendo: "Un usuario puede tener muchas cuentas, pero una cuenta solo la puedfe tener un usuario"; relacion (users) de 1 a M (accounts)
-Tecnologias seleccionadas:
  *Visual Studio .Net
  *Entity Framework
  *MVC
  *log4net
  *POO
-Mejoras con mas tiempo:
  *Creacion de Login para manejo de cuentas segun la session iniciada.
  *Encryptacion de datos(tanto para usuario como cuentas) debido a la informacion delicada que se maneja; (Mejora seguridad de la informacion)
  *Reglas de negocio(Abono inicial para crear cuenta, informacion detallada en DB, tipo de encriptacion, manejo de excepciones, entro otros)
  *Campos date_updated funcionando con fecha en ese momento (DataTime.now())
  *Archivos log4net separados (manejos individuales de info, errores y demas opciones existentes en el sistema)
  *Manejo condicionales especificas
  *Mejorar modularidad en DB (city y contry en otras tablas, y manejo de seguridad desde DB)

