namespace trainteaser.Route
{
    public class Route
    {
        public char StartingTown { get; set; }

        public char EndingTown { get; set; }

        public int Distance { get; set; }

        public bool NoRouteFound { get; set; }

        public bool Visited { get; set; }

        public Route Parent { get; set; }

        public int PathDistance
        {
            get
            {
                if (Parent != null)
                    return Distance + Parent.PathDistance;
                return Distance;
            }
        }
    }
}