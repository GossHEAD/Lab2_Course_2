/*
namespace CircleRayIntersection.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestIntersectionPointsAreCalculatedCorrectly()
        {
            // Arrange
            double centerX = 0;
            double centerY = 0;
            double radius = 1;
            double startX = 1;
            double startY = 0;
            double directionX = -1;
            double directionY = 0;

            // Act
            Program.CalculateIntersectionPoints(centerX, centerY, radius, startX, startY, directionX, directionY);

            // Assert
            string expectedOutput = "Intersection point 1: (0, 0)\r\nIntersection point 2: (2, 0)\r\n";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void TestNoIntersectionPointsAreFound()
        {
            // Arrange
            double centerX = 0;
            double centerY = 0;
            double radius = 1;
            double startX = 2;
            double startY = 2;
            double directionX = -1;
            double directionY = -1;

            // Act
            Program.CalculateIntersectionPoints(centerX, centerY, radius, startX, startY, directionX, directionY);

            // Assert
            Assert.AreEqual("Ray does not intersect circle.\r\n", output.ToString());
        }

        [Test]
        public void TestSavingResultToFileWorks()
        {
            // Arrange
            double centerX = 0;
            double centerY = 0;
            double radius = 1;
            double startX = 1;
            double startY = 0;
            double directionX = -1;
            double directionY = 0;
            string fileName = "test_output.txt";

            // Act
            Program.CalculateIntersectionPoints(centerX, centerY, radius, startX, startY, directionX, directionY);
            Program.SaveResultToFile(fileName);

            // Assert
            string expectedOutput = "Intersection point 1: (0, 0)\r\nIntersection point 2: (2, 0)\r\n";
            Assert.AreEqual(expectedOutput, File.ReadAllText(fileName));
            File.Delete(fileName);
        }
    }
}
*/