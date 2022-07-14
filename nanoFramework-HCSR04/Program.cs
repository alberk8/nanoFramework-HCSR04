using Iot.Device.Hcsr04.Esp32;
using System;
using System.Diagnostics;
using System.Threading;
using UnitsNet;

namespace nanoFramework_HCSR04
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");


            using (var sonar = new Hcsr04(18, 19))
            {
                try
                {
                    int count = 1;
                    while (true)
                    {
                        if (sonar.TryGetDistance(out Length distance))
                        {
                            Debug.WriteLine($"Distance: {distance.Centimeters} cm  memory: {nanoFramework.Runtime.Native.GC.Run(false)} Cnt: {count} ");
                        }
                        else
                        {
                            Debug.WriteLine("Error reading sensor");
                        }
                        count++;

                        Thread.Sleep(200);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("nF Error: " + ex.Message);
                }
            }

            Thread.Sleep(Timeout.Infinite);


        }
    }
}
