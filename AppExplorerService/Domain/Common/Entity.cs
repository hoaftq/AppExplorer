namespace Domain.Common
{
    public class Entity
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
