using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottlePuzzle
{
    internal class Bottle
    {
        private int capacity { get;}
        public int content { get; private set; }

        public Bottle(int Capacity)
        {
            capacity = Capacity;
        }

        public bool FillToTop(Bottle otherBottle)
        {
            var volumeNeeded = capacity - content;
            if (otherBottle.content < volumeNeeded) { return  false;}
            content = capacity;
            otherBottle.Remove(volumeNeeded);
            return true;
        }

        private void Remove(int volumeNeeded)
        {
            content -= volumeNeeded;
        }

        public bool Fill(int volume)
        {
            if (volume + content > capacity) { return  false; }
            content += volume;
            return true;
        }

        public int Empty()
        {
            int Content = content;
            content = 0;
            return Content;
        }

        public bool isEmpty()
        {
            return content == 0;
        }

        internal void FillToTopFromTap()
        {
            content = capacity;
        }
    }
}
