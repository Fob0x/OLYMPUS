using System;

namespace OLYMPUS
{
    internal class CALCULE
    {
        /*
            Назначение: Описание и объявление нестандартных типов, глобальных
                        данных и объектов.
            Автор: Землянухин Роман Михайлович, КБХА, 106 отдел
            Версия: 01.01
            Дата: 12.03.2024
        */
        public CALCULE() { }

        static double SinRange(double r_, double mu)
        {
            double delta = 1;
            double result = delta;
            int iter = 1;
            while (iter < DECLARE.MaxIter && Math.Abs(delta) >= DECLARE.Eps)
            {
                delta *= (-1) * (r_ * mu) * (r_ * mu) / (2 * iter) / (2 * iter + 1);
                result += delta;
                iter++;
            }
            return result;
        }

        static void CalculateRelativeTemperature()
        {
            double a = DECLARE.Lambda / (DECLARE.Ro * DECLARE.Cv);
            for (int r = 0; r < DECLARE.Nr; r++)
            {
                DECLARE.Fo = a * DECLARE.Step / (DECLARE.R * DECLARE.R);
                DECLARE.Theta[r, DECLARE.Step] = 0;
                double r_ = (double)r / DECLARE.Nr;
                int iter = 1;
                double delta = DECLARE.Eps + 1;
                while (iter < DECLARE.MaxIter && Math.Abs(delta) >= DECLARE.Eps)
                {
                    double mu = iter * Math.PI;
                    int pow = -1;
                    for (int i = 2; i <= iter + 1; i++)
                    {
                        pow *= -1;
                    }
                    double sinRange = SinRange(r_, mu);
                    delta = pow * 2 * sinRange * Math.Exp(-mu * mu * DECLARE.Fo);
                    DECLARE.Theta[r, DECLARE.Step] += delta;
                    iter++;
                }
            }
        }


        public static void Stepon()
        {
            CalculateRelativeTemperature();
        }

        public static void Result() { }

        /*Данный класс реализует вычислительный алгоритм на базе одного из численных методов решения
         * начально-краевой задачи и проводит расчёт основных интегральных характеристик изучаемого
         * процесса или явления.*/
    }
}
