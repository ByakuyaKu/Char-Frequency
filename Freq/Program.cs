using System;
using System.Collections.Generic;
using System.IO;

namespace Freq
{
    class Program
    {
        static void Main(string[] args)
        {
            string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            List<Alph> Alph = new List<Alph>();

            for (int i = 0; i < alph.Length; i++)
                Alph.Add(new Alph(alph[i], 0));

            string path = @"C:\Users\Aspire R5-571PG\source\repos\Freq\text.txt";
            string InputText = "";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    InputText = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int counter = 0;
            foreach (var item in InputText)
                for (int i = 0; i < Alph.Count; i++)
                    if (item == Alph[i].AlphChar)
                    {
                        Alph[i].count++;
                        counter++;
                    }

            for (int i = 0; i < Alph.Count; i++)
            {
                Alph[i].count /= counter;
                Alph[i].count = Math.Round(Alph[i].count, 2);
            }


            foreach(var item in Alph)
                Console.WriteLine(item.AlphChar + " " + item.count);

            Console.ReadKey();
        }
    }
}
