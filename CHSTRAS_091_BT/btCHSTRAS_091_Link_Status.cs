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
        public ArrayList links;
        private int arrayLength;

        public btCHSTRAS_091_Link_Status(int arrayLength)
        {
            this.arrayLength = arrayLength;
            list = new ArrayList(arrayLength);
            images = new ArrayList(arrayLength);
            labels = new ArrayList(arrayLength);
            links = new ArrayList(arrayLength);
            for (int i = 0; i < arrayLength; i++)
            {
                list.Add(false);
                links.Add(-1);
            }
            unset();
        }

        public void clean()
        {
            for (int i = 0; i < arrayLength; i++)
            {
                links[i] = -1;
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

        public void setLinks()
        {
            int key = getImages();
            int value = getLabels();
            int i = links.IndexOf(value);
            Console.Write("key=" + key + " value=" + value + "\n");
            if (key > -1)
            {
                //如果label已经连线，赋-1，撤销之。
                if (i > -1)
                {
                    links[i] = -1;
                }
                links[key] = value;
                if (value != -1)
                {
                    unset();
                }
            }
            else if(value != -1)
            {
                if (i != -1)
                {
                    links[i] = -1 ;
                }
            }
        }

        public void setImages(int i)
        {
            bool b = (bool)images[i];
            unsetImages();
            if (!b)
            {
                images[i] = true;
            }
        }

        public void setLabels(int i)
        {
            bool b = (bool)labels[i];
            unsetLabels();
            if (!b)
            {
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
