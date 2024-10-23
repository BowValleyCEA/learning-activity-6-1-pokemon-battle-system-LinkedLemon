using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1401_la_starter
{
    internal class Pokemon
    {
        public string _name;
        protected Types _type;
        private int _damage;
        private int _health;
        private int _maxHealth;
        
        public Pokemon(string name) 
        {
            _name = name;
            _type = Types.Normal;
            _damage = new Random().Next(2, 12);
            _health = new Random().Next(30, 100);
            _maxHealth = _health;
        }
        public int GetAttackDamage()
        {
               return _damage += new Random().Next(0, 3);
        }

        public int TakeDamage(int otherDamage)
        {
            _health -= otherDamage;

            if (_health < 0)
            {
                Console.WriteLine(_name + " has died");
            }
            else
            {
                Console.WriteLine(_name + " has took " + otherDamage + " damage points");
            }

            return _health;
        }

        public int GetCurrentHealth()
        {
            //Console.WriteLine(_name + "s current health is " + _health);
            return _health;
        }
        public Types GetType()
        {
            return _type;
        }

        public string GetName()
        {
            return _name;
        }

        public int HealHealth(int healAmount)
        {
            if ((_health + healAmount) > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health += healAmount;
            }
            return _health;
        }

        public enum Types
        {
            Fire,
            Grass,
            Electric,
            Water,
            Normal
        }
    }
}
