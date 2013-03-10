using System.Linq;

namespace trainteaser
{
    public class RouteFinder
    {
        public Graph Graph { get; set; }

        public RouteFinder(Graph graph)
        {
            Graph = graph;
        }

        public RouteResponse FindRoute(RouteRequest routeRequest)
        {
            var distance = 0;

            foreach (var route in routeRequest.GetRoutes())
            {
                var foundRoute = FindRouteForStartingTownToEndingTown(route.StartingTown, route.EndingTown);
                distance += foundRoute.Distance;
            }

            return new RouteResponse {Distance = distance};
        }

        private Route FindRouteForStartingTownToEndingTown(char startingTown, char endingTown)
        {
            return Graph.QueryRoutes().FirstOrDefault(x => x.StartingTown == startingTown && x.EndingTown == endingTown);
        }
    }
}