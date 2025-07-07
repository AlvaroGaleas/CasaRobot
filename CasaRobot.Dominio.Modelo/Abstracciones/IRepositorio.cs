using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Dominio.Modelo.Abstracciones
{
    public interface IRepositorio <T> where T : class
    {
        Task AddAsync(T entidad);//Insertar
        Task DeleteAsync(int id);//Eliminar
        Task UpdateAsync(T entidad);//Actualizar
        Task<IEnumerable<T>> GetAllAsync();//Select *
        Task<T> GetbyIdAsync(int id);//Buscar entidades por ID
    }
}
