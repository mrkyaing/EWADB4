using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.Entities
{
    [Table("Position")]
    public class PositionEntity : BaseEntity
    {
        public string Code { get; set; }
        public string? Name { get; set; }

        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid Level Value");
                }
                level = value;
            }
        }
    }
}
