using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaciTech.Apartment.Database.Migrations
{
    public partial class initalMigration : Migration
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
                name: "Feature",
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
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
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
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
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
                    table.PrimaryKey("PK_Role", x => x.Id);
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
                    ContactId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
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
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupRole",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRole", x => new { x.GroupId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_GroupRole_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleFeature",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    FeatureId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFeature", x => new { x.RoleId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_RoleFeature_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFeature_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroup_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    StateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Area_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_SubArea_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BuilderName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Landmark = table.Column<string>(nullable: true),
                    LocationLink = table.Column<string>(nullable: true),
                    AssociationName = table.Column<string>(nullable: true),
                    AssociationNumber = table.Column<string>(nullable: true),
                    AssociationBankName = table.Column<string>(nullable: true),
                    AssociationBankAccountNumber = table.Column<string>(nullable: true),
                    AssociationBankBranchAddress = table.Column<string>(nullable: true),
                    AssociationBankIFSC = table.Column<string>(nullable: true),
                    AmenityIds = table.Column<string>(nullable: true),
                    SubAreaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Community_SubArea_SubAreaId",
                        column: x => x.SubAreaId,
                        principalTable: "SubArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FloorNumber = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Specification = table.Column<string>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: false),
                    OwnerContactId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Contact_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unit_Block_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Block",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    Primary = table.Column<bool>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenant_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Comments", "Created", "CreatedBy", "Inactive", "Name", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("f95c0b64-669a-494c-9b11-1b4241a33a94"), null, new DateTime(2019, 6, 18, 18, 3, 56, 803, DateTimeKind.Utc).AddTicks(8348), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "India", new DateTime(2019, 6, 18, 18, 3, 56, 803, DateTimeKind.Utc).AddTicks(9089), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Comments", "ContactId", "Created", "CreatedBy", "Inactive", "Password", "Salt", "Updated", "UpdatedBy", "Username" },
                values: new object[] { new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), "sys user record", null, new DateTime(2019, 6, 18, 18, 3, 56, 803, DateTimeKind.Utc).AddTicks(2153), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "Bi4Fi6tHEiF+Cv3Jh0V0MA==", "123", new DateTime(2019, 6, 18, 18, 3, 56, 803, DateTimeKind.Utc).AddTicks(2985), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), "system" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Comments", "CountryId", "Created", "CreatedBy", "Inactive", "Name", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("06dbbab9-40bd-4a02-9b91-cbadbf136624"), null, new Guid("f95c0b64-669a-494c-9b11-1b4241a33a94"), new DateTime(2019, 6, 18, 18, 3, 56, 804, DateTimeKind.Utc).AddTicks(1911), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "Karnataka", new DateTime(2019, 6, 18, 18, 3, 56, 804, DateTimeKind.Utc).AddTicks(2612), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2") });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Comments", "Created", "CreatedBy", "Inactive", "Name", "StateId", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("8a4f5fa0-9935-4e18-b153-cf22a2deea78"), null, new DateTime(2019, 6, 18, 18, 3, 56, 804, DateTimeKind.Utc).AddTicks(5275), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "Bangalore", new Guid("06dbbab9-40bd-4a02-9b91-cbadbf136624"), new DateTime(2019, 6, 18, 18, 3, 56, 804, DateTimeKind.Utc).AddTicks(5969), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2") });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "CityId", "Comments", "Created", "CreatedBy", "Inactive", "Name", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("e297c484-666d-4009-8dd6-d4eda26bae0c"), new Guid("8a4f5fa0-9935-4e18-b153-cf22a2deea78"), null, new DateTime(2019, 6, 18, 18, 3, 56, 804, DateTimeKind.Utc).AddTicks(8613), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "North", new DateTime(2019, 6, 18, 18, 3, 56, 804, DateTimeKind.Utc).AddTicks(9338), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2") });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "CityId", "Comments", "Created", "CreatedBy", "Inactive", "Name", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("b0ab2ec4-d093-43a5-ad6b-93b94d1341ad"), new Guid("8a4f5fa0-9935-4e18-b153-cf22a2deea78"), null, new DateTime(2019, 6, 18, 18, 3, 56, 805, DateTimeKind.Utc).AddTicks(573), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "South", new DateTime(2019, 6, 18, 18, 3, 56, 805, DateTimeKind.Utc).AddTicks(578), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2") });

            migrationBuilder.InsertData(
                table: "SubArea",
                columns: new[] { "Id", "AreaId", "Comments", "Created", "CreatedBy", "Inactive", "Name", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("76887194-dbe6-42af-958f-7a8bf63a1045"), new Guid("e297c484-666d-4009-8dd6-d4eda26bae0c"), null, new DateTime(2019, 6, 18, 18, 3, 56, 805, DateTimeKind.Utc).AddTicks(4136), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "Hebbal", new DateTime(2019, 6, 18, 18, 3, 56, 805, DateTimeKind.Utc).AddTicks(4141), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2") });

            migrationBuilder.InsertData(
                table: "SubArea",
                columns: new[] { "Id", "AreaId", "Comments", "Created", "CreatedBy", "Inactive", "Name", "Updated", "UpdatedBy" },
                values: new object[] { new Guid("19f3e783-32f5-441e-9004-c760f8d50cfc"), new Guid("b0ab2ec4-d093-43a5-ad6b-93b94d1341ad"), null, new DateTime(2019, 6, 18, 18, 3, 56, 805, DateTimeKind.Utc).AddTicks(2149), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2"), false, "Jayanagar", new DateTime(2019, 6, 18, 18, 3, 56, 805, DateTimeKind.Utc).AddTicks(2861), new Guid("fa1c974f-70c3-4e8f-830f-3249380972a2") });

            migrationBuilder.CreateIndex(
                name: "IX_Area_CityId",
                table: "Area",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Block_CommunityId",
                table: "Block",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Community_SubAreaId",
                table: "Community",
                column: "SubAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRole_RoleId",
                table: "GroupRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFeature_FeatureId",
                table: "RoleFeature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubArea_AreaId",
                table: "SubArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_ContactId",
                table: "Tenant",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_UnitId",
                table: "Tenant",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_OwnerId",
                table: "Unit",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_SectionId",
                table: "Unit",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ContactId",
                table: "User",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "CommunityLocation");

            migrationBuilder.DropTable(
                name: "GroupRole");

            migrationBuilder.DropTable(
                name: "RoleFeature");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropTable(
                name: "SubArea");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
