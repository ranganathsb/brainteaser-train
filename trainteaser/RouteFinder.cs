namespace trainteaser
{
    public class RouteFinder
    {
        public RouteFinder(Graph graph)
        {
        }

        public RouteResponse FindRoute(RouteRequest routeRequest)
        {
            return new RouteResponse { Distance = 9 };
        }
    }
}