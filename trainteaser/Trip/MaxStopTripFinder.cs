using System.Linq;

namespace trainteaser.Trip
{
    public class MaxStopTripFinder: TripFinder
    {
        private int NumberOfStops { get; set; }

        public MaxStopTripFinder(Graph graph)
            : base(graph)
        {
            NumberOfStops = 3;
        }

        public override TripResponse FindTrip(char startTown, char destination)
        {
            var response = new TripResponse();

            FindTrips(new TripQuery { StartingTown = startTown, Desination = destination, Stops = 0, Response = response});

            return response;
        }

        protected override void FindTrips(TripQuery query)
        {
            if (query.Stops == NumberOfStops)
                return;

            var routes = GetRoutesFromStartingTown(query.StartingTown);

            query.Response.NumberOfTrips += GetRoutesThatAreFinished(query.Desination, routes);

            query.Stops++;

            LookAtRoutesThatCouldWork(query.Desination, query.Stops, query.Response, routes);
        }

        protected override IQueryable<Route.Route> GetRoutesToLookAt(char destination, IQueryable<Route.Route> routes)
        {
            return routes.Where(x => x.EndingTown != destination);
        }
    }
}