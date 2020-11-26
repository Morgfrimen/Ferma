using ModelsLib;

namespace FermaLib.Models
{

	public record FermaPositionModels : IPositionFerma
	{

		#region Implementation of IPosition

		public FermaPositionModels(double positionX1, double positionY1, double positionX2, double positionY2)
		{
			PositionX1 = positionX1;
			PositionY1 = positionY1;
			PositionX2 = positionX2;
			PositionY2 = positionY2;

			PositionPoint2DOne = new PositionPoint2D(PositionX1, PositionY1);
			PositionPoint2DSecond = new PositionPoint2D(PositionX2, PositionY2);
		}

		public double PositionX1 { get; }
		public double PositionY1 { get; }

		public double PositionX2 { get; }
		public double PositionY2 { get; }

		public PositionPoint2D PositionPoint2DOne { get; }
		public PositionPoint2D PositionPoint2DSecond { get; }
		#endregion

	}

}