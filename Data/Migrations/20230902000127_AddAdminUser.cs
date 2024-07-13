using Microsoft.EntityFrameworkCore.Migrations;

namespace project01.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture]) VALUES (N'aeb8e3cd-0174-4965-957d-a7d77a8f0ced', N'mennatallah.ahmed', N'MENNATALLAH.AHMED', N'mennatallah.ahmed@gmail.com', N'MENNATALLAH.AHMED@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECZ6kzTq3U6ND+8WONXcQczMKy25qsBPAhMBN02lSnePzFFQK460nzsDW3nQ2OKjPw==', N'EYYOBLFXYMVR42DECVQEV5UVKGOZNXGO', N'b9c61438-b78f-4b79-b017-8ef86de03510', NULL, 0, 0, NULL, 1, 0, N'Mennatallah', N'Ahmed', NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[Users] where Id='aeb8e3cd-0174-4965-957d-a7d77a8f0ced' ");
        }
    }
}
