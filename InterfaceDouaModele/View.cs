using InterfaceDouaModele.models;
using InterfaceDouaModele.repository;
using InterfaceDouaModele.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele
{
    public class View
    {
        private IVehiculeQueryService _vehiculeQueryService;
        private IVehiculeComandService _vehiculeComandService;
        private IOameniQueryService _oameniQueryService;
        private IOameniComandService _oameniComandService;

        public View(IVehiculeQueryService vehiculeQueryService, IVehiculeComandService vehiculeComandService, IVehiculeRepository vehiculeRepository,
            IOameniQueryService oameniQueryService, IOameniComandService oameniComandService, IOameniRepository oameniRepository)
        {
            _vehiculeQueryService = vehiculeQueryService;
            _vehiculeComandService = vehiculeComandService;
            _oameniQueryService = oameniQueryService;
            _oameniComandService = oameniComandService;
        }

        public void Meniu()
        {
            Console.WriteLine("1. Vezi toate vehiculele");
            Console.WriteLine("2. Adauga un vehicul");
            Console.WriteLine("3. Sterge un vehicul");
            Console.WriteLine("4. Editare vehicul");
            Console.WriteLine("5. Vezi toti oamenii");
            Console.WriteLine("6. Adauga un om");
            Console.WriteLine("7. Sterge un om");
            Console.WriteLine("8. Editare om");
            Console.WriteLine("9. Iesi");
        }

        public void Play()
        {
            bool running = true;
            while (running)
            {
                Meniu();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        AfisareVehicule();
                        break;

                    case "2":
                        AddVehicul();
                        break;

                    case "3":
                        RemoveVehicul();
                        break;

                    case "4":
                        EditVehicul();
                        break;

                    case "5":
                        AfisareOameni();
                        break;

                    case "6":
                        AddOm();
                        break;

                    case "7":
                        RemoveOm();
                        break;

                    case "8":
                        EditOm();
                        break;

                    case "9":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Optiune invalida");
                        break;
                }
            }
        }



        public void AfisareVehicule()
        {
            var vehicule = _vehiculeQueryService.getAll();
            if (vehicule == null || vehicule.Count == 0)
            {
                Console.WriteLine("Nu sunt vehicule disponibile.");
            }
            else
            {
                foreach (Vehicul vehicul in vehicule)
                {
                    Console.WriteLine(vehicul);
                }
            }
        }

        public void AddVehicul()
        {
            Console.WriteLine("Introdu datele vehiculului: ");
            Console.Write("ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("Tip: ");
            string type = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Putere (HP): ");
            int hp = Int32.Parse(Console.ReadLine());

            Vehicul newVehicul = new Vehicul(id, type, model, hp);
            _vehiculeComandService.AddVehicul(newVehicul);

            Console.WriteLine("Vehicul adaugat cu succes!");
        }

        public void RemoveVehicul()
        {
            Console.Write("Introdu ID-ul vehiculului de sters: ");
            int id = Int32.Parse(Console.ReadLine());

            Vehicul vehicul = _vehiculeQueryService.FindVehiculById(id);
            if (vehicul != null)
            {
                _vehiculeComandService.RemoveVehicul(vehicul);
                Console.WriteLine("Vehicul sters cu succes.");
            }
            else
            {
                Console.WriteLine("Vehiculul nu a fost gasit.");
            }
        }

        public void EditVehicul()
        {
            Console.Write("Introdu ID-ul vehiculului pe care vrei sa-l editezi: ");
            int id = Int32.Parse(Console.ReadLine());

            Vehicul vehicul = _vehiculeQueryService.FindVehiculById(id);
            if (vehicul != null)
            {
                Console.WriteLine("Ce atribut doresti sa modifici?");
                Console.WriteLine("1. Tip");
                Console.WriteLine("2. Model");
                Console.WriteLine("3. Putere (HP)");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.Write("Introdu noul tip: ");
                        vehicul.Type = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Introdu noul model: ");
                        vehicul.Model = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Introdu noua putere (HP): ");
                        vehicul.Hp = Int32.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        return;
                }

                _vehiculeComandService.UpdateVehicul(vehicul);
                Console.WriteLine("Vehiculul a fost actualizat cu succes.");
            }
            else
            {
                Console.WriteLine("Vehiculul nu a fost gasit.");
            }
        }

        public void AfisareOameni()
        {
            var oameni = _oameniQueryService.getAll();
            if (oameni == null || oameni.Count == 0)
            {
                Console.WriteLine("Nu sunt oameni disponibili.");
            }
            else
            {
                foreach (Oameni om in oameni)
                {
                    Console.WriteLine(om);
                }
            }
        }

        public void AddOm()
        {
            Console.WriteLine("Introdu datele omului: ");
            Console.Write("ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("Nume complet: ");
            string fullName = Console.ReadLine();

            Console.Write("Email: ");
            string mail = Console.ReadLine();

            Console.Write("Parola: ");
            string password = Console.ReadLine();

            Oameni newOameni = new Oameni(id, fullName, mail, password);
            _oameniComandService.AddOameni(newOameni);

            Console.WriteLine("Om adaugat cu succes!");
        }

        public void RemoveOm()
        {
            Console.Write("Introdu ID-ul omului de sters: ");
            int id = Int32.Parse(Console.ReadLine());

            Oameni om = _oameniQueryService.FindOameniById(id);
            if (om != null)
            {
                _oameniComandService.RemoveOameni(om);
                Console.WriteLine("Om sters cu succes.");
            }
            else
            {
                Console.WriteLine("Omul nu a fost gasit.");
            }
        }

        public void EditOm()
        {
            Console.Write("Introdu ID-ul omului pe care vrei sa-l editezi: ");
            int id = Int32.Parse(Console.ReadLine());

            Oameni om = _oameniQueryService.FindOameniById(id);
            if (om != null)
            {
                Console.WriteLine("Ce atribut doresti sa modifici?");
                Console.WriteLine("1. Nume complet");
                Console.WriteLine("2. Email");
                Console.WriteLine("3. Parola");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.Write("Introdu noul nume complet: ");
                        om.FullName = Console.ReadLine();
                        break;

                    case "2":
                        Console.Write("Introdu noul email: ");
                        om.Mail = Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Introdu noua parola: ");
                        om.Password = Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        return;
                }

                _oameniComandService.UpdateOameni(om);
                Console.WriteLine("Omul a fost actualizat cu succes.");
            }
            else
            {
                Console.WriteLine("Omul nu a fost gasit.");
            }
        }

    }
}
