using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project.Common.Models.Request;
using Project.Common.Models.Response;
using Project.Data.Repository;
using Project.Business.Mappers;
using Project.Common.Contracts;
using Project.Common.Helpers;

namespace Project.Business
{
    public class PersonService : IPersonService
    {
        PersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public PersonInsertResponse Insert(PersonInsertRequest request)
        {
            var response = new PersonInsertResponse();

            if (request.IsNotValid())
            {
                response.Message = ConstHelper.REQUEST_NOT_VALID;
                return response;
            }

            try
            {
                var entity = PersonMapper.MapEntityFromRequest(request);
                _personRepository.Insert(entity);

                var model = PersonMapper.MapModelFromEntity(entity);
                response.Model = model;
            }
            catch (Exception)
            {
                response.Message = "Insert to database failed!";
                return response;
            }            

            response.Status = true;
            response.Message = "Person inserted.";
            return response;
        }
        
        public PersonUpdateResponse Update(PersonUpdateRequest request)
        {
            var response = new PersonUpdateResponse();

            if (request.IsNotValid())
            {
                response.Message = ConstHelper.REQUEST_NOT_VALID;
                return response;
            }

            try
            {
                var entity = _personRepository.SelectOne(request.UId);
                if (entity == null)
                {
                    response.Message = "There is no entity with this uid!";
                    return response;
                }

                PersonMapper.MapEntityFromRequest(request, entity);
                var result = _personRepository.Update(entity);

                if (result.ModifiedCount != 1)
                {
                    response.Message = "Update could not be done!";
                    return response;
                }

                var model = PersonMapper.MapModelFromEntity(entity);
                response.Model = model;
            }
            catch (Exception)
            {
                response.Message = "Update entity failed on database process!";
                return response;
            }

            response.Status = true;
            response.Message = "Person updated.";
            return response;
        }

        public PersonSelectResponse Select(PersonSelectRequest request)
        {
            var response = new PersonSelectResponse();

            if (request.IsNotValid())
            {
                response.Message = ConstHelper.REQUEST_NOT_VALID;
                return response;
            }

            try
            {                
                var entity = _personRepository.SelectOne(request.UId);
                var model = PersonMapper.MapModelFromEntity(entity);
                response.Model = model;
            }
            catch (Exception)
            {
                response.Message = "Selecting failed while getting from database!";
                return response;
            }

            response.Status = true;
            response.Message = "Person selected.";            
            return response;
        }

        public PersonSelectPageResponse SelectPage(PersonSelectPageRequest request)
        {
            var response = new PersonSelectPageResponse();

            if (request.IsNotValid())
            {
                response.Message = ConstHelper.REQUEST_NOT_VALID;
                return response;
            }



            return response;
        }

    }
}
