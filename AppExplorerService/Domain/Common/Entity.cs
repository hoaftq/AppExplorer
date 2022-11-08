namespace Domain.Common
{
    public class Entity
    {
        public long Id { get; private set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return obj is Entity entity && Id == entity.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Id);
    }
}
