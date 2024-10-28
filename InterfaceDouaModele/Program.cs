using InterfaceDouaModele;
using InterfaceDouaModele.models;
using InterfaceDouaModele.repository;
using InterfaceDouaModele.services;

internal class Program
{
    private static void Main(string[] args)
    {
        VehiculeRepository vehRepository = new VehiculeRepository();
        OameniRepository omRepository = new OameniRepository();

        VehiculeQueryService vehiculeQueryService = new VehiculeQueryService(vehRepository);
        VehiculeComandService vehiculeComandService = new VehiculeComandService(vehRepository);
        OameniQueryService oameniQueryService = new OameniQueryService(omRepository);
        OameniComandService oameniComandService = new OameniComandService(omRepository);

        //View view = new View(vehiculeQueryService, vehiculeComandService, vehRepository, oameniQueryService, oameniComandService, omRepository);








        //test

        //List<Vehicul> toateVehiculele = vehiculeQueryService.getAll();
        //if (toateVehiculele != null)
        //{
        //    Console.WriteLine($"numărul de vehicule: {toateVehiculele.Count}");
        //}
        //else
        //{
        //    Console.WriteLine("nu există vehicule.");
        //}


        //Vehicul vehicul = vehiculeQueryService.FindOameniById(1);
        //if(vehicul != null)
        //{
        //    Console.WriteLine($"vehicul găsit: {vehicul}");
        //}
        //else
        //{
        //    Console.WriteLine("vehicul nu a fost găsit");
        //}



        //Vehicul vehiculNou = new Vehicul(1, "tesla", "s", 200);
        //vehiculeComandService.AddVehicul(vehiculNou);
        //Console.WriteLine("vehicul adăugat.");


        //vehiculNou = new Vehicul(1, "tesla model s", "plus", 220);
        //vehiculeComandService.UpdateOameni(vehiculNou);
        //Console.WriteLine("vehicul actualizat.");


        //vehiculeComandService.RemoveVehicul(vehiculNou);
        //Console.WriteLine("vehicul șters.");


        List<Oameni> toatiOamenii = oameniQueryService.getAll();
        if (toatiOamenii != null)
        {
            Console.WriteLine($"numărul de oameni: {toatiOamenii.Count}");
        }
        else
        {
            Console.WriteLine("nu există oameni.");
        }


        Oameni om = oameniQueryService.FindOameniById(1);
        if (om != null)
        {
            Console.WriteLine($"om găsit: {om}");
        }
        else
        {
            Console.WriteLine("om nu a fost găsit");
        }


        Oameni omNou = new Oameni(1, "ion", "yahooIon", "passwordIon");
        oameniComandService.AddOameni(omNou);
        Console.WriteLine("om adăugat.");


        omNou = new Oameni(1, "ion actualizat", "yahooIon Actual", "password Ion Actualizat");
        oameniComandService.UpdateOameni(omNou);
        Console.WriteLine("om actualizat.");


        oameniComandService.RemoveOameni(omNou);
        Console.WriteLine("om sters.");

    }
}
