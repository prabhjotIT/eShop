namespace Domain.Products;

//Stock keeping unit
public record Sku
{
    public string Value { get; init; }
    private Sku(string value) => Value = value;
    private const int defaultLength = 15;

    public static Sku? Create(string value)
    {
        
        if(string.IsNullOrEmpty(value)) return null; 
        
        if(value.Length!= defaultLength) return null;

        return new Sku(value);
    }
}
