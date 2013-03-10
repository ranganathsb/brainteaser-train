using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace trainteaser.tests
{
    [TestFixture]
    public class RouteDistanceTests
    {
        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 9)]
        [Test]
        public void WhatIsTheDistance_ForRoute_AtoBtoC(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var foundRoute = new RouteFinder(graph).FindRoute(new RouteRequest("A", "B", "C"));

            //assert
            Assert.That(foundRoute.Distance, Is.EqualTo(expectation));
        }
        
    }
}
