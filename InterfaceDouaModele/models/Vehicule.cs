using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDouaModele.models
{
    public class Vehicul
    {
        private int _id;
        private string _type;
        private string _model;
        private int _hp;

        public Vehicul(string proprietati)
        {
            string[] tokne = proprietati.Split(',');

            _id = int.Parse(tokne[0]);
            _type = tokne[1];
            _model = tokne[2];
            _hp = int.Parse(tokne[3]);
        }

        public Vehicul(int id, string type, string model, int hp)
        {
            _id = id;
            _type = type;
            _model = model;
            _hp = hp;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public override string ToString()
        {
            return $"{Id},{Type},{Model},{Hp}";
        }

        public override bool Equals(object? obj)
        {
            Vehicul vehicul = obj as Vehicul;
            return _id == vehicul._id;
        }

        public string ToSave()
        {
            return Id + "," + Type + "," + Model + "," + Hp;
        }
    }

}
