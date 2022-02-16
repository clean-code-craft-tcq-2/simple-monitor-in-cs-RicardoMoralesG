using System;
using System.Diagnostics;

class Checker
{
    static bool batteryIsOk(float temperature, float soc, float chargeRate)
    {
      

        return rangeIsOK(0f, 45f, temperature) && rangeIsOK(20f, 80f, soc) && temperatureUnderLimit(0.8f, chargeRate);
       
    }

    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main()
    {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");

       
        Debug.Assert(rangeIsOK(0f, 45f, -1.3f) == false, "Temperature under range");
        Debug.Assert(rangeIsOK(0f, 45f, 45.5f) == false, "Temperature over range");




        return 0;
    }


    static bool rangeIsOK(float MIN, float MAX, float Value)
    {

        if (Value <= MIN || Value >= MAX)
        {

            return false;
        }

        return true;

    }

    static bool temperatureUnderLimit(float temperatureLimit, float Value)
    {

        if (Value > temperatureLimit)
        {

            return false;
        }

        return true;

    }
}