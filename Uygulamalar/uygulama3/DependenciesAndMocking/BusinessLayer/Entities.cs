using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
   public class AlbumDto
    {

        public int Id { get; set; }
        public string Title { get; set; }




    }

   public class ArtistDto
   {

       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }

       public int Age { get; set; }
       public string PhoneNumber { set; get; }

       public string WebSite { get; set; }

        public List<AlbumDto> AlbumDtos { get; set; }




    }




   public class PersonDto
   {
        public int Id { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }

        public int Age { get; set; }
   }


}
