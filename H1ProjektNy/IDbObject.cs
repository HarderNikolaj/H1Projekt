namespace H1ProjektNy
{
    public interface IDbObject
    {
        int Id { get; set; }
        
        void Insert();
        void Update(string column, string newValue);
        void Delete();
    }
}
