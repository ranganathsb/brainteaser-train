namespace trainteaser.Route
{
    public interface IRoutesFound
    {
        NumberOfRoutesResponse WithDistanceLessThan(int distance);
    }
}