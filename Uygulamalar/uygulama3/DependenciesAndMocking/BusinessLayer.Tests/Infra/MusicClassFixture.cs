using System;
using System.Collections.Generic;
using System.Linq;
using GenFu;
using DataAccessLayer;
using MoreLinq;

namespace BusinessLayer.Tests.Infra
{
    public class MusicClassFixture : IDisposable
    {

        public MusicClassFixture()
        {

           

            A.Default().FillerManager.RegisterFiller(new WebAddressFiller());
            A.Default().FillerManager.RegisterFiller(new MusicAlbumTitleFiller());

           


            A.Configure<Album>()
                .Fill(a => a.Id).WithinRange(1, 1000);
            //album title belirtmedik

             Albums = A.ListOf<Album>(100);


             var random = Albums.RandomSubset(3);

             A.Configure<Artist>()
                 .Fill(a => a.Id).WithinRange(1, 1000)
                 .Fill(a => a.FirstName).AsFirstName()
                 .Fill(a => a.LastName).AsLastName()
                 .Fill(a => a.Age).WithinRange(25, 55)
                 .Fill(a => a.PhoneNumber).AsPhoneNumber()
                 .Fill(a => a.Albums, () => { return random.ToList(); });
             //WebSite belirtmedik


             Artists = A.ListOf<Artist>(100);




        }


        public void Dispose()
        {
            Artists.Clear();
            Albums.Clear();
        }

        public List<Artist> Artists { get; private set; }
        public List<Album> Albums { get; private set; }
    }
}
