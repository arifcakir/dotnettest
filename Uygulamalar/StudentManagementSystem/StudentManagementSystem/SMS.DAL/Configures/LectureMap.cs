using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Configures
{
    public class LectureMap : IEntityTypeConfiguration<Lecture>
    {

        public void Configure(EntityTypeBuilder<Lecture> entityBuilder)
        {


            entityBuilder
                .HasKey(lecture => lecture.Id);


            entityBuilder.ToTable("Lecture");


        }
    }
}
