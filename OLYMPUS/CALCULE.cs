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

        /* Этот код реализует вычислительный алгоритм относительной температуры в некоторой системе, 
         * используя метод конечных разностей и тригонометрические ряды.*/

        /// <summary>
        /// Этот метод вычисляет ряд для синуса
        /// </summary>
        /// <param name="r_"></param>
        /// <param name="mu"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Вычисляет распределение относительной температуры по радиальному направлению на каждом шаге времени
        /// </summary>
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
    }
}
