using System.Linq;

namespace trainteaser.Trip
{
    public class ExactStopTripFinder: TripFinder
    {
        private int NumberOfStops { get; set; }

        public ExactStopTripFinder(Graph graph) : base(graph)
        {
            NumberOfStops = 4;
        }

        public override TripResponse FindTrip(char startTown, char destination)
        {
            var response = new TripResponse();

            FindTrips(new TripQuery {StartingTown = startTown, Desination = destination, Stops = 0, Response = response});

            return response;
        }

        protected override void FindTrips(TripQuery query)
        {
            if (query.Stops > NumberOfStops)
                return;

            var countTheseTrips = query.Stops == NumberOfStops;

            var routes = GetRoutesFromStartingTown(query.StartingTown);

            query.Response.NumberOfTrips += countTheseTrips ? GetRoutesThatAreFinished(query.Desination, routes) : 0;

            query.Stops++;

            LookAtRoutesThatCouldWork(query.Desination, query.Stops, query.Response, routes);
        }

        protected override IQueryable<Route.Route> GetRoutesToLookAt(char destination, IQueryable<Route.Route> routes)
        {
            return routes;
        }
    }
}