namespace trainteaser.Route
{
    public class NumberOfRoutesResponse: IResponse
    {
        public int NumberOfRoutes { get; set; }

        public string GetResponse()
        {
            return NumberOfRoutes.ToString();
        }
    }
}