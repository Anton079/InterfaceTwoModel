using InterfaceDouaModele.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.services
{
    public interface IOameniQueryService
    {
        List<Oameni> getAll();

        Oameni FindOameniById(int id);
    }
}
