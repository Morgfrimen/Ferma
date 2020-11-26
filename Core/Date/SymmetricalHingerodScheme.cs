using System;
using System.Collections.Generic;
using System.Linq;

using ModelsLib;
using ModelsLib.Models;

namespace Core.Date
{

	public class SymmetricalHingerodScheme : IAlgoritm
	{

		#region Static Fields and Constants

		private const uint N = 6;

		#endregion

		#region Constructors

		public SymmetricalHingerodScheme(double l, double h, double alfa)
		{
			if(l < 0 || h < 0 || alfa < 0)
			{
				throw new Exception("Value < 0");
			}

			L = l;
			H = h;
			Alfa = alfa;
		}

		#endregion

		#region Properties

		private double Alfa { get; }

		private double H { get; }

		private double L { get; }

		#endregion

		#region Methods

		public IEnumerable<IPoint2D> GetPosition()
		{
			double OneItem = L / N; //одна часть общей длины
			double TwoItem = OneItem * 2;
			double ThreeItem = OneItem * 3;
			double H1 = Math.Tan(Alfa) * ThreeItem; //вторая часть всей высоты
			double FullH = H + H1;
			double H2 = Math.Tan(Alfa) * OneItem; //часть высоты слева от вершины до фермы

			FermaPositionModels ferma1 = new(OneItem, 0, 0, H);
			FermaPositionModels ferma2 = new(ferma1.PositionX1, ferma1.PositionY1, ThreeItem, 0);
			FermaPositionModels ferma3 = new(ferma1.PositionX2, ferma1.PositionY2, ThreeItem, FullH);
			FermaPositionModels ferma4 = new(ferma1.PositionX1, ferma1.PositionY1, TwoItem, FullH - H2);
			FermaPositionModels ferma5 = new(ferma4.PositionX2, ferma4.PositionY2, ferma2.PositionX2, ferma2.PositionY2);
			FermaPositionModels ferma6 = new(ferma4.PositionX2, ferma4.PositionY2, ThreeItem, FullH);
			FermaPositionModels ferma7 = new(ferma6.PositionX2, ferma6.PositionY2, ferma2.PositionX2, ferma2.PositionY2);

			//так как конструкция симметричка - зеркалим её координаты по оси ординате (ферма 7)
			IList<FermaPositionModels> left = new List<FermaPositionModels>()
			{
				ferma1, ferma2, ferma3, ferma4, ferma5, ferma6
			};

			IList<FermaPositionModels> rigth = new List<FermaPositionModels>();

			foreach(FermaPositionModels fermaModelsese in left)
			{
				rigth.Add(new FermaPositionModels(L - fermaModelsese.PositionX1, fermaModelsese.PositionY1, L - fermaModelsese.PositionX2, fermaModelsese.PositionY2));
			}

			left.Add(ferma7);
			List<FermaPositionModels> result = left.Concat(rigth).ToList();

			//Расстановка против часовой стрелки

			IEnumerable<PositionPoint2D> pointsUp = result.Select(item => item.PositionPoint2DOne).Concat(result.Select(item => item.PositionPoint2DSecond))
				.Where(item => item.Y > 0)
				.OrderByDescending(item => item.X)
				.Distinct();

			IEnumerable<PositionPoint2D> pointsBotton = result.Select(item => item.PositionPoint2DOne).Concat(result.Select(item => item.PositionPoint2DSecond))
				.Where(item => item.Y == 0)
				.OrderBy(item => item.X)
				.Distinct();

			return pointsUp.Concat(pointsBotton);

		}

		#endregion

	}

}