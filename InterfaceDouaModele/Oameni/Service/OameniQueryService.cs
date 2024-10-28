using InterfaceDouaModele.models;
using InterfaceDouaModele.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.services
{
    public class OameniQueryService : IOameniQueryService
    {
        private IOameniRepository _oameniRepository;

        public OameniQueryService(IOameniRepository oameniRepository)
        {
            _oameniRepository = oameniRepository;
        }

        public List<Oameni> getAll()
        {

            List<Oameni> oameni = this._oameniRepository.getAll();

            if (oameni.Count == 0)
            {

                return null;
            }

            return oameni;
        }

        public Oameni FindOameniById(int id)
        {
            Oameni oameni = _oameniRepository.FindById(id);

            return oameni;
        }

    }
}
