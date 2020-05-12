using System;

namespace GardenBoxer.Models
{
  public class Bed
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public int BedX { get; set; }
    public int BedY { get; set; }
    public DateTime DatePlanted { get; set; }
    public DateTime DateFertilized { get; set; }
    public string Img { get; set; }
    public int GardenId { get; set; }
  }
}