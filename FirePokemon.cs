﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1401_la_starter
{
    internal class FirePokemon : Pokemon
    {
        
        public FirePokemon(string name) : base(name)
        {
            _type = Types.Fire;
        }
    }
}
