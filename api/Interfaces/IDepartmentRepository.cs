using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Department;
using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<Department> CreateAsync(Department departmentModel);
        Task<Department?> UpdateAsync(int projectId, int departmentId, UpdateDepartmentRequestDto departmentDto);
        Task<Department?> DeleteAsync(int id);
    }
}