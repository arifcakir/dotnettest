using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Configures
{
    public class TeacherMap: IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(teacher => teacher.Id);

            builder.Property(teacher => teacher.FirstName).IsRequired(true);
            builder.Property(teacher => teacher.LastName).IsRequired(true);
            builder.Property(teacher => teacher.BirthDate).IsRequired(true);
            builder.Property(teacher => teacher.Gender).IsRequired(true);

            builder.ToTable("Teacher");
        }
    }
}