using InterfaceDouaModele.models;
using InterfaceDouaModele.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.services
{
    internal class OameniComandService : IOameniComandService
    {

        private IOameniRepository _omRepository;

        public OameniComandService(IOameniRepository oameniRepository)
        {
            _omRepository = oameniRepository;
        }

        //crud

        public Oameni RemoveOameni(Oameni oameni)
        {
            if (oameni != null && _omRepository.FindById(oameni.Id) != null)
            {
                _omRepository.Remove(oameni);
                return oameni;
            }

            return null;
        }

        public Oameni AddOameni(Oameni oameni)
        {
            if (oameni != null && _omRepository.FindById(oameni.Id) == null)
            {
                _omRepository.Add(oameni);
                return oameni;
            }

            return null;
        }

        public Oameni UpdateOameni(Oameni oameni)
        {
            if (oameni != null && _omRepository.FindById(oameni.Id) != null)
            {
                _omRepository.UpdateOameni(oameni);
                return oameni;
            }
            return null;
        }

    }
}
