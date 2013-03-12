namespace trainteaser.Route
{
    public class RouteResponse: IResponse
    {
        public int Distance { get; set; }

        public bool NoRouteFound { get; set; }

        public string GetResponse()
        {
            return NoRouteFound ? "NO SUCH ROUTE" : Distance.ToString();
        }
    }
}