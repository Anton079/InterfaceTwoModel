using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.models
{
    public class Oameni
    {
        private int _id;
        private string _fullName;
        private string _mail;
        private string _password;

        public Oameni(string proprietati)
        {
            string[] tokne = proprietati.Split(',');

            _id = int.Parse(tokne[0]);
            _fullName = tokne[1];
            _mail = tokne[2];
            _password = tokne[3];
        }

        public Oameni(int id, string fullName, string mail, string password)
        {
            _id = id;
            _fullName = fullName;
            _mail = mail;
            _password = password;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public override string ToString()
        {
            return $"{Id},{FullName},{Mail},{Password}";
        }

        public override bool Equals(object? obj)
        {
            Oameni oameni = obj as Oameni;
            return _id == oameni._id;
        }

        public string ToSave()
        {
            return Id + "," + FullName + "," + Mail + "," + Password;
        }
    }

}
