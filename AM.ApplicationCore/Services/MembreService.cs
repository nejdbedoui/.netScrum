using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class MembreService : Service<Membre>, IMembreService
    {
        public MembreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int NbTache(string id)
        {
            var taches= GetById(id).Taches.Where(t=>t.Etat==EtatTache.EnCours);
            return taches.Count();
        }
    }
}
