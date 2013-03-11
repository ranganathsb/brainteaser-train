using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace trainteaser.Route
{
    public class ShortestRouteFinder
    {
        private Graph Graph { get; set; }

        public ShortestRouteFinder(Graph graph)
        {
            Graph = graph;
        }

        public RouteResponse FindRoute(char startingTown, char endingTown)
        {
            var routes = FindAllRoutes(startingTown, endingTown);

            return new RouteResponse {Distance = routes.Min(x => x.PathDistance)};
        }

        private IList<Route> FindAllRoutes(char startingTown, char endingTown)
        {
            var routes = Graph.QueryRoutes().Where(x => x.StartingTown == startingTown);
            
            var queue = new Queue<Route>();
            routes.ToList().ForEach(queue.Enqueue);

            var result = new List<Route>();

            while(queue.Count != 0)
            {
                var currentRoute = queue.Dequeue();
                
                currentRoute.Visited = true;

                foreach (var child in GetRoutesChildren(currentRoute))
                {
                    child.Visited = true;

                    child.Parent = currentRoute;

                    if (child.EndingTown == endingTown)
                        result.Add(child);
                    else
                        queue.Enqueue(child);
                }
            }

            return result;
        }

        private IEnumerable<Route> GetRoutesChildren(Route currentRoute)
        {
            return Graph.QueryRoutes().Where(x => x.StartingTown == currentRoute.EndingTown && x.Visited == false);
        }
    }
}