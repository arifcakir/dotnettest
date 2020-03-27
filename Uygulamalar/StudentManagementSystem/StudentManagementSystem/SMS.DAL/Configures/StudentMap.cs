using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Configures
{
    public class StudentMap: IEntityTypeConfiguration<Student>
    {

        public void Configure(EntityTypeBuilder<Student> entityBuilder)
        {
            entityBuilder.HasKey(student => student.Id);
            entityBuilder.Property(student => student.FirstName).IsRequired(true);
            entityBuilder.Property(student => student.LastName).IsRequired(true);
            entityBuilder.Property(student => student.BirthDate).IsRequired(true);
            entityBuilder.Property(student => student.Gender).IsRequired(true);
            entityBuilder.Property(student => student.StudentId).IsRequired(true);

            entityBuilder.ToTable("Student");


        }

    }
}
