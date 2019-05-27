using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaciTech.Apartment.Database.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SubAreaId = table.Column<Guid>(nullable: false),
                    BuilderName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Landmark = table.Column<string>(nullable: true),
                    LocationLink = table.Column<string>(nullable: true),
                    AssociationName = table.Column<string>(nullable: true),
                    AssociationNumber = table.Column<string>(nullable: true),
                    AssociationBankName = table.Column<string>(nullable: true),
                    AssociationBankAccountNumber = table.Column<string>(nullable: true),
                    AssociationBankBranchAddress = table.Column<string>(nullable: true),
                    AssociationBankIFSC = table.Column<string>(nullable: true),
                    AmenityIds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Community = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    AreaId = table.Column<Guid>(nullable: false),
                    SubArea = table.Column<string>(nullable: true),
                    SubAreaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubArea",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NoOfFloors = table.Column<int>(nullable: false),
                    CommunityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Block_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false),
                    BlockId = table.Column<Guid>(nullable: true),
                    FloorNumber = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Specification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Block_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Block",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Block_CommunityId",
                table: "Block",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_BlockId",
                table: "Unit",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ContactId",
                table: "User",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CommunityLocation");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "SubArea");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Community");
        }
    }
}
