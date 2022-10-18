using System;

class KMP_Algorithm
{
    readonly string line = "";
    readonly string searchLine = "";

    public KMP_Algorithm(string line, string searchLine)
    {
        this.line = line;
        this.searchLine = searchLine;
    }

    public string KMPSearch()
    {
        string nom = "";

        int M = searchLine.Length;
        int N = line.Length;

        // Створити lps[], який зберігатиме найдовші значення суфікса префікса для шаблону
        int[] lps = new int[M];
        int j = 0; // індекс для pat[]

        // Попередньо обробити шаблон (обчислити масив lps[])
        ComputeLPSArray(searchLine, M, lps);

        int i = 0; // індекс для txt[]
        while (i < N)
        {
            if (searchLine[j] == line[i])
            {
                j++;
                i++;
            }
            if (j == M)
            {
                nom += Convert.ToString((i - j) + ", ");
                j = lps[j - 1];
            }

            // Невідповідність після j збігів
            else if (i < N && searchLine[j] != line[i])
            {
                // Не співпадаючі символи lps[0..lps[j-1]], все одно збігатимуться
                if (j != 0) j = lps[j - 1];
                else i++;
            }
        }

        if (nom != "") // якщо входження знайдено
            nom = nom.Substring(0, nom.Length - 2); // видалення зайвої коми і пробіла

        return nom;
    }

    static void ComputeLPSArray(string pat, int M, int[] lps)
    {
        // Довжина попереднього найдовшого суфікса префікса
        int len = 0;
        int i = 1;
        lps[0] = 0; // lps[0] завжди дорівнює 0

        // Цикл обчислює lps[i] для i = 1 до M-1
        while (i < M)
        {
            if (pat[i] == pat[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else // (pat[i] != pat[len])
            {
                // This is tricky. Consider the example.
                // AAACAAAA and i = 7. The idea is similar
                // to search step.
                if (len != 0)
                    len = lps[len - 1];
                else // if (len == 0)
                {
                    lps[i] = len;
                    i++;
                }
            }
        }
    }
}