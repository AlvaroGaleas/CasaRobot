using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Infraestructura.AccesoDatos.Repositorio
{
    public class RepositorioImpl<T>: IRepositorio<T> where T : class
    {
        private readonly CasaRobot2Context _context;
        private readonly DbSet<T> _dbSet;

        public RepositorioImpl (CasaRobot2Context context)
        {
            _context = context;
            _dbSet= context.Set<T>();
        }

        public async Task AddAsync(T entidad)
        {
            try
            {
                await _dbSet.AddAsync(entidad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar registro," + ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entidad = await GetbyIdAsync(id);
                _dbSet.Remove(entidad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar registro," + ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar registro," + ex.Message);
            }
        }

        public async Task<T> GetbyIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar registro," + ex.Message);
            }
        }

        public async Task UpdateAsync(T entidad)
        {
            try
            {
                _dbSet.Update(entidad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar registro," + ex.Message);
            }
        }
    }
}
