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
        public static void Preset() { }
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
