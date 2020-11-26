using System.Collections.Generic;
using System.Linq;

using FermaLib.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelsLib;

namespace Test
{
	[TestClass]
	public class UnitTestSymmetricallHingerodScheme
	{
		private const double Delta = 0.01;

		private double L { get; set; }
		private double H { get; set; }
		private double Alfa { get; set; }


		public UnitTestSymmetricallHingerodScheme()
		{
			L = 250;
			H = 50;
			Alfa = 45;
		}

		[TestMethod]
		public void TestGetPosition()
		{
			IList<IPoint2D> first = Core.Core.CreateInstance().GetSymmetricalHingerodScheme(L, H, Alfa).GetPosition().ToList();
			IList<IPoint2D> second = new List<IPoint2D>()
			{
				new PositionPoint2D(250,50),
				new PositionPoint2D(166.66,184.98),
				new PositionPoint2D(125,252.47),
				new PositionPoint2D(83.33,184.98),
				new PositionPoint2D(0,50),
				new PositionPoint2D(41.66,0),
				new PositionPoint2D(125,0),
				new PositionPoint2D(208.33,0)
			};

			for(int i = 0; i < second.Count; i++)
			{
				Assert.AreEqual(second[i].X, first[i].X, Delta);
				Assert.AreEqual(second[i].Y, first[i].Y, Delta);
			}
		}

		[TestMethod]
		public void TestGetPositionAsync()
		{
			IList<IPoint2D> first = ( Core.Core.CreateInstance().GetSymmetricalHingerodScheme(L, H, Alfa).GetPositionAsync().Result ).ToList();
			IList<IPoint2D> second = new List<IPoint2D>()
			{
				new PositionPoint2D(250,50),
				new PositionPoint2D(166.66,184.98),
				new PositionPoint2D(125,252.47),
				new PositionPoint2D(83.33,184.98),
				new PositionPoint2D(0,50),
				new PositionPoint2D(41.66,0),
				new PositionPoint2D(125,0),
				new PositionPoint2D(208.33,0)
			};

			for(int i = 0; i < second.Count; i++)
			{
				Assert.AreEqual(second[i].X, first[i].X, Delta);
				Assert.AreEqual(second[i].Y, first[i].Y, Delta);
			}
		}
	}
}
