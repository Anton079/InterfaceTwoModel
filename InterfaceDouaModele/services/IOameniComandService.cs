using InterfaceDouaModele.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.services
{
    public interface IOameniComandService
    {
        Oameni AddOameni(Oameni oameni);

        Oameni RemoveOameni(Oameni oameni);

        Oameni UpdateOameni(Oameni oameni);
    }
}
