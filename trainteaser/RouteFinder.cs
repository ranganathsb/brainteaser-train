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
                var proposedRoute = FindRouteForStartingTownToEndingTown(route.StartingTown, route.EndingTown);

                if (proposedRoute.NoRouteFound)
                    return new RouteResponse {Distance = 0, NoRouteFound = true};

                distance += proposedRoute.Distance;
            }

            return new RouteResponse {Distance = distance};
        }

        private Route FindRouteForStartingTownToEndingTown(char startingTown, char endingTown)
        {
            var result =
                Graph.QueryRoutes().FirstOrDefault(x => x.StartingTown == startingTown && x.EndingTown == endingTown);
            return result ?? new Route {Distance = 0, NoRouteFound = true};
        }
    }
}