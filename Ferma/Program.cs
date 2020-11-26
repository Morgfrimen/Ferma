using FermaLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;

namespace Ferma
{

    internal class Program
    {

        #region Methods

        private static void Main(string[] args)
        {
            bool runApp = true;
            Console.WriteLine("Запуск расчета");

            while (runApp)
                try
                {

                    Console.Write("Введите L (длина), мм: ");

                    if (!double.TryParse(Console.ReadLine(), out double L) && L < 0)
                    {
                        Console.WriteLine("Ошибка! Введенно не корректное число!");

                        continue;
                    }

                    Console.Write("Введите H (высота), мм: ");

                    if (!double.TryParse(Console.ReadLine(), out double H) && H < 0)
                    {
                        Console.WriteLine("Ошибка! Введенно не корректное число!");

                        continue;
                    }

                    Console.Write("Введите угол, градуссы: ");

                    if (!double.TryParse(Console.ReadLine(), out double Alfa))
                    {
                        Console.WriteLine("Ошибка! Введенно не корректное число!");

                        continue;
                    }

                    Console.WriteLine("Запуск расчета координат!");
                    Task task = Task.Run
                    (
                        () =>
                        {
                            IEnumerable<IPoint2D> position = Core.Core.CreateInstance().GetSymmetricalHingerodScheme(L, H, Alfa).GetPosition();

                            foreach (IPoint2D position1 in position)
                            {
                                Console.WriteLine($"Точка: ({position1.X.ToString("F2",CultureInfo.GetCultureInfo("en-US"))} , {position1.Y.ToString("F2", CultureInfo.GetCultureInfo("en-US"))})");
                            }

                        }
                    );

                    if (!task.Wait(new TimeSpan(0, 0, 1)))
                        throw new TimeoutException();

                    Console.WriteLine("Расчет координат завершен!");
                    Console.WriteLine("Продолжить?(Д\\Н)");
                    if (Console.ReadKey().KeyChar.ToString().ToUpper() == "Н")
                        runApp = false;
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка, проверьте входные параметры. В случае правильности данных, сообщите об этом разработчику.");
                }
        }

        #endregion

    }

}