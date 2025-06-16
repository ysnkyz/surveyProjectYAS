using Microsoft.EntityFrameworkCore;
namespace surveyProjectYAS.Models;
    public class SurveyContext : DbContext
    {
    public SurveyContext(DbContextOptions<SurveyContext> options) : base(options) { }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Option> Options { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>().HasData(new Question
        {
            Id = 1,
            Text = "En sevdiğiniz renk nedir?"
        });

        modelBuilder.Entity<Option>().HasData(
            new Option { Id = 1, Text = "Kırmızı", QuestionId = 1 },
            new Option { Id = 2, Text = "Mavi", QuestionId = 1 },
            new Option { Id = 3, Text = "Yeşil", QuestionId = 1 },
            new Option { Id = 4, Text = "Sarı", QuestionId = 1 },
            new Option { Id = 5, Text = "Siyah", QuestionId = 1 }
        );
    }
}
    



