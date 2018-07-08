namespace MyDiary.FileServer.Domain.Models.FactoryPattern
{
    public interface IRepositoryFactory 
    {
        IRepositoryProvider CreateInstance(IRepository repository);
    }
}
