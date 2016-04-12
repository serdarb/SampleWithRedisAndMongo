using System;
using System.Text;
using Project.Business.Managers;
using Project.Common.Models.Request;
using Project.Common.Models.Response;
using Project.Data.Repository;
using Project.Business.Mappers;
using Project.Common.Contracts;
using Project.Common.Helpers;
using Project.Common.Models;
using Project.Data.Entity;

namespace Project.Business
{
    public class PersonService : IPersonService
    {
        readonly PersonRepository _personRepository;

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
            catch (Exception ex)
            {
                response.Message = string.Format("Insert to database failed!{0}{1}", Environment.NewLine, ex.Message);
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

                var cacheKey = "Person-" + request.UId;
                CacheManager.AddOrUpdateItem(cacheKey, model);
            }
            catch (Exception ex)
            {
                response.Message = string.Format("Update entity failed on database process!{0}{1}", Environment.NewLine, ex.Message);
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
                var cacheKey = "Person-" + request.UId;
                var cachedItem = CacheManager.GetItem(cacheKey);
                if (cachedItem == null)
                {
                    var entity = _personRepository.SelectOne(request.UId);
                    var model = PersonMapper.MapModelFromEntity(entity);
                    response.Model = model;
                    CacheManager.AddOrUpdateItem(cacheKey, model);
                }
                else
                {
                    response.Model = (PersonModel) cachedItem;
                }
            }
            catch (Exception ex)
            {
                response.Message = string.Format("Selecting failed while getting from database!{0}{1}", Environment.NewLine, ex.Message);
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

            var result = _personRepository.SelectPage(request.Skip, request.Take, request.Filter);
            response.TotalCount = result.Count;

            foreach (var item in result.Items)
            {
                var model = PersonMapper.MapModelFromEntity(item);
                response.Items.Add(model);
            }

            return response;
        }

    }
}
