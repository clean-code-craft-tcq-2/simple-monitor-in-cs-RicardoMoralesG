using System;
using System.Diagnostics;

class Checker
{
    static bool batteryIsOk(float temperature, float soc, float chargeRate) {
        //if(temperature < 0 || temperature > 45) {
        //    Console.WriteLine("Temperature is out of range!");
        //    return false;
        //} else if(soc < 20 || soc > 80) {
        //    Console.WriteLine("State of Charge is out of range!");
        //    return false;
        //} else if(chargeRate > 0.8) {
        //    Console.WriteLine("Charge Rate is out of range!");
        //    return false;
        //}

        return rangeIsOK(0f, 45f, temperature) && rangeIsOK(20f, 80f, soc) && temperatureUnderLimit(0.8f, chargeRate);
        return true;
    }

    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");

        Debug.Assert(temperatureUnderLimit(0.8f, 0.70f) == true);
        Debug.Assert(temperatureUnderLimit(0.8f, 0.80f) == false);

        Debug.Assert(rangeIsOK(0f, 45f, 0f) == false);
        Debug.Assert(rangeIsOK(0f, 45f, 46f) == false);

       
              

        return 0;
    }


    static bool rangeIsOK(float MIN, float MAX, float Value)
    {

        if (Value <= MIN || Value => MAX)
        {

            return false;
        }

        return true;

    }

    static bool temperatureUnderLimit(float temperatureLimit, float Value)
    {

        if (Value => temperatureLimit)
        {

            return false;
        }

        return true;

    }
}