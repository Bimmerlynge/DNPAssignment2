using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models {
public class Person {
    
    public int Id { get; set; }
    [Required, MaxLength(20)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    [Required, Range(25,130, ErrorMessage = "Please check the Age-input again for any mistakes. Must be greater than 25")]
    public int? Age { get; set; }
    [Range(20,int.MaxValue,ErrorMessage = "Only positive values for weight")]
    public float? Weight { get; set; }
    [Range(100,250,ErrorMessage = "Check your height input again")]
    public int? Height { get; set; }
    [RegularExpression("M|F",ErrorMessage = "Sex must either be 'M' or 'F'")]
    public string Sex { get; set; }
}


}