using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary
{
   public class BarManager
    {
        private Bar bar;
        private Bar[] bars;

        public BarManager()
        {
            bars = initBars();
        }

        public String[] getBarList()
        {
            String[] barlist=new String[bars.Length];
            for(int i=0;i<=bars.Length-1;i++)
            {
                barlist[i] = bars[i].name;
                i++; 
            }
            return barlist;
        }

        private Bar[] initBars() //get list of bar from database matching search criteria
        {
            var initBar = new Bar[3];
            initBar[0]= getBarFromId(1);
            initBar[1] = getBarFromId(2);
            initBar[2] = getBarFromId(3);
            return initBar;
        }

        private Bar getBarFromId(int pBarId)
        {
            Bar mBar = new Bar();
            switch (pBarId)
            {
                case 1:
                    mBar.name = "After Hours";
                    mBar.barId = 1;
                    break;
                case 2:
                    mBar.name = "Point Bar";
                    mBar.barId = 2;
                    break;
                case 3:
                    mBar.name = "Pearl";
                    mBar.barId = 3;
                    break;
            }
            return mBar;
        }
    }
}
