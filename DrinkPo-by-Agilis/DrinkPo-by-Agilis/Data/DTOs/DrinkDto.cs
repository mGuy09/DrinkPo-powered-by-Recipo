namespace DrinkPo_by_Agilis.Data.DTOs;

public class DrinkDto : BaseDto
{
    public string Description { get; set; }
    public List<string> Steps { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
}