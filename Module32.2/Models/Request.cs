using System.ComponentModel.DataAnnotations.Schema;

namespace Module32._2.Models;
[Table("Requests")]
public class Request
{
   public Guid Id { get; set; }
   public DateTime Date { get; set; }
   public string Url { get; set; }
}