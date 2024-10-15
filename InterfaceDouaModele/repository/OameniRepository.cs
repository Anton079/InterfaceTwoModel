using InterfaceDouaModele.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.repository
{
    public class OameniRepository : IOameniRepository
    {
        private List<Oameni> oameniList;

        public OameniRepository()
        {
            oameniList = new List<Oameni>();
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
                        Oameni oameni = new Oameni(line);
                        this.oameniList.Add(oameni);

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

            string file = Path.Combine(folder, "Oameni");

            return file;
        }

        private void SaveData()
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

            for (int i = 0; i < oameniList.Count; i++)
            {
                save += oameniList[i].ToString();

                if (i < oameniList.Count - 1)
                {
                    save += "\n";
                }
            }

            return save;
        }

        //crud
        public Oameni Add(Oameni oameni)
        {
            this.oameniList.Add(oameni);
            this.SaveData();

            return oameni;
        }

        public List<Oameni> getAll()
        {
            return oameniList;
        }

        public Oameni Remove(Oameni oameni)
        {
            oameniList.Remove(oameni);
            this.SaveData();

            return oameni;
        }

        public Oameni UpdateOameni(Oameni oameni)
        {
            Oameni oameniUpdate = FindById(oameni.Id);

            if(oameniUpdate.FullName != null)
            {
                oameniUpdate.FullName = oameni.FullName;
            }

            if(oameniUpdate.Mail != null)
            {
                oameniUpdate.Mail = oameni.Mail;
            }

            if(oameniUpdate.Password != null)
            {
                oameniUpdate.Password = oameni.Password;
            }

            this.SaveData();
            return oameniUpdate;
        }

        public Oameni FindById(int id)
        {
            foreach(Oameni x in oameniList)
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
