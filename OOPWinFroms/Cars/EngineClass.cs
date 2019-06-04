using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Cars
{
    class EngineClass : CarPart
    {
        private static HashSet<int> AllSN = new HashSet<int>();
        public int SerialNumber { get; set; }
        public float Quality { get; }
        public float MaxSpeed { get; }

        public EngineClass(int serialNumber, float quality, float maxSpeed)
        {
            if (quality < 0f || quality > 1f)
                throw new Exception("Incorrect engine's quality! (value should be in range [0 .. 1])");
            Quality = quality;
            if (maxSpeed < 0)
                throw new Exception("Incorrect engine's maxSpeed! (value should be greater than zero)");
            MaxSpeed = maxSpeed;
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
        }

        public EngineClass(float quality, float maxSpeed) : this(-1, quality, maxSpeed) { }

        public override int GetCost()
        {
            return (int)(Quality + MaxSpeed);
        }

        public override string ToString()
        {
            return string.Format($"Serial number = {SerialNumber}, Quality = {Quality}, MaxSpeed = {MaxSpeed}");
        }
    }
}
