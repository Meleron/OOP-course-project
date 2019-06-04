using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Cars
{
    class BodyworkClass : CarPart
    {
        private static HashSet<int> AllSN = new HashSet<int>();
        public int SerialNumber { get; }
        public string Color { get; }
        public Types Type { get; }
        public float Quality { get; }

        public BodyworkClass(int serialNumber, string color, Types type, float quality)
        {
            try
            {
                if (color.Length > 20)
                    throw new Exception("Incorrect string length! (secondName's length should 20 or less)");
                Color = color;
                Type = type;
                if (quality < 0f || quality > 1f)
                    throw new Exception("Incorrect bodywork's quality! (value should be in range [0 .. 1])");
                Quality = quality;
                //if (serialNumber < 0)
                //    throw new Exception("Incorrect serial number! (serial number should be greater than zero)");
                int prevSNSize = AllSN.Count;
                if (serialNumber == -1)
                {
                    Random rnd = new Random();
                    while (AllSN.Count == prevSNSize)
                    {
                        SerialNumber = rnd.Next(100000);
                        AllSN.Add(SerialNumber);
                    }
                }
                else
                {
                    AllSN.Add(serialNumber);
                    //if (AllSN.Count == prevSNSize)
                    //    throw new Exception("Incorrect serial number! (not unique)");
                    SerialNumber = serialNumber;
                }
            } catch(NullReferenceException ex)
            {
                throw new NullReferenceException("Parameters can't be empty!", ex);
            }
        }

        public BodyworkClass(string color, Types type, float quality):this(-1, color, type, quality){}

        //public BodyworkClass(string color, Types type, float quality):this(color, type, quality, new Random().Next(0, 10000)) { }

        public override int GetCost()
        {
            return (int)Quality * 10;
        }

        public override string ToString()
        {
            return string.Format($"SerialNumber = {SerialNumber}, Color = {Color}, Type = {(int)Type}, Quality = {Quality}");
        }
    }
}
