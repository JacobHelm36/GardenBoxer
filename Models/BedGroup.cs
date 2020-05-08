namespace GardenBoxer.Models
{
  public class BedGroup
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int BedId { get; set; }
    public int GroupId { get; set; }
    public int GardenId { get; set; }
  }
}