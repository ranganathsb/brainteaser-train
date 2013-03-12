using System.Collections.Generic;
using System.Linq;

namespace trainteaser.Route
{
    public class NumberOfRoutesFinder: IRoutesFound
    {
        private Graph Graph { get; set; }
        private AllRoutesAlgorithm Algorithm { get; set; }

        private char StartingTown { get; set; }
        private char EndingTown { get; set; }

        public NumberOfRoutesFinder(Graph graph)
        {
            Graph = graph;
            Algorithm = new AllRoutesAlgorithm(Graph);
        }

        public IRoutesFound FindRoutes(char startingTown, char endingTown)
        {
            StartingTown = startingTown;
            EndingTown = endingTown;

            return this;
        }

        public NumberOfRoutesResponse WithDistanceLessThan(int distance)
        {
            var routes = Algorithm.FindAllRoutes(StartingTown, EndingTown, distance);

            return new NumberOfRoutesResponse {NumberOfRoutes = routes.Count()};
        }
    }
}