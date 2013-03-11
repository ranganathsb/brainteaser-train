using System.Collections.Generic;
using System.Linq;

namespace trainteaser
{
    public class TripFinder
    {
        public Graph Graph { get; set; }

        public TripFinder(Graph graph)
        {
            Graph = graph;
        }

        public TripResponse FindTrip(char startTown, char destination)
        {
            var response = new TripResponse();

            FindTrips(startTown, destination, 0, response);

            return response;
        }

        private void FindTrips(char startTown, char destination, int stops, TripResponse response)
        {
            if (stops == 3)
                return;

            var routes = Graph.QueryRoutes().Where(x => x.StartingTown == startTown);

            response.NumberOfTrips += routes.Count(x => x.EndingTown == destination);

            stops++;

            foreach (var routeToCheck in routes.Where(x => x.EndingTown != destination))
            {
                FindTrips(routeToCheck.EndingTown, destination, stops, response);
            }
        }
    }
}