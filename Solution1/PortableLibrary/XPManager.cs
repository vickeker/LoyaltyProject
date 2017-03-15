using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary
{
   public class XPManager
    {
        private XP xp;

        public XPManager(int pBarId, int pUserId)
        {
            xp = initXP(pBarId, pUserId);
        }
        


        private XP initXP(int pBarId, int pUserId)
        {
            XP mxp = new XP();
            if (pUserId == 1)
            {
                if (pBarId == 1)
                {
                    mxp.currentXP = 100;
                    mxp.potentialXP = 130;
                }
                else if (pBarId == 2)
                {
                    mxp.currentXP = 260;
                    mxp.potentialXP = 300;
                } else if (pBarId == 3)
                {
                    mxp.currentXP = 180;
                    mxp.potentialXP = 200;
                }
                else
                {
                    mxp.currentXP = 45;
                    mxp.potentialXP = 60;
                }
            }
            else if (pUserId==2) {
                if (pBarId == 1)
                {
                    mxp.currentXP = 90;
                    mxp.potentialXP = 140;
                }
                else if (pBarId == 2)
                {
                    mxp.currentXP = 250;
                    mxp.potentialXP = 280;
                }
                else if (pBarId == 3)
                {
                    mxp.currentXP = 300;
                    mxp.potentialXP = 320;
                }
                else
                {
                    mxp.currentXP = 0;
                    mxp.potentialXP = 0;
                }
            }
            else if (pUserId == 3)
            {
                if (pBarId == 1)
                {
                    mxp.currentXP = 50;
                    mxp.potentialXP = 90;
                }
                else if (pBarId == 2)
                {
                    mxp.currentXP = 120;
                    mxp.potentialXP = 170;
                }
                else if (pBarId == 3)
                {
                    mxp.currentXP = 150;
                    mxp.potentialXP = 180;
                }
                else
                {
                    mxp.currentXP = 200;
                    mxp.potentialXP = 230;
                }
            }
            else
            {
                mxp.currentXP = 0;
                mxp.potentialXP = 0;
            }
            return mxp;
        }
    }
}
