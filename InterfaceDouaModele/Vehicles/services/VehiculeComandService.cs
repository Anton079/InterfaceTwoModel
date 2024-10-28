using InterfaceDouaModele.models;
using InterfaceDouaModele.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.services
{
    public class VehiculeComandService
    {
        private IVehiculeRepository _veRepository;

        public VehiculeComandService(IVehiculeRepository vehiculRepository)
        {
            _veRepository = vehiculRepository;
        }

        //crud

        public Vehicul RemoveVehicul(Vehicul vehicul)
        {
            if (vehicul != null && _veRepository.FindById(vehicul.Id) != null)
            {
                _veRepository.Remove(vehicul);
                return vehicul;
            }

            return null;
        }

        public Vehicul AddVehicul(Vehicul vehicul)
        {
            if (vehicul != null && _veRepository.FindById(vehicul.Id) == null)
            {
                _veRepository.Add(vehicul);
                return vehicul;
            }
            return null;
        }

        public Vehicul UpdateOameni(Vehicul vehicul)
        {
            if (vehicul != null && _veRepository.FindById(vehicul.Id) != null)
            {
                _veRepository.UpdateVehicul(vehicul);
                return vehicul;
            }
            return null;
        }

    }
}
