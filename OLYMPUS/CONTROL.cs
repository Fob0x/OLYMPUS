namespace OLYMPUS
{
    
    internal class CONTROL
    {
        /*
            Назначение: Описание и объявление нестандартных типов, глобальных
                        данных и объектов.
            Автор: Землянухин Роман Михайлович, КБХА, 106 отдел
            Версия: 01.01
            Дата: 12.03.2024
        */

        public CONTROL() { }
        public static void Contrl() 
        {
            PROLOG.LabRun();
            PROLOG.Clear();
            PROLOG.Initial();
            PROLOG.Auxval();
            PROLOG.Start();
            OUTPUT.Output1();
            do
            {
                CALCULE.Stepon();
                OUTPUT.Output2();
                EPILOG.Tesend();
            } while (!DECLARE.EndCal);
            CALCULE.Result();
        }

        
    }
}
