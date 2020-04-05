using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Tests.Infra;
using DataAccessLayer;
using FluentAssertions;
using GenFu;
using MoreLinq;
using NSubstitute;
using Xunit;

namespace BusinessLayer.Tests
{

    /// <summary>
    /// Alternatif bu çözümde FluentAssertion daha okunaklı Assert işlerimler için kullanıldı.
    /// NSubstitute ise mock lama işlmelerini daha oklunaklı ve kolay yapılabilir hale getirmek için kullanıldı
    /// gerçekçi veri üretmek içinde GenFu kullanıldı
    /// </summary>
   public class MusicManagerTests:IClassFixture<MusicClassFixture>
    {
        private IMusicManager _musicManager;
        private IMusicRepository _musicRepository;
        private MusicClassFixture _fixture;

        public MusicManagerTests(MusicClassFixture fixture)
        {
            _fixture = fixture;

            _musicRepository = Substitute.For<IMusicRepository>();

            _musicRepository.ClearAll().Returns(true);
            _musicRepository.GetAllArtists().Returns(_fixture.Artists);
            _musicManager = new MusicManager(_musicRepository);
        }


        [Fact]
        public void Butun_Artisler()
        {
            var result = _musicManager.GetAllArtists();

            result.Count.Should().Be(100);
        }


        [Fact]
        public void Id_si_girilen_artistin_verisi_gelmeli()
        {

            var randomArtist = _fixture.Artists.RandomSubset(1).SingleOrDefault();


            var artist = _musicManager.GetArtist(randomArtist.Id);


            artist.FirstName.Should().Be(randomArtist.FirstName);
        }





    }
}
