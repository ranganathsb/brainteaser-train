using System;
using System.Collections.Generic;
using System.Linq;

namespace trainteaser.Route
{
    public class RouteRequest
    {
        private IList<Route> Routes { get; set; } 

        public RouteRequest(params char[] nodes)
        {
            if (nodes.Length <= 1)
            {
                throw new ArgumentException("You have to have at least 2 towns in your request");
            }

            Routes = new List<Route>();

            for (var i = 0; i < nodes.Length - 1; i++)
            {
                Routes.Add(new Route{ StartingTown = nodes[i], EndingTown = nodes[i+1]});
            }
        }

        public IList<Route> GetRoutes()
        {
            return Routes.ToList();
        }
    }
}