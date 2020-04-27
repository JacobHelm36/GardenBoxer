namespace GardenBoxer.Models
{
  public class Garden
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



  }
}