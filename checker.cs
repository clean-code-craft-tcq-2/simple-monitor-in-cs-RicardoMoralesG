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


    private static float BATERY_MAX_TEMPERATURE = 45f;
    private static float BATERY_MIN_TEMPERATURE = 0f;

    private static float BATERY_MAX_STATEOFCHARGE = 80f;
    private static float BATERY_MIN_STATEOFCHARGE = 20f;

    private static float BATERY_LIMIT = 0.8f;

    private static float TOLERANCE_IN_PERCENTAGE = 0.05f;
    static int Main()
    {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");

        Debug.Assert(rangeIsOK(BATERY_MIN_TEMPERATURE, BATERY_MAX_TEMPERATURE, -1.3f) == false);
        Debug.Assert(rangeIsOK(BATERY_MIN_TEMPERATURE, BATERY_MAX_TEMPERATURE, 45.5f) == false);

        Debug.Assert(rangeIsOK(BATERY_MIN_STATEOFCHARGE, BATERY_MAX_STATEOFCHARGE, 19.5f) == false);
        Debug.Assert(rangeIsOK(BATERY_MIN_STATEOFCHARGE, BATERY_MAX_STATEOFCHARGE, 80.2f) == false);

        Debug.Assert(temperatureUnderLimit(BATERY_LIMIT, 0.75f) == true);




        return 0;
    }

    static bool rangeIsOK(float MIN, float MAX, float Value)
    {

        var tolerance = MAX * TOLERANCE_IN_PERCENTAGE;

        var temperatureUpper = MAX - tolerance;

        var lowertemperatureLimit = MIN + tolerance;

        if (Value <= lowertemperatureLimit || Value >= temperatureUpper)
        {

            PrintAlert();

            return false;
        }
        else
        {
            return true;
        }

    }

    static bool temperatureUnderLimit(float temperatureLimit, float Value)
    {
        var tolerance = temperatureLimit * TOLERANCE_IN_PERCENTAGE;

        var temperatureUpper = temperatureLimit - tolerance;

        if (Value >= temperatureUpper)
        {
            PrintAlert();


            return false;
        }
        else
        {
            return true;
        }

    }


    public static string PrintAlert()
    {


        string alert = "Alert: Please Check Battery Level";
        Console.WriteLine(string.Format("{0}", alert));

        return alert;


    }
}