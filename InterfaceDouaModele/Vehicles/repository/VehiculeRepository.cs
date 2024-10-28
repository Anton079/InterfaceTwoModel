using InterfaceDouaModele.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.repository
{
    public class VehiculeRepository : IVehiculeRepository
    {
        private List<Vehicul> vehiculList;

        public VehiculeRepository()
        {
            vehiculList = new List<Vehicul>();
            Load();
        }

        public void Load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Vehicul vehicul = new Vehicul(line);
                        vehiculList.Add(vehicul);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "Vehicule");

            return file;
        }

        public void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetFilePath()))
                {
                    sw.WriteLine(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string ToSaveAll()
        {
            string save = "";

            for (int i = 0; i < vehiculList.Count; i++)
            {
                save += vehiculList[i].ToString();

                if (i < vehiculList.Count - 1)
                {
                    save += "\n";
                }
            }

            return save;
        }

        //CRUD
        public Vehicul Add(Vehicul vehicul)
        {
            this.vehiculList.Add(vehicul);
            this.SaveData();

            return vehicul;
        }

        public List<Vehicul> getAll()
        {
            return vehiculList;
        }

        public Vehicul Remove(Vehicul vehicul)
        {
            vehiculList.Remove(vehicul);
            this.SaveData();

            return vehicul;
        }

        public Vehicul UpdateVehicul(Vehicul vehicul)
        {
            Vehicul vehUpdate = FindById(vehicul.Id);

            if(vehicul.Hp != -1)
            {
                vehUpdate.Hp = vehicul.Hp;
            }

            if(vehicul.Type != null)
            {
                vehUpdate.Type = vehicul.Type;
            }

            if(vehicul.Model != null)
            {
                vehUpdate.Model = vehicul.Model;
            }

            this.SaveData();
            return vehUpdate;
        }

        public Vehicul FindById(int id)
        {
            foreach(Vehicul x in vehiculList)
            {
                if(x.Id == id)
                {
                    return x;
                }
            }
            return null;
        }
    }
}
