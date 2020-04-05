using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface  IMusicManager
    {
        List<ArtistDto> GetAllArtists();

        ArtistDto GetArtist(int Id);


        bool ClearAll();

        int AddArtist(ArtistDto artist);
    }
}
