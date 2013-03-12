using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace trainteaser.Route
{
    public class ShortestRouteFinder
    {
        private Graph Graph { get; set; }
        private AllRoutesAlgorithm Algorithm { get; set; }

        public ShortestRouteFinder(Graph graph)
        {
            Graph = graph;
            Algorithm = new AllRoutesAlgorithm(Graph);
        }

        public RouteResponse FindRoute(char startingTown, char endingTown)
        {
            var routes = Algorithm.FindAllRoutes(startingTown, endingTown);

            return !routes.Any() ? new RouteResponse {NoRouteFound = true} : new RouteResponse {Distance = routes.Min(x => x.PathDistance)};
        }
    }
}