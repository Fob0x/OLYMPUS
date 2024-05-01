using System.IO;
using System;

namespace OLYMPUS
{
    internal class OUTPUT
    {
        /*
            Назначение: Описание и объявление нестандартных типов, глобальных
                        данных и объектов.
            Автор: Землянухин Роман Михайлович, КБХА, 106 отдел
            Версия: 01.01
            Дата: 12.03.2024
        */
        public OUTPUT() { }
        
        public static void Output1()
        {
            DateTime now = DateTime.Now;
            string way_str = DECLARE.wayOut;

            using (StreamWriter fout = new StreamWriter(way_str))
            {
                fout.WriteLine("Выходные данные для программного комплекса \"OLYMPUS-MVSC\"");
                fout.WriteLine("*************************************************************");
                fout.WriteLine($"Версия: 02.01 Дата: {now.Day}.{(now.Month >= 9 ? "" : "0")}{now.Month}.{now.Year}");

                fout.WriteLine("\n1. Геометрические параметры объекта\n");
                fout.WriteLine($"{DECLARE.R} - радиус шара, м\n");

                fout.WriteLine("\n2. Физические параметры объекта\n");
                fout.WriteLine($"{DECLARE.Lambda} - коэффициент теплопроводности, Вт/(м*К)");
                fout.WriteLine($"{DECLARE.Ro} - плотность, кг/м^3");
                fout.WriteLine($"{DECLARE.Cv} - теплоемкость, Д/(кг*К)");
                fout.WriteLine($"{DECLARE.T0} - начальная температура, К");
                fout.WriteLine($"{DECLARE.Tz} - температура окружающей среды\n");

                fout.WriteLine("\n3. Параметры алгоритма\n");
                fout.WriteLine($"{DECLARE.Eps} - точность вычислений");
                fout.WriteLine($"{DECLARE.Nr} - количество узлов вдоль R-оси");
                fout.WriteLine($"{DECLARE.Nt} - количество узлов вдоль t-оси");
                fout.WriteLine($"{DECLARE.MaxIter} - количество итераций\n");

                fout.WriteLine("\n4. Управляющие параметры\n");
                fout.WriteLine($"{DECLARE.PrintStep} - шаг вывода результата\n");

                fout.WriteLine("\n5. Числа подобия\n\n\n\n\n");
                fout.WriteLine("№ Шаг Число Фурье Таблица температур");
            }
        }
        public static void Output2()
        {
            // Вывод в файл промежуточных результатов
            //if (DECLARE.Step % DECLARE.PrintStep == 0) Почему-то появляется деление на нуль
            if (DECLARE.PrintStep != 0 && DECLARE.Step % DECLARE.PrintStep == 0)
            {
                string way_str = DECLARE.wayOut;
                using (StreamWriter fout = new StreamWriter(way_str, true))
                {
                    fout.AutoFlush = true;
                    fout.WriteLine();
                    fout.Write($"{DECLARE.Step / DECLARE.PrintStep} {DECLARE.Step} {DECLARE.Fo} ");
                    for (int r = 0; r <= DECLARE.Nr; r++)
                    {
                        double eval = DECLARE.Theta[r, DECLARE.Step];
                        fout.Write($" {eval}");
                    }
                }
            }

        }
        public static void Output3() { }
        public static void Report() { }
    }
}