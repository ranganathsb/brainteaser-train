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
        private static readonly string[] graphInputs = new[]
            {
                "Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7",
                "Graph: AB1, BC4, CD1, DA2, DE6, AD5, CE2, EB3, AE7"
            };

        private static Graph CreateGraph(string graphInput)
        {
            return new Graph(graphInput);
        }

        static void Main(string[] args)
        {
            foreach (var graphInput in graphInputs)
            {
                Console.WriteLine(graphInput);

                var graph = CreateGraph(graphInput);

                var responses = new List<IResponse>();

                DoStraightRoutes(graph, responses);

                DoMaxTripFinder(graph, responses);

                DoExactTripFinder(graph, responses);

                DoShortestRouteFinder(responses, graphInput);

                DoNumberOfRoutesFinder(graph, responses);

                ProcessResponses(responses);

                Console.ReadLine();
            }
        }

        private static void ProcessResponses(List<IResponse> responses)
        {
            var i = 0;
            foreach (var response in responses)
            {
                i++;
                Console.WriteLine("Output #{0}: {1}", i, response.GetResponse());
            }
        }

        private static void DoNumberOfRoutesFinder(Graph graph, List<IResponse> responses)
        {
            var numberOfRoutesFinder = new NumberOfRoutesFinder(graph);

            responses.Add(numberOfRoutesFinder.FindRoutes('C', 'C').WithDistanceLessThan(30));
        }

        private static void DoShortestRouteFinder(List<IResponse> responses, string graphInput)
        {
            responses.Add(new ShortestRouteFinder(CreateGraph(graphInput)).FindRoute('A', 'C'));
            responses.Add(new ShortestRouteFinder(CreateGraph(graphInput)).FindRoute('B', 'B'));
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
