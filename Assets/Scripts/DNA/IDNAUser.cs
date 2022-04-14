using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAStruct
{
    public interface IDNAUser
    {
        public void Init();
        public void Configure(DNA dna);
    }
}
