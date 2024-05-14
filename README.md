# Sistema de Gestión de Expedientes - SGE

## Descripción

Este proyecto es un Sistema de Gestión de Trámites y Expedientes, diseñado para gestionar y organizar los con acciones de crear, leer, actualizar y deletar.

## Ejecución
Ejecutando el Program.cs (el cual se encuentra dentro de SGE.Consola) es posible hacer todo por el menú de la consola. Así se puede crear los registros que quiera, así como ingresar los datos de modo incorrecto para mirar las salidas de excepciones.

El flujo de las informaciones salen de la consola para los repositorios y sus respectivos métodos. Los repositorios llaman los casos de uso y manejan el proceso de guardar los datos. Los casos de uso manejan las reglas del negocio dentro de la Aplicación.

La aplicación no conoce repositorios ni consola. Repositorios conoce Aplicacion pero no Consola. Consola conoce repositorio y aplicación.

### Expediente
Cuando creados empiezan automáticamente con la data de modificación y creación iguales, así como con el estado de recién iniciado.
Cuando se elige modificar se puede modificar la carátula o el estado (entre los listados para elegir). la fecha de modificación se actualiza, así como el id del usuario que hace la modificación.
Cuando se elige dar baja basta poner el id del expediente para dar baja, todos los trámites asociados también son eliminados.El estado es automáticamente cambiado cuando haya una creación, baja o modificación de trámites que involucren etiqueta, entonces, si está dentro de las reglas del negocio y es el último trámite, el estado se cambia.

Para probar la funcionalidad se puede seguir estos pasos:
- crear un expediente
- consultar el expediente y verificar que estado es recién iniciado- crear un trámites asociados a el expediente creado- modificar el trámite y elegir la etiqueta PaseAEstudio- consultar el expediente creado y verificar que el estado se cambió para ParaResolver
- crear un tramite nuevo
- consultar el trámite y verificar que el estado no se cambió
- modificar la etiqueta del primero tramite para PaseAlArchivo
consultar el expediente y verificar que el estado todavía no modificó, porque el trámite cambiado no era el último
- dar baja en el último trámite
- consultar el expediente y verificar que el estado se cambió para Finalizado, porque ahora el último trámite tiene la etiqueta de archivo.

Si intenta crear/modificar/bajar con id de usuário que no sea de id 1 sale error de autenticaciónSi intenta crear/modificar con la carátula vacía sale un error de validación
Si intenta consultar/modificar/bajar un expediente por Id que no existe entonces sale error general de no encontrado

### Trámite
Cuando creados empiezan automáticamente con la data de modificación y creación iguales, así como con el estado de recién iniciado.
Cuando se elige modificar se puede modificar el contenido o la etiqueta (entre los listados para elegir). la fecha de modificación se actualiza, así como el id del usuario que hace la modificación.
Cuando se elige dar baja basta poner el id del expediente o del trámite para dar baja individual o en bloque.


Si intenta crear/modificar/bajar  con id de usuário que no sea de id 1 sale error de autenticación
Si intenta crear/modificar con el contenido vacío sale un error de validación
Si intenta crear con un Id de expediente no válido, sale un error general de no encontrado
Si intenta modificar/bajar/consultar un trámite por Id que no existe entonces sale error general de no encontradoSi intenta modificar/bajar/consultar por id de expediente que no existe sale un error de no encontrado

## Aclaraciones
- Usuário no es una entidad implementada con detalles como las demás, solo fue implementada para que se pueda crear usuarios y guardar los valores
- Las interfaces de los repositorios no fueron implementadas una vez que estos van cambiar para banco de datos y toda la lógica se modifica