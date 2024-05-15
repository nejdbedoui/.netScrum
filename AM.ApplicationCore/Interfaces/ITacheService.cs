using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface ITacheService : IService<Tache>
    {
        List<Tache> GetListOuverte();
        double GetMoyDate();

        IEnumerable<IGrouping<Projet, Tache>> GetListTaches();
    }
}
