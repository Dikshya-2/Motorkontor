using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motorkontor.Services
{
    public class CounterStatesService
    {
        public int Count { get; set; }

        public void Increment ()
        {
            Count += 1;

        }
    }

}
