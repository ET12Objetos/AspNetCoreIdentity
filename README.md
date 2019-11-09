# Asp Net Core Identity

## Configuración

1. Clonar el repositorio
2. Compilar la solución (CTRL + SHIFT + B)
3. Actualizar el connectionString en el archivo de configuración **appsettings.json**

Modelo de ConnectionString ```"server=NOMBRE_SERVER;database=NOMBRE_DB;user=USUARIO;password=CONTRASEÑA"``` donde: 

- *NOMBRE_SERVER*: es nombre de dominio o IP del servidor de base de datos, por ejemplo **win2012-01** si es remoto o **localhost** 
si es la misma PC
- *NOMBRE_DB*: es el nombre de la base de datos o SCHEMA
- *USUARIO*: usuario con el cual se accede al servidor de base de datos
- *CONTRASEÑA*: contraseña asociada al usuario de la base de datos

Un ejemplo del archivo de configuración **appsettings.json** es:
```json
{
  "ConnectionStrings": {
    "db_usuarios": "server=localhost;database=db_usuarios;user=root;password=1234"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

4. Abrir la consola en el menú **Herramientas** -> **Administrador de paquetes NuGet** -> **Consola del Administrador de paquetes**
5. Dentro la consola copiar y pega la siguiente linea, luego pulsar la tecla *enter* para confirmar:
```sh
dotnet ef migrations add Initial -p IdentityTemplate -c AplicacionDbContext
```
**AplicacionDbContext**: es la clase que contiene al contexto del modelo de datos

6. Realizar el mismo procedimiento con la siguiente linea:
```sh
dotnet ef database update -p IdentityTemplate
```
7. En el Workbench, en la sección de **SCHEMAS** deberán tener una base de datos creada con el nombre de la base de datos que 
indicaron en el archivo de configuracion, en este caso será **db_usuarios**, ahi se almacenaran los usuarios creados entre otras cosas
8. Operar desde la aplicación web

---

## Migraciones

**Migrations** es una caracteristica que posee **Entity Framework** la cual posiblita la creación del modelo de datos en código C#
y persistencia a una base de datos mediante una biblioteca llamada **provider**, nos permite:

- Crear una base de datos vacia mediante el modelo de datos
- Generar migraciones, para tener un seguimiento de cambios que se realizan en el modelo de datos
- Mantener la base de datos actualizada con esos cambios

### Como se crea una migración ?

Abrir la consola en el menú **Herramientas** -> **Administrador de paquetes NuGet** -> **Consola del Administrador de paquetes**

Escribir el siguiente comando ```dotnet ef migrations add NOMBRE_MIGRACION -p NOMBRE_PROYECTO -c NOMBRE_CONTEXTO``` donde:

- *NOMBRE_MIGRACION* es el nombre de la migracion, cada migracion debe tener un nombre que la identique y debe ser único
- *NOMBRE_PROYECTO* es el nombre del proyecto en donde se creara la migración 
- *NOMBRE_CONTEXTO* es el nombre del **contexto**, el contexto es una clase en donde se encuentran las listas que representan 
las tablas de la base de datos y los mapeos de cada atributo

Al momento de ejecutar si salió todo bien, deberá aparecer un mensaje con el nombre de ```DONE.``` 

Un error muy común con MySQL es la conversion de tipo de datos a bool (no existe ese tipo de datos en MySQL) por lo cual 
en el siguiente [enlace](https://github.com/aspnet/EntityFrameworkCore/issues/14051#issuecomment-444264243) hay una solución

### Como se persiste una migración a la base de datos?

Mediante el siguiente comando se indica que quiere persistir todos los cambios 
```dotnet ef database update -p NOMBRE_PROYECTO``` de la última migración a la base de datos
