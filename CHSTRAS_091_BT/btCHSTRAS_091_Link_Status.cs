using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Link_Status
    {
        private ArrayList list;
        public ArrayList images;
        public ArrayList labels;

        public btCHSTRAS_091_Link_Status(int arrayLength)
        {
            list = new ArrayList(arrayLength);
            images = new ArrayList(arrayLength);
            labels = new ArrayList(arrayLength);
            for (int i = 0; i < 4; i++)
            {
                list.Add(false);
            }
            unset();
        }

        public void unset()
        {
            unsetImages();
            unsetLabels();
        }

        public void unsetImages()
        {
            images = (ArrayList)list.Clone();
        }

        public void unsetLabels()
        {
            labels = (ArrayList)list.Clone();
        }

        public void setImages(int i)
        {
            if ((bool)images[i])
            {
                unsetImages();
            }
            else
            {
                unsetImages();
                images[i] = true;
            }
        }

        public void setLabels(int i)
        {
            if ((bool)labels[i])
            {
                unsetLabels();
            }
            else
            {
                unsetLabels();
                labels[i] = true;
            }
        }

        public int getImages()
        {
            return images.IndexOf(true);
        }

        public int getLabels()
        {
            return labels.IndexOf(true);
        }
    }
}
