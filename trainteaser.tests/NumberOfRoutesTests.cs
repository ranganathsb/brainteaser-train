using NUnit.Framework;
using trainteaser.Route;

namespace trainteaser.tests
{
    [TestFixture]
    public class NumberOfRoutesTests
    {
        [Test]
        public void HowManyDifferentRoutes_FromCtoC_WithADistanceLessThan30()
        {
            //arrange
            var graph = new Graph("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

            //act
            var response = new NumberOfRoutesFinder(graph).FindRoutes('C', 'C').WithDistanceLessThan(30);

            //assert
            Assert.That(response.GetResponse(), Is.EqualTo(7.ToString()));
        }
         
    }
}