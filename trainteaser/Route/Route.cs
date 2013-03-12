namespace trainteaser.Route
{
    public class Route
    {
        public char StartingTown { get; set; }

        public char EndingTown { get; set; }

        public int Distance { get; set; }

        public bool NoRouteFound { get; set; }

        public bool Visited { get; set; }

        private Route Parent { get; set; }

        public void SetParent(Route parent)
        {
            Parent = new Route
                {
                    Distance = parent.Distance,
                    EndingTown = parent.EndingTown,
                    StartingTown = parent.StartingTown,
                    Visited = parent.Visited,
                    NoRouteFound = parent.NoRouteFound,
                    Parent = parent.Parent
                };

            var route = parent;

            pathDistance = Distance;

            while(route != null)
            {
                pathDistance += route.Distance;
                route = route.Parent;
            }
        }

        private int pathDistance;
        public int PathDistance
        {
            get { return pathDistance <= 0 ? Distance : pathDistance; }
        }

        public string Path
        {
            get { return (Parent == null ? StartingTown.ToString() : Parent.Path) + EndingTown; }
        }
    }
}