using Business.Automapper;
using Business.Interfaces;
using DTO.Response.Constans;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DTO.Request;
using DataAccess.Context;
using Common.logs;
using Microsoft.EntityFrameworkCore;

namespace Business.BLL
{
    public class StudentBLL : IStudentBLL
    {
        private readonly WebserviceContext _db;

        public StudentBLL(WebserviceContext db)
        {
            _db = db;
        }

        public virtual async Task<GenericResponse<StudentResponse>> Get(string document)
        {
            try
            {

                Student entityRecord = await _db.Set<Student>().FirstOrDefaultAsync(x => x.Document == document);

                StudentResponse record = ConvertMapping<StudentRequest, StudentResponse, Student, object>.ConvertToResponseModel(entityRecord);

                if (record is not null)
                {
                    return GenericResponse<StudentResponse>.ResponseOK(record);
                }
                else
                {
                    return GenericResponse<StudentResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<StudentResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<StudentResponse>>> GetAll()
        {
            try
            {

                List<Student> entityRecordList = await _db.Set<Student>().ToListAsync();

                List<StudentResponse> recordList = ConvertMapping<StudentRequest, StudentResponse, Student, object>.ConvertToResponseModelList(entityRecordList);

                if (recordList.Count() > 0)
                {
                    return GenericResponse<IEnumerable<StudentResponse>>.ResponseOK(recordList);
                }
                else
                {
                    return GenericResponse<IEnumerable<StudentResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<StudentResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<StudentResponse>> Modify(StudentResponse modifiedModel)
        {
            try
            {
                Student modifiedEntity = ConvertMapping<StudentResponse, StudentResponse, Student, object>.ConvertToEntity(modifiedModel);

                _db.Entry(modifiedEntity).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                StudentResponse model = ConvertMapping<StudentRequest, StudentResponse, Student, object>.ConvertToResponseModel(modifiedEntity);

                if (model != null)
                {
                    return GenericResponse<StudentResponse>.ResponseOK(model);
                }
                else
                {
                    return GenericResponse<StudentResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<StudentResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<StudentResponse>> Insert(StudentRequest model)
        {
            try
            {
                Student entity = ConvertMapping<StudentRequest, StudentResponse, Student, object>.ConvertToEntity(model);
                _db.Set<Student>().Add(entity);
                await _db.SaveChangesAsync();
                StudentResponse modelResponse = ConvertMapping<StudentRequest, StudentResponse, Student, object>.ConvertToResponseModel(entity);

                if (model != null)
                {
                    return GenericResponse<StudentResponse>.ResponseOK(modelResponse);
                }
                else
                {
                    return GenericResponse<StudentResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<StudentResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<StudentResponse>> Delete(string document)
        {
            try
            {
                Student entityDelete = await _db.Set<Student>().FirstOrDefaultAsync(x => x.Document == document);
                if (entityDelete is not null)
                {
                    _db.Entry(entityDelete).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();

                    Student entityRecord = await _db.Set<Student>().FirstOrDefaultAsync(x => x.Document == document);

                    if (entityRecord == null)
                    {
                        return GenericResponse<StudentResponse>.ResponseOKDelete(ConstansApp.Messages.Delete);
                    }
                    else
                    {
                        return GenericResponse<StudentResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                    }
                }
                else
                {
                    return GenericResponse<StudentResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<StudentResponse>.ResponseError(ex.Message);
            }
        }
    }
}
