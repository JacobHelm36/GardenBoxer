namespace GardenBoxer.Models
{
  public class Bed
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int BedX { get; set; }
    public int BedY { get; set; }
    public string DatePlanted { get; set; }
    public string DateFertilized { get; set; }
    public string Img { get; set; }
    public int GardenId { get; set; }


  }
}