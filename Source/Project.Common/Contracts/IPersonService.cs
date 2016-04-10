using Project.Common.Models.Request;
using Project.Common.Models.Response;

namespace Project.Common.Contracts
{
    public interface IPersonService
    {
        /// <summary>
        /// Inserts person entity. 
        /// Email is a required field for person.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status is true if inserted</returns>
        PersonInsertResponse Insert(PersonInsertRequest request);

        /// <summary>
        /// Updates person entity.
        /// Email can not be updated.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PersonUpdateResponse Update(PersonUpdateRequest request);

        /// <summary>
        /// Selects person entity via Uid.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PersonSelectResponse Select(PersonSelectRequest request);

        /// <summary>
        /// Selects list of person entities with page limit.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PersonSelectPageResponse SelectPage(PersonSelectPageRequest request);

       
    }
}
