using System.Linq;

namespace ViewModelsLab.Domain
{
    public interface IUnitOfWork
    {
        // Doesn't define any members - this interface is simply to allow injection of 
        // per HTTP request context instance into repositories 
    }
}