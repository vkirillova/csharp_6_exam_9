namespace BulletinBoard.DAL.Entities
{
    public class GalleryImage: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int NoticeId { get; set; }
        public Notice Notice { get; set; }
    }
}