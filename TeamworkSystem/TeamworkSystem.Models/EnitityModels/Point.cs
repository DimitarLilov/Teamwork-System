namespace TeamworkSystem.Models.EnitityModels
{
    public class Point
    {
        public int Id { get; set; }

        public virtual Criteria Criteria { get; set; }

        public decimal Value { get; set; }
    }
}
