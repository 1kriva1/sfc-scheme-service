﻿using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SFC.Scheme.Infrastructure.Persistence.Migrations.Scheme
{
    /// <inheritdoc />
    public partial class SchemeDbContextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Player");

            migrationBuilder.EnsureSchema(
                name: "Team");

            migrationBuilder.EnsureSchema(
                name: "Metadata");

            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.EnsureSchema(
                name: "Scheme");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Domains",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballPositions",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStyles",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatuses",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchemeTypes",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shirts",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatCategories",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatSkills",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkingFoots",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingFoots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormationPositions",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FootballPositionId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormationPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormationPositions_FootballPositions_FootballPositionId",
                        column: x => x.FootballPositionId,
                        principalSchema: "Data",
                        principalTable: "FootballPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatTypes",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatTypes_StatCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Data",
                        principalTable: "StatCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatTypes_StatSkills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Data",
                        principalTable: "StatSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                schema: "Metadata",
                columns: table => new
                {
                    Service = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Domain = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => new { x.Service, x.Type, x.Domain });
                    table.ForeignKey(
                        name: "FK_Metadata_Domains_Domain",
                        column: x => x.Domain,
                        principalSchema: "Metadata",
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Metadata_Services_Service",
                        column: x => x.Service,
                        principalSchema: "Metadata",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Metadata_States_State",
                        column: x => x.State,
                        principalSchema: "Metadata",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Metadata_Types_Type",
                        column: x => x.Type,
                        principalSchema: "Metadata",
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameSchemes",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSchemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSchemes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameSchemes_Users_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameSchemes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Users_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Users_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormationValues",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Line = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    FormationId = table.Column<int>(type: "int", nullable: false),
                    FormationPositionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormationValues_FormationPositions_FormationPositionId",
                        column: x => x.FormationPositionId,
                        principalSchema: "Scheme",
                        principalTable: "FormationPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormationValues_Formations_FormationId",
                        column: x => x.FormationId,
                        principalSchema: "Scheme",
                        principalTable: "Formations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    From = table.Column<TimeSpan>(type: "time", nullable: true),
                    To = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Players_Id",
                        column: x => x.Id,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballProfiles",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Height = table.Column<short>(type: "smallint", nullable: true),
                    Weight = table.Column<short>(type: "smallint", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    AdditionalPositionId = table.Column<int>(type: "int", nullable: true),
                    WorkingFootId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<short>(type: "smallint", nullable: true),
                    GameStyleId = table.Column<int>(type: "int", nullable: true),
                    Skill = table.Column<byte>(type: "tinyint", nullable: true),
                    WeakFoot = table.Column<byte>(type: "tinyint", nullable: true),
                    PhysicalCondition = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballProfiles_FootballPositions_AdditionalPositionId",
                        column: x => x.AdditionalPositionId,
                        principalSchema: "Data",
                        principalTable: "FootballPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FootballProfiles_FootballPositions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Data",
                        principalTable: "FootballPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FootballProfiles_GameStyles_GameStyleId",
                        column: x => x.GameStyleId,
                        principalSchema: "Data",
                        principalTable: "GameStyles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FootballProfiles_Players_Id",
                        column: x => x.Id,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballProfiles_WorkingFoots_WorkingFootId",
                        column: x => x.WorkingFootId,
                        principalSchema: "Data",
                        principalTable: "WorkingFoots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralProfiles",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(1050)", maxLength: 1050, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FreePlay = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralProfiles_Players_Id",
                        column: x => x.Id,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Source = table.Column<byte[]>(type: "image", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<int>(type: "int", maxLength: 5242880, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Players_Id",
                        column: x => x.Id,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Available = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    Used = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Players_Id",
                        column: x => x.Id,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stats_StatTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Data",
                        principalTable: "StatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<byte>(type: "tinyint", nullable: false),
                    From = table.Column<TimeSpan>(type: "time", nullable: false),
                    To = table.Column<TimeSpan>(type: "time", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialProfiles",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FreePlay = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialProfiles_Teams_Id",
                        column: x => x.Id,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTeamSchemes",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTeamSchemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTeamSchemes_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralProfiles",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1050)", maxLength: 1050, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralProfiles_Teams_Id",
                        column: x => x.Id,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logos",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Source = table.Column<byte[]>(type: "image", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<int>(type: "int", maxLength: 5242880, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logos_Teams_Id",
                        column: x => x.Id,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Team",
                        principalTable: "PlayerStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Users_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shirts",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShirtId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shirts_Shirts_ShirtId",
                        column: x => x.ShirtId,
                        principalSchema: "Data",
                        principalTable: "Shirts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shirts_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSchemes",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSchemes_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Team",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSchemes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamSchemes_Users_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamSchemes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AvailableDays",
                schema: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailabilityId = table.Column<long>(type: "bigint", nullable: false),
                    Day = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableDays_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalSchema: "Player",
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSchemeGeneralProfiles",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1050)", maxLength: 1050, nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    FormationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchemeGeneralProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSchemeGeneralProfiles_Formations_FormationId",
                        column: x => x.FormationId,
                        principalSchema: "Scheme",
                        principalTable: "Formations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSchemeGeneralProfiles_SchemeTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Scheme",
                        principalTable: "SchemeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSchemeGeneralProfiles_TeamSchemes_Id",
                        column: x => x.Id,
                        principalSchema: "Scheme",
                        principalTable: "TeamSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSchemePlayers",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    TeamSchemeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchemePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSchemePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Player",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSchemePlayers_TeamSchemes_TeamSchemeId",
                        column: x => x.TeamSchemeId,
                        principalSchema: "Scheme",
                        principalTable: "TeamSchemes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamSchemePlayerPositions",
                schema: "Scheme",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    X = table.Column<int>(type: "int", nullable: true),
                    Y = table.Column<int>(type: "int", nullable: true),
                    FormationPositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchemePlayerPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSchemePlayerPositions_FormationPositions_FormationPositionId",
                        column: x => x.FormationPositionId,
                        principalSchema: "Scheme",
                        principalTable: "FormationPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSchemePlayerPositions_TeamSchemePlayers_Id",
                        column: x => x.Id,
                        principalSchema: "Scheme",
                        principalTable: "TeamSchemePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Domains",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 0, "Data" },
                    { 1, "User" },
                    { 2, "Player" },
                    { 3, "Team" },
                    { 4, "TeamPlayer" },
                    { 5, "TeamScheme" },
                    { 6, "GameScheme" }
                });

            migrationBuilder.InsertData(
                schema: "Scheme",
                table: "SchemeTypes",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 5, 21, 12, 41, 14, 348, DateTimeKind.Utc).AddTicks(5281), "Formation" },
                    { 1, new DateTime(2025, 5, 21, 12, 41, 14, 348, DateTimeKind.Utc).AddTicks(5293), "Custom" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Services",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 0, "Data" },
                    { 1, "Identity" },
                    { 2, "Player" },
                    { 3, "Team" },
                    { 4, "Scheme" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "States",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 0, "Not Required" },
                    { 1, "Required" },
                    { 2, "Done" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Types",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 0, "Initialization" },
                    { 1, "Seed" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Metadata",
                columns: new[] { "Domain", "Service", "Type", "State" },
                values: new object[,]
                {
                    { 0, 0, 0, 1 },
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 0, 3, 0, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 3, 1, 1 },
                    { 0, 4, 0, 1 },
                    { 5, 4, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_TeamId",
                schema: "Team",
                table: "Availabilities",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDays_AvailabilityId",
                schema: "Player",
                table: "AvailableDays",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballProfiles_AdditionalPositionId",
                schema: "Player",
                table: "FootballProfiles",
                column: "AdditionalPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballProfiles_GameStyleId",
                schema: "Player",
                table: "FootballProfiles",
                column: "GameStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballProfiles_PositionId",
                schema: "Player",
                table: "FootballProfiles",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballProfiles_WorkingFootId",
                schema: "Player",
                table: "FootballProfiles",
                column: "WorkingFootId");

            migrationBuilder.CreateIndex(
                name: "IX_FormationPositions_FootballPositionId",
                schema: "Scheme",
                table: "FormationPositions",
                column: "FootballPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormationValues_FormationId",
                schema: "Scheme",
                table: "FormationValues",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_FormationValues_FormationPositionId",
                schema: "Scheme",
                table: "FormationValues",
                column: "FormationPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSchemes_CreatedBy",
                schema: "Scheme",
                table: "GameSchemes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GameSchemes_LastModifiedBy",
                schema: "Scheme",
                table: "GameSchemes",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GameSchemes_UserId",
                schema: "Scheme",
                table: "GameSchemes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTeamSchemes_TeamId",
                schema: "Scheme",
                table: "GameTeamSchemes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_Domain",
                schema: "Metadata",
                table: "Metadata",
                column: "Domain");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_State",
                schema: "Metadata",
                table: "Metadata",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_Type",
                schema: "Metadata",
                table: "Metadata",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CreatedBy",
                schema: "Player",
                table: "Players",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LastModifiedBy",
                schema: "Player",
                table: "Players",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                schema: "Player",
                table: "Players",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CreatedBy",
                schema: "Team",
                table: "Players",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LastModifiedBy",
                schema: "Team",
                table: "Players",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerId",
                schema: "Team",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_StatusId",
                schema: "Team",
                table: "Players",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                schema: "Team",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                schema: "Team",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_ShirtId",
                schema: "Team",
                table: "Shirts",
                column: "ShirtId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_TeamId",
                schema: "Team",
                table: "Shirts",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                schema: "Player",
                table: "Stats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_TypeId",
                schema: "Player",
                table: "Stats",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatTypes_CategoryId",
                schema: "Data",
                table: "StatTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StatTypes_SkillId",
                schema: "Data",
                table: "StatTypes",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PlayerId",
                schema: "Player",
                table: "Tags",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TeamId",
                schema: "Team",
                table: "Tags",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatedBy",
                schema: "Team",
                table: "Teams",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LastModifiedBy",
                schema: "Team",
                table: "Teams",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId",
                schema: "Team",
                table: "Teams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemeGeneralProfiles_FormationId",
                schema: "Scheme",
                table: "TeamSchemeGeneralProfiles",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemeGeneralProfiles_TypeId",
                schema: "Scheme",
                table: "TeamSchemeGeneralProfiles",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemePlayerPositions_FormationPositionId",
                schema: "Scheme",
                table: "TeamSchemePlayerPositions",
                column: "FormationPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemePlayers_PlayerId",
                schema: "Scheme",
                table: "TeamSchemePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemePlayers_TeamSchemeId",
                schema: "Scheme",
                table: "TeamSchemePlayers",
                column: "TeamSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemes_CreatedBy",
                schema: "Scheme",
                table: "TeamSchemes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemes_LastModifiedBy",
                schema: "Scheme",
                table: "TeamSchemes",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemes_TeamId",
                schema: "Scheme",
                table: "TeamSchemes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchemes_UserId",
                schema: "Scheme",
                table: "TeamSchemes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                schema: "Identity",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastModifiedBy",
                schema: "Identity",
                table: "Users",
                column: "LastModifiedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "AvailableDays",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "FinancialProfiles",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "FootballProfiles",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "FormationValues",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "GameSchemes",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "GameTeamSchemes",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "GeneralProfiles",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "GeneralProfiles",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "Logos",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "Metadata",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "Photos",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "Points",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "Shirts",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "Stats",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "TeamSchemeGeneralProfiles",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "TeamSchemePlayerPositions",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "Availabilities",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "GameStyles",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "WorkingFoots",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Domains",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "States",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "PlayerStatuses",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "Shirts",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "StatTypes",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Formations",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "SchemeTypes",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "FormationPositions",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "TeamSchemePlayers",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "StatCategories",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "StatSkills",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "FootballPositions",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "Player");

            migrationBuilder.DropTable(
                name: "TeamSchemes",
                schema: "Scheme");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "Team");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");
        }
    }
}