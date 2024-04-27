using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IStudentBLL
    {
        Task<GenericResponse<StudentResponse>> Get(string document);
        Task<GenericResponse<IEnumerable<StudentResponse>>> GetAll();
        Task<GenericResponse<StudentResponse>> Modify(StudentResponse modeloModificado);
        Task<GenericResponse<StudentResponse>> Insert(StudentRequest modelo);
        Task<GenericResponse<StudentResponse>> Delete(string document);
    }
}
