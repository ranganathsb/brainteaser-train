﻿using System.Collections.Generic;
using System.Linq;

namespace trainteaser
{
    public class TripFinder
    {
        private Graph Graph { get; set; }

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

            var routes = GetRoutesFromStartingTown(startTown);

            response.NumberOfTrips += GetRoutesThatAreFinished(destination, routes);

            stops++;

            LookAtRoutesThatCouldWork(destination, stops, response, routes);
        }

        private static int GetRoutesThatAreFinished(char destination, IQueryable<Route> routes)
        {
            return routes.Count(x => x.EndingTown == destination);
        }

        private IQueryable<Route> GetRoutesFromStartingTown(char startTown)
        {
            return Graph.QueryRoutes().Where(x => x.StartingTown == startTown);
        }

        private void LookAtRoutesThatCouldWork(char destination, int stops, TripResponse response, IQueryable<Route> routes)
        {
            foreach (var routeToCheck in routes.Where(x => x.EndingTown != destination))
            {
                FindTrips(routeToCheck.EndingTown, destination, stops, response);
            }
        }
    }
}