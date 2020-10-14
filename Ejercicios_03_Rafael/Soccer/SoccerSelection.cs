using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_03.Soccer
{
    abstract class SoccerSelection : SoccerSelectionMember
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }

        abstract public void Focus();
        abstract public void PlayAGame();
        abstract public void Train();
        abstract public void Travel();
    }
}
