namespace OLYMPUS
{
    internal class EPILOG
    {
        /*
            Назначение: Описание и объявление нестандартных типов, глобальных
                        данных и объектов.
            Автор: Землянухин Роман Михайлович, КБХА, 106 отдел
            Версия: 01.01
            Дата: 12.03.2024
        */

        public EPILOG() { }

        public static void Tesend()
        {
            DECLARE.Step++;
            if (DECLARE.Step > DECLARE.Nt)
                DECLARE.EndCal = true;
        }

        public static void Endrun() { DECLARE.EndExp = true; }
    }
}