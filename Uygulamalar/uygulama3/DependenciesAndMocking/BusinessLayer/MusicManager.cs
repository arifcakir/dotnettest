using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccessLayer;

namespace BusinessLayer
{
    public class MusicManager:IMusicManager
    {
        private IMusicRepository _musicRepository;

        public MusicManager(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public List<ArtistDto> GetAllArtists()
        {
            var artists = _musicRepository.GetAllArtists();

            var conf = new MapperConfiguration(cfg => cfg.CreateMap<Artist, ArtistDto>());
            var mapper = new Mapper(conf);
            var artistDtos = mapper.Map<List<ArtistDto>>(artists);


            return artistDtos;

        }

        public ArtistDto GetArtist(int Id)
        {
            var artist = _musicRepository.GetArtist(Id);

            var conf = new MapperConfiguration(cfg => cfg.CreateMap<Artist, ArtistDto>());
            var mapper = new Mapper(conf);
            var artistDto = mapper.Map<ArtistDto>(artist);


            return artistDto;
        }

        public bool ClearAll()
        {
            var result = _musicRepository.ClearAll();
            return result;
        }

        public int AddArtist(ArtistDto artistDto)
        {

            var conf = new MapperConfiguration(cfg => cfg.CreateMap<ArtistDto, Artist>());
            var mapper = new Mapper(conf);
            var artist = mapper.Map<Artist>(artistDto);

          var result=  _musicRepository.AddArtist(artist);

          return result.Id;


        }
    }
}
