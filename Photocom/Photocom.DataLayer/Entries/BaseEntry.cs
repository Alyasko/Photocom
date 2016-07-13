
using System.ComponentModel.DataAnnotations;
using Photocom.BusinessLogic.Utils;

namespace Photocom.DataLayer.Entries
{
    public abstract class BaseEntry<T>
    {
        [Key]
        public int Id { get; set; }

        public TModel ConvertToModel<TModel>() where TModel : new()
        {
            return ReflectionHelper.ConvertEntryToEntity<TModel>(ReflectionHelper.GetFullTypeName(this.GetType()), this);
        }
    }
}
