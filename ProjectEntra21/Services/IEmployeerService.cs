using ProjectEntra21.Domain.Entiteis;
using System.Collections.Generic;

namespace ProjectEntra21.Services
{
    public interface IEmployeerService
    {
        Employeer Create(Employeer employeer);
        Employeer Update(Employeer employeer);
        Employeer FindById(long id);
        List<Employeer> FindAll();
        void Delete(long id);

    }
}
