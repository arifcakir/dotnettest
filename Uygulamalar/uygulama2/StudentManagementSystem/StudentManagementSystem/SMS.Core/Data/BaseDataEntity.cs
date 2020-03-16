using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SMS.Core.Data.Interfaces;

namespace SMS.Core.Data
{
  public abstract class BaseDataEntity : IDataEntity
    {

        //TODO: auto increment oluşturmakiçin gerekli
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }


    }
}
