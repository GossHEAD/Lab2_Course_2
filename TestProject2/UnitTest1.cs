using CircleRayIntersection;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Point circleCoordinates = new Point(0, 0);
            double radius = 5;
            Point rayStartCoordinates = new Point(3, 3);
            Point rayDirectionCoordinates = new Point(-3, 3);
            double[] resIntersection = new double[] {1.1291713066130291, 4.87082869338697, 4.87082869338697, 1.1291713066130291};
            double[] doubles = new double[] { 0, 0, 5, 3, 0, -3, 0 };
            double[] doubles2 = Intersection.CalculateIntersectionPoints(circleCoordinates, radius, rayStartCoordinates, rayDirectionCoordinates, doubles);
            CollectionAssert.AreEqual(resIntersection, doubles2);

        }
    }
}