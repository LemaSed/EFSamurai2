using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamurai.Data.Migrations
{
    public partial class korreksjon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEvent_BattleLog_BattleLogId",
                table: "BattleEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleLog_Battle_BattleId",
                table: "BattleLog");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Battle_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleLog",
                table: "BattleLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleEvent",
                table: "BattleEvent");

            migrationBuilder.DropIndex(
                name: "IX_BattleEvent_BattleLogId",
                table: "BattleEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battle",
                table: "Battle");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SamuraiBattle");

            migrationBuilder.DropColumn(
                name: "Descripion",
                table: "BattleEvent");

            migrationBuilder.RenameTable(
                name: "SecretIdentity",
                newName: "SecretIdentities");

            migrationBuilder.RenameTable(
                name: "SamuraiBattle",
                newName: "SamuraiBattles");

            migrationBuilder.RenameTable(
                name: "BattleLog",
                newName: "BattleLogs");

            migrationBuilder.RenameTable(
                name: "BattleEvent",
                newName: "BattleEvents");

            migrationBuilder.RenameTable(
                name: "Battle",
                newName: "Battles");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentities",
                newName: "IX_SecretIdentities_SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattles",
                newName: "IX_SamuraiBattles_SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleLog_BattleId",
                table: "BattleLogs",
                newName: "IX_BattleLogs_BattleId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BattleEvents",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentities",
                table: "SecretIdentities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattles",
                table: "SamuraiBattles",
                columns: new[] { "BattleId", "SamuraiId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleLogs",
                table: "BattleLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleEvents",
                table: "BattleEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEvents_BattleLogId",
                table: "BattleEvents",
                column: "BattleLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEvents_BattleLogs_BattleLogId",
                table: "BattleEvents",
                column: "BattleLogId",
                principalTable: "BattleLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLogs_Battles_BattleId",
                table: "BattleLogs",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleId",
                table: "SamuraiBattles",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Samurais_SamuraiId",
                table: "SamuraiBattles",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentities_Samurais_SamuraiId",
                table: "SecretIdentities",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEvents_BattleLogs_BattleLogId",
                table: "BattleEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleLogs_Battles_BattleId",
                table: "BattleLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleId",
                table: "SamuraiBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Samurais_SamuraiId",
                table: "SamuraiBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Samurais_SamuraiId",
                table: "SecretIdentities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentities",
                table: "SecretIdentities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattles",
                table: "SamuraiBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleLogs",
                table: "BattleLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleEvents",
                table: "BattleEvents");

            migrationBuilder.DropIndex(
                name: "IX_BattleEvents_BattleLogId",
                table: "BattleEvents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BattleEvents");

            migrationBuilder.RenameTable(
                name: "SecretIdentities",
                newName: "SecretIdentity");

            migrationBuilder.RenameTable(
                name: "SamuraiBattles",
                newName: "SamuraiBattle");

            migrationBuilder.RenameTable(
                name: "Battles",
                newName: "Battle");

            migrationBuilder.RenameTable(
                name: "BattleLogs",
                newName: "BattleLog");

            migrationBuilder.RenameTable(
                name: "BattleEvents",
                newName: "BattleEvent");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentities_SamuraiId",
                table: "SecretIdentity",
                newName: "IX_SecretIdentity_SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_SamuraiBattles_SamuraiId",
                table: "SamuraiBattle",
                newName: "IX_SamuraiBattle_SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleLogs_BattleId",
                table: "BattleLog",
                newName: "IX_BattleLog_BattleId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SamuraiBattle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripion",
                table: "BattleEvent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "BattleId", "SamuraiId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battle",
                table: "Battle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleLog",
                table: "BattleLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleEvent",
                table: "BattleEvent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEvent_BattleLogId",
                table: "BattleEvent",
                column: "BattleLogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEvent_BattleLog_BattleLogId",
                table: "BattleEvent",
                column: "BattleLogId",
                principalTable: "BattleLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLog_Battle_BattleId",
                table: "BattleLog",
                column: "BattleId",
                principalTable: "Battle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Battle_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                principalTable: "Battle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
