using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Tangy_DataAccess;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}