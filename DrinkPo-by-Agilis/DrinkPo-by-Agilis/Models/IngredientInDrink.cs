namespace DrinkPo_by_Agilis.Models;

public class IngredientInDrink : BaseModel
{
    public int DrinkId { get; set; }
    public int IngredientId { get; set; }
    public decimal IngredientAmount { get; set;}
    public string AmountType { get; set; }
}