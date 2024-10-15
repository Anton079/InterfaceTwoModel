using InterfaceDouaModele.models;
using InterfaceDouaModele.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.services
{
    public class VehiculeQueryService
    {
        private IVehiculeRepository _vehiculRepository;

        public VehiculeQueryService(IVehiculeRepository vehiculRepository)
        {
            _vehiculRepository = vehiculRepository;
        }

        public List<Vehicul> getAll()
        {

            List<Vehicul> vehiculs = _vehiculRepository.getAll();

            if (vehiculs.Count == 0)
            {

                return null;
            }

            return vehiculs;
        }

        public Vehicul FindOameniById(int id)
        {
            Vehicul vehiculs = _vehiculRepository.FindById(id);

            return vehiculs;
        }
    }

}
