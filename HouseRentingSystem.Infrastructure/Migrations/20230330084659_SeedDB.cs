using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "AF724889-F204-4573-8D65-ED50557A9B71", 0, "18b14a1f-c929-4f11-af8a-c1a8f0fbf21d", "guest@mail.com", false, null, true, null, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAENeyfrq+DZ3kmC7o5Dgqaau1az70azkIwNVYjnHA7HiWViwu0q7nTa2RWQGhnWcLJg==", null, false, null, false, "guest@mail.com" },
                    { "E305205E-A570-40AE-9644-D4E173B05D0D", 0, "61e5de36-9f72-4245-985f-9beec84d6219", "agent@mail.com", false, null, true, null, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEH6UdjC31egpPKEFrAuSLu1yOAUnCLaoddmuR7kPME7COa7sEtFqtUNRvabeVcaQQw==", null, false, null, false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "4FDD33D0-218F-4094-B1D4-707403A8ADD4", "Single-Family" },
                    { "B3D23CE7-7A38-4E00-91E3-BD446A6C1033", "Cottage" },
                    { "B8B55D74-60EB-4ED7-AC6D-AC75F4B31179", "Duplex" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { "D00DD0BB-783B-4766-AF26-5958608A96FE", "+359888888888", "E305205E-A570-40AE-9644-D4E173B05D0D" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { "1DFB745D-E948-4375-81AC-3A86EBBFC237", "Near the Sea Garden in Burgas, Bulgaria", "D00DD0BB-783B-4766-AF26-5958608A96FE", "4FDD33D0-218F-4094-B1D4-707403A8ADD4", "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { "3C3A02DC-DF00-47DA-B053-FB81BB714A90", "North London, UK (near the border)", "D00DD0BB-783B-4766-AF26-5958608A96FE", "B8B55D74-60EB-4ED7-AC6D-AC75F4B31179", "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", true, 2100.00m, "AF724889-F204-4573-8D65-ED50557A9B71", "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { "BF445967-EF66-41CC-BA39-462CBC7D24DE", "Boyana Neighbourhood, Sofia, Bulgaria", "D00DD0BB-783B-4766-AF26-5958608A96FE", "4FDD33D0-218F-4094-B1D4-707403A8ADD4", "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "B3D23CE7-7A38-4E00-91E3-BD446A6C1033");

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: "1DFB745D-E948-4375-81AC-3A86EBBFC237");

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: "3C3A02DC-DF00-47DA-B053-FB81BB714A90");

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: "BF445967-EF66-41CC-BA39-462CBC7D24DE");

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: "D00DD0BB-783B-4766-AF26-5958608A96FE");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "AF724889-F204-4573-8D65-ED50557A9B71");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4FDD33D0-218F-4094-B1D4-707403A8ADD4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "B8B55D74-60EB-4ED7-AC6D-AC75F4B31179");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E305205E-A570-40AE-9644-D4E173B05D0D");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
