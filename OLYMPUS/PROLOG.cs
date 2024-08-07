﻿using System;
using System.IO;

namespace OLYMPUS
{
    internal class PROLOG
    {
        /*
            Назначение: Описание и объявление нестандартных типов, глобальных
                        данных и объектов.
            Автор: Землянухин Роман Михайлович, КБХА, 106 отдел
            Версия: 01.01
            Дата: 12.03.2024
        */

        public static void LabRun()
        {
            
            // Инициализация Theta
            DECLARE.Theta = new double[DECLARE.Nr + 1, DECLARE.Nt + 1];

            for (int r = 0; r <= DECLARE.Nr; r++)
            {
                for (int t = 0; t <= DECLARE.Nt; t++)
                {
                    DECLARE.Theta[r, t] = 0; // Инициализация элементов массива
                }
            }
		    
            // Инициализируем путь нахождения файла записи
            /* "В хороших инженерских программах сначала информация записывается в файл, а после оттуда считываются данные*/
            if (DECLARE.wayOut == null)
                DECLARE.wayOut = $"{Environment.CurrentDirectory}\\OLYMPUS\\OutputData\\output_system.txt";

        }
        public static void Clear() { }

        /// <summary>
        /// Считывает данные из файла и подставляет их в inputForm
        /// </summary>
        public static void Preset()
        {
            string way_str = DECLARE.wayIn;
            StreamReader fin = new StreamReader(way_str);

            if (fin != null)
            {
                // Пропускаем первые 6 строк
                for (int i = 0; i < 6; i++)
                    fin.ReadLine();

                // Считываем и устанавливаем значения переменных DECLARE
                DECLARE.R = ReadDoubleFromLine(fin.ReadLine());

                // Пропускаем следующие 3 строки
                for (int i = 0; i < 3; i++)
                    fin.ReadLine();
                DECLARE.Lambda = ReadDoubleFromLine(fin.ReadLine());
                DECLARE.Ro = ReadDoubleFromLine(fin.ReadLine());
                DECLARE.Cv = ReadDoubleFromLine(fin.ReadLine());
                DECLARE.T0 = ReadDoubleFromLine(fin.ReadLine());
                DECLARE.Tz = ReadDoubleFromLine(fin.ReadLine());

                // Пропускаем еще 3 строки
                for (int i = 0; i < 3; i++)
                    fin.ReadLine();
                DECLARE.Eps = ReadDoubleFromLine(fin.ReadLine());
                DECLARE.Nr = (int)ReadDoubleFromLine(fin.ReadLine());
                DECLARE.Nt = (int)ReadDoubleFromLine(fin.ReadLine());
                DECLARE.MaxIter = (int)ReadDoubleFromLine(fin.ReadLine());

                // Пропускаем еще 3 строки 
                for (int i = 0; i < 3; i++)
                    fin.ReadLine();
                DECLARE.PrintStep = (int)ReadDoubleFromLine(fin.ReadLine());
            }
            fin.Close();
        }

        private static double ReadDoubleFromLine(string line)
        {
            string[] elements = line.Split(' '); // Разбиваем строку на массив строк по пробелает
            double elem;
            if (elements.Length > 0 && double.TryParse(elements[0], out elem))
                return elem;
            return 0; // или другое значение по умолчанию
        }
        public static void Data() { }
        public static void Initial()
        {
            DECLARE.Step = 1;
            for (int r = 0; r <= DECLARE.Nr; r++)
                DECLARE.Theta[r, 0] = 1; // если Theta - двумерный массив
        }
        public static void Auxval() { }
        /// <summary>
        /// В методе управляющим переменным присвиваются значения false, показывающие, 
        /// что вычисления не окончены (они ещё и не начинались) и компьютерный эксперимент не завершён 
        /// (он только начинается при передаче управления методу Contrl)
        /// </summary>
        public static void Start() { DECLARE.EndCal = false; DECLARE.EndExp = false; }

        public static void GetWay(string path)
        {
            DECLARE.wayIn = path;
        }
    }
}
