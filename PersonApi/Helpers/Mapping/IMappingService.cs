using PersonApi.DTOs;

namespace PersonApi.Helpers.Mapping
{
    public interface IMappingService<E, D>
        where E : class, new()
        where D : BaseDto
    {
        D ToDto(E e);
        E ToEntity(D d);

        List<D> ToDto(IEnumerable<E> es);
        List<E> ToEntity(IEnumerable<D> ds);

        //void UpdateValues(in D dto, ref E entity);
    }
}
