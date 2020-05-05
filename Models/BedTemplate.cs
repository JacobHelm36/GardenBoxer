namespace GardenBoxer.Models
{
  public class BedTemplate
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Img { get; set; }
  }
}