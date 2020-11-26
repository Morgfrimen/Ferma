namespace FermaLib.Models
{
	public record PositionPoint2D : IPoint2D
	{
		public PositionPoint2D(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X { get; }
		public double Y { get; }
	}
}
