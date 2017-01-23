using Models;

namespace Services
{
    public interface IOperationResultRepository : IEntityRepository<OperationResult>
    {
        //void Clean();
        Operation FindOperByName(string name);
        User FindUserById(int Id);
    } 
}
