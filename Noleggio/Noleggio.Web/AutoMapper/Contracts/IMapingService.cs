namespace Noleggio.Web.AutoMapper.Contracts
{
    public interface IMapingService
    {
        T Map<T>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
