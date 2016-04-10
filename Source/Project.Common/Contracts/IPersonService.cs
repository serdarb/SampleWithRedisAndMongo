using Project.Common.Models.Request;
using Project.Common.Models.Response;

namespace Project.Common.Contracts
{
    public interface IPersonService
    {
        /// <summary>
        /// Inserts person entity to database. 
        /// Email is a required field for person.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status is true if inserted</returns>
        PersonInsertResponse Insert(PersonInsertRequest request);

        /// <summary>
        /// Selects person entity via the Uid.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PersonSelectResponse Select(PersonSelectRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PersonSelectPageResponse SelectPage(PersonSelectPageRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PersonUpdateResponse Update(PersonUpdateRequest request);
    }
}
