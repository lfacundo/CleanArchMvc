namespace CleanArchMvc.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public string Name { get; protected set; }
    }
}
