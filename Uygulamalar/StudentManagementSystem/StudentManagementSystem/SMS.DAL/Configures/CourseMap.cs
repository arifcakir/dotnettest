using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Configures
{
   public class CourseMap: IEntityTypeConfiguration<Course>
    {
      public void Configure(EntityTypeBuilder<Course> builder)
       {
           builder.HasKey(course => course.Id);


           builder
                .HasOne(course => course.Lecture)
               .WithMany(lecture => lecture.Courses)
               .HasForeignKey(course => course.LectureId);

           builder
                .HasOne(course => course.Semester)
               .WithMany(semester => semester.Courses)
               .HasForeignKey(course => course.SemesterId);


           builder
                .HasOne(course => course.Semester)
               .WithMany(teacher => teacher.Courses)
               .HasForeignKey(teacher => teacher.TeacherId);

           builder.ToTable("Course");
        }
    }
}
