namespace BlazorWebServer
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }

    public class DataService
    {
        public IQueryable<Item> Items { get; } = new List<Item>
        {
            new Item { Id = 1, Name = "Elemento 1" },
            new Item { Id = 2, Name = "Elemento 2" },
            new Item { Id = 3, Name = "Elemento 3" },
            new Item { Id = 4, Name = "Elemento 4" },
            new Item { Id = 5, Name = "Elemento 5" },
        }.AsQueryable();
    }

}
