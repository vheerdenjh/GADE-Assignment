using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class GameEngine
    {
        Map map = new Map();

        public void generate()
        {
            map.unitGenerator();
        }
    }
}
