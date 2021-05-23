using Backend.Models;
using Backend.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class ClienteCore
    {
        PetHouseDBContext dbContext;
        public ClienteCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Cliente> GetAll()
        {
            try
            {
                //List<Cliente> clientes = (
                //    from c in dbContext.Cliente
                //    select c).ToList();

                //return clientes;

                //var clientesSimple = (
                //    from cs in dbContext.Cliente
                //    join ci in dbContext.Ciudad on cs.CiudadId equals ci.ID
                //    select new
                //    {
                //        nombre = cs.Nombre,
                //        apellidoPaterno = cs.ApellidoPaterno,
                //        apellidoMaterno = cs.ApellidoMaterno,
                //        ciudad = ci.Nombre
                //    }).ToList();

                List<Cliente> clientes = dbContext.Cliente
                .Include(x => x.Ciudad)
                .Include(y => y.Ciudad.Estado)
                .Include(z => z.Ciudad.Estado.Pais)
                .ToList();

                return clientes;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> Get()
        {
            try
            {
                List<Cliente> clientesActivos = dbContext.Cliente
                .Include(x => x.Ciudad)
                .Include(y => y.Ciudad.Estado)
                .Include(z => z.Ciudad.Estado.Pais)
                .Where(cliente => cliente.Bloqueado == false)
                .ToList();

                return clientesActivos;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public ClienteVM GetFromId(int idParam)
        {
            try
            {
                var query = (from Cliente in dbContext.Cliente
                             join Ciudad in dbContext.Ciudad on Cliente.CiudadId equals Ciudad.Id
                             join Estado in dbContext.Estado on Ciudad.EstadoId equals Estado.ID
                             where Cliente.ID == idParam
                             select new
                             {
                                 id = Cliente.ID,
                                 nombre = Cliente.Nombre,
                                 apellidoPaterno = Cliente.ApellidoPaterno,
                                 apellidoMaterno = Cliente.ApellidoMaterno,
                                 correoElectronico = Cliente.CorreoElectronico,
                                 estadoId = Ciudad.EstadoId,
                                 estado = Estado.Nombre,
                                 ciudadId = Cliente.CiudadId,
                                 ciudad = Ciudad.Nombre,
                                 calle = Cliente.Calle,
                                 noExterior = Cliente.NumExt,
                                 noInterior = Cliente.NumInt,
                                 codigoPostal = Cliente.CodigoPostal,
                                 telefono = Cliente.NumeroTelefonico,
                                 celular = Cliente.NumeroCelular,
                                 bloqueado = Cliente.Bloqueado
                                }).First();

                ClienteVM restructure = new ClienteVM()
                {
                    id = query.id,
                    nombre = query.nombre,
                    apellidoPaterno = query.apellidoPaterno,
                    apellidoMaterno = query.apellidoMaterno,
                    correoElectronico = query.correoElectronico,
                    estadoId = query.estadoId,
                    estadoNombre = query.estado,
                    ciudadId = query.ciudadId,
                    ciudadNombre = query.ciudad,
                    calle = query.calle,
                    noExterior = query.noExterior,
                    noInterior = query.noInterior,
                    codigoPostal = query.codigoPostal,
                    telefono=query.telefono,
                    celular = query.celular,
                    bloqueado = query.bloqueado

                };

                //IQueryable<Cliente> clienteFromId = dbContext.Cliente
                //.Include(x => x.Ciudad)
                //.Include(y => y.Ciudad.Estado)
                //.Include(z => z.Ciudad.Estado.Pais)
                //.Where(cliente => cliente.ID == idParam);

                return restructure;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Cliente> GetFromEmail(string emailParam)
        {
            try
            {
                IQueryable<Cliente> clienteFromEmail = dbContext.Cliente
                .Include(x => x.Ciudad)
                .Include(y => y.Ciudad.Estado)
                .Include(z => z.Ciudad.Estado.Pais)
                .Where(cliente => cliente.CorreoElectronico == emailParam);

                return clienteFromEmail;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(Cliente cliente)
        {
            try
            {
                if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.ApellidoMaterno) ||
                    string.IsNullOrEmpty(cliente.ApellidoPaterno) || string.IsNullOrEmpty(cliente.Calle) ||
                    cliente.CiudadId.Equals(null) || cliente.CodigoPostal.Equals(null) || string.IsNullOrEmpty(cliente.Contrasena) ||
                    string.IsNullOrEmpty(cliente.CorreoElectronico) || cliente.FechaNacimiento.Equals(null) ||
                    string.IsNullOrEmpty(cliente.NumeroCelular) || string.IsNullOrEmpty(cliente.NumeroTelefonico) ||
                    string.IsNullOrEmpty(cliente.NumExt))
                    return false;

                return true;


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Create(Cliente cliente)
        {
            try
            {
                if(Validate(cliente))
                {
                    dbContext.Cliente.Add(cliente);
                    dbContext.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Cliente cliente, int id)
        {
            try
            {
                if(Validate(cliente))
                {
                    if(dbContext.Cliente.Any(x => x.ID == id))
                    {
                        cliente.ID = id;
                        dbContext.Cliente.Update(cliente);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Disable(int id)
        {
            try
            {
                Cliente cliente = dbContext.Cliente.FirstOrDefault(x => x.ID == id && !x.Bloqueado);
                if (cliente != null)
                {
                    cliente.Bloqueado = true;
                    dbContext.Cliente.Update(cliente);
                    dbContext.SaveChanges();
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Enable(int id)
        {
            try
            {
                Cliente cliente = dbContext.Cliente.FirstOrDefault(x => x.ID == id && x.Bloqueado);
                if (cliente != null)
                {
                    cliente.Bloqueado = false;
                    dbContext.Cliente.Update(cliente);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteViewModel GetMascotas(int id)
        {
            try
            {
                //Consultar
                var query = (from Cliente in dbContext.Cliente
                            join Mascota in dbContext.Mascota on Cliente.ID equals Mascota.Cliente.ID
                            where Cliente.ID == id
                            select new
                            {
                                Id = Cliente.ID,
                                NombreCompleto = $"{Cliente.Nombre} {Cliente.ApellidoPaterno} {Cliente.ApellidoMaterno}",
                                NombreMascota = Mascota.Nombre,
                                TipoMascota = Mascota.TipoMascota.Nombre,
                                TamanoMascota = Mascota.CategoriaMascota.Nombre
                            }).ToList();

                //Estructurar
                ClienteViewModel restructure = query.GroupBy(x => (x.Id, x.NombreCompleto)).Select(y => new ClienteViewModel
                {
                    nombreCompleto = y.Key.NombreCompleto,
                    mascotas = y.Select(z => new MascotaViewModel
                    {
                        nombre = z.NombreMascota,
                        tamano = z.TamanoMascota,
                        tipo = z.TipoMascota
                    }).ToList()
                }).First();


                return restructure;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
