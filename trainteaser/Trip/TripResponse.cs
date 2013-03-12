namespace trainteaser.Trip
{
    public class TripResponse: IResponse
    {
        public int NumberOfTrips { get; set; }

        public string GetResponse()
        {
            return NumberOfTrips.ToString();
        }
    }
}