using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class TacheService : Service<Tache>, ITacheService
    {
        public TacheService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Tache> GetListOuverte()
        {
            return GetMany(t => t.Etat == EtatTache.Ouverte).OrderBy(t => t.Titre).ToList();
        }

        public double GetMoyDate()
        {
            var taches = GetMany(t => t.Etat == EtatTache.Fermee);
            List<TimeSpan> durees = new List<TimeSpan>();
            foreach (Tache t in taches)
            {
                TimeSpan duree = t.DateDebut - t.DateDebut;
                durees.Add(duree);
            }
            return durees.Any() ? durees.Sum(d => d.TotalDays) / durees.Count : 0;
        }

        public IEnumerable <IGrouping<Projet,Tache>> GetListTaches()
        {
            return GetAll().GroupBy(t=>t.Sprint.Projet).ToList();
        }

    }
}
