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
        [TestCase("Graph: AB5, BC8, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 13)]
        [Test]
        public void WhatIsTheDistance_ForRoute_AtoBtoC(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var foundRoute = new RouteFinder(graph).FindRoute(new RouteRequest('A', 'B', 'C'));

            //assert
            Assert.That(foundRoute.Distance, Is.EqualTo(expectation));
        }

        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 5)]
        [TestCase("Graph: AB5, BC8, CD8, DC8, DE6, AD9, CE2, EB3, AE7", 9)]
        [Test]
        public void WhatIsTheDistance_ForRoute_AtoD(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var foundRoute = new RouteFinder(graph).FindRoute(new RouteRequest('A', 'D'));

            //assert
            Assert.That(foundRoute.Distance, Is.EqualTo(expectation));
        }

        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 13)]
        [TestCase("Graph: AB5, BC8, CD8, DC8, DE6, AD9, CE2, EB3, AE7", 17)]
        [Test]
        public void WhatIsTheDistance_ForRoute_AtoDtoC(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var foundRoute = new RouteFinder(graph).FindRoute(new RouteRequest('A', 'D', 'C'));

            //assert
            Assert.That(foundRoute.Distance, Is.EqualTo(expectation));
        }

        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 22)]
        [TestCase("Graph: AB5, BC8, CD8, DC8, DE6, AD9, CE2, EB3, AE7", 26)]
        [Test]
        public void WhatIsTheDistance_ForRoute_AtoEtoBtoCtoD(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var foundRoute = new RouteFinder(graph).FindRoute(new RouteRequest('A', 'E', 'B', 'C', 'D'));

            //assert
            Assert.That(foundRoute.Distance, Is.EqualTo(expectation));
        }

        [TestCase("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7", 22)]
        [TestCase("Graph: AB5, BC8, CD8, DC8, DE6, AD9, CE2, EB3, AE7", 26)]
        [Test]
        public void WhatIsTheDistance_ForRoute_AtoEtoD(string graphInput, int expectation)
        {
            //arrange
            var graph = new Graph(graphInput);

            //act
            var foundRoute = new RouteFinder(graph).FindRoute(new RouteRequest('A', 'E', 'D'));

            //assert
            Assert.That(foundRoute.Distance, Is.EqualTo(expectation));
        }
    }
}
