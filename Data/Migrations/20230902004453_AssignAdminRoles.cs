using Microsoft.EntityFrameworkCore.Migrations;

namespace project01.Data.Migrations
{
    public partial class AssignAdminRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into [dbo].[UserRoles](UserId, RoleId) select 'aeb8e3cd-0174-4965-957d-a7d77a8f0ced', Id from [dbo].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[Users] where Id='aeb8e3cd-0174-4965-957d-a7d77a8f0ced' ");
        }
    }
}
