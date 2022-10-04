namespace WindowsFormsApplication.Models
{
    public class Player : IClient
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public Color PlayerColor { get; set; }
        public bool IsReadyToPlay { get; set; }
    }

}
