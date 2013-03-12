using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trainteaser.Route;
using trainteaser.Trip;

namespace trainteaser
{
    class Program
    {
        private static Graph CreateGraph()
        {
            return new Graph("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
        }

        static void Main(string[] args)
        {
            var graph = CreateGraph();

            var responses = new List<IResponse>();

            DoStraightRoutes(graph, responses);

            DoMaxTripFinder(graph, responses);

            DoExactTripFinder(graph, responses);

            responses.Add(new ShortestRouteFinder(CreateGraph()).FindRoute('A', 'C'));
            responses.Add(new ShortestRouteFinder(CreateGraph()).FindRoute('B', 'B'));

            var numberOfRoutesFinder = new NumberOfRoutesFinder(graph);

            responses.Add(numberOfRoutesFinder.FindRoutes('C', 'C').WithDistanceLessThan(30));

            var i = 0;
            foreach (var response in responses)
            {
                i++;
                Console.WriteLine("Output #{0}: {1}", i, response.GetResponse());
            }
            
            Console.ReadLine();
        }

        private static void DoExactTripFinder(Graph graph, List<IResponse> responses)
        {
            var exactTripFinder = new ExactStopTripFinder(graph);

            responses.Add(exactTripFinder.FindTrip('A', 'C'));
        }

        private static void DoMaxTripFinder(Graph graph, List<IResponse> responses)
        {
            var maxTripFinder = new MaxStopTripFinder(graph);

            responses.Add(maxTripFinder.FindTrip('C', 'C'));
        }

        private static void DoStraightRoutes(Graph graph, List<IResponse> responses)
        {
            var routeFinder = new RouteFinder(graph);

            responses.Add(routeFinder.FindRoute(new RouteRequest('A', 'B', 'C')));
            responses.Add(routeFinder.FindRoute(new RouteRequest('A', 'D')));
            responses.Add(routeFinder.FindRoute(new RouteRequest('A', 'D', 'C')));
            responses.Add(routeFinder.FindRoute(new RouteRequest('A', 'E', 'B', 'C', 'D')));
            responses.Add(routeFinder.FindRoute(new RouteRequest('A', 'E', 'D')));
        }
    }
}
