using InterfaceDouaModele.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.repository
{
    public interface IOameniRepository
    {
        Oameni Add(Oameni oameni);

        List<Oameni> getAll();

        Oameni Remove(Oameni oameni);

        Oameni UpdateOameni(Oameni oameni);

        Oameni FindById(int id);
    }
}
