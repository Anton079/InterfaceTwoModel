using InterfaceDouaModele.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.services
{
    public interface IVehiculeComandService
    {
        Vehicul AddVehicul(Vehicul vehicul);

        Vehicul RemoveVehicul(Vehicul vehicul);

        Vehicul UpdateVehicul(Vehicul vehicul);
    }
}
