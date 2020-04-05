
using System.Collections.Generic;

namespace DataAccessLayer
{




   public interface IMusicRepository
    {


        List<Artist> GetAllArtists();

        Artist GetArtist(int Id);


        bool ClearAll();

        Artist AddArtist(Artist artist);

    }
}
