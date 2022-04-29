using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs
{
    public interface IDNAUser
    {
        public void Init();
        public void Configure(DNA dna);
    }
}
