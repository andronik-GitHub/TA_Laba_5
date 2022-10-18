using System;

class Laba_5
{
    static void Main()
    {
        Rabita_Karpa_Algorithm RKA = new("abcdeabfgfcakmbddaf", "bfgfc");
        Console.WriteLine("Rabina-Karpa Algorithm: " + RKA.Rabina());


        KMP_Algorithm KMP = new("аbаbааbаbаbаbсbаbаbаbаbсаbb", "аbаbаbаbса");
        Console.WriteLine("KMP Algorithm: " + KMP.KMPSearch());


        Console.ReadKey();
    }
}