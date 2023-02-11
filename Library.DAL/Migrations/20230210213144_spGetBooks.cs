using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class spGetBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var spGetBooks = @"CREATE PROCEDURE [dbo].[spGetBooks]
                  
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select tBook.Id as bookId,tBook.Name as bookName,tbook.PublishDate as bookPublishDate,tAuthor.Name as authorName,tBookCategory.CategoryName as categoryName    from Books as tBook
                        INNER JOIN Authors as tAuthor ON tAuthor.Id = tBook.AuthorId
                        INNER JOIN BookCategories as tBookCategory ON tBookCategory.Id = tBook.BookCategoryId

                END";

            migrationBuilder.Sql(spGetBooks);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
