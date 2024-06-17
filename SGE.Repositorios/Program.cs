// using System;
// using SGE.Aplicacion;

// var dbContext = new SGEContexto();

// SGESqlite.Inicializar();
// var repositorioUsuarios = new UsuarioRepositorioSqlite(dbContext);

// var casoDeUsoUsuarioAlta = new CasoDeUsoUsuarioAlta(repositorioUsuarios);

// var usuario = new Usuario
// {
//     Email = "admin@mail.com",
//     Nombre = "Administrador",
//     Apellido = "Test",
//     Password = "admin",
//     Permisos = new List<Permiso> { 
//         Permiso.ExpedienteAlta,
//         Permiso.ExpedienteBaja,
//         Permiso.ExpedienteModificacion,
//         Permiso.TramiteAlta,
//         Permiso.TramiteBaja,
//         Permiso.TramiteModificacion,
//         Permiso.UsuarioAlta,
//         Permiso.UsuarioBaja,
//         Permiso.UsuarioModificacion,
//         Permiso.UsuarioConsulta,
//     }
// };

// casoDeUsoUsuarioAlta.Ejecutar(usuario);