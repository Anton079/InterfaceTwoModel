using InterfaceDouaModele.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.repository
{
    public interface IVehiculeRepository
    {
        Vehicul Add(Vehicul vehicul);

        List<Vehicul> getAll();

        Vehicul Remove(Vehicul vehicul);

        Vehicul UpdateVehicul(Vehicul vehicul);

        Vehicul FindById(int id);
    }
}
