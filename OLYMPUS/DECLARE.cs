namespace OLYMPUS
{
    internal class DECLARE
    {
        /*
            Назначение: Описание и объявление нестандартных типов, глобальных
                        данных и объектов.
            Автор: Землянухин Роман Михайлович, КБХА, 106 отдел
            Версия: 01.01
            Дата: 12.03.2024
        */

        public static double Fo; // Число Фурье
        public static double[,] Theta; // Профили температуры

        /// <summary>
        /// Отслеживание окончания вычислений
        /// </summary>
        public static bool EndCal;
        /// <summary>
        /// Отслеживание окончания компьютерного эксперимента
        /// </summary>
        public static bool EndExp;
        /// <summary>
        /// Шаг программы
        /// </summary>
        public static int Step;
        /// <summary>
        /// Радиус шара
        /// </summary>
        public static double R;
        /// <summary>
        /// Коэффициент теплопроводности
        /// </summary>
        public static double Lambda;
        /// <summary>
        /// Плотность
        /// </summary>
        public static double Ro;
        /// <summary>
        /// Теплоёмкость
        /// </summary>
        public static double Cv;
        /// <summary>
        /// Начальная температура шара
        /// </summary>
        public static double T0;
        /// <summary>
        /// Температура окружающей среды
        /// </summary>
        public static double Tz;

        /// <summary>
        /// Точность вычислений
        /// </summary>
        public static double Eps;
        /// <summary>
        /// Количество узлов вдоль R-оси
        /// </summary>
        public static int Nr;
        /// <summary>
        /// Количество узлов вдоль T-оси
        /// </summary>
        public static int Nt;
        /// <summary>
        /// Максимальное количество итераций
        /// </summary>
        public static int MaxIter;

        /// <summary>
        /// Шаг вывода результата
        /// </summary>
        public static int PrintStep;

        public static string wayIn; // Путь файла исходных данных
        public static string wayOut ; // Путь файлы выходных данны

        /* 
         * Две управляющие переменные.
         * If True - возникновение события окончания высичлений в соответствии
         * с разработанным алгоритмом или завершение сеанса компьютерного эксперимента.
         * Сохраняем файл
         */
        DECLARE() { }
    }
    

}
