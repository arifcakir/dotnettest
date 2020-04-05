using System.Collections.Generic;

namespace DataAccessLayer
{
   public class Album
    {

        public int Id { get; set; }
        public string Title { get; set; }

    }

    public class Artist
   {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }

       public int Age { get; set; }

        public string PhoneNumber { set; get; }

        public string WebSite { get; set; }

        public List<Album> Albums { get; set; }

    }




   public class Person
   {
        public int Id { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }

        public int Age { get; set; }
   }


}
