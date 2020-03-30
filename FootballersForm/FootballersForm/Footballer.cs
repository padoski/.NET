using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballersForm
{
    class Footballer
    {
        private string _name;
        private string _surname;
        private byte _age;
        private float _weight;
        

        public Footballer(string _name, string _surname, byte _age, float _weight)
        {
            this._name = _name;
            this._surname = _surname;
            this._age = _age;
            this._weight = _weight;
        }
        public bool isInList(Footballer pilkarz)
        {
            if (pilkarz._name != _name) return false;
            if (pilkarz._surname != _surname) return false;
            if (pilkarz._age != _age) return false;
            if (pilkarz._weight != _weight) return false;
            return true;
        }
        public override string ToString()
        {
            return _name + " " +   _surname + " " +  + _age + " lat " + _weight + " kg wagi ";
        }
        public string FormatSaving()
        {
            return _name + ";" + _surname + ";" + _age + ";" + _weight;
        }
        public static Footballer FootballerReadyToAdd(string s)
        {
            string name, surname;
            byte age;
            float weight;
            var array = s.Split(';');
            if (array.Length == 4)
            {
                {
                    name = array[0];
                    surname = array[1];
                    age = Convert.ToByte(array[2]);
                    weight = float.Parse(array[3]);
                    return new Footballer(name, surname, age, weight);
                }
            }
            throw new Exception("Błędny format danych z pliku");
        }
        public string getName()
        {
            return _name;
        }
        public void setName(string _name)
        {
            this._name = _name;
        }
        public string getSurname()
        {
            return _surname;
        }
        public void setSurname(string _surnname)
        {
            this._surname = _surnname;
        }
        public byte getAge()
        {
            return _age;
        }
        public void setAge(byte _age)
        {
            this._age = _age;
        }
        public float getWeight()
        {
            return _weight;
        }
        public void setWeight(byte _weight)
        {
            this._weight = _weight;
        }
    }
}
