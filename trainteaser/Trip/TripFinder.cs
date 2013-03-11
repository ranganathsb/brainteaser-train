using System.Linq;

namespace trainteaser.Trip
{
    public abstract class TripFinder
    {
        private Graph Graph { get; set; }

        protected TripFinder(Graph graph)
        {
            Graph = graph;
        }

        public abstract TripResponse FindTrip(char startTown, char destination);

        protected abstract void FindTrips(TripQuery query);
        
        protected static int GetRoutesThatAreFinished(char destination, IQueryable<Route.Route> routes)
        {
            return routes.Count(x => x.EndingTown == destination);
        }

        protected IQueryable<Route.Route> GetRoutesFromStartingTown(char startTown)
        {
            return Graph.QueryRoutes().Where(x => x.StartingTown == startTown);
        }

        protected void LookAtRoutesThatCouldWork(char destination, int stops, TripResponse response, IQueryable<Route.Route> routes)
        {
            foreach (var routeToCheck in GetRoutesToLookAt(destination, routes))
            {
                FindTrips(new TripQuery { StartingTown = routeToCheck.EndingTown, Desination = destination, Stops = stops, Response = response });
            }
        }

        protected abstract IQueryable<Route.Route> GetRoutesToLookAt(char destination, IQueryable<Route.Route> routes);
    }

    public class TripQuery
    {
        public char StartingTown { get; set; }

        public char Desination { get; set; }

        public int Stops { get; set; }

        public TripResponse Response { get; set; }
    }
}