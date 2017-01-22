using Web.Models;

namespace Web.Services
{
    interface IOperationResultRepository : IEntityRepository<OperationResult>
    {
        //void Clean();
        Operation FindOperByName(string name);
    } 
}
