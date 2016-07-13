using System.ComponentModel.DataAnnotations;
using Photocom.Models.Entities;

namespace Photocom.DataLayer.Entries
{
    public class CategoryEntry : BaseEntry<Category>
    {
        public string Name { get; set; }
    }
}
