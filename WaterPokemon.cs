using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static game1401_la_starter.Pokemon;

namespace game1401_la_starter
{
    internal class WaterPokemon : Pokemon
    {

        public WaterPokemon(string name) : base(name)
        {
            _type = Types.Water;
        }

    }
}
