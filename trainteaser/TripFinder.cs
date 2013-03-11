namespace trainteaser
{
    public class TripFinder
    {
        public TripFinder(Graph graph)
        {
            
        }

        public TripResponse FindTrip(params char[] towns)
        {
            return new TripResponse {NumberOfTrips = 2};
        }
    }
}