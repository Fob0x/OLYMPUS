﻿using System.IO;

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

        public PROLOG() { }

        public static void LabRun() { }
        public static void Clear() { }
        public static void Preset()
        {
            string way_str = DECLARE.wayIn;
            StreamReader fin = new StreamReader(way_str);

            if (fin != null)
            {
                string str;
                double elem;

                // Пропускаем первые 6 строк
                for (int i = 0; i < 6; i++)
                    fin.ReadLine();

                // Считываем и устанавливаем значения переменных DECLARE
                fin.ReadLine(); // Пропускаем первую строку
                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.R = elem;

                fin.ReadLine(); // Пропускаем 3 строки
                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.Lambda = elem;

                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.Ro = elem;

                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.Cv = elem;

                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.T0 = elem;

                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.Tz = elem;

                fin.ReadLine(); // Пропускаем 4 строки
                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.Eps = elem;

                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.Nr = (int)elem; // Явное преобразование double к int

                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.Nt = (int)elem;

                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.MaxIter = (int)elem;

                fin.ReadLine(); // Пропускаем 4 строки
                if (double.TryParse(fin.ReadLine(), out elem))
                    DECLARE.PrintStep = (int)elem;
            }

            fin.Close();
        }
        public static void Data() { }
        public static void Initial() { }
        public static void Auxval() { }
        /// <summary>
        /// В методе управляющим переменным присвиваются значения false, показывающие, 
        /// что вычисления не окончены (они ещё и не начинались) и компьютерный эксперимент не завершён 
        /// (он только начинается при передаче управления методу Contrl)
        /// </summary>
        public static void Start() { DECLARE.EndCal = false; DECLARE.EndExp = false; }
    }
}
