namespace Weather.Api.Services.Mapper
{
    public interface IMapper<in T, out TY>
    {
        TY Map(T instance);
    }
}
