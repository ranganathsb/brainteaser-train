using System.Collections.Generic;
using System.Linq;

namespace trainteaser.Route
{
    public class AllRoutesAlgorithm
    {
        private Graph Graph { get; set; }

        public AllRoutesAlgorithm(Graph graph)
        {
            Graph = graph;
        }

        public IList<Route> FindAllRoutes(char startingTown, char endingTown)
        {
            var routes = Graph.QueryRoutes().Where(x => x.StartingTown == startingTown);

            var queue = new Queue<Route>();
            routes.ToList().ForEach(queue.Enqueue);

            var result = new List<Route>();

            while (queue.Count != 0)
            {
                var currentRoute = queue.Dequeue();

                currentRoute.Visited = true;

                foreach (var child in GetAllChildrenRoutesNotVisited(currentRoute))
                {
                    child.Visited = true;

                    child.SetParent(currentRoute);

                    if (child.EndingTown == endingTown)
                        result.Add(child);
                    else
                        queue.Enqueue(child);
                }
            }

            return result;
        }

        public IList<Route> FindAllRoutes(char startingTown, char endingTown, int maxDistance)
        {
            var routes = Graph.CopyRoutes().Where(x => x.StartingTown == startingTown);

            var queue = new Queue<Route>();
            routes.ToList().ForEach(queue.Enqueue);

            var result = new List<Route>();
            
            while (queue.Count != 0)
            {
                var currentRoute = queue.Dequeue();
                
                foreach (var child in GetAllChildrenRoutes(currentRoute, true))
                {
                    child.SetParent(currentRoute);

                    if (child.PathDistance >= maxDistance)
                        continue;

                    if (child.EndingTown == endingTown)
                        result.Add(child);
                    
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private IEnumerable<Route> GetAllChildrenRoutes(Route currentRoute, bool copy = false)
        {
            var routes = copy ? Graph.CopyRoutes() : Graph.QueryRoutes();
            return routes.Where(x => x.StartingTown == currentRoute.EndingTown);
        }

        private IEnumerable<Route> GetAllChildrenRoutesNotVisited(Route currentRoute)
        {
            return GetAllChildrenRoutes(currentRoute).Where(x => x.Visited == false);
        }
    }
}