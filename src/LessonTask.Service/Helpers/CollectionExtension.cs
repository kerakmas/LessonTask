using LessonTask.Domain.Commons;
using LessonTask.Domain.Configurations;
using LessonTask.Service.Exceptions;

namespace LessonTask.Shared.Helpers
{
    public static class CollectionExtension
    {
        public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> entities, PaginationParamas @params)
            where TEntity : Auditable
        {
            return @params.PageIndex > 0 && @params.PageSize > 0 ?
                entities.OrderBy(e => e.Id)
                    .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize) :
                        throw new TaskLessonException(400, "Please, enter valid numbers");
        }
    }
}
