using System.Linq;

namespace ViewModelsLab.Domain
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}