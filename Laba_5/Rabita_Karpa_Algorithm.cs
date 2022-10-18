using System;
using System.Text;

class Rabita_Karpa_Algorithm
{
    readonly string line = "";
    readonly string searchLine = "";

    public Rabita_Karpa_Algorithm(string line, string searchLine)
    {
        this.line = line;
        this.searchLine = searchLine;
    }


    // Хеш-функція для алгоритма Рабіна-Карпа
    public static int Hash(string x)
    {
        int p = 31; // просте число
        int rez = 0;    // результат обчислення
        for (int i = 0; i < x.Length; i++)
            rez += (int)Math.Pow(p, x.Length - 1 - i) * (int)(x[i]);    // підрахунок хеш-функції

        return rez;
    }

    // Функція пошуку алгоритмом Рабіна-Карпа
    public string Rabina()
    {
        string nom = "";    // номера всіх входжень пошукової строки

        if (searchLine.Length > line.Length) return nom;    // якщо шукана строка більше основної – повернення пустого пошуку

        int xhash = Hash(searchLine);   // обчислення хеш-функції шуканої строки
        int shash = Hash(line.Substring(0, searchLine.Length)); // обчислення хеш-функції першого слова довжини образца в основній строці
        bool flag;
        int j;

        for (int i = 0; i < line.Length - searchLine.Length; i++)
        {
            if (xhash == shash) // якщо значения хеш-функцій співпадають
            {
                flag = true;
                j = 0;

                while ((flag == true) && (j < searchLine.Length))
                {
                    if (searchLine[j] != line[i + j]) flag = false;
                    j++;
                }

                if (flag == true)   // якщо шукана строка співпала з частиною основній
                    nom += Convert.ToString(i) + ", "; // додавання номера вхождения
            }
            else    // іначе обчислення нового значения хеш-функції
                shash = (shash - (int)Math.Pow(31, searchLine.Length - 1) * (int)(line[i])) * 31 + (int)(line[i + searchLine.Length]);
        }

        if (nom != "") // якщо входження знайдено
            nom = nom.Substring(0, nom.Length - 2); // видалення зайвої коми і пробіла

        return nom; // повернення результата пошуку
    }
}