using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DashBoard.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RegionForeignKey = table.Column<int>(nullable: true),
                    Zone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Regions_RegionForeignKey",
                        column: x => x.RegionForeignKey,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SectionForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communities_Sections_SectionForeignKey",
                        column: x => x.SectionForeignKey,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AmcItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityForeignKey = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmcItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmcItems_Communities_CommunityForeignKey",
                        column: x => x.CommunityForeignKey,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ameneties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityForeignKey = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ameneties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ameneties_Communities_CommunityForeignKey",
                        column: x => x.CommunityForeignKey,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityForeignKey = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Communities_CommunityForeignKey",
                        column: x => x.CommunityForeignKey,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GateKeepers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityForeignKey = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateKeepers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GateKeepers_Communities_CommunityForeignKey",
                        column: x => x.CommunityForeignKey,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLayouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLayouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingLayouts_Communities_CommunityForeignKey",
                        column: x => x.CommunityForeignKey,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityForeignKey = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Pupose = table.Column<string>(nullable: true),
                    Schedule = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_Communities_CommunityForeignKey",
                        column: x => x.CommunityForeignKey,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockForeignKey = table.Column<int>(nullable: true),
                    IsRented = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_Blocks_BlockForeignKey",
                        column: x => x.BlockForeignKey,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSlots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockId = table.Column<int>(nullable: false),
                    CommunityId = table.Column<int>(nullable: false),
                    FlatForeignKey = table.Column<int>(nullable: true),
                    FloorName = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    ParkingLayoutId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSlots_Flats_FlatForeignKey",
                        column: x => x.FlatForeignKey,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingSlots_ParkingLayouts_ParkingLayoutId",
                        column: x => x.ParkingLayoutId,
                        principalTable: "ParkingLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalHelpers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlatForeignKey = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalHelpers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalHelpers_Flats_FlatForeignKey",
                        column: x => x.FlatForeignKey,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    FlatForeignKey = table.Column<int>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    VehicleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Flats_FlatForeignKey",
                        column: x => x.FlatForeignKey,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    GateKeeperForeignKey = table.Column<int>(nullable: true),
                    LocationOrArea = table.Column<string>(nullable: true),
                    PersonalHelperForeignKey = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PinCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    VendorForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_GateKeepers_GateKeeperForeignKey",
                        column: x => x.GateKeeperForeignKey,
                        principalTable: "GateKeepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_PersonalHelpers_PersonalHelperForeignKey",
                        column: x => x.PersonalHelperForeignKey,
                        principalTable: "PersonalHelpers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Vendors_VendorForeignKey",
                        column: x => x.VendorForeignKey,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssociationId = table.Column<int>(nullable: true),
                    AssociationId1 = table.Column<int>(nullable: true),
                    FlatForeignKey = table.Column<int>(nullable: true),
                    IsAssociationMember = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumbers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Flats_FlatForeignKey",
                        column: x => x.FlatForeignKey,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommunityForeignKey = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PresidentId = table.Column<int>(nullable: true),
                    SecretaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Associations_Communities_CommunityForeignKey",
                        column: x => x.CommunityForeignKey,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Associations_Members_PresidentId",
                        column: x => x.PresidentId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Associations_Members_SecretaryId",
                        column: x => x.SecretaryId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_GateKeeperForeignKey",
                table: "Address",
                column: "GateKeeperForeignKey",
                unique: true,
                filter: "[GateKeeperForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonalHelperForeignKey",
                table: "Address",
                column: "PersonalHelperForeignKey",
                unique: true,
                filter: "[PersonalHelperForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_VendorForeignKey",
                table: "Address",
                column: "VendorForeignKey",
                unique: true,
                filter: "[VendorForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AmcItems_CommunityForeignKey",
                table: "AmcItems",
                column: "CommunityForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Ameneties_CommunityForeignKey",
                table: "Ameneties",
                column: "CommunityForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_CommunityForeignKey",
                table: "Associations",
                column: "CommunityForeignKey",
                unique: true,
                filter: "[CommunityForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_PresidentId",
                table: "Associations",
                column: "PresidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_SecretaryId",
                table: "Associations",
                column: "SecretaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_CommunityForeignKey",
                table: "Blocks",
                column: "CommunityForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_SectionForeignKey",
                table: "Communities",
                column: "SectionForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_BlockForeignKey",
                table: "Flats",
                column: "BlockForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_GateKeepers_CommunityForeignKey",
                table: "GateKeepers",
                column: "CommunityForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Members_AssociationId",
                table: "Members",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_AssociationId1",
                table: "Members",
                column: "AssociationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Members_FlatForeignKey",
                table: "Members",
                column: "FlatForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLayouts_CommunityForeignKey",
                table: "ParkingLayouts",
                column: "CommunityForeignKey",
                unique: true,
                filter: "[CommunityForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlots_FlatForeignKey",
                table: "ParkingSlots",
                column: "FlatForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlots_ParkingLayoutId",
                table: "ParkingSlots",
                column: "ParkingLayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalHelpers_FlatForeignKey",
                table: "PersonalHelpers",
                column: "FlatForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_RegionForeignKey",
                table: "Sections",
                column: "RegionForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FlatForeignKey",
                table: "Vehicles",
                column: "FlatForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CommunityForeignKey",
                table: "Vendors",
                column: "CommunityForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Associations_AssociationId",
                table: "Members",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Associations_AssociationId1",
                table: "Members",
                column: "AssociationId1",
                principalTable: "Associations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Communities_CommunityForeignKey",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Communities_CommunityForeignKey",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Members_PresidentId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Members_SecretaryId",
                table: "Associations");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AmcItems");

            migrationBuilder.DropTable(
                name: "Ameneties");

            migrationBuilder.DropTable(
                name: "ParkingSlots");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "GateKeepers");

            migrationBuilder.DropTable(
                name: "PersonalHelpers");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "ParkingLayouts");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Blocks");
        }
    }
}
