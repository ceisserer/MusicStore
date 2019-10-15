namespace MusicStore.Contracts
{
	public interface IAlbum : IIdentifiable
    {
        int ArtistId { get; set; }
        string Title { get; set; }
    }
}
