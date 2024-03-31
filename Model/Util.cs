using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Util
    {
        public System.Drawing.Image getImage(byte[] imageBlob)
        {
            System.Drawing.Image img = null;


            using (MemoryStream memoryStr = new MemoryStream(imageBlob))
            {
                img = System.Drawing.Image.FromStream(memoryStr);
            }


            return img;
        }
    }
}
