using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainteaser
{
    public class Graph
    {
        public Graph(string graphInput)
        {
            graphInput = graphInput.TrimStart("Graph:".ToCharArray());

            var routeInputs = graphInput.Split(',');

            Routes = new List<Route.Route>();

            foreach (var routeInput in routeInputs)
            {
                var route = routeInput.Trim();
                Routes.Add(new Route.Route
                    {
                        StartingTown = route[0],
                        EndingTown = route[1],
                        Distance = Convert.ToInt32(route[2].ToString()) //you have to convert this as a string because if you do it as a char then the convert function will use the ASCII value
                    });
            }
        }

        private IList<Route.Route> Routes { get; set; }

        public IQueryable<Route.Route> QueryRoutes()
        {
            return Routes.AsQueryable();
        }

        public IQueryable<Route.Route> CopyRoutes()
        {
            return Routes.Select(x => new Route.Route { Distance = x.Distance, EndingTown = x.EndingTown, StartingTown = x.StartingTown }).AsQueryable();
        }
    }
}
