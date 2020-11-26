
using Core.Date;

namespace Core
{
	public class Core
	{
		private Core() { }
		private static Core GetCore { get; set; }
		public static Core CreateInstance()
		{
			GetCore ??= new Core();
			return GetCore;
		}

#pragma warning disable CA1822 // Пометьте члены как статические
		public IAlgoritm GetSymmetricalHingerodScheme(double L, double H, double Alfa)
#pragma warning restore CA1822 // Пометьте члены как статические
		{
			return new SymmetricalHingerodScheme(L, H, Alfa);
		}
	}
}
